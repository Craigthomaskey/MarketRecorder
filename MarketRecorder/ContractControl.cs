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
        public ContractControl()
        {
            InitializeComponent();
        }

        public void Init(string name)
        {
            MainLabel.Text = name;
        }

        public void PassData(string[] data)
        {
            LastTradeLbl.Text = data[0];
            LastPriceLbl.Text = data[1];
            TradeTypeLabl.Text = data[2];
            AskVolumeLbl.Text = data[3];
            BidVolumeLbl.Text = data[4];

        }



        private void CloseBttn_Click(object sender, EventArgs e)
        {

        }

        private void SettingsBttn_Click(object sender, EventArgs e)
        {

        }
    }
}
