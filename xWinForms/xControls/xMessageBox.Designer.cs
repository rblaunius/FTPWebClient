namespace xWinForms.xControls
{
    partial class xMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xMessageBox));
            this.txtMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnAffirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            resources.ApplyResources(this.txtMessage, "txtMessage");
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Name = "txtMessage";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDeny);
            this.panel1.Controls.Add(this.btnAffirm);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeny
            // 
            resources.ApplyResources(this.btnDeny, "btnDeny");
            this.btnDeny.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDeny.FlatAppearance.BorderSize = 0;
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            this.btnDeny.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDeny.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnAffirm
            // 
            resources.ApplyResources(this.btnAffirm, "btnAffirm");
            this.btnAffirm.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAffirm.FlatAppearance.BorderSize = 0;
            this.btnAffirm.Name = "btnAffirm";
            this.btnAffirm.UseVisualStyleBackColor = false;
            this.btnAffirm.Click += new System.EventHandler(this.btnAffirm_Click);
            this.btnAffirm.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAffirm.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // xMessageBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ControlBox = false;
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "xMessageBox";
            this.Opacity = 0.88D;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label txtMessage;
        private Panel panel1;
        private Button btnAffirm;
        private Button btnDeny;
        private Button btnCancel;
    }
}