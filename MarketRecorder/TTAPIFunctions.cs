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
        Form1 MainForm; UniversalLoginTTAPI apiInstance; UIDispatcher m_disp = null; 
        bool m_disposed = false; object m_lock = new object(); string m_username = "KWILSON"; string m_password = "wt2626wt";
        string SavePath = @"{0}\{1} " + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
        string ContConfigPath = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Config\MarketRecorder-Contracts.txt";
        public List<Contract> ContList = new List<Contract>(); List<string[]> AllDataHoldList = new List<string[]>();
        public Dictionary<string, string[]> SavedDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> DataDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> CrossedDataDict = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> WindowData = new Dictionary<string, string[]>();
        List<string> HeadingsList = new List<string>() {"OrderKey", "Machine Time", "Sever Time", "Contract", "Quantity", "Price", "Direction", "Ask Vol", "Bid Vol", "Market/Firm", "Order Tag", "Trader ID", "Fill Type", "Order Date/Time" };
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
                MainForm.BuildNotification("TT API Initialization Failed: " + ex.Message, Properties.Resources.ChickenBlack, MainForm);
                Dispose();
            }
        }
        public void apiInstance_AuthenticationStatusUpdate(object sender, AuthenticationStatusUpdateEventArgs e)
        {
            MainForm.XtraderConnected(apiInstance);
            MainForm.BuildNotification(LoadSavedContracts(), Properties.Resources.LoadNote, MainForm);
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





        // 0 = all data // 1 = cross data // 2 = window data
        public void IncommingData(Dictionary<string, string[]> data, int type)
        {
            if (!PauseRecording)
            {
                if (type == 0) DataDict = data.Concat(DataDict).Concat(DataDict).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
                else if (type == 1) CrossedDataDict = data.Concat(CrossedDataDict).Concat(CrossedDataDict).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
                else if (type == 2) WindowData = data.Concat(CrossedDataDict).Concat(CrossedDataDict).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
            }
        }

        public void SaveData()
        {
            Dictionary<string, string[]> toSaveDict = new Dictionary<string, string[]>();


            for (int i = 0; i < DataDict.Count; i++)            
                if(!SavedDict.ContainsKey(DataDict.ElementAt(i).Key))             
                    toSaveDict.Add(DataDict.ElementAt(i).Key, DataDict.ElementAt(i).Value);
                         
            
            //toSaveDict = DataDict.Concat(SavedDict).Concat(toSaveDict).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
            if (toSaveDict.Count > 0)
            {
                if (WriteDataToFile(toSaveDict, "MarketData"))
                {
                    MainForm.BuildNotification("Data written (" + toSaveDict.Count + " lines).", Properties.Resources.SaveNote, MainForm);

                    foreach (var item in toSaveDict)
                        SavedDict.Add(item.Key, item.Value);
                                        
                    //      SavedDict = SavedDict.Concat(toSaveDict).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
                }
                else MainForm.BuildNotification("Error while writing data. File may currently be in use.", Properties.Resources.ErrorNote, MainForm);
            }
        }

        public void SaveWindowData(Dictionary<string, string[]> data, string name)
        {
            if (data.Count > 0 && !PauseRecording)
            {
                if (WriteDataToFile(data, "WindowData " + name)) MainForm.BuildNotification("Window Data written (" + data.Count + " lines).", Properties.Resources.SaveNote, MainForm);
                else MainForm.BuildNotification("Error while writing data. File may currently be in use.", Properties.Resources.ErrorNote, MainForm);
            }
        }



        bool WriteDataToFile(Dictionary<string, string[]> data, string type)
        {
            string saveFile = string.Format(SavePath, Properties.Settings.Default.SaveDirectory, type);
            if (!File.Exists(saveFile))
            {
                string tempHeaders = "";
                for (int i = 0; i < HeadingsList.Count; i++) tempHeaders += HeadingsList[i] + ",";
                File.WriteAllText(saveFile, tempHeaders + Environment.NewLine);
            }
            try
            {               
                string writeLine = "";
                //writeLine += Environment.NewLine;
                foreach (var DataPoint in data)
                {
                    writeLine += DataPoint.Key + ",";
                    for (int i = 0; i < DataPoint.Value.Count(); i++)
                        writeLine += DataPoint.Value[i] + ",";
                    writeLine += Environment.NewLine;
                }
                File.AppendAllText(saveFile, writeLine);
                return true;
            }
            catch { return false; }
        }











        public List<string[]> GetDriveUploadList()
        {
            List<string[]> tempList = new List<string[]>();

            if (Properties.Settings.Default.DriveUploadMainFile) tempList.Add(
                new string[2] { string.Format(SavePath, Properties.Settings.Default.SaveDirectory, "MarketData"),
                    "MarketData" + DateTime.Today.ToString("yyyy-MM-dd") + ".csv" });

            foreach (Contract cont in ContList)
            {
                string tempString = cont.DriveUploadWindowFile();
                if (tempString != "No") tempList.Add(
                    new string[2] { string.Format(SavePath, Properties.Settings.Default.SaveDirectory, "WindowData " + tempString),
                        "WindowData " + tempString + DateTime.Today.ToString("yyyy-MM-dd") + ".csv" } );
            }
            return tempList;
        }














        public void SaveContracts(bool closing)
        {
            List<string[]> tempSaveInfo = new List<string[]>();

            for (int i = 0; i < ContList.Count; i++)
            {
                string[] temp = ContList[i].SaveInformation();
                if (temp != null) tempSaveInfo.Add(temp); else i--;
            }

            string tempLine = "";
            foreach (string[] items in tempSaveInfo)
            {
                for (int i = 0; i < items.Count(); i++)
                    tempLine += items[i] + "^";
                tempLine += Environment.NewLine;
            }
            File.WriteAllText(ContConfigPath, tempLine);

            if (!closing) MainForm.BuildNotification("Contracts saved.", Properties.Resources.SaveNote, MainForm);
        }














        public void Dispose() { lock (m_lock) { if (!m_disposed) { while (ContList.Count > 0) { ContList[0].Dispose(); ContList.RemoveAt(0); } TTAPI.ShutdownCompleted += new EventHandler(TTAPI_ShutdownCompleted); TTAPI.Shutdown(); m_disposed = true; } } }
        public void TTAPI_ShutdownCompleted(object sender, EventArgs e) { if (m_disp != null) { m_disp.Dispose(); m_disp = null; } apiInstance = null; m_disp = null; m_username = null; m_password = null; GC.SuppressFinalize(this); }
    }
}
