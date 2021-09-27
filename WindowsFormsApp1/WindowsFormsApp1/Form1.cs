using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class shouldDetectGestureChckBox : Form
    {
        private static readonly int NUM_ACCELERATION_HISTORY_TO_STD = 100;
        private static readonly int NUM_ACCELERATION_HISTORY_TO_MAX = 500;
        SerialPort serialPort1 = new SerialPort("portNameNotSet", 9600, Parity.None, 8, StopBits.One);
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        AccelerationAxis nextAccelerationAxis = AccelerationAxis.Unknown;
        Acceleration acceleration = new Acceleration();
        FixedSizedQueue<Acceleration> accelerationsHistory = new FixedSizedQueue<Acceleration>(100);
        FixedSizedQueue<double> xAccelerationHistory = new FixedSizedQueue<double>(NUM_ACCELERATION_HISTORY_TO_MAX);
        FixedSizedQueue<double> yAccelerationHistory = new FixedSizedQueue<double>(NUM_ACCELERATION_HISTORY_TO_MAX);
        FixedSizedQueue<double> zAccelerationHistory = new FixedSizedQueue<double>(NUM_ACCELERATION_HISTORY_TO_MAX);


        String serialDataString = "";

        public shouldDetectGestureChckBox()
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

                xAccelerationHistory.Enqueue(AccelerationHandler.convertToG(acceleration.AxValue));
                yAccelerationHistory.Enqueue(AccelerationHandler.convertToG(acceleration.AyValue));
                zAccelerationHistory.Enqueue(AccelerationHandler.convertToG(acceleration.AzValue));
                displayMaxAcc(xAccelerationHistory, yAccelerationHistory, zAccelerationHistory);

                accelerationsHistory.Enqueue(new Acceleration(acceleration));
                GestureState gestureStateDetected = AccelerationHandler.getGestureStateQueue(accelerationsHistory);

                if (enableGestureDetectionBox.Checked)
                {
                    if (gestureStateDetected != GestureState.Null)
                    {
                        ThreadHelperClass.SetText(this, stateDetectedTxtBox, gestureStateDetected.ToString());
                        Thread.Sleep(1000);
                        ThreadHelperClass.SetText(this, stateDetectedTxtBox, "");

                        serialPort1.DiscardInBuffer();
                        serialPort1.DiscardOutBuffer();
                        accelerationsHistory.Clear();
                        nextAccelerationAxis = AccelerationAxis.Unknown;
                    }
                    serialDataString = serialDataString + "," + newByte.ToString();
                    bytesToRead = serialPort1.BytesToRead;
                }
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

        private void displayMaxAcc(FixedSizedQueue<double> xAccelerations, FixedSizedQueue<double> yAccelerations, FixedSizedQueue<double> zAccelerations) {

            if (xAccelerationHistory.Count > NUM_ACCELERATION_HISTORY_TO_STD) { 
                List<double> xAcclerationsToStd = xAccelerations.Skip(Math.Max(0, xAccelerations.Count() - NUM_ACCELERATION_HISTORY_TO_STD)).ToList();
                ThreadHelperClass.SetText(this, stdXtxtBox, AccelerationHandler.getStandardDeviation(xAcclerationsToStd).ToString());
            }

            if (yAccelerationHistory.Count > NUM_ACCELERATION_HISTORY_TO_STD)
            {
                List<double> yAcclerationsToStd = yAccelerations.Skip(Math.Max(0, yAccelerations.Count() - NUM_ACCELERATION_HISTORY_TO_STD)).ToList();
                ThreadHelperClass.SetText(this, stdYTxtBox, AccelerationHandler.getStandardDeviation(yAcclerationsToStd).ToString());
            }

            if (yAccelerationHistory.Count > NUM_ACCELERATION_HISTORY_TO_STD)
            {
                List<double> zAcclerationsToStd = yAccelerations.Skip(Math.Max(0, zAccelerations.Count() - NUM_ACCELERATION_HISTORY_TO_STD)).ToList();
                ThreadHelperClass.SetText(this, stdZTxtBox, AccelerationHandler.getStandardDeviation(zAcclerationsToStd).ToString());
            }

            if (xAccelerationHistory.Count == NUM_ACCELERATION_HISTORY_TO_MAX) {
                ThreadHelperClass.SetText(this, AxMaxTxtBox, xAccelerationHistory.ToList().Max().ToString());
            }

            if (yAccelerationHistory.Count == NUM_ACCELERATION_HISTORY_TO_MAX)
            {
                ThreadHelperClass.SetText(this, AyMaxTxtBox, yAccelerationHistory.ToList().Max().ToString());
            }

            if (zAccelerationHistory.Count == NUM_ACCELERATION_HISTORY_TO_MAX)
            {
                ThreadHelperClass.SetText(this, AzMaxTxtBox, zAccelerationHistory.ToList().Max().ToString());
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
