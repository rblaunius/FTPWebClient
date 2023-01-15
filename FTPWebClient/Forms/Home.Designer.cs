using xWinForms.xControls;

namespace FTPWebClient.Forms
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.toolbar = new xWinForms.xControls.xToolbar();
            this.homeuc1 = new FTPWebClient.UserControls.HomeUC();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Transparent;
            this.toolbar.curLocation = null;
            resources.ApplyResources(this.toolbar, "toolbar");
            this.toolbar.Name = "toolbar";
            this.toolbar.ParentFrm = null;
            this.toolbar.SettingsFrm = null;
            // 
            // homeuc1
            // 
            this.homeuc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.homeuc1, "homeuc1");
            this.homeuc1.ForeColor = System.Drawing.Color.Black;
            this.homeuc1.Name = "homeuc1";
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ControlBox = false;
            this.Controls.Add(this.homeuc1);
            this.Controls.Add(this.toolbar);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Home_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private xToolbar toolbar;
        private UserControls.HomeUC homeuc1;
    }
}