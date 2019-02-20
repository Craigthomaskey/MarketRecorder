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
    public partial class DataDisplay : Form
    {

        private bool mouseDown; private Point lastLocation;
        private void LocationMouseDown(object sender, MouseEventArgs e) { mouseDown = true; lastLocation = e.Location; }
        private void LocationMouseMove(object sender, MouseEventArgs e) { if (mouseDown) { Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y); Update(); } }
        private void LocationMouseUp(object sender, MouseEventArgs e) { mouseDown = false; var screen = Screen.FromPoint(Location); Properties.Settings.Default.Location = Location; }
        private bool dragging = false; private Point dragCursorPoint; private Point dragFormPoint;
        private void SizeMouseDown(object sender, MouseEventArgs e) { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = Location; }
        private void SizeMouseMove(object sender, MouseEventArgs e) { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragFormPoint)); Size = new Size(dif); } }
        private void SizeMouseUp(object sender, MouseEventArgs e) { dragging = false; Properties.Settings.Default.Size = Size; }



        public DataDisplay()
        {
            InitializeComponent();
        }

        public void WriteData(Dictionary<string,string[]> data, string type)
        {
            NameLbl.Text = type;
            string temp = "";
            foreach (var item in data)
            {
                temp += item.Key + " - ";
                for (int i = 0; i < item.Value.Count(); i++)
                {
                    temp += item.Value[i] + ", ";
                }
                temp += Environment.NewLine;
            }
            DataWindow.Text = temp;
        }

        private void CloseBttn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
