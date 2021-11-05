using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public class EncoderData
    {
        public Int32 channelADiffMSB = -1;
        public Int32 channelADiffLSB = -1;
        public Int32 channelBDiffMSB = -1;
        public Int32 channelBDiffLSB = -1;
        public EncoderData(Int32 channelADiffMSB, Int32 channelADiffLSB, Int32 channelBDiffMSB, Int32 channelBDiffLSB)
        {
            this.channelADiffMSB = channelADiffMSB;
            this.channelADiffLSB = channelADiffLSB;
            this.channelBDiffMSB = channelBDiffMSB;
            this.channelBDiffLSB = channelBDiffLSB;
        }
        public EncoderData()
        {
        }
        public override string ToString()
        {
            return channelADiffMSB.ToString() + "," + channelADiffLSB.ToString() + "," + channelBDiffMSB.ToString() + "," + channelBDiffLSB.ToString();
        }
    }
}
