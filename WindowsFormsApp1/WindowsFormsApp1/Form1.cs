using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort("portNameNotSet", 9600, Parity.None, 8, StopBits.One);
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        AccelerationAxis nextAccelerationAxis = AccelerationAxis.Unknown;
        Acceleration acceleration = new Acceleration();
        FixedSizedQueue<Acceleration> accelerationsHistory = new FixedSizedQueue<Acceleration>(50);
        String serialDataString = "";

        public Form1()
        {
            InitializeComponent();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(
                    object sender,
                    SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                ThreadHelperClass.SetText(this, serialBytesToReadTxtBox, serialPort1.BytesToRead.ToString());
                int newByte = serialPort1.ReadByte();
                AssignToAccelerationAxis(newByte);
                ThreadHelperClass.SetText(this, orientationTxtBox, AccelerationHandler.getOrientationDisplayed(acceleration));
                AccelerationHandler.writeAccelerationToFile(acceleration, selectFileNameTxtBox.Text);
                dataQueue.Enqueue(newByte);

                accelerationsHistory.Enqueue(new Acceleration(acceleration));
                if (AccelerationHandler.getGestureStateQueue(accelerationsHistory) != GestureState.Waiting)
                {
                    MessageBox.Show(AccelerationHandler.getGestureStateQueue(accelerationsHistory).ToString());
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    accelerationsHistory.Clear();
                }
                serialDataString = serialDataString + "," + newByte.ToString();
                bytesToRead = serialPort1.BytesToRead;
            }

        }
        private void doWhenLoadForm(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }



        private void openPort_Click(object sender, EventArgs e)
        {
            debugTxtBox.AppendText("clicked open port");
            serialPort1.PortName = comboBoxCOMPorts.Text;
            serialPort1.Open();
            serialPort1.Write("A");
            displayContentTimer.Enabled = true;
            debugTxtBox.AppendText("enabled timer");
        }

        private void displayContentTimer_tick(object sender, EventArgs e)
        {
            debugTxtBox.AppendText("triggered Timer event");
            if (serialPort1.IsOpen)
            {
                serialBytesToReadTxtBox.Text = serialPort1.BytesToRead.ToString();
                itemsInQueueTxtBox.Text = dataQueue.Count.ToString();
                while (!dataQueue.IsEmpty)
                {
                    if (dataQueue.TryDequeue(out int dequeueResult))
                    {
                        serialDataStringTxtBox.AppendText(dequeueResult.ToString() + ",");
                    }
                }
                tempStringLenTxtBox.Text = serialDataString.Length.ToString();
                serialDataString = "";
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
                acceleration.AxValue = newByte;
                ThreadHelperClass.SetText(this, AxTxtBox, acceleration.AxValue.ToString());
                nextAccelerationAxis = AccelerationAxis.Ay;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Ay)
            {
                acceleration.AyValue = newByte;
                ThreadHelperClass.SetText(this, AyTxtBox, acceleration.AyValue.ToString());
                nextAccelerationAxis = AccelerationAxis.Az;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Az)
            {
                acceleration.AzValue = newByte;
                ThreadHelperClass.SetText(this, AzTxtBox, acceleration.AzValue.ToString());
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

        private void closePortClick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectFileNameTxtBox.Text = saveFileDialog1.FileName;
            }
        }
    }
}
