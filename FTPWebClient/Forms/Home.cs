using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPWebClient.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings f = new Forms.Settings();
            f.ShowDialog();
            f.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        Point? relativeLoc = null;

        private void Toolbar_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
            relativeLoc = ((MouseEventArgs)e).Location;
        }

        private void Toolbar_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            relativeLoc = null;
        }

        private void Toolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor == Cursors.SizeAll && relativeLoc != null)
            {
                int dx = e.Location.X - relativeLoc.Value.X;
                int dy = relativeLoc.Value.Y - e.Location.Y;



            }
        }

        private void Home_MouseClick(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.WaitCursor)
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
