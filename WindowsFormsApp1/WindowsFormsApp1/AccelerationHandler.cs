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

        public static String getOrientationDisplayed(Acceleration acceleration)
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

        public static GestureState getGestureStateQueue(FixedSizedQueue<Acceleration> accelerationsQueue)
        {
            if (accelerationsQueue.Count < accelerationsQueue.Size)
            {
                return GestureState.Waiting;
            }
            int maxAx = 0;
            int maxAy = 0;
            int maxAz = 0;
            int num_points_to_expand = 5;
            int exceed_threshold = 180;
            List<Acceleration> accelerations = accelerationsQueue.ToList();
            int firstIndexXExceed = accelerations.FindIndex(a => a.AxValue >= 150);
            if (firstIndexXExceed == -1)
            {
                return GestureState.Waiting;
            }

            if (firstIndexXExceed + num_points_to_expand > accelerationsQueue.Size ||
                firstIndexXExceed - num_points_to_expand < 0)
            {
                return GestureState.Waiting;
            }

            else
            {
                maxAx = accelerations[firstIndexXExceed].AxValue;
                foreach (Acceleration acceleration in accelerations.Skip(firstIndexXExceed - num_points_to_expand).Take(2 * num_points_to_expand + 1))
                {
                    maxAy = Math.Max(maxAy, acceleration.AyValue);
                    maxAz = Math.Max(maxAz, acceleration.AzValue);
                }
            }

            if (maxAx > exceed_threshold && maxAy > exceed_threshold && maxAz > exceed_threshold)
            {
                return GestureState.RightHookXYZ;
            }
            else if (maxAx > exceed_threshold && maxAz > exceed_threshold)
            {
                return GestureState.HighPunchZX;
            }
            else if (maxAx > exceed_threshold)
            {
                return GestureState.SimplePunchX;
            }
            else
            {
                return GestureState.Waiting;
            }

        }

        public static GestureState getGestureState(Acceleration acceleration)
        {
            int threshHold = 190;

            if (acceleration.AxValue > threshHold && acceleration.AyValue > threshHold && acceleration.AzValue > threshHold)
            {
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
