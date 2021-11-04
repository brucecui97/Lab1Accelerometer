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
        EncoderValues nextAccelerationAxis = EncoderValues.Unknown;
        Acceleration acceleration = new Acceleration();

       

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
                processEncoderStream(newByte);
                //ThreadHelperClass.SetText(this, orientationTxtBox, EncoderHandler.getOrientationDisplayed(acceleration));
                //EncoderHandler.writeAccelerationToFile(acceleration, selectFileNameTxtBox.Text);
                dataQueue.Enqueue(newByte);

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

        private void processEncoderStream(int newByte)
        {
            //if (nextAccelerationAxis == EncoderValues.Unknown)
            //{
            //    if (newByte == 255)
            //    {
            //        //nextAccelerationAxis = EncoderValues.ChannelAMSB;
            //    }
            //}
            //else if (nextAccelerationAxis == EncoderValues.ChannelAMSB)
            //{

            //    //ThreadHelperClass.SetText(this, AxTxtBox, acceleration.AxValue.ToString());
            //    //nextAccelerationAxis = EncoderValues.Ay;
            //}

            //else if (nextAccelerationAxis == EncoderValues.Ay)
            //{
            //    acceleration.AyValue = newByte;
            //    ThreadHelperClass.SetText(this, AyTxtBox, acceleration.AyValue.ToString());
            //    nextAccelerationAxis = EncoderValues.Az;
            //}

            //else if (nextAccelerationAxis == EncoderValues.Az)
            //{
            //    acceleration.AzValue = newByte;
            //    ThreadHelperClass.SetText(this, AzTxtBox, acceleration.AzValue.ToString());
            //    nextAccelerationAxis = EncoderValues.Unknown;
            //}
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
    }
}
