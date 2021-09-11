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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(488, 95);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 332);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 525);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

