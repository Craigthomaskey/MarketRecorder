﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TradingTechnologies.TTAPI;
using TradingTechnologies.TTAPI.Tradebook;

namespace MarketRecorder
{
    public class Contract
    {
        public void Dispose()
        {
            if (req != null) { req.Update -= req_Update; req.Dispose(); }
            if (tsSub != null) { tsSub.Update -= tsSub_Update; tsSub.Dispose(); }
            if (ps != null) { ps.FieldsUpdated -= ps_FieldsUpdated; ps.Dispose(); }
            apiInstance = null; ps = null; tsSub = null;
            GC.SuppressFinalize(this);
        }

        Form1 MainForm; TTAPIFunctions TTAPIF; UniversalLoginTTAPI apiInstance; ContractControl ContControl;
        PriceSubscription ps; TimeAndSalesSubscription tsSub; Instrument Instrument; InstrumentLookupSubscription req; FillsSubscription fs;
        public List<string[]> DataList = new List<string[]>(); public List<string[]> WindowDataList = new List<string[]>();
        double AskVolume = 0; double BidVolume = 0;
        public DateTime StartRecordWindowTime; public DateTime EndRecordWindowTime; public bool SeperateFileForWindowRecord = false; public bool RecordAllDay = true;
        public void Init(TTAPIFunctions conclass, Form1 f, UniversalLoginTTAPI api, InstrumentLookupSubscription ils) { MainForm = f; TTAPIF = conclass; apiInstance = api; req = ils; }

        public void req_Update(object sender, InstrumentLookupSubscriptionEventArgs e)
        {
            if (e.Instrument != null && e.Error == null)
            {
                ps = new PriceSubscription(e.Instrument, Dispatcher.Current) { Settings = new PriceSubscriptionSettings(PriceSubscriptionType.InsideMarket) }; ps.FieldsUpdated += new FieldsUpdatedEventHandler(ps_FieldsUpdated); ps.Start();
                tsSub = new TimeAndSalesSubscription(e.Instrument, Dispatcher.Current); tsSub.Update += new EventHandler<TimeAndSalesEventArgs>(tsSub_Update); tsSub.Start();
                fs = new FillsSubscription(apiInstance.Session, Dispatcher.Current); fs.FillAdded += new EventHandler<FillAddedEventArgs>(fs_FillAdded); fs.Start();
                Instrument = e.Instrument; SetUp();
            }
        }

