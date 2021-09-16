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
        Acceleration acceleration = new Acceleration();
        List<StateMachineTesterHistory> stateMachineTesterHistories = new List<StateMachineTesterHistory>();
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

            stateMachineTesterHistories.Add(new StateMachineTesterHistory(acceleration, AccelerationHandler.getGestureState(acceleration)));
        }

        private void timer_tick(object sender, EventArgs e)
        {
            dataHistory.Clear();
            foreach (StateMachineTesterHistory stateMachineTesterHistory in stateMachineTesterHistories) {
                dataHistory.AppendText(stateMachineTesterHistory.ToString());
            }
            
        }
    }
}
