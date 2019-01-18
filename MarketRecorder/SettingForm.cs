using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRecorder
{
    public partial class SettingForm : Form
    {
        public SettingForm() { InitializeComponent(); }
        public void RepositionThis(int hght, int wdth, Point lctn) { Height = hght; Location = new Point(lctn.X + wdth, lctn.Y); }
        Form1 MainForm;
        public void Init(Form1 f)
        {
            MainForm = f;
        }
        private void CloseBttn_Click(object sender, EventArgs e)        {            Hide(); MainForm.SettingFormClosed();        }


        Contract LinkedCont;
        public void ConnectContract(string name, Contract cont)
        {
            NameLbl.Text = name;            LinkedCont = cont;
            StartTimePicker.Value = cont.StartRecordWindowTime;
            EndTimePicker.Value = cont.EndRecordWindowTime;
            SeprateFileCheck.Checked = cont.SeperateFileForWindowRecord;
            AllDayCheck.Checked = cont.RecordAllDay;
        }

        private void StartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LinkedCont.StartRecordWindowTime = StartTimePicker.Value;
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LinkedCont.EndRecordWindowTime = EndTimePicker.Value;
        }

        private void SeprateFileCheck_CheckedChanged(object sender, EventArgs e)
        {
            LinkedCont.SeperateFileForWindowRecord = SeprateFileCheck.Checked;
        }

        private void AllDayCheck_CheckedChanged(object sender, EventArgs e)
        {
            LinkedCont.RecordAllDay = AllDayCheck.Checked;
        }
    }
}
