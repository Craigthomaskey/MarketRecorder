using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRecorder
{
    public partial class SettingForm : Form
    {
        public SettingForm() { InitializeComponent(); }
        public void RepositionThis(int hght, int wdth, Point lctn) { Height = hght; Location = new Point(lctn.X + wdth, lctn.Y); ScrollSizing(); }
        Form1 MainForm;
        public void Init(Form1 f) { MainForm = f; Owner = MainForm; ShowInTaskbar = false; }
        private void CloseBttn_Click(object sender, EventArgs e) { Hide(); MainForm.SettingFormClosed(); }

        Contract LinkedCont;
        public void ConnectContract(string name, Contract cont)
        {
            NameLbl.Text = name; LinkedCont = cont;
            StartTimePicker.Value = cont.StartRecordWindowTime;
            EndTimePicker.Value = cont.EndRecordWindowTime;
            SeprateFileCheck.Checked = cont.SeperateFileForWindowRecord;
            AllDayCheck.Checked = cont.RecordAllDay;
            DriveLoadUploadTypeControls(cont.DriveUploadType);
            DriveUploadTimePicker.Value = DateTime.ParseExact(Properties.Settings.Default.DriveUploadTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            DriveMainFileCheck.Checked = Properties.Settings.Default.DriveUploadMainFile;
            DriveAutoConnectCheck.Checked = Properties.Settings.Default.DriveAutoConnect;
            DriveAutoUploadCheck.Checked = Properties.Settings.Default.DriveAutoUpload;
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e) { LinkedCont.StartRecordWindowTime = StartTimePicker.Value; }
        private void EndTimePicker_ValueChanged(object sender, EventArgs e) { LinkedCont.EndRecordWindowTime = EndTimePicker.Value; }
        private void SeprateFileCheck_CheckedChanged(object sender, EventArgs e) { LinkedCont.SeperateFileForWindowRecord = SeprateFileCheck.Checked; }
        private void AllDayCheck_CheckedChanged(object sender, EventArgs e) { LinkedCont.RecordAllDay = AllDayCheck.Checked; }
        private void SettingsScroll_Scroll(object sender, ScrollEventArgs e) { ScrollContainer.SuspendLayout(); MainContainer.Location = new Point(0, 0 - SettingsScroll.Value); ScrollContainer.ResumeLayout(); }
        void ScrollSizing()
        {
            int scrollHeight = MainContainer.Height - ScrollContainer.Height;
            if (scrollHeight > 0) { SettingsScroll.Maximum = scrollHeight + 30; SettingsScroll.Enabled = true; Width = 240; }
            else { SettingsScroll.Enabled = false; Width = 212; MainContainer.Location = new Point(0, 0); }
            try { SettingsScroll.SmallChange = scrollHeight / 5; SettingsScroll.LargeChange = scrollHeight / 2; }
            catch { SettingsScroll.SmallChange = 20; SettingsScroll.LargeChange = 45; }
        }

        public void DriveFileCount(int i) => FileCountLbl.Text = i.ToString();
        public void DriveStatusChange(bool connected)
        {
            if (connected) { DriveConnectionLbl.Text = "Connection Status: Connected"; DriveConnectionLbl.ForeColor = Color.Green; DriveConnectButton.Enabled = false; DriveUploadButton.Enabled = true; }
            else { DriveConnectionLbl.Text = "Connection Status : Not Connected"; DriveConnectionLbl.ForeColor = Color.DarkRed; DriveConnectButton.Enabled = true; DriveUploadButton.Enabled = false; }
        }

        private void DriveUploadTimePicker_ValueChanged(object sender, EventArgs e) { Properties.Settings.Default.DriveUploadTime = DriveUploadTimePicker.Value.ToString("HH:mm:ss"); if (DateTime.Now < DriveUploadTimePicker.Value) MainForm.HasUploaded = false; }
        private void DriveAutoConnectCheck_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.DriveAutoConnect = DriveAutoConnectCheck.Checked; }
        private void DriveAutoUploadCheck_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.DriveAutoUpload = DriveAutoUploadCheck.Checked; }

        bool AllCheckChange = false;
        private void DriveUploadAllNoneBttn_Click(object sender, EventArgs e)
        {
            AllCheckChange = true; bool x = true;
            if (DriveUploadAllNoneBttn.Text == "Clear") { DriveUploadAllNoneBttn.Text = "All"; x = false; } else DriveUploadAllNoneBttn.Text = "Clear";
            foreach (Control item in DriveAutoUploadGroup.Controls) { if (item.GetType() == typeof(CheckBox)) { CheckBox CB = item as CheckBox; CB.Checked = x; } }
            AllCheckChange = false;
        }
        private void DriveMainFileCheck_CheckedChanged(object sender, EventArgs e) { if (!AllCheckChange) DriveUploadTypeControlShift(); }
        private void DriveWindowFilesCheck_CheckedChanged(object sender, EventArgs e) { if (!AllCheckChange) DriveUploadTypeControlShift(); }
        void DriveLoadUploadTypeControls(int i)
        {
            if (i == 0) { DriveWindowFilesCheck.Checked = false; DriveMainFileCheck.Checked = false; DriveUploadAllNoneBttn.Text = "All"; }
            else if (i == 1) { DriveWindowFilesCheck.Checked = true; DriveMainFileCheck.Checked = true; DriveUploadAllNoneBttn.Text = "Clear"; }
            else if (i == 2) { DriveWindowFilesCheck.Checked = false; DriveMainFileCheck.Checked = true; DriveUploadAllNoneBttn.Text = "All"; }
            else { DriveWindowFilesCheck.Checked = true; DriveMainFileCheck.Checked = false; DriveUploadAllNoneBttn.Text = "All"; }
            Properties.Settings.Default.DriveUploadMainFile = DriveMainFileCheck.Checked;
        }
        void DriveUploadTypeControlShift()
        {
            if (!DriveWindowFilesCheck.Checked && !DriveMainFileCheck.Checked) { LinkedCont.DriveUploadType = 0; DriveUploadAllNoneBttn.Text = "All"; }
            else if (DriveWindowFilesCheck.Checked && DriveMainFileCheck.Checked) { LinkedCont.DriveUploadType = 1; DriveUploadAllNoneBttn.Text = "Clear"; }
            else if (!DriveWindowFilesCheck.Checked && DriveMainFileCheck.Checked) { LinkedCont.DriveUploadType = 2; DriveUploadAllNoneBttn.Text = "All"; }
            else if (DriveWindowFilesCheck.Checked && !DriveMainFileCheck.Checked) { LinkedCont.DriveUploadType = 3; DriveUploadAllNoneBttn.Text = "All"; }
            Properties.Settings.Default.DriveUploadMainFile = DriveMainFileCheck.Checked;
        }

        private void DriveConnectButton_Click(object sender, EventArgs e) { MainForm.DriveConnectionLogic(); }
        private void DriveUploadButton_Click(object sender, EventArgs e) { MainForm.DriveUploadLogic(); }

        public void ChangeLastUploadTime(string s) => LastUploadLBL.Text = "Last Upload : " + s;

    }
}
