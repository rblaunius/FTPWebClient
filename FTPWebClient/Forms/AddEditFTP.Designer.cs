namespace FTPWebClient.Forms
{
    partial class AddEditFTP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditFTP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtNotFoundFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnHShow = new System.Windows.Forms.Button();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 295);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnBrowse);
            this.panel8.Controls.Add(this.txtNotFoundFile);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 197);
            this.panel8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel8.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel8.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel8.Size = new System.Drawing.Size(441, 29);
            this.panel8.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Location = new System.Drawing.Point(413, 4);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 24);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.btnBrowse.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnBrowse.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // txtNotFoundFile
            // 
            this.txtNotFoundFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotFoundFile.Location = new System.Drawing.Point(103, 5);
            this.txtNotFoundFile.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtNotFoundFile.Name = "txtNotFoundFile";
            this.txtNotFoundFile.Size = new System.Drawing.Size(306, 23);
            this.txtNotFoundFile.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtNotFoundFile, "If selected, this file will uploaded to the FTP to replace all other files in it." +
        "");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Placeholder File:";
            this.toolTip1.SetToolTip(this.label6, "If selected, this file will uploaded to the FTP to replace all other files in it." +
        "");
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtFolder);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 168);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel6.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel6.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel6.Size = new System.Drawing.Size(441, 29);
            this.panel6.TabIndex = 0;
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(103, 5);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(336, 23);
            this.txtFolder.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtFolder, "The location of the folder to upload web files to on the FTP (ex: /httpdocs)");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Location:";
            this.toolTip1.SetToolTip(this.label4, "The location of the folder to upload web files to on the FTP (ex: /httpdocs)");
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnHShow);
            this.panel5.Controls.Add(this.txtPW);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 139);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel5.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel5.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel5.Size = new System.Drawing.Size(441, 29);
            this.panel5.TabIndex = 0;
            // 
            // btnHShow
            // 
            this.btnHShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHShow.BackColor = System.Drawing.Color.Transparent;
            this.btnHShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHShow.BackgroundImage")));
            this.btnHShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHShow.Location = new System.Drawing.Point(413, 5);
            this.btnHShow.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnHShow.Name = "btnHShow";
            this.btnHShow.Size = new System.Drawing.Size(26, 24);
            this.btnHShow.TabIndex = 10;
            this.btnHShow.TabStop = false;
            this.btnHShow.UseVisualStyleBackColor = false;
            this.btnHShow.Click += new System.EventHandler(this.btnHShow_Click);
            this.btnHShow.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnHShow.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // txtPW
            // 
            this.txtPW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPW.Location = new System.Drawing.Point(103, 5);
            this.txtPW.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(306, 23);
            this.txtPW.TabIndex = 4;
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtLogin);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 110);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel4.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel4.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel4.Size = new System.Drawing.Size(441, 29);
            this.panel4.TabIndex = 0;
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.Location = new System.Drawing.Point(103, 5);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(336, 23);
            this.txtLogin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtName);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 81);
            this.panel7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel7.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel7.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel7.Size = new System.Drawing.Size(441, 29);
            this.panel7.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(103, 5);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 23);
            this.txtName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nickname:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtIP);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel3.MaximumSize = new System.Drawing.Size(0, 29);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Size = new System.Drawing.Size(441, 29);
            this.panel3.TabIndex = 0;
            // 
            // txtIP
            // 
            this.txtIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIP.Location = new System.Drawing.Point(103, 5);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(336, 23);
            this.txtIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP/Host:";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.txtTitle.Size = new System.Drawing.Size(441, 52);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "Add New FTP Connection";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 260);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 47);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(4, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(326, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 9200;
            this.toolTip1.InitialDelay = 620;
            this.toolTip1.ReshowDelay = 124;
            // 
            // AddEditFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(186)))), ((int)(((byte)(98)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(463, 307);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "AddEditFTP";
            this.Padding = new System.Windows.Forms.Padding(10, 12, 12, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnSave;
        private Button btnCancel;
        private Panel panel5;
        private TextBox txtPW;
        private Label label3;
        private Panel panel4;
        private TextBox txtLogin;
        private Label label2;
        private Panel panel3;
        private TextBox txtIP;
        private Label label1;
        private Button btnHShow;
        private Panel panel6;
        private TextBox txtFolder;
        private Label label4;
        private ToolTip toolTip1;
        private Panel panel7;
        private TextBox txtName;
        private Label label5;
        private Label txtTitle;
        private Panel panel8;
        private TextBox txtNotFoundFile;
        private Label label6;
        private Button btnBrowse;
    }
}