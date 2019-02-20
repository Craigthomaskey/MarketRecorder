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
        }



        // public void GetParent(Form1 f) => MainForm = f;

        public string MainTextGet() => MainLabel.Text;



        public void CallClose(bool placement)
        {
            DurrationTimer.Stop();
            MainForm.NoteList.Remove(this);
            if (placement) MainForm.NotificationPlacement();
            Dispose();
        }




        private void CloseBttn_Click(object sender, EventArgs e) => CallClose(true);
        private void DurrationTimer_Tick(object sender, EventArgs e) => CallClose(true);




        private void Notification_Shown(object sender, EventArgs e)
        {
           // MainForm.NotificationPlacement();
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {

        }

        private void IconBox_Click(object sender, EventArgs e)
        {

        }

        private void OptionsBttn_Click(object sender, EventArgs e)
        {

        }
    }
}
