using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    public class EncoderDataHandler
    {
        private static readonly Double COUNT_PER_REVOLUTION = 100;
        private static readonly Double SECONDS_BETWEEN_UART = 0.04;
        private static readonly Double SIXTY_SECONDS_PER_MINUTE = 60;

        public static Double calculateRotationalSpeedHz(EncoderData encoderData) {

            byte[] channelAByteArray =
            { (byte) encoderData.channelADiffLSB, (byte) encoderData.channelADiffMSB};
            double channelADiffCount = BitConverter.ToUInt16(channelAByteArray, 0);

            byte[] channelBByteArray =
                { (byte) encoderData.channelBDiffLSB, (byte) encoderData.channelBDiffMSB};
            double channelBDiffCount = BitConverter.ToUInt16(channelBByteArray, 0);

            return (channelADiffCount - channelBDiffCount) * (1 / COUNT_PER_REVOLUTION) / SECONDS_BETWEEN_UART;

        }

        public static Double calculateRotationalSpeedRPM(EncoderData encoderData)
        {
            return calculateRotationalSpeedHz(encoderData)* SIXTY_SECONDS_PER_MINUTE;
        }
    }
}
