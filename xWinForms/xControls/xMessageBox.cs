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
    public partial class xMessageBox : Form
    {
        public enum xDialogResultType
        {
            OK,
            YesNo,
            YesNoCancel
        }
        public static DialogResult Show(string msg, xDialogResultType dr = xDialogResultType.OK)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                using (var box = new xMessageBox(msg, dr))
                {
                    box.ShowDialog();
                    return box.DialogResult;
                }
            }
            else return DialogResult.Abort;
        }

        public xMessageBox(string msg, xDialogResultType dr = xDialogResultType.OK)
        {
            InitializeComponent();
            this.txtMessage.Text = msg;
            if (dr == xDialogResultType.OK)
            {
                btnDeny.Visible = false;
                btnCancel.Visible = false;
                btnAffirm.Text = "Ok";
            }
            else if (dr == xDialogResultType.YesNoCancel)
            {
                btnDeny.Text = "No";
                btnCancel.Text = "Cancel";
                btnAffirm.Text = "Yes";
            }
            else if (dr == xDialogResultType.YesNo)
            {
                btnDeny.Text = "No";
                btnCancel.Visible = false;
                btnAffirm.Text = "Yes";
            }
        }

        private void btnAffirm_Click(object sender, EventArgs e)
        {
            if (btnAffirm.Visible)
            {
                if (btnAffirm.Text == "Ok")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (btnAffirm.Text == "Yes")
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (btnDeny.Text == "No" && btnDeny.Visible)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Visible)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 128, 0);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromKnownColor(KnownColor.Gainsboro);
        }
    }
}
