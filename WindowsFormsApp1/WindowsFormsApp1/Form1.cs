using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    enum AccelerationAxis
    {
        Ax,
        Ay,
        Az,
        Unknown,
    }
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort("portNameNotSet", 9600, Parity.None, 8, StopBits.One);
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        AccelerationAxis nextAccelerationAxis = AccelerationAxis.Unknown;

        public Form1()
        {
            InitializeComponent();
        }

        private void doWhenLoadForm(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
            serialPort1.PortName = comboBoxCOMPorts.Text;
        }

        private void openPort_Click(object sender, EventArgs e)
        {
            debugTxtBox.AppendText("clicked open port");
            serialPort1.Open();
            serialPort1.Write("A");
            displayContentTimer.Enabled = true;
            debugTxtBox.AppendText("enabled timer");
        }

        private void displayContentTimer_tick(object sender, EventArgs e)
        {
            debugTxtBox.AppendText("triggered Timer event");

            int bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                serialBytesToReadTxtBox.Text = serialPort1.BytesToRead.ToString();

                int newByte = serialPort1.ReadByte();
                AssignToAccelerationAxis(newByte);
                dataQueue.Enqueue(newByte);

                bytesToRead = serialPort1.BytesToRead;
            }

            if (serialPort1.IsOpen)
            {
                serialBytesToReadTxtBox.Text = serialPort1.BytesToRead.ToString();
                tempStringLenTxtBox.Text = dataQueue.Count.ToString();
                while (!dataQueue.IsEmpty)
                {
                    if (dataQueue.TryDequeue(out int dequeueResult))
                    {
                        serialDataStringTxtBox.AppendText(dequeueResult.ToString() + ",");
                    }
                }
            }
        }

        private void AssignToAccelerationAxis(int newByte)
        {
            if (nextAccelerationAxis == AccelerationAxis.Unknown)
            {
                if (newByte == 255)
                {
                    nextAccelerationAxis = AccelerationAxis.Ax;
                }
            }
            else if (nextAccelerationAxis == AccelerationAxis.Ax)
            {
                AxTxtBox.Text = newByte.ToString();
                nextAccelerationAxis = AccelerationAxis.Ay;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Ay)
            {
                AyTxtBox.Text = newByte.ToString();
                nextAccelerationAxis = AccelerationAxis.Az;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Az)
            {
                AzTxtBox.Text = newByte.ToString();
                nextAccelerationAxis = AccelerationAxis.Unknown;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }
    }
}
