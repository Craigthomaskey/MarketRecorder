﻿using System;
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
        public void Init(string name, Contract cont, Form1 f) { MainLabel.Text = name; LinkedCont = cont; MainForm = f; }
        public void PassData(string[] data)
        {
            LastTradeLbl.Text = data[2];
            LastPriceLbl.Text = data[3];
            TradeTypeLabl.Text = data[4];
            AskVolumeLbl.Text = data[5];
            BidVolumeLbl.Text = data[6];
        }

        private void CloseBttn_Click(object sender, EventArgs e) { LinkedCont.DeathCall(); MainForm.ControlDeathCall(MainLabel.Text, this); }
        private void SettingsBttn_Click(object sender, EventArgs e)
        {
            //open settings panel and adjust the controls to effect the linked contract
            SettingsBttn.BackColor = SystemColors.ControlDark;
            MainForm.ShiftSettingsForm(LinkedCont, this, MainLabel.Text);
        }
        public void SettingsRemoveHighlight() => SettingsBttn.BackColor = SystemColors.Control;








    }
}
