using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort("portNameNotSet", 9600, Parity.None, 8, StopBits.One);
        String serialDataString = "";
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();

        public Form1()
        {
            InitializeComponent();
        }

        private void doWhenLoadForm(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;

            serialPort1.PortName = comboBoxCOMPorts.Text;
        }

        private void openPort_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.Write("A");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //serialPort.Write("A");
            int bytesToRead = serialPort1.BytesToRead;
            debugTxtBox.AppendText("triggered Timer event");
            while (bytesToRead != 0)
            {
                int newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
                //MessageBox.Show("read stuff");
            }

            if (serialPort1.IsOpen)
            {
                //MessageBox.Show("serial port open");
                serialBytesToReadTxtBox.Text = serialPort1.BytesToRead.ToString();
                tempStringLenTxtBox.Text = dataQueue.Count.ToString();
                while (!dataQueue.IsEmpty) {

                    int dequeueResult;
                    if (dataQueue.TryDequeue(out dequeueResult)) {
                        serialDataStringTxtBox.AppendText(dequeueResult.ToString() + ",");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
