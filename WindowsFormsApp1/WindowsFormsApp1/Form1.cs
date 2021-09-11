using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort("defaultPortName", 9600, Parity.None, 8, StopBits.One);
        String serialDataString = "";
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doWhenLoadForm(object sender, EventArgs e)
        {
            serialPort.PortName = "COM1";
        }

        private void openPort_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            serialPort.Write("A");

            int newByte = 0;
            int bytesToRead = serialPort.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort.ReadByte();
                serialDataString = serialDataString + newByte.ToString() + ", ";
                bytesToRead = serialPort.BytesToRead;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialBytesToReadTxtBox.Text = serialPort.BytesToRead.ToString();
                tempStringLenTxtBox.Text = serialDataString.Length.ToString();
                serialDataStringTxtBox.AppendText(serialDataString);
                serialDataString = "";
            }
        }
    }
}
