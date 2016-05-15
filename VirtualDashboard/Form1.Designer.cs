namespace VirtualDashboard
{
    partial class Form1
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
            this.ComPort = new System.Windows.Forms.ComboBox();
            this.ComPortLabel = new System.Windows.Forms.Label();
            this.BaudLabel = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RPMLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EngineLoad = new System.Windows.Forms.Label();
            this.CoolantTemp = new System.Windows.Forms.Label();
            this.FileChosen = new System.Windows.Forms.Label();
            this.OpenLayout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComPort
            // 
            this.ComPort.FormattingEnabled = true;
            this.ComPort.Location = new System.Drawing.Point(99, 63);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(121, 21);
            this.ComPort.TabIndex = 0;
            // 
            // ComPortLabel
            // 
            this.ComPortLabel.AutoSize = true;
            this.ComPortLabel.Location = new System.Drawing.Point(46, 66);
            this.ComPortLabel.Name = "ComPortLabel";
            this.ComPortLabel.Size = new System.Drawing.Size(47, 13);
            this.ComPortLabel.TabIndex = 1;
            this.ComPortLabel.Text = "ComPort";
            // 
            // BaudLabel
            // 
            this.BaudLabel.AutoSize = true;
            this.BaudLabel.Location = new System.Drawing.Point(46, 110);
            this.BaudLabel.Name = "BaudLabel";
            this.BaudLabel.Size = new System.Drawing.Size(32, 13);
            this.BaudLabel.TabIndex = 3;
            this.BaudLabel.Text = "Baud";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Enabled = false;
            this.ConnectBtn.Location = new System.Drawing.Point(99, 144);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // BaudRate
            // 
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Location = new System.Drawing.Point(99, 107);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(121, 21);
            this.BaudRate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "RPM:";
            // 
            // RPMLabel
            // 
            this.RPMLabel.AutoSize = true;
            this.RPMLabel.Location = new System.Drawing.Point(596, 71);
            this.RPMLabel.Name = "RPMLabel";
            this.RPMLabel.Size = new System.Drawing.Size(13, 13);
            this.RPMLabel.TabIndex = 7;
            this.RPMLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Speed (Km/h)";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(596, 107);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(13, 13);
            this.SpeedLabel.TabIndex = 9;
            this.SpeedLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Engine Load";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Coolant Temp";
            // 
            // EngineLoad
            // 
            this.EngineLoad.AutoSize = true;
            this.EngineLoad.Location = new System.Drawing.Point(596, 144);
            this.EngineLoad.Name = "EngineLoad";
            this.EngineLoad.Size = new System.Drawing.Size(13, 13);
            this.EngineLoad.TabIndex = 12;
            this.EngineLoad.Text = "0";
            // 
            // CoolantTemp
            // 
            this.CoolantTemp.AutoSize = true;
            this.CoolantTemp.Location = new System.Drawing.Point(596, 181);
            this.CoolantTemp.Name = "CoolantTemp";
            this.CoolantTemp.Size = new System.Drawing.Size(13, 13);
            this.CoolantTemp.TabIndex = 13;
            this.CoolantTemp.Text = "0";
            // 
            // FileChosen
            // 
            this.FileChosen.AutoSize = true;
            this.FileChosen.Location = new System.Drawing.Point(46, 207);
            this.FileChosen.Name = "FileChosen";
            this.FileChosen.Size = new System.Drawing.Size(58, 13);
            this.FileChosen.TabIndex = 14;
            this.FileChosen.Text = "Layout File";
            // 
            // OpenLayout
            // 
            this.OpenLayout.Location = new System.Drawing.Point(49, 233);
            this.OpenLayout.Name = "OpenLayout";
            this.OpenLayout.Size = new System.Drawing.Size(75, 23);
            this.OpenLayout.TabIndex = 15;
            this.OpenLayout.Text = "Open";
            this.OpenLayout.UseVisualStyleBackColor = true;
            this.OpenLayout.Click += new System.EventHandler(this.OpenLayout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 588);
            this.Controls.Add(this.OpenLayout);
            this.Controls.Add(this.FileChosen);
            this.Controls.Add(this.CoolantTemp);
            this.Controls.Add(this.EngineLoad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RPMLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.BaudLabel);
            this.Controls.Add(this.ComPortLabel);
            this.Controls.Add(this.ComPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComPort;
        private System.Windows.Forms.Label ComPortLabel;
        private System.Windows.Forms.Label BaudLabel;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label RPMLabel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label EngineLoad;
        public System.Windows.Forms.Label CoolantTemp;
        private System.Windows.Forms.Label FileChosen;
        private System.Windows.Forms.Button OpenLayout;
    }
}

