using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
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
        private void SizeMouseMove(object sender, MouseEventArgs e) { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragFormPoint)); Size = new Size(dif); if (SetForm.Visible) SetForm.RepositionThis(Height, Width, Location); } }
        private void SizeMouseUp(object sender, MouseEventArgs e) { dragging = false; Properties.Settings.Default.Size = Size; }
        private void ContDragOver(object sender, DragEventArgs e) { if (e.Data.HasInstrumentKeys() && apiInstance != null) e.Effect = DragDropEffects.Copy; }
        private void ContDragDrop(object sender, DragEventArgs e) { if (e.Data.HasInstrumentKeys()) foreach (InstrumentKey ik in e.Data.GetInstrumentKeys()) TTAPIF.CallInsturmentSubscription(ik); }
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

        private void SettingsBttn_Click(object sender, EventArgs e) { SettingMenu.Show(PointToScreen(SettingsBttn.Location)); }
        private void CloseBttn_Click(object sender, EventArgs e) { if (Properties.Settings.Default.WriteOnClose) TTAPIF.SaveAllDataCall(); TTAPIF.SaveContracts(true); Properties.Settings.Default.Save(); TTAPIF.Dispose(); Application.Exit(); }

        private void saveContractsToolStripMenuItem_Click(object sender, EventArgs e) { TTAPIF.SaveContracts(false); }

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed) versionToolStripMenuItem.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            Location = Properties.Settings.Default.Location; Size = Properties.Settings.Default.Size;
            MainContainer.HorizontalScroll.Enabled = false;
            notificationsToolStripMenuItem.Checked = Properties.Settings.Default.Popups;
            sIMToolStripMenuItem.Checked = Properties.Settings.Default.SIM;
            writeOnCloseToolStripMenuItem.Checked = Properties.Settings.Default.WriteOnClose;

            if (Properties.Settings.Default.WriteSpeed == 15000) secondsToolStripMenuItem1.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 30000) secondsToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 60000) minuteToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 120000) minutesToolStripMenuItem.PerformClick();
            else if (Properties.Settings.Default.WriteSpeed == 300000) minutesToolStripMenuItem1.PerformClick();
            else hourToolStripMenuItem.PerformClick();

            ((ToolStripDropDownMenu)dataUpdateSpeedToolStripMenuItem.DropDown).ShowImageMargin = false; dataUpdateSpeedToolStripMenuItem.DropDown.Closing += DropDown_Closing;
        }
        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e) { if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) e.Cancel = true; }
        private void SettingMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e) { if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) e.Cancel = true; }

        private void Form1_Shown(object sender, EventArgs e) { TTAPIF = new TTAPIFunctions(); TTAPIF.Init(this, Properties.Settings.Default.SIM); SetForm = new SettingForm(); SetForm.Init(this); }

        public void XtraderConnected(UniversalLoginTTAPI uapi) { apiInstance = uapi; BuildNotification("Xtrader connected.", Properties.Resources.ConnectedNote); }


        public List<Notification> NoteList = new List<Notification>();
        public void BuildNotification(string text, Image img)
        {
            if (Properties.Settings.Default.Popups)
            {
                if (img == null) img = Properties.Resources.ChickenBlack;
                Notification N = new Notification(); N.Show(); N.Init(this, text, img, BackColor, Width); NoteList.Add(N); NotificationPlacement();
            }
        }
        public void NotificationPlacement()
        {
            int Stacker = 5;
            while (NoteList.Count > 5) { Notification N = NoteList[0]; N.CallClose(); }
            for (int i = NoteList.Count - 1; i >= 0; i--) { Notification N = NoteList[i]; if (N.Visible) { N.Width = Width; var screen = Screen.FromPoint(Location); N.Location = new Point(Location.X, Location.Y - N.Height - Stacker); Stacker += N.Height + 5; } }
        }

        SortedDictionary<string, ContractControl> ContControlDict = new SortedDictionary<string, ContractControl>();
        public ContractControl BuildControl(string name, Contract cont, string dispName)
        {
            if (!ContControlDict.ContainsKey(name))
            {
                ContractControl CC = new ContractControl(); CC.Init(name, cont, this, dispName); ContControlDict.Add(name, CC); MainContainer.Controls.Add(CC);
                foreach (var v in ContControlDict) MainContainer.Controls.SetChildIndex(v.Value, ContControlDict.Values.ToList().IndexOf(v.Value)); return CC;
            }
            else { return null; }
        }
        public void ControlDeathCall(string name, ContractControl cont) { MainContainer.Controls.Remove(cont); ContControlDict.Remove(name); }

        ContractControl HighlightedContCtrl;
        public void ShiftSettingsForm(Contract cont, ContractControl contCtrl, string name)
        {
            if (HighlightedContCtrl != null) HighlightedContCtrl.SettingsRemoveHighlight();
            HighlightedContCtrl = contCtrl;
            SetForm.Visible = true; SetForm.ConnectContract(name, cont); SetForm.RepositionThis(Height, Width, Location);
        }
        public void SettingFormClosed() { if (HighlightedContCtrl != null) { HighlightedContCtrl.SettingsRemoveHighlight(); HighlightedContCtrl = null; } } 

        private void writeDataToolStripMenuItem_Click(object sender, EventArgs e) { TTAPIF.SaveAllDataCall(); BuildNotification("Data Exported.", Properties.Resources.SaveNote); }
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

        private void ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Checked) tsmi.BackColor = SystemColors.ControlLight;
            else tsmi.BackColor = SystemColors.Control;
        }


    }
}
