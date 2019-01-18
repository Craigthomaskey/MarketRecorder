using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void SettingsBttn_Click(object sender, EventArgs e) { SettingMenu.Show(PointToScreen(SettingsBttn.Location)); }
        private void CloseBttn_Click(object sender, EventArgs e) { TTAPIF.SaveContracts(true); Properties.Settings.Default.Save(); TTAPIF.Dispose(); Application.Exit(); }

        private void saveContractsToolStripMenuItem_Click(object sender, EventArgs e) { TTAPIF.SaveContracts(false); }

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Location; Size = Properties.Settings.Default.Size;
            MainContainer.HorizontalScroll.Enabled = false;
            //load config files 
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // need to add sim setting
            TTAPIF = new TTAPIFunctions(); TTAPIF.Init(this, true);
            SetForm = new SettingForm(); SetForm.Init(this);
        }

        public void XtraderConnected(UniversalLoginTTAPI uapi)
        {
            apiInstance = uapi;
            BuildNotification("Xtrader connected.", Properties.Resources.ChickenBlack);
        }


        public List<Notification> NoteList = new List<Notification>();
        public void BuildNotification(string text, Image img)
        {
            // if (Properties.Settings.Default.Popups)
            //{
            if (img == null) img = Properties.Resources.ChickenBlack;
            Notification N = new Notification();
            N.Show();
            N.Init(this, text, img, BackColor, Width);
            NoteList.Add(N);
            NotificationPlacement();
            //}
        }
        public void NotificationPlacement()
        {
            int Stacker = 5;
            while (NoteList.Count > 5) { Notification N = NoteList[0]; N.CallClose(); }
            for (int i = NoteList.Count - 1; i >= 0; i--) { Notification N = NoteList[i]; if (N.Visible) { N.Width = Width; var screen = Screen.FromPoint(Location); N.Location = new Point(Location.X, Location.Y - N.Height - Stacker); Stacker += N.Height + 5; } }
        }

        SortedDictionary<string, ContractControl> ContControlDict = new SortedDictionary<string, ContractControl>();
        public ContractControl BuildControl(string name, Contract cont)
        {
            if (!ContControlDict.ContainsKey(name))
            {
                ContractControl CC = new ContractControl(); CC.Init(name, cont, this); ContControlDict.Add(name, CC); MainContainer.Controls.Add(CC);
                foreach (var v in ContControlDict) MainContainer.Controls.SetChildIndex(v.Value, ContControlDict.Values.ToList().IndexOf(v.Value));
                return CC;
            }
            else
            {
                return null;
            }
        }
        public void ControlDeathCall(string name, ContractControl cont) { MainContainer.Controls.Remove(cont); ContControlDict.Remove(name); }

        ContractControl HighlightedContCtrl;
        public void ShiftSettingsForm(Contract cont, ContractControl contCtrl, string name)
        {
            if (HighlightedContCtrl != null) HighlightedContCtrl.SettingsRemoveHighlight(); HighlightedContCtrl = contCtrl;
            SetForm.Visible = true; SetForm.ConnectContract(name, cont); SetForm.RepositionThis(Height, Width, Location);

        }
        public void SettingFormClosed() { if (HighlightedContCtrl != null) HighlightedContCtrl.SettingsRemoveHighlight(); }












    }
}
