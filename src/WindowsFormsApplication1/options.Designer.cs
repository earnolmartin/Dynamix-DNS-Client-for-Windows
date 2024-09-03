namespace DynamixDNS
{
    partial class options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(options));
            this.timeSeconds = new System.Windows.Forms.RadioButton();
            this.timeMinutes = new System.Windows.Forms.RadioButton();
            this.timeHours = new System.Windows.Forms.RadioButton();
            this.scanTimeLabel = new System.Windows.Forms.Label();
            this.intTimeInserted = new System.Windows.Forms.ComboBox();
            this.enterTimeLabel = new System.Windows.Forms.Label();
            this.autoStartLabel = new System.Windows.Forms.Label();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grabIP = new System.Windows.Forms.RadioButton();
            this.dinofly = new System.Windows.Forms.RadioButton();
            this.dynamix = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.scriptText = new System.Windows.Forms.TextBox();
            this.browseScriptButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clearScripts = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dynServicesBox = new System.Windows.Forms.CheckBox();
            this.configOtherDynDNS = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeSeconds
            // 
            this.timeSeconds.AutoSize = true;
            this.timeSeconds.Location = new System.Drawing.Point(35, 53);
            this.timeSeconds.Name = "timeSeconds";
            this.timeSeconds.Size = new System.Drawing.Size(67, 17);
            this.timeSeconds.TabIndex = 0;
            this.timeSeconds.TabStop = true;
            this.timeSeconds.Text = "&Seconds";
            this.timeSeconds.UseVisualStyleBackColor = true;
            // 
            // timeMinutes
            // 
            this.timeMinutes.AutoSize = true;
            this.timeMinutes.Location = new System.Drawing.Point(142, 53);
            this.timeMinutes.Name = "timeMinutes";
            this.timeMinutes.Size = new System.Drawing.Size(62, 17);
            this.timeMinutes.TabIndex = 1;
            this.timeMinutes.TabStop = true;
            this.timeMinutes.Text = "&Minutes";
            this.timeMinutes.UseVisualStyleBackColor = true;
            // 
            // timeHours
            // 
            this.timeHours.AutoSize = true;
            this.timeHours.Location = new System.Drawing.Point(253, 53);
            this.timeHours.Name = "timeHours";
            this.timeHours.Size = new System.Drawing.Size(53, 17);
            this.timeHours.TabIndex = 2;
            this.timeHours.TabStop = true;
            this.timeHours.Text = "&Hours";
            this.timeHours.UseVisualStyleBackColor = true;
            // 
            // scanTimeLabel
            // 
            this.scanTimeLabel.AutoSize = true;
            this.scanTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanTimeLabel.Location = new System.Drawing.Point(31, 28);
            this.scanTimeLabel.Name = "scanTimeLabel";
            this.scanTimeLabel.Size = new System.Drawing.Size(161, 20);
            this.scanTimeLabel.TabIndex = 3;
            this.scanTimeLabel.Text = "Scan Interval Options";
            // 
            // intTimeInserted
            // 
            this.intTimeInserted.FormattingEnabled = true;
            this.intTimeInserted.Location = new System.Drawing.Point(171, 80);
            this.intTimeInserted.Name = "intTimeInserted";
            this.intTimeInserted.Size = new System.Drawing.Size(121, 21);
            this.intTimeInserted.TabIndex = 4;
            this.intTimeInserted.Text = "60";
            // 
            // enterTimeLabel
            // 
            this.enterTimeLabel.AutoSize = true;
            this.enterTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterTimeLabel.Location = new System.Drawing.Point(29, 80);
            this.enterTimeLabel.Name = "enterTimeLabel";
            this.enterTimeLabel.Size = new System.Drawing.Size(124, 20);
            this.enterTimeLabel.TabIndex = 5;
            this.enterTimeLabel.Text = "Desired Interval:";
            // 
            // autoStartLabel
            // 
            this.autoStartLabel.AutoSize = true;
            this.autoStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartLabel.Location = new System.Drawing.Point(29, 236);
            this.autoStartLabel.Name = "autoStartLabel";
            this.autoStartLabel.Size = new System.Drawing.Size(127, 20);
            this.autoStartLabel.TabIndex = 9;
            this.autoStartLabel.Text = "Auto Start Scan:";
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Checked = true;
            this.autoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoStart.Location = new System.Drawing.Point(277, 242);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(15, 14);
            this.autoStart.TabIndex = 10;
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(121, 487);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(118, 23);
            this.saveSettings.TabIndex = 16;
            this.saveSettings.Text = "&Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP Script:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grabIP);
            this.groupBox1.Controls.Add(this.dinofly);
            this.groupBox1.Controls.Add(this.dynamix);
            this.groupBox1.Location = new System.Drawing.Point(35, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 98);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // grabIP
            // 
            this.grabIP.AutoSize = true;
            this.grabIP.Location = new System.Drawing.Point(7, 39);
            this.grabIP.Name = "grabIP";
            this.grabIP.Size = new System.Drawing.Size(136, 17);
            this.grabIP.TabIndex = 7;
            this.grabIP.Text = "Grab IP http://grabip.ezpz.cc";
            this.grabIP.UseVisualStyleBackColor = true;
            // 
            // dinofly
            // 
            this.dinofly.AutoSize = true;
            this.dinofly.Location = new System.Drawing.Point(7, 62);
            this.dinofly.Name = "dinofly";
            this.dinofly.Size = new System.Drawing.Size(237, 17);
            this.dinofly.TabIndex = 8;
            this.dinofly.Text = "DinoFly http://dinofly.com/misc/ipcheck.php";
            this.dinofly.UseVisualStyleBackColor = true;
            // 
            // dynamix
            // 
            this.dynamix.AutoSize = true;
            this.dynamix.Checked = true;
            this.dynamix.Location = new System.Drawing.Point(7, 16);
            this.dynamix.Name = "dynamix";
            this.dynamix.Size = new System.Drawing.Size(220, 17);
            this.dynamix.TabIndex = 6;
            this.dynamix.TabStop = true;
            this.dynamix.Text = "Dynamix DNS https://dynamix.run/ip.php";
            this.dynamix.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Run Scripts After IP Change:";
            // 
            // scriptText
            // 
            this.scriptText.Location = new System.Drawing.Point(33, 395);
            this.scriptText.Name = "scriptText";
            this.scriptText.ReadOnly = true;
            this.scriptText.Size = new System.Drawing.Size(271, 20);
            this.scriptText.TabIndex = 13;
            // 
            // browseScriptButton
            // 
            this.browseScriptButton.Location = new System.Drawing.Point(33, 421);
            this.browseScriptButton.Name = "browseScriptButton";
            this.browseScriptButton.Size = new System.Drawing.Size(75, 23);
            this.browseScriptButton.TabIndex = 14;
            this.browseScriptButton.Text = "&Browse";
            this.browseScriptButton.UseVisualStyleBackColor = true;
            this.browseScriptButton.Click += new System.EventHandler(this.browseScriptButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(31, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Supports .php, .exe, .bat, .jar";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AutoUpgradeEnabled = false;
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // clearScripts
            // 
            this.clearScripts.Location = new System.Drawing.Point(228, 420);
            this.clearScripts.Name = "clearScripts";
            this.clearScripts.Size = new System.Drawing.Size(75, 23);
            this.clearScripts.TabIndex = 15;
            this.clearScripts.Text = "&Clear";
            this.clearScripts.UseVisualStyleBackColor = true;
            this.clearScripts.Click += new System.EventHandler(this.clearScripts_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sync to Dynamic DNS Services:";
            // 
            // dynServicesBox
            // 
            this.dynServicesBox.AutoSize = true;
            this.dynServicesBox.Checked = true;
            this.dynServicesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dynServicesBox.Location = new System.Drawing.Point(277, 275);
            this.dynServicesBox.Name = "dynServicesBox";
            this.dynServicesBox.Size = new System.Drawing.Size(15, 14);
            this.dynServicesBox.TabIndex = 11;
            this.dynServicesBox.UseVisualStyleBackColor = true;
            // 
            // configOtherDynDNS
            // 
            this.configOtherDynDNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configOtherDynDNS.Location = new System.Drawing.Point(30, 306);
            this.configOtherDynDNS.Name = "configOtherDynDNS";
            this.configOtherDynDNS.Size = new System.Drawing.Size(273, 35);
            this.configOtherDynDNS.TabIndex = 12;
            this.configOtherDynDNS.Text = "&Configure Services (Dynamix, No-IP, FreeDNS...)";
            this.configOtherDynDNS.UseVisualStyleBackColor = true;
            this.configOtherDynDNS.Click += new System.EventHandler(this.configOtherDynDNS_Click);
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 536);
            this.Controls.Add(this.configOtherDynDNS);
            this.Controls.Add(this.dynServicesBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clearScripts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browseScriptButton);
            this.Controls.Add(this.scriptText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.autoStartLabel);
            this.Controls.Add(this.enterTimeLabel);
            this.Controls.Add(this.intTimeInserted);
            this.Controls.Add(this.scanTimeLabel);
            this.Controls.Add(this.timeHours);
            this.Controls.Add(this.timeMinutes);
            this.Controls.Add(this.timeSeconds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.Name = "options";
            this.Text = "Dynamix DNS Client Options";
            this.Load += new System.EventHandler(this.options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton timeSeconds;
        public System.Windows.Forms.RadioButton timeMinutes;
        public System.Windows.Forms.RadioButton timeHours;
        public System.Windows.Forms.Label scanTimeLabel;
        public System.Windows.Forms.ComboBox intTimeInserted;
        public System.Windows.Forms.Label enterTimeLabel;
        public System.Windows.Forms.Label autoStartLabel;
        public System.Windows.Forms.CheckBox autoStart;
        public System.Windows.Forms.Button saveSettings;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton grabIP;
        public System.Windows.Forms.RadioButton dinofly;
        public System.Windows.Forms.RadioButton dynamix;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox scriptText;
        public System.Windows.Forms.Button browseScriptButton;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button clearScripts;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox dynServicesBox;
        public System.Windows.Forms.Button configOtherDynDNS;
    }
}