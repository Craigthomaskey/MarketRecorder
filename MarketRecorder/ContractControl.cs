using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRecorder
{
    public partial class ContractControl : UserControl
    {
        public ContractControl() { InitializeComponent(); }
        Contract LinkedCont; Form1 MainForm;
        public void Init(string name, Contract cont, Form1 f, string dispName) { MainLabel.Text = dispName; Name = name; LinkedCont = cont; MainForm = f; }
        public void PassData(string[] data)
        {
            LastTradeLbl.Text = data[3];
            LastPriceLbl.Text = data[4];
            TradeTypeLabl.Text = data[5];
            AskVolumeLbl.Text = data[6];
            BidVolumeLbl.Text = data[7];
        }

        private void CloseBttn_Click(object sender, EventArgs e) { LinkedCont.DeathCall(); MainForm.ControlDeathCall(Name, this); }
        private void SettingsBttn_Click(object sender, EventArgs e)
        {
            MainForm.ShiftSettingsForm(LinkedCont, this, MainLabel.Text);
        }








    }
}
