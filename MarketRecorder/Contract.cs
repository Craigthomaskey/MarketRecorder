using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingTechnologies.TTAPI;
using TradingTechnologies.TTAPI.Tradebook;

namespace MarketRecorder
{
    public class Contract
    {
        Form1 MainForm; TTAPIFunctions TTAPIF; UniversalLoginTTAPI apiInstance; ContractControl ContControl;
        PriceSubscription ps; TimeAndSalesSubscription tsSub; Instrument Instrument; InstrumentLookupSubscription req; FillsSubscription fs;
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



        public void SetUp()
        {
            ContControl = MainForm.BuildControl(Instrument.GetFormattedName(InstrumentNameFormat.Normal));
            if (ContControl == null) TTAPIF.CallBackCancel(this);
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

                string[] tempList = new string[11];
                tempList[0] = tsData.TimeStamp.ToString("HH:mm:ss:ffff");
                tempList[1] = ltq.ToString();
                tempList[2] = ltp.ToDouble().ToString();
                tempList[3] = tsData.Direction.ToString();
                tempList[4] = AskVolume.ToString();
                tempList[5] = BidVolume.ToString();
                tempList[6] = "MarketOrder";

                ContControl.PassData(tempList);
                DataList.Add(tempList);
                TTAPIF.IncomingData(tsData.TimeStamp, tempList);
            }
        }





        private void fs_FillAdded(object sender, FillAddedEventArgs e)
        {
            for (int i = 0; i < DataList.Count; i++)
            {
                if(DataList[i][0] == e.Fill.TransactionDateTime.ToString("HH:mm:ss:ffff") && DataList[i][0] == e.Fill.Quantity.ToString())
                {
                    DataList[i][6] = "FirmOrder";
                    DataList[i][7] = e.Fill.OrderTag;
                    DataList[i][8] = e.Fill.TraderId;
                    DataList[i][9] = e.Fill.OrderType.ToString();
                    DataList[i][10] = e.Fill.FillSource.ToString();
                }
            }
        }


        public List<string[]> DataList = new List<string[]>();
       // public Dictionary<DateTime, string[]> DataDict = new Dictionary<DateTime, string[]>();
        double AskVolume = 0; double BidVolume = 0;
        string OrderTag = "";










        public void Dispose()
        {
            // Dispose of any other objects / resources
            if(req != null) { req.Update -= req_Update; req.Dispose(); }
            if (tsSub != null) { tsSub.Update -= tsSub_Update; tsSub.Dispose(); }
            if (ps != null) { ps.FieldsUpdated -= ps_FieldsUpdated; ps.Dispose(); }
            apiInstance = null; ps = null; tsSub = null; 
            GC.SuppressFinalize(this);
        }

    }
}
