using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    public class AccelerationHandler
    {
        private static readonly int NEUTRAL_ACCELERATION_VAL = 126;

        public static String getOrientationDisplayed(Acceleration acceleration) {
            int AxDiffWithNeutral = acceleration.AxValue - NEUTRAL_ACCELERATION_VAL;
            int AyDiffWithNeutral = acceleration.AyValue - NEUTRAL_ACCELERATION_VAL;
            int AzDiffWIthNeutral = acceleration.AzValue - NEUTRAL_ACCELERATION_VAL;

            var diffs = new List<int> {
                Math.Abs(AxDiffWithNeutral),
                Math.Abs(AyDiffWithNeutral),
                Math.Abs(AzDiffWIthNeutral) };

            if (Math.Abs(AxDiffWithNeutral) == diffs.Max())
            {
                return Math.Sign(AxDiffWithNeutral).ToString() + "X";
            }
            else if (Math.Abs(AyDiffWithNeutral) == diffs.Max())
            {
                return Math.Sign(AyDiffWithNeutral).ToString() + "Y";
            }
            else
            {
                return Math.Sign(AzDiffWIthNeutral).ToString() + "Z";
            }
        }

        public static void writeAccelerationToFile(Acceleration acceleration, String path)
        {

            if (path.Length > 0)
            {
                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(path, append: true))
                {
                    DateTime timeNow = DateTime.Now;
                    outputFile.WriteLine(timeNow.Ticks / TimeSpan.TicksPerMillisecond + "," + acceleration.ToString());
                }
            }
        }

        public static GestureState getGestureState(Acceleration acceleration) {
            int threshHold = 190;

            if (acceleration.AxValue > threshHold && acceleration.AyValue > threshHold && acceleration.AzValue > threshHold) {
                return GestureState.RightHookXYZ;
            }
            else if (acceleration.AxValue > threshHold && acceleration.AzValue > threshHold)
            {
                return GestureState.HighPunchZX;
            }
            else if (acceleration.AxValue > 190)
            {
                return GestureState.SimplePunchX;
            }

            return GestureState.Waiting;
        }
    }
}
