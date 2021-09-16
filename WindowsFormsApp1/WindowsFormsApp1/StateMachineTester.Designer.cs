
namespace WindowsFormsApp1
{
    partial class StateMachineTester
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
            this.Ay = new System.Windows.Forms.Label();
            this.ProcessNewDataPoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AyTxtBox = new System.Windows.Forms.TextBox();
            this.AxTxtBox = new System.Windows.Forms.TextBox();
            this.AzTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.currentStateTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataHistory = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Ay
            // 
            this.Ay.AutoSize = true;
            this.Ay.Location = new System.Drawing.Point(12, 9);
            this.Ay.Name = "Ay";
            this.Ay.Size = new System.Drawing.Size(26, 20);
            this.Ay.TabIndex = 1;
            this.Ay.Text = "Ax";
            // 
            // ProcessNewDataPoint
            // 
            this.ProcessNewDataPoint.Location = new System.Drawing.Point(91, 85);
            this.ProcessNewDataPoint.Name = "ProcessNewDataPoint";
            this.ProcessNewDataPoint.Size = new System.Drawing.Size(264, 29);
            this.ProcessNewDataPoint.TabIndex = 3;
            this.ProcessNewDataPoint.Text = "Process New Data Point";
            this.ProcessNewDataPoint.UseVisualStyleBackColor = true;
            this.ProcessNewDataPoint.Click += new System.EventHandler(this.ProcessNewDataPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Az";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ay";
            // 
            // AyTxtBox
            // 
            this.AyTxtBox.Location = new System.Drawing.Point(145, 15);
            this.AyTxtBox.Name = "AyTxtBox";
            this.AyTxtBox.Size = new System.Drawing.Size(69, 27);
            this.AyTxtBox.TabIndex = 6;
            // 
            // AxTxtBox
            // 
            this.AxTxtBox.Location = new System.Drawing.Point(44, 12);
            this.AxTxtBox.Name = "AxTxtBox";
            this.AxTxtBox.Size = new System.Drawing.Size(55, 27);
            this.AxTxtBox.TabIndex = 7;
            // 
            // AzTxtBox
            // 
            this.AzTxtBox.Location = new System.Drawing.Point(267, 15);
            this.AzTxtBox.Name = "AzTxtBox";
            this.AzTxtBox.Size = new System.Drawing.Size(125, 27);
            this.AzTxtBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "CurrentState";
            // 
            // currentStateTxtBox
            // 
            this.currentStateTxtBox.Location = new System.Drawing.Point(330, 140);
            this.currentStateTxtBox.Name = "currentStateTxtBox";
            this.currentStateTxtBox.Size = new System.Drawing.Size(141, 27);
            this.currentStateTxtBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data History";
            // 
            // dataHistory
            // 
            this.dataHistory.Location = new System.Drawing.Point(27, 244);
            this.dataHistory.Multiline = true;
            this.dataHistory.Name = "dataHistory";
            this.dataHistory.Size = new System.Drawing.Size(365, 194);
            this.dataHistory.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer_tick);
            // 
            // StateMachineTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataHistory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentStateTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AzTxtBox);
            this.Controls.Add(this.AxTxtBox);
            this.Controls.Add(this.AyTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcessNewDataPoint);
            this.Controls.Add(this.Ay);
            this.Name = "StateMachineTester";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.StateMachineTester_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ay;
        private System.Windows.Forms.Button ProcessNewDataPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AyTxtBox;
        private System.Windows.Forms.TextBox AxTxtBox;
        private System.Windows.Forms.TextBox AzTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currentStateTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataHistory;
        private System.Windows.Forms.Timer timer1;
    }
}