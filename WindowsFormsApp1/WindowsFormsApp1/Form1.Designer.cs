namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.itemsInQueueTxtBox = new System.Windows.Forms.TextBox();
            this.openPort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tempStringLenTxtBox = new System.Windows.Forms.TextBox();
            this.serialBytesToReadTxtBox = new System.Windows.Forms.TextBox();
            this.serialDataStringLabel = new System.Windows.Forms.Label();
            this.serialDataStringTxtBox = new System.Windows.Forms.TextBox();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.displayContentTimer = new System.Windows.Forms.Timer(this.components);
            this.debugTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AxTxtBox = new System.Windows.Forms.TextBox();
            this.AzTxtBox = new System.Windows.Forms.TextBox();
            this.AyTxtBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orientationTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "serial bytes to read";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // itemsInQueueTxtBox
            // 
            this.itemsInQueueTxtBox.Location = new System.Drawing.Point(171, 172);
            this.itemsInQueueTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemsInQueueTxtBox.Name = "itemsInQueueTxtBox";
            this.itemsInQueueTxtBox.Size = new System.Drawing.Size(114, 27);
            this.itemsInQueueTxtBox.TabIndex = 1;
            // 
            // openPort
            // 
            this.openPort.Location = new System.Drawing.Point(171, 16);
            this.openPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openPort.Name = "openPort";
            this.openPort.Size = new System.Drawing.Size(86, 31);
            this.openPort.TabIndex = 2;
            this.openPort.Text = "open port";
            this.openPort.UseVisualStyleBackColor = true;
            this.openPort.Click += new System.EventHandler(this.openPort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "temp string length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "items in queue";
            // 
            // tempStringLenTxtBox
            // 
            this.tempStringLenTxtBox.Location = new System.Drawing.Point(171, 133);
            this.tempStringLenTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tempStringLenTxtBox.Name = "tempStringLenTxtBox";
            this.tempStringLenTxtBox.Size = new System.Drawing.Size(114, 27);
            this.tempStringLenTxtBox.TabIndex = 1;
            // 
            // serialBytesToReadTxtBox
            // 
            this.serialBytesToReadTxtBox.Location = new System.Drawing.Point(171, 95);
            this.serialBytesToReadTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialBytesToReadTxtBox.Name = "serialBytesToReadTxtBox";
            this.serialBytesToReadTxtBox.Size = new System.Drawing.Size(114, 27);
            this.serialBytesToReadTxtBox.TabIndex = 1;
            // 
            // serialDataStringLabel
            // 
            this.serialDataStringLabel.AutoSize = true;
            this.serialDataStringLabel.Location = new System.Drawing.Point(13, 236);
            this.serialDataStringLabel.Name = "serialDataStringLabel";
            this.serialDataStringLabel.Size = new System.Drawing.Size(151, 20);
            this.serialDataStringLabel.TabIndex = 0;
            this.serialDataStringLabel.Text = "serialDataStringLabel";
            // 
            // serialDataStringTxtBox
            // 
            this.serialDataStringTxtBox.Location = new System.Drawing.Point(13, 260);
            this.serialDataStringTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialDataStringTxtBox.Multiline = true;
            this.serialDataStringTxtBox.Name = "serialDataStringTxtBox";
            this.serialDataStringTxtBox.Size = new System.Drawing.Size(236, 249);
            this.serialDataStringTxtBox.TabIndex = 1;
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(26, 17);
            this.comboBoxCOMPorts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(138, 28);
            this.comboBoxCOMPorts.TabIndex = 3;
            // 
            // displayContentTimer
            // 
            this.displayContentTimer.Tick += new System.EventHandler(this.displayContentTimer_tick);
            // 
            // debugTxtBox
            // 
            this.debugTxtBox.Location = new System.Drawing.Point(488, 95);
            this.debugTxtBox.Multiline = true;
            this.debugTxtBox.Name = "debugTxtBox";
            this.debugTxtBox.Size = new System.Drawing.Size(422, 332);
            this.debugTxtBox.TabIndex = 4;
            this.debugTxtBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 530);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Az";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ay";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ax";
            // 
            // AxTxtBox
            // 
            this.AxTxtBox.Location = new System.Drawing.Point(58, 528);
            this.AxTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AxTxtBox.Name = "AxTxtBox";
            this.AxTxtBox.Size = new System.Drawing.Size(57, 27);
            this.AxTxtBox.TabIndex = 1;
            // 
            // AzTxtBox
            // 
            this.AzTxtBox.Location = new System.Drawing.Point(361, 523);
            this.AzTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AzTxtBox.Name = "AzTxtBox";
            this.AzTxtBox.Size = new System.Drawing.Size(57, 27);
            this.AzTxtBox.TabIndex = 1;
            // 
            // AyTxtBox
            // 
            this.AyTxtBox.Location = new System.Drawing.Point(228, 523);
            this.AyTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AyTxtBox.Name = "AyTxtBox";
            this.AyTxtBox.Size = new System.Drawing.Size(57, 27);
            this.AyTxtBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // orientationTxtBox
            // 
            this.orientationTxtBox.Location = new System.Drawing.Point(511, 527);
            this.orientationTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.orientationTxtBox.Name = "orientationTxtBox";
            this.orientationTxtBox.Size = new System.Drawing.Size(114, 27);
            this.orientationTxtBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 568);
            this.Controls.Add(this.orientationTxtBox);
            this.Controls.Add(this.AyTxtBox);
            this.Controls.Add(this.AzTxtBox);
            this.Controls.Add(this.AxTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.debugTxtBox);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.serialDataStringTxtBox);
            this.Controls.Add(this.serialDataStringLabel);
            this.Controls.Add(this.serialBytesToReadTxtBox);
            this.Controls.Add(this.tempStringLenTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openPort);
            this.Controls.Add(this.itemsInQueueTxtBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.doWhenLoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemsInQueueTxtBox;
        private System.Windows.Forms.Button openPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tempStringLenTxtBox;
        private System.Windows.Forms.TextBox serialBytesToReadTxtBox;
        private System.Windows.Forms.Label serialDataStringLabel;
        private System.Windows.Forms.TextBox serialDataStringTxtBox;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Timer displayContentTimer;
        private System.Windows.Forms.TextBox debugTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AxTxtBox;
        private System.Windows.Forms.TextBox AzTxtBox;
        private System.Windows.Forms.TextBox AyTxtBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox orientationTxtBox;
    }
}

