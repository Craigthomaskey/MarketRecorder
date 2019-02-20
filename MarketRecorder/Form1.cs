using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingTechnologies.TTAPI;
using TradingTechnologies.TTAPI.WinFormsHelpers;

namespace MarketRecorder
{
    public partial class Form1 : Form
    {

        TTAPIFunctions TTAPIF; UniversalLoginTTAPI apiInstance; SettingForm SetForm;
        private bool mouseDown; private Point lastLocation;
        private void LocationMouseDown(object sender, MouseEventArgs e) { mouseDown = true; lastLocation = e.Location; }
        private void LocationMouseMove(object sender, MouseEventArgs e) { if (mouseDown) { Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y); Update(); NotificationPlacement(); if (SetForm.Visible) SetForm.RepositionThis(Height, Width, Location); } }
        private void LocationMouseUp(object sender, MouseEventArgs e) { mouseDown = false; var screen = Screen.FromPoint(Location); Properties.Settings.Default.Location = Location; }
        private bool dragging = false; private Point dragCursorPoint; private Point dragFormPoint;
        private void SizeMouseDown(object sender, MouseEventArgs e) { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = Location; }
        private void SizeMouseMove(object sender, MouseEventArgs e) { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragFormPoint)); Size = new Size(dif); if (SetForm.Visible) SetForm.RepositionThis(Height, Width, Location); } ScrollSizing(); }
        private void SizeMouseUp(object sender, MouseEventArgs e) { dragging = false; Properties.Settings.Default.Size = Size; }
        private void ContDragOver(object sender, DragEventArgs e) { if (e.Data.HasInstrumentKeys() && apiInstance != null) e.Effect = DragDropEffects.Copy; }
        private void ContDragDrop(object sender, DragEventArgs e) { if (e.Data.HasInstrumentKeys()) foreach (InstrumentKey ik in e.Data.GetInstrumentKeys()) TTAPIF.CallInsturmentSubscription(ik); }
        void ChangeFormWidth(int i) { MaximumSize = new Size(i, 2000); MinimumSize = new Size(i, 200); }
        void ScrollSizing()
        {
            DisplayScroll.Height = ScrollContainer.Height - 3;
            int scrollHeight = MainContainer.Height - ScrollContainer.Height;
            if (scrollHeight > 0) { DisplayScroll.Maximum = scrollHeight + 20; DisplayScroll.Enabled = true; ChangeFormWidth(550); }
            else { DisplayScroll.Enabled = false; ChangeFormWidth(533); }
            try { DisplayScroll.SmallChange = scrollHeight / 10; DisplayScroll.LargeChange = scrollHeight / 5; }
            catch { DisplayScroll.SmallChange = 20; DisplayScroll.LargeChange = 45; }
            if (SetForm.Visible) SetForm.RepositionThis(Height, Width, Location);
        }
        private void DisplayScroll_Scroll(object sender, ScrollEventArgs e) { ScrollContainer.SuspendLayout(); MainContainer.Location = new Point(0, 0 - DisplayScroll.Value); }
        string ReleaseNotes = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Config\MarketRecorder-ReleaseNotes.txt";
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string path = Directory.GetCurrentDirectory();
                File.Copy(System.IO.Path.Combine(path, "MarketRecorder-ReleaseNotes.txt"), ReleaseNotes, true);
                Process.Start("notepad.exe", ReleaseNotes);
            }
        }
        private void ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Checked) tsmi.BackColor = SystemColors.ControlLight;
            else tsmi.BackColor = SystemColors.Control;
        }

        private void SettingsBttn_Click(object sender, EventArgs e) { SettingMenu.Show(PointToScreen(SettingsBttn.Location)); }
        private void CloseBttn_Click(object sender, EventArgs e) { if (Properties.Settings.Default.WriteOnClose) TTAPIF.SaveData(); TTAPIF.SaveContracts(true); Properties.Settings.Default.Save(); TTAPIF.Dispose(); Application.Exit(); }
        private void saveContractsToolStripMenuItem_Click(object sender, EventArgs e) { TTAPIF.SaveContracts(false); }
        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            MainContainer.VerticalScroll.Enabled = false; MainContainer.HorizontalScroll.Enabled = false;

            if (ApplicationDeployment.IsNetworkDeployed) versionToolStripMenuItem.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            Location = Properties.Settings.Default.Location; Size = Properties.Settings.Default.Size;
            notificationsToolStripMenuItem.Checked = Properties.Settings.Default.Popups;
            sIMToolStripMenuItem.Checked = Properties.Settings.Default.SIM;
            writeOnCloseToolStripMenuItem.Checked = Properties.Settings.Default.WriteOnClose;

            if (Properties.Settings.Default.WriteSpeed == 15000) secondsToolStripMenuItem1.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 30000) secondsToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 60000) minuteToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 120000) minutesToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 300000) minutesToolStripMenuItem1.PerformClick();
            else hourToolStripMenuItem.PerformClick();
            WriteTimer.Interval = Properties.Settings.Default.WriteSpeed;

            ((ToolStripDropDownMenu)dataUpdateSpeedToolStripMenuItem.DropDown).ShowImageMargin = false; dataUpdateSpeedToolStripMenuItem.DropDown.Closing += DropDown_Closing;

            CheckDirectories();
        }
        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e) { if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) e.Cancel = true; }
        private void SettingMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e) { if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) e.Cancel = true; }
        private void Form1_Shown(object sender, EventArgs e) { TTAPIF = new TTAPIFunctions(); TTAPIF.Init(this, Properties.Settings.Default.SIM); SetForm = new SettingForm(); SetForm.Init(this); ScrollSizing(); if (Properties.Settings.Default.DriveAutoConnect) DriveConnectionLogic();        }
        public void XtraderConnected(UniversalLoginTTAPI uapi) { apiInstance = uapi; BuildNotification("Xtrader connected.", Properties.Resources.ConnectedNote, this); }

        private void WriteTimer_Tick(object sender, EventArgs e)
        {
            WriteTimer.Stop();
            WriteTimer.Interval = Properties.Settings.Default.WriteSpeed;
            TTAPIF.SaveData();
            WriteTimer.Start();
        }

        public List<Notification> NoteList = new List<Notification>();
        public void BuildNotification(string text, Image img, Form1 f)
        {
            if (Properties.Settings.Default.Popups && text.Length > 0)
            {
                if (img == null) img = Properties.Resources.ChickenBlack;
                Notification N = new Notification();
                N.Init(f, text, img, BackColor, Width);
                N.Show();
                NoteList.Add(N);
                NotificationPlacement();
            }
        }
        public void NotificationPlacement()
        {
            try
            {
                int Stacker = 0;

                for (int i = 0; i < NoteList.Count; i++)
                {
                    Notification N = NoteList[i];
                    if (!N.IsDisposed)
                    {
                        if (N.MainTextGet() == "") { NoteList.RemoveAt(i); i--; continue; }
                        if (i > 4)
                        {
                            if (N.InvokeRequired) N.Invoke(new Action(() => N.CallClose(false)));
                            else N.CallClose(false);
                            NoteList.RemoveAt(i); i--;
                        }
                        else
                        {
                            var screen = Screen.FromPoint(Location);
                            if (N.InvokeRequired) N.Invoke(new Action(() => N.Location = new Point(Location.X, Location.Y - N.Height - Stacker)));
                            else N.Location = new Point(Location.X, Location.Y - 50 - Stacker);
                            Stacker += N.Height + 5;
                        }
                    }
                    else { NoteList.RemoveAt(i); i--; }
                }
            }
            catch { }
        }

        SortedDictionary<string, ContractControl> ContControlDict = new SortedDictionary<string, ContractControl>();
        public ContractControl BuildControl(string name, Contract cont, string dispName)
        {
            if (!ContControlDict.ContainsKey(name))
            {
                ContractControl CC = new ContractControl();
                CC.Init(name, cont, this, dispName);
                ContControlDict.Add(name, CC);
                MainContainer.Controls.Add(CC); MainContainer.Height += CC.Height; ScrollSizing();
                foreach (var v in ContControlDict)
                    MainContainer.Controls.SetChildIndex(v.Value, ContControlDict.Values.ToList().IndexOf(v.Value));
                return CC;
            }
            else { return null; }
        }
        public void ControlDeathCall(string name, ContractControl cont) { MainContainer.Controls.Remove(cont); MainContainer.Height -= cont.Height; ScrollSizing(); ContControlDict.Remove(name); }

        ContractControl HighlightedContCtrl;
        public void ShiftSettingsForm(Contract cont, ContractControl contCtrl, string name)
        {
            if (HighlightedContCtrl != null) HighlightedContCtrl.BorderStyle = BorderStyle.None;
            HighlightedContCtrl = contCtrl; HighlightedContCtrl.BorderStyle = BorderStyle.FixedSingle;
            SetForm.Visible = true; SetForm.ConnectContract(name, cont); SetForm.RepositionThis(Height, Width, Location);
        }
        public void SettingFormClosed() { if (HighlightedContCtrl != null) { HighlightedContCtrl.BorderStyle = BorderStyle.None; HighlightedContCtrl = null; } }

        private void writeDataToolStripMenuItem_Click(object sender, EventArgs e) { BuildNotification("Data Exported.", Properties.Resources.SaveNote, this); }
        private void pauseRecordingToolStripMenuItem_Click(object sender, EventArgs e) { pauseRecordingToolStripMenuItem.Checked = TTAPIF.PauseRecording ^= true; }
        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e) { notificationsToolStripMenuItem.Checked = Properties.Settings.Default.Popups ^= true; }
        private void sIMToolStripMenuItem_Click(object sender, EventArgs e) { sIMToolStripMenuItem.Checked = Properties.Settings.Default.SIM ^= true; }
        private void writeOnCloseToolStripMenuItem_Click(object sender, EventArgs e) { writeOnCloseToolStripMenuItem.Checked = Properties.Settings.Default.WriteOnClose ^= true; }

        private void secondsToolStripMenuItem1_Click(object sender, EventArgs e) { ChangeWriteSpeed(15000, secondsToolStripMenuItem1); }
        private void secondsToolStripMenuItem_Click(object sender, EventArgs e) { ChangeWriteSpeed(30000, secondsToolStripMenuItem); }
        private void minuteToolStripMenuItem_Click(object sender, EventArgs e) { ChangeWriteSpeed(60000, minuteToolStripMenuItem); }
        private void minutesToolStripMenuItem_Click(object sender, EventArgs e) { ChangeWriteSpeed(120000, minutesToolStripMenuItem); }
        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e) { ChangeWriteSpeed(300000, minutesToolStripMenuItem1); }
        private void hourToolStripMenuItem_Click(object sender, EventArgs e) { ChangeWriteSpeed(3600000, hourToolStripMenuItem); }
        void ChangeWriteSpeed(int speed, ToolStripMenuItem SMI)
        {
            foreach (ToolStripMenuItem MI in dataUpdateSpeedToolStripMenuItem.DropDownItems) MI.Checked = false;
            Properties.Settings.Default.WriteSpeed = speed;
            SMI.Checked = true;
        }


        private void dataDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay DatDisp = new DataDisplay();
            DatDisp.Location = Location; DatDisp.Size = Size; DatDisp.Show();
            DatDisp.WriteData(TTAPIF.DataDict, "All Data");
        }
        private void crossDataDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay DatDisp = new DataDisplay();
            DatDisp.Location = Location; DatDisp.Size = Size; DatDisp.Show();
            DatDisp.WriteData(TTAPIF.CrossedDataDict, "Crossed Data");
        }
        private void savedDataDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay DatDisp = new DataDisplay();
            DatDisp.Location = Location; DatDisp.Size = Size; DatDisp.Show();
            DatDisp.WriteData(TTAPIF.SavedDict, "Saved Data");
        }

        private void openSaveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SaveDirectory != "") Process.Start(Properties.Settings.Default.SaveDirectory);
            else BuildNotification("No save path selected :(", Properties.Resources.ChickenBlack, this);
        }

        private void changeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SFD = new FolderBrowserDialog();
            SFD.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult DR = SFD.ShowDialog();
            if (DR == DialogResult.OK)
            {
                Properties.Settings.Default.SaveDirectory = SFD.SelectedPath;
                BuildNotification("New save directory confirmed! - " + SFD.SelectedPath, Properties.Resources.ChickenBlack, this);
            }
        }

        void CheckDirectories()
        {
            if (Properties.Settings.Default.SaveDirectory == "") Properties.Settings.Default.SaveDirectory = @"C:\Users\" + Environment.UserName + @"\Documents\KDM\Logs";
            System.IO.Directory.CreateDirectory(Properties.Settings.Default.SaveDirectory);
            System.IO.Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\KDM\Config");
        }


        public DriveManager DM;
        public void DisplayShadowServicesMessage(bool x)        {                DriveProcessLabel.Visible = x;        }

        public bool HasUploaded = false;
        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            if (apiInstance != null)
            {
                if (Properties.Settings.Default.DriveAutoUpload &&DateTime.Now > DateTime.ParseExact(Properties.Settings.Default.DriveUploadTime, "HH:mm:ss", CultureInfo.InvariantCulture) && !HasUploaded)
                {
                    HasUploaded = true;
                    if (DM == null) DriveConnectionLogic();
                    DriveUploadLogic();
                }
            }
        }

        public void DriveConnectionLogic()
        {
            if (DM == null)
            {
                DM = new DriveManager();
                if (DM.DriveConnection(this, SetForm))
                {
                    BuildNotification("Drive Connection started.", Properties.Resources.ConnectedNote, this);
                    SetForm.DriveStatusChange(true);
                }
                else { BuildNotification("Drive Connection cannot be established.", Properties.Resources.ErrorNote, this); SetForm.DriveStatusChange(false); return; }
            }
            else { BuildNotification("Drive Connection has already been started.", Properties.Resources.ErrorNote, this); SetForm.DriveStatusChange(false); }
        }

        public void DriveUploadLogic()
        {
            if (DM != null)
            {
                DisplayShadowServicesMessage(true);
                BuildNotification(DM.RunFileSearchAsync() + " Files found.", Properties.Resources.ConnectedNote, this);
            }
            else { BuildNotification("Drive Connection has not been started.", Properties.Resources.ErrorNote, this); }
        }
        public void DriveFilesDownloaded()
        {
            foreach (string[] item in TTAPIF.GetDriveUploadList()) BuildNotification(DM.UploadFiles(item[0], item[2]), Properties.Resources.UploadNote,this);
            SetForm.ChangeLastUploadTime(DateTime.Now.ToString("HH:mm:ss"));            DisplayShadowServicesMessage(false); 
        }


    }
}
