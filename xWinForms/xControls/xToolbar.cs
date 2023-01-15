using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWinForms.xControls
{
    public partial class xToolbar : UserControl
    {
        public Form? SettingsFrm { get; set; }
        public Form? ParentFrm { get; set; }
        public xToolbar()
        {
            InitializeComponent();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender as Button == btnClose)
            {
                btnClose.BackColor = Color.FromArgb(234, 67, 53);
                Cursor = Cursors.Default;
            }
            else
            {
                btnMinimize.BackColor = Color.FromArgb(221, 221, 221);
                Cursor = Cursors.Hand;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Transparent;
            Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //if (SettingsFrm != null) SettingsFrm.ShowDialog();
            if (ParentFrm != null) ParentFrm.WindowState = FormWindowState.Minimized;
        }

        
        public Point? curLocation { get; set; } = null;
        private void xToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            this.curLocation = e.Location;
        }

        private void xToolbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.curLocation = null;
        }

        private void xToolbar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        private void xToolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor == Cursors.SizeAll && this.curLocation != null && ParentFrm != null)
            {
                int dx = e.X - this.curLocation.Value.X;
                int dy = e.Y - this.curLocation.Value.Y;
                ParentFrm.Location = new Point(ParentFrm.Location.X + dx, ParentFrm.Location.Y + dy);
            }
        }
    }
}
