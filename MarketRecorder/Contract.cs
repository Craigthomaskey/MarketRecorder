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
        Form1 MainForm; TTAPIFunctions TTAPIF; UniversalLoginTTAPI apiInstance;
        PriceSubscription ps; TimeAndSalesSubscription tsSub; Instrument Instrument; InstrumentLookupSubscription req;
        public void Init(TTAPIFunctions conclass, Form1 f, UniversalLoginTTAPI api, InstrumentLookupSubscription ils) { MainForm = f; TTAPIF = conclass; apiInstance = api; req = ils; }

        public void req_Update(object sender, InstrumentLookupSubscriptionEventArgs e)
        {
            if (e.Instrument != null && e.Error == null)
            {
                ps = new PriceSubscription(e.Instrument, Dispatcher.Current) { Settings = new PriceSubscriptionSettings(PriceSubscriptionType.InsideMarket) }; ps.FieldsUpdated += new FieldsUpdatedEventHandler(ps_FieldsUpdated); ps.Start();
                tsSub = new TimeAndSalesSubscription(e.Instrument, Dispatcher.Current); tsSub.Update += new EventHandler<TimeAndSalesEventArgs>(tsSub_Update); tsSub.Start();
                Instrument = e.Instrument; SetUp();
            }
        }
        void SetUp()
        {

        }





        private void ps_FieldsUpdated(object sender, FieldsUpdatedEventArgs e)
        {
            if (e.Error == null)
            {

            }
        }





        private void tsSub_Update(object sender, TimeAndSalesEventArgs e)
        {
            foreach (TimeAndSalesData tsData in e.Data)
            {
                Price ltp = tsData.TradePrice;
                Quantity ltq = tsData.TradeQuantity;


            }
        }


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