        string OutputName = ""; Timer SaveTImer;
        public void SetUp()
        {
            if (StartRecordWindowTime == DateTime.MinValue || EndRecordWindowTime == DateTime.MinValue)
            {
                if (Instrument.Product.Name == "HE" || Instrument.Product.Name == "LE" || Instrument.Product.Name == "GF") { StartRecordWindowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 59, 00); EndRecordWindowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 00, 30); }
                else { StartRecordWindowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 13, 00); EndRecordWindowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 15, 00); }
            }
            if (Instrument.Product.Type == ProductType.Spread) OutputName = Instrument.Product.Name + " " + Instrument.GetFormattedName(InstrumentNameFormat.Expiry).Substring(Instrument.GetFormattedName(InstrumentNameFormat.Expiry).Length - 14, 5) + " x " + Instrument.GetFormattedName(InstrumentNameFormat.Expiry).Substring(Instrument.GetFormattedName(InstrumentNameFormat.Expiry).Length - 5);
            else OutputName = Instrument.Product.Name + " " + Instrument.GetFormattedName(InstrumentNameFormat.Expiry);

            ContControl = MainForm.BuildControl(Instrument.GetFormattedName(InstrumentNameFormat.Normal), this, OutputName); if (ContControl == null) TTAPIF.CallBackCancel(this);
        }
        public void DeathCall() { TTAPIF.CallBackCancel(this); }






        public void ClearListsCall(int type)
        {
            if (type == 1) DataList.Clear();
            else WindowDataList.Clear();
        }



        private void ps_FieldsUpdated(object sender, FieldsUpdatedEventArgs e)
        {
            if (e.Error == null)
            {
                AskVolume = e.Fields.GetBestAskQuantityField().Value;
                BidVolume = e.Fields.GetBestBidQuantityField().Value;
            }
        }

        bool IsSpeprateData = false;
        private void tsSub_Update(object sender, TimeAndSalesEventArgs e)
        {
            foreach (TimeAndSalesData tsData in e.Data)
            {
                Price ltp = tsData.TradePrice;
                Quantity ltq = tsData.TradeQuantity;

                for (int i = 0; i < DataList.Count; i++) { if (DataList[i][0] == tsData.TimeStamp.ToString("HH:mm:ss:ffff") && DataList[i][2] == ltq.ToString() && DataList[i][1] == Instrument.GetFormattedName(InstrumentNameFormat.Normal)) { DataList[i][4] = tsData.Direction.ToString(); return; } }

                string[] tempList = new string[12];
                tempList[0] = tsData.TimeStamp.ToString("HH:mm:ss:ffff");
                tempList[1] = OutputName;
                tempList[2] = ltq.ToString();
                tempList[3] = ltp.ToDouble().ToString();
                tempList[4] = tsData.Direction.ToString();
                tempList[5] = AskVolume.ToString();
                tempList[6] = BidVolume.ToString();
                tempList[7] = "MO";

                RecordingSettings(tempList);   
            }
        }

        private void fs_FillAdded(object sender, FillAddedEventArgs e)
        {
            if (e.Fill.InstrumentKey == Instrument.Key)
            {
                string[] tempList = new string[12];
                tempList[0] = e.Fill.TransactionDateTime.ToString("HH:mm:ss:ffff");
                tempList[1] = OutputName;
                tempList[2] = e.Fill.Quantity.ToString();
                tempList[3] = e.Fill.MatchPrice.ToDouble().ToString();
                tempList[4] = "";
                tempList[5] = AskVolume.ToString();
                tempList[6] = BidVolume.ToString();
                tempList[7] = "FO";
                tempList[8] = e.Fill.OrderTag;
                tempList[9] = e.Fill.TraderId;
                tempList[10] = e.Fill.OrderType.ToString();
                tempList[11] = e.Fill.BuySell.ToString();

                RecordingSettings(tempList);
            }
        }


        void RecordingSettings(string[] tempList)
        {
            if (!TTAPIF.PauseRecording)
            {
                ContControl.PassData(tempList);
                if (RecordAllDay || IsTimeWindow()) DataList.Add(tempList);
                if (IsTimeWindow() && SeperateFileForWindowRecord) { IsSpeprateData = true; WindowDataList.Add(tempList); }
                else if (IsSpeprateData && DateTime.Now > EndRecordWindowTime) { IsSpeprateData = false; TTAPIF.DataSaveCall(OutputName, 2); }
            }
        }

        bool IsTimeWindow() { if (DateTime.Now > StartRecordWindowTime && DateTime.Now < EndRecordWindowTime) return true; else return false; }











        public void LoadSavedInformation(string[] info)
        {
            StartRecordWindowTime = DateTime.ParseExact(info[4], "HH:mm:ss", CultureInfo.InvariantCulture);
            EndRecordWindowTime = DateTime.ParseExact(info[5], "HH:mm:ss", CultureInfo.InvariantCulture);
            SeperateFileForWindowRecord = Convert.ToBoolean(info[6]);
            RecordAllDay = Convert.ToBoolean(info[7]);
        }


        public string[] SaveInformation()
        {
            string[] tempInfo = new string[8];

            //add all info to string[]
            tempInfo[0] = Instrument.Product.Market.Name;
            tempInfo[1] = Instrument.Product.Type.Name;
            tempInfo[2] = Instrument.Product.Name;
            tempInfo[3] = Instrument.GetFormattedName(InstrumentNameFormat.Expiry);
            tempInfo[4] = StartRecordWindowTime.ToString("HH:mm:ss");
            tempInfo[5] = EndRecordWindowTime.ToString("HH:mm:ss");
            tempInfo[6] = SeperateFileForWindowRecord.ToString();
            tempInfo[7] = RecordAllDay.ToString();

            return tempInfo;
        }




    }
}
