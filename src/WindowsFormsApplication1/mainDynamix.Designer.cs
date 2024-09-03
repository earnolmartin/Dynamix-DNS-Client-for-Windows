namespace DynamixDNS
{
    partial class mainDynamix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainDynamix));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToStartupProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromStartupProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ipLabel = new System.Windows.Forms.Label();
            this.currentIP = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stopScanButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.oldIPLabelText = new System.Windows.Forms.Label();
            this.oldIPLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optiToolStripMenuItem,
            this.addToStartupProgramsToolStripMenuItem,
            this.removeFromStartupProgramsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editToolStripMenuItem.Text = "&Options";
            // 
            // optiToolStripMenuItem
            // 
            this.optiToolStripMenuItem.Name = "optiToolStripMenuItem";
            this.optiToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.optiToolStripMenuItem.Text = "&Preferences";
            this.optiToolStripMenuItem.Click += new System.EventHandler(this.optiToolStripMenuItem_Click);
            // 
            // addToStartupProgramsToolStripMenuItem
            // 
            this.addToStartupProgramsToolStripMenuItem.Name = "addToStartupProgramsToolStripMenuItem";
            this.addToStartupProgramsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.addToStartupProgramsToolStripMenuItem.Text = "&Add to Startup Programs";
            this.addToStartupProgramsToolStripMenuItem.Click += new System.EventHandler(this.addToStartupProgramsToolStripMenuItem_Click);
            // 
            // removeFromStartupProgramsToolStripMenuItem
            // 
            this.removeFromStartupProgramsToolStripMenuItem.Name = "removeFromStartupProgramsToolStripMenuItem";
            this.removeFromStartupProgramsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.removeFromStartupProgramsToolStripMenuItem.Text = "&Remove from Startup Programs";
            this.removeFromStartupProgramsToolStripMenuItem.Click += new System.EventHandler(this.removeFromStartupProgramsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(32, 106);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(91, 20);
            this.ipLabel.TabIndex = 4;
            this.ipLabel.Text = "IP Address:";
            // 
            // currentIP
            // 
            this.currentIP.AutoSize = true;
            this.currentIP.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentIP.ForeColor = System.Drawing.Color.Navy;
            this.currentIP.Location = new System.Drawing.Point(175, 104);
            this.currentIP.Name = "currentIP";
            this.currentIP.Size = new System.Drawing.Size(0, 22);
            this.currentIP.TabIndex = 5;
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(36, 261);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 6;
            this.scanButton.Text = "&Start";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000000000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // stopScanButton
            // 
            this.stopScanButton.Location = new System.Drawing.Point(489, 261);
            this.stopScanButton.Name = "stopScanButton";
            this.stopScanButton.Size = new System.Drawing.Size(75, 23);
            this.stopScanButton.TabIndex = 7;
            this.stopScanButton.Text = "S&top";
            this.stopScanButton.UseVisualStyleBackColor = true;
            this.stopScanButton.Visible = false;
            this.stopScanButton.Click += new System.EventHandler(this.stopScanButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time Since Last Scan:";
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursLabel.Location = new System.Drawing.Point(219, 209);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(27, 20);
            this.hoursLabel.TabIndex = 9;
            this.hoursLabel.Text = "00";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutesLabel.Location = new System.Drawing.Point(252, 209);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(27, 20);
            this.minutesLabel.TabIndex = 10;
            this.minutesLabel.Text = "00";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondsLabel.Location = new System.Drawing.Point(285, 209);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(27, 20);
            this.secondsLabel.TabIndex = 11;
            this.secondsLabel.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(275, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = ":";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // oldIPLabelText
            // 
            this.oldIPLabelText.AutoSize = true;
            this.oldIPLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldIPLabelText.Location = new System.Drawing.Point(32, 161);
            this.oldIPLabelText.Name = "oldIPLabelText";
            this.oldIPLabelText.Size = new System.Drawing.Size(119, 20);
            this.oldIPLabelText.TabIndex = 15;
            this.oldIPLabelText.Text = "Old IP Address:";
            this.oldIPLabelText.Visible = false;
            // 
            // oldIPLabel
            // 
            this.oldIPLabel.AutoSize = true;
            this.oldIPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldIPLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.oldIPLabel.Location = new System.Drawing.Point(175, 161);
            this.oldIPLabel.Name = "oldIPLabel";
            this.oldIPLabel.Size = new System.Drawing.Size(0, 20);
            this.oldIPLabel.TabIndex = 16;
            this.oldIPLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "Dynamix DNS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainDynamix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.oldIPLabel);
            this.Controls.Add(this.oldIPLabelText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopScanButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.currentIP);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "mainDynamix";
            this.Text = "Dynamix DNS Client";
            this.Load += new System.EventHandler(this.Dynamix_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label currentIP;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button stopScanButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label oldIPLabelText;
        private System.Windows.Forms.Label oldIPLabel;
        private System.Windows.Forms.ToolStripMenuItem addToStartupProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromStartupProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label4;
    }
}

