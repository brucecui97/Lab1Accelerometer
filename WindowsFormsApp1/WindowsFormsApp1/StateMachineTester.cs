using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StateMachineTester : Form
    {
        Acceleration acceleration = new Acceleration();
        List<StateMachineTesterHistory> stateMachineTesterHistories = new List<StateMachineTesterHistory>();
        FixedSizedQueue<Acceleration> fixedSizedAccelerationHistoryQueue = new FixedSizedQueue<Acceleration>(50);
        public StateMachineTester()
        {
            InitializeComponent();
            stateMachineTesterHistories.Add(new StateMachineTesterHistory(new Acceleration(), GestureState.Null));
            for (int i = 0; i < 50; i++)
            {
                fixedSizedAccelerationHistoryQueue.Enqueue(new Acceleration(126, 126, 126));
            }
        }

        private void StateMachineTester_Load(object sender, EventArgs e)
        {

        }

        private void ProcessNewDataPoint_Click(object sender, EventArgs e)
        {
            acceleration = new Acceleration(Int32.Parse(AxTxtBox.Text),
               Int32.Parse(AyTxtBox.Text),
               Int32.Parse(AzTxtBox.Text));

            GestureState currState = AccelerationHandler.getGestureState(acceleration, stateMachineTesterHistories.LastOrDefault().previousState);
            stateMachineTesterHistories.Add(new StateMachineTesterHistory(acceleration, currState));
            currentStateTxtBox.Text = currState.ToString();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            dataHistory.Clear();
            foreach (StateMachineTesterHistory stateMachineTesterHistory in stateMachineTesterHistories)
            {
                dataHistory.AppendText(stateMachineTesterHistory.ToString());
            }

        }
    }
}
