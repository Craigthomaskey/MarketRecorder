using System;
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
            else if (e.IsFinal) { DeathCall(); }
        }

        string OutputName = "";
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


        private void tsSub_Update(object sender, TimeAndSalesEventArgs e)
        {
            foreach (TimeAndSalesData tsData in e.Data)
            {
                Price ltp = tsData.TradePrice;
                Quantity ltq = tsData.TradeQuantity;

                string orderKey = OutputName + "MO" + AllCount.ToString("D4") + ltq;

                if (LastOrderKey.Contains("FO"))
                {
                    string[] temp = DataDict[LastOrderKey];
                    if (temp[3] == ltq.ToString() && temp[2] == OutputName && temp[4] == ltp.ToString())
                    {
                        DateTime dateTime = DateTime.ParseExact(temp[1], "HH:mm:ss:ffff", CultureInfo.InvariantCulture);
                        if (Math.Abs(dateTime.Subtract(tsData.TimeStamp).Milliseconds) < 40)
                        {
                            string[] data = new string[13];
                            data[0] = temp[0];
                            data[1] = temp[1];
                            data[2] = temp[2];
                            data[3] = temp[3];
                            data[4] = temp[4];
                            data[5] = temp[5];
                            data[6] = "   ||   ";
                            data[7] = DateTime.Now.ToString("HH:mm:ss:ffff");
                            data[8] = tsData.TimeStamp.ToString("HH:mm:ss:ffff");
                            data[9] = OutputName;
                            data[10] = ltq.ToString();
                            data[11] = ltp.ToString();
                            data[12] = tsData.Direction.ToString();

                            CrossedDict.Add(LastOrderKey, data);
                        }

                        temp[5] = tsData.Direction.ToString();
                        DataDict[LastOrderKey] = temp;
                    }
                }
                else
                {
                    string[] data = new string[13];
                    data[0] = DateTime.Now.ToString("HH:mm:ss:ffff");
                    data[1] = tsData.TimeStamp.ToString("HH:mm:ss:ffff");
                    data[2] = OutputName;
                    data[3] = ltq.ToString();
                    data[4] = ltp.ToString();
                    data[5] = tsData.Direction.ToString();
                    data[6] = AskVolume.ToString();
                    data[7] = BidVolume.ToString();
                    data[8] = "MO";

                    DataManager(orderKey, data);
                }                
            }
        }


        private void fs_FillAdded(object sender, FillAddedEventArgs e)
        {
            if (e.Fill.InstrumentKey == Instrument.Key)
            {
                string orderKey = OutputName + "FO" + AllCount.ToString("D4") + e.Fill.Quantity;

                string[] data = new string[13];
                data[0] = DateTime.Now.ToString("HH:mm:ss:ffff");
                data[1] = e.Fill.TransactionDateTime.ToString("HH:mm:ss:ffff");
                data[2] = OutputName;
                data[3] = e.Fill.Quantity.ToString();
                data[4] = e.Fill.MatchPrice.ToString();
                data[5] = e.Fill.BuySell.ToString();
                data[6] = AskVolume.ToString();
                data[7] = BidVolume.ToString();
                data[8] = "FO";
                data[9] = e.Fill.OrderTag;
                data[10] = e.Fill.TraderId;
                data[11] = e.Fill.FillType.ToString();
                data[12] = e.Fill.OrderDateTime.ToString("dd/MM/yy - HH:mm:ss:ffff");

                DataManager(orderKey, data);    
            }
        }

        bool IsTimeWindow() { if (DateTime.Now > StartRecordWindowTime && DateTime.Now < EndRecordWindowTime) return true; else return false; }


        int AllCount = 0; string LastOrderKey = ""; bool IsSeperateData = false;
        Dictionary<string, string[]> DataDict = new Dictionary<string, string[]>();
        Dictionary<string, string[]> CrossedDict = new Dictionary<string, string[]>();
        Dictionary<string, string[]> WindowDict = new Dictionary<string, string[]>();

        void DataManager(string orderKey, string[] data)
        {           
            if (RecordAllDay || IsTimeWindow())
            {
                DataDict.Add(orderKey, data);
                TTAPIF.IncommingData(DataDict, 0);
                //need settings for cross data exports
                TTAPIF.IncommingData(CrossedDict, 1);
                if (IsTimeWindow() && SeperateFileForWindowRecord)
                {
                    IsSeperateData = true;
                    WindowDict.Add(orderKey, data);
                    TTAPIF.IncommingData(WindowDict, 2);
                }
                LastOrderKey = orderKey; AllCount++;
            }
            if (IsSeperateData && DateTime.Now > EndRecordWindowTime)
            {
                IsSeperateData = false;
                TTAPIF.SaveWindowData(WindowDict, OutputName);
            }
            ContControl.PassData(data);
        }





        public string DriveUploadWindowFile()
        {
            if (DriveUploadType == 1 || DriveUploadType == 3) return OutputName;
            else return "No";
        }










        public void LoadSavedInformation(string[] info)
        {
            StartRecordWindowTime = DateTime.ParseExact(info[4], "HH:mm:ss", CultureInfo.InvariantCulture);
            EndRecordWindowTime = DateTime.ParseExact(info[5], "HH:mm:ss", CultureInfo.InvariantCulture);
            SeperateFileForWindowRecord = Convert.ToBoolean(info[6]);
            RecordAllDay = Convert.ToBoolean(info[7]);
            DriveUploadType = Convert.ToInt32(info[8]);
        }


      public  int DriveUploadType = 0;
        public string[] SaveInformation()
        {
            if (Instrument != null)
            {
                string[] tempInfo = new string[9];

                //add all info to string[]
                tempInfo[0] = Instrument.Product.Market.Name;
                tempInfo[1] = Instrument.Product.Type.Name;
                tempInfo[2] = Instrument.Product.Name;
                tempInfo[3] = Instrument.GetFormattedName(InstrumentNameFormat.Expiry);
                tempInfo[4] = StartRecordWindowTime.ToString("HH:mm:ss");
                tempInfo[5] = EndRecordWindowTime.ToString("HH:mm:ss");
                tempInfo[6] = SeperateFileForWindowRecord.ToString();
                tempInfo[7] = RecordAllDay.ToString();
                tempInfo[8] = DriveUploadType.ToString();

                return tempInfo;
            }
            else
            {
                DeathCall();
                return null;
            }
        }




    }
}
