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
    public partial class Notification : Form
    {
        public Notification() => InitializeComponent();

        Form1 MainForm;
        public void Init(Form1 f, string txt, Image icn, Color bckclr, int wdth)
        {
            MainForm = f;
            MainLabel.Text = txt;
            IconBox.Image = icn;
            BackColor = bckclr;
            Width = wdth;
            //add custon settings for notification display times
        }
        public void CallClose() => CloseBttn.PerformClick();
        private void CloseBttn_Click(object sender, EventArgs e)        { DurrationTimer.Stop(); MainForm.NoteList.Remove(this); MainForm.NotificationPlacement(); Dispose();        }
        private void DurrationTimer_Tick(object sender, EventArgs e)        =>            CallClose();
        
    }
}
