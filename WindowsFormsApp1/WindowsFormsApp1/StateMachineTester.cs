using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StateMachineTester : Form
    {
        Acceleration acceleration;
        public StateMachineTester()
        {
            InitializeComponent();
        }

        private void StateMachineTester_Load(object sender, EventArgs e)
        {

        }

        private void ProcessNewDataPoint_Click(object sender, EventArgs e)
        {
            acceleration = new Acceleration(Int32.Parse(AxTxtBox.Text),
               Int32.Parse(AyTxtBox.Text),
               Int32.Parse(AzTxtBox.Text));
        }
    }
}
