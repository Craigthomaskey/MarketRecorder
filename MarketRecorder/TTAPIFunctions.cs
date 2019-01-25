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
        public bool PauseRecording = false;
        Form1 MainForm; UniversalLoginTTAPI apiInstance; UIDispatcher m_disp = null; Timer SvaeTimer;
        bool m_disposed = false; object m_lock = new object(); string m_username = "KWILSON"; string m_password = "wt2626wt";
        string SavePath = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Logs\MaxData {0} " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
        string ContConfigPath = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Config\MarketRecorder-Contracts.txt";
        public List<Contract> ContList = new List<Contract>(); List<string[]> AllDataHoldList = new List<string[]>();
        List<string> HeadingsList = new List<string>() { "Time", "Contract", "Quantity", "Price", "Direction", "Ask Vol", "Bid Vol", "Market/Firm", "Order Tag", "Trader ID", "Order Type", "Buy/Sell" };
        public void Init(Form1 f, bool sim)
        {
            MainForm = f; if (!sim) { m_username = "JHUSCHER"; m_password = "wt2626wt"; }
            m_disp = Dispatcher.AttachUIDispatcher(); ApiInitializeHandler h = new ApiInitializeHandler(ttApiInitComplete); TTAPI.CreateUniversalLoginTTAPI(Dispatcher.Current, m_username, m_password, h);
        }
        public void ttApiInitComplete(TTAPI api, ApiCreationException ex)
        {
            if (ex == null)
            {
                apiInstance = (UniversalLoginTTAPI)api; apiInstance.AuthenticationStatusUpdate += new EventHandler<AuthenticationStatusUpdateEventArgs>(apiInstance_AuthenticationStatusUpdate); apiInstance.Start();
            }
            else
            {
                MainForm.BuildNotification("TT API Initialization Failed: " + ex.Message, Properties.Resources.ChickenBlack);
                Dispose();
            }
        }
        public void apiInstance_AuthenticationStatusUpdate(object sender, AuthenticationStatusUpdateEventArgs e)
        {
            MainForm.XtraderConnected(apiInstance);
            MainForm.BuildNotification(LoadSavedContracts(), Properties.Resources.LoadNote);

            SvaeTimer = new Timer(60000); SvaeTimer.Elapsed += SvaeTimer_Elapsed; ; SvaeTimer.Enabled = true;
        }

        public void CallInsturmentSubscription(InstrumentKey ik) { Contract C; ContList.Add(C = new Contract()); InstrumentLookupSubscription req = new InstrumentLookupSubscription(apiInstance.Session, Dispatcher.Current, ik); C.Init(this, MainForm, apiInstance, req); req.Update += new EventHandler<InstrumentLookupSubscriptionEventArgs>(C.req_Update); req.Start(); }
        public void CallBackCancel(Contract c) { ContList.Remove(c); c.Dispose(); }

        string LoadSavedContracts()
        {
            int count = 0;
            try
            {
                if (File.Exists(ContConfigPath))
                {
                    foreach (string line in File.ReadLines(ContConfigPath).ToList())
                    {
                        string[] splitString = line.Split('^'); Contract C; ContList.Add(C = new Contract());
                        InstrumentLookupSubscription req = new InstrumentLookupSubscription(apiInstance.Session, Dispatcher.Current, new ProductKey(splitString[0], splitString[1], splitString[2]), splitString[3]);
                        C.Init(this, MainForm, apiInstance, req); C.LoadSavedInformation(splitString);
                        req.Update += new EventHandler<InstrumentLookupSubscriptionEventArgs>(C.req_Update); req.Start(); count++;
                    }
                    return "Started " + count + " saved contracts! Just a moment while connections are verified.";
                }
                else { return "Hmmm. Seems there is no saved contracts file."; }
            }
            catch { return "Opps... Something went wrong while trying to load saved contracts. Some contracts might not have been loaded!"; }
        }




        private void SvaeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataSaveCall("Main", 1);
            SvaeTimer.Interval = Properties.Settings.Default.WriteSpeed;
        }





        public bool DataSaveCall(string name, int type)
        {
            string saveFile = string.Format(SavePath, "Main");
            List<string[]> tempList = CollectData(type);
            if (tempList.Count > 0)
            {
                bool HWttn = true;
                if (!File.Exists(saveFile)) HWttn = WriteHeaders(saveFile);
                if(HWttn) return WriteData(saveFile, tempList);
            }
            return false;
        }

        List<string[]> CollectData(int type)
        {
            List<string[]> tempList = new List<string[]>();
            for (int i = 0; i < ContList.Count; i++)
                if (type == 1) tempList.AddRange(ContList[i].DataList);
                else tempList.AddRange(ContList[i].WindowDataList);
            return tempList;
        }

        bool WriteHeaders(string path)
        {
            try
            {
                string tempHeaders = "";
                for (int i = 0; i < HeadingsList.Count; i++) tempHeaders += HeadingsList[i] + ",";
                File.WriteAllText(path, tempHeaders + Environment.NewLine);
                return true;
            }
            catch { return false; }
        }
        bool WriteData(string path, List<string[]> data)
        {
            try
            {
                string tempLine = "";
                for (int i = 0; i < data.Count; i++)
                {
                    for (int d = 0; d < data[i].Count(); d++)
                        tempLine += data[i][d] + ",";
                    tempLine += Environment.NewLine;
                }
                File.AppendAllText(path, tempLine); return true;
            }
            catch (Exception e) { return false; }
        }
    









        public void SaveAllDataCall()
        {
            foreach (Contract cont in ContList)
            {
              cont.SaveDataCall();
            }
        } 

        public bool SaveData(List<string[]> data)
        {
            string saveFile = string.Format(SavePath, "Main");

            if (!File.Exists(saveFile))
            {
                string tempHeaders = "";
                for (int i = 0; i < HeadingsList.Count; i++)
                    tempHeaders += HeadingsList[i] + ",";
                File.WriteAllText(saveFile, tempHeaders + Environment.NewLine);
            }
            if (data.Count > 0)
            {
                try
                {
                    string tempLine = "";
                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int d = 0; d < data[i].Count(); d++)
                            tempLine += data[i][d] + ",";
                        tempLine += Environment.NewLine;
                    }
                    File.AppendAllText(saveFile, tempLine); return true;
                }
                catch (Exception e) { return false; }
            }
            else return false;
        }

        public bool SaveWindowData(string name, List<string[]> data)
        {
            string saveFile = string.Format(SavePath, name);
            if (!File.Exists(saveFile))
            {
                string tempHeaders = "";
                for (int i = 0; i < HeadingsList.Count; i++)
                    tempHeaders += HeadingsList[i] + ",";
                File.WriteAllText(saveFile, tempHeaders + Environment.NewLine);
            }
            if (data.Count > 0)
            {
                try
                {
                    string tempLine = "";
                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int d = 0; d < data[i].Count(); d++)
                            tempLine += data[i][d] + ",";
                        tempLine += Environment.NewLine;
                    }
                    File.AppendAllText(saveFile, tempLine); return true;
                }
                catch (Exception e) { return false; }
            }
            else return false;
        }










































        public void SaveContracts(bool closing)
        {
            List<string[]> tempSaveInfo = new List<string[]>();
            foreach (var cont in ContList)            
                tempSaveInfo.Add(cont.SaveInformation());

            string tempLine = "";
            foreach (string[] items in tempSaveInfo)
            {
                for (int i = 0; i < items.Count(); i++)
                    tempLine += items[i] + "^";
                tempLine += Environment.NewLine;
            }
            File.WriteAllText(ContConfigPath, tempLine);

            if (!closing) MainForm.BuildNotification("Contracts saved.", Properties.Resources.SaveNote);
        }















        public void Dispose() { lock (m_lock) { if (!m_disposed) { while (ContList.Count > 0) { ContList[0].Dispose(); ContList.RemoveAt(0); } TTAPI.ShutdownCompleted += new EventHandler(TTAPI_ShutdownCompleted); TTAPI.Shutdown(); m_disposed = true; } } }
        public void TTAPI_ShutdownCompleted(object sender, EventArgs e) { if (m_disp != null) { m_disp.Dispose(); m_disp = null; } apiInstance = null; m_disp = null; m_username = null; m_password = null; GC.SuppressFinalize(this); }
    }
}
