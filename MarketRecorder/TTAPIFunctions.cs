using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingTechnologies.TTAPI;
using System.Timers;

namespace MarketRecorder
{
    public class TTAPIFunctions : IDisposable
    {
        Form1 MainForm; UniversalLoginTTAPI apiInstance; UIDispatcher m_disp = null; Timer SaveTImer;
        bool m_disposed = false; object m_lock = new object(); string m_username = "KWILSON"; string m_password = "wt2626wt";
        string SavePath = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Logs\MaxData " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
        List<Contract> ContList = new List<Contract>(); Dictionary<DateTime, string[]> DataToSave = new Dictionary<DateTime, string[]>();

        public void Init(Form1 f, bool sim)
        {
            MainForm = f; if (!sim) { m_username = "JHUSCHER"; m_password = "wt2626wt"; }
            m_disp = Dispatcher.AttachUIDispatcher(); ApiInitializeHandler h = new ApiInitializeHandler(ttApiInitComplete); TTAPI.CreateUniversalLoginTTAPI(Dispatcher.Current, m_username, m_password, h);
        }
        public void ttApiInitComplete(TTAPI api, ApiCreationException ex)
        {
            if (ex == null) { apiInstance = (UniversalLoginTTAPI)api; apiInstance.AuthenticationStatusUpdate += new EventHandler<AuthenticationStatusUpdateEventArgs>(apiInstance_AuthenticationStatusUpdate); apiInstance.Start(); }
            else { MainForm.BuildNotification("TT API Initialization Failed: " + ex.Message, Properties.Resources.ChickenBlack); Dispose(); }
        }
        public void apiInstance_AuthenticationStatusUpdate(object sender, AuthenticationStatusUpdateEventArgs e)
        {
            MainForm.XtraderConnected(apiInstance);
            //start timer for saving data (?per minute?)
            SaveTImer = new Timer(60000); SaveTImer.Elapsed += SaveTImer_Elapsed; SaveTImer.Enabled = true;
        }

        private void SaveTImer_Elapsed(object sender, ElapsedEventArgs e) { if (SaveData()) DataToSave.Clear(); }

        public void CallInsturmentSubscription(InstrumentKey ik)
        {
            Contract C; ContList.Add(C = new Contract());
            InstrumentLookupSubscription req = new InstrumentLookupSubscription(apiInstance.Session, Dispatcher.Current, ik);
            C.Init(this, MainForm, apiInstance, req);
            req.Update += new EventHandler<InstrumentLookupSubscriptionEventArgs>(C.req_Update); req.Start();
        }

        public void CallBackCancel(Contract c) { ContList.Remove(c); c.Dispose(); }

        public void IncomingData(DateTime timeStamp, string[] data) { if (DataToSave.ContainsKey(timeStamp)) DataToSave.Add(timeStamp.AddMilliseconds(1), data); else DataToSave.Add(timeStamp, data); }

        public bool SaveData()
        {
            if (DataToSave.Count > 0)
            {
                try
                {
                    var csvString = new StringBuilder(); string tempLine = "";
                    foreach (var item in DataToSave) { tempLine = item.Key.ToString("HH:mm:ss"); for (int i = 0; i < item.Value.Count(); i++) tempLine += "," + item.Value[i]; }
                    csvString.AppendLine(tempLine); File.AppendAllText(SavePath, csvString.ToString());
                    return true;
                }
                catch { return false; }
            }
            else return false;
        }

        public void Dispose() { lock (m_lock) { if (!m_disposed) { while (ContList.Count > 0) { ContList[0].Dispose(); ContList.RemoveAt(0); } TTAPI.ShutdownCompleted += new EventHandler(TTAPI_ShutdownCompleted); TTAPI.Shutdown(); m_disposed = true; } } }
        public void TTAPI_ShutdownCompleted(object sender, EventArgs e) { if (m_disp != null) { m_disp.Dispose(); m_disp = null; } apiInstance = null; m_disp = null; m_username = null; m_password = null; GC.SuppressFinalize(this); }
    }
}
