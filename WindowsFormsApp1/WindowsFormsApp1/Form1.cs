using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
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
        Acceleration acceleration = new Acceleration();
        private static readonly int NEUTRAL_ACCELERATION_VAL = 126;

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
            if (serialPort1.IsOpen)
            {
                int bytesToRead = serialPort1.BytesToRead;
                while (bytesToRead != 0)
                {
                    serialBytesToReadTxtBox.Text = serialPort1.BytesToRead.ToString();

                    int newByte = serialPort1.ReadByte();
                    AssignToAccelerationAxis(newByte);
                    updateOrientationDisplayed();
                    writeAccelerationToFile();
                    dataQueue.Enqueue(newByte);

                    bytesToRead = serialPort1.BytesToRead;
                }


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
                AxTxtBox.Text = acceleration.AxValue.ToString();
                nextAccelerationAxis = AccelerationAxis.Ay;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Ay)
            {
                acceleration.AyValue = newByte;
                AyTxtBox.Text = acceleration.AyValue.ToString();
                nextAccelerationAxis = AccelerationAxis.Az;
            }

            else if (nextAccelerationAxis == AccelerationAxis.Az)
            {
                acceleration.AzValue = newByte;
                AzTxtBox.Text = acceleration.AzValue.ToString();
                nextAccelerationAxis = AccelerationAxis.Unknown;
            }
        }

        private void updateOrientationDisplayed()
        {
            int AxDiffWithNeutral = acceleration.AxValue - NEUTRAL_ACCELERATION_VAL;
            int AyDiffWithNeutral = acceleration.AyValue - NEUTRAL_ACCELERATION_VAL;
            int AzDiffWIthNeutral = acceleration.AzValue - NEUTRAL_ACCELERATION_VAL;

            var diffs = new List<int> {
                Math.Abs(AxDiffWithNeutral),
                Math.Abs(AyDiffWithNeutral),
                Math.Abs(AzDiffWIthNeutral) };

            if (Math.Abs(AxDiffWithNeutral) == diffs.Max())
            {
                orientationTxtBox.Text = Math.Sign(AxDiffWithNeutral).ToString() + "X";
            }
            else if (Math.Abs(AyDiffWithNeutral) == diffs.Max())
            {
                orientationTxtBox.Text = Math.Sign(AyDiffWithNeutral).ToString() + "Y";
            }
            else
            {
                orientationTxtBox.Text = Math.Sign(AzDiffWIthNeutral).ToString() + "Z";
            }
        }

        private void writeAccelerationToFile()
        {
            // Set a variable to the Documents path.
            string docPath = System.AppContext.BaseDirectory;

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.csv"), append: true))
            {
                DateTime timeNow = DateTime.Now;
                outputFile.WriteLine(acceleration.ToString() + "," + "readable: " + timeNow.ToString("MM/dd/yyyy HH:mm:ss.fff"));
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
    }
}
