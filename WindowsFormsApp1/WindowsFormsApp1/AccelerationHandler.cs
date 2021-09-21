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
            int xthreshold = 150;
            int ythreshold = 150;
            int zthreshold = 200;
            int pointsToBreak = 30;

            GestureState currentState = GestureState.Null;
            int numPointsAfterEnteringState = 0;


            foreach (Acceleration acceleration in accelerationsQueue.ToList())
            {
                if (numPointsAfterEnteringState > pointsToBreak)
                {
                    if (currentState == GestureState.X || currentState == GestureState.ZX || currentState == GestureState.XYZ)
                    {
                        return currentState;
                    }
                    else {
                        return GestureState.Null;
                    }
                }

                if (currentState == GestureState.Null)
                {
                    if (acceleration.AxValue > xthreshold)
                    {
                        currentState = GestureState.X;
                        numPointsAfterEnteringState = 0;
                    }
                    else if (acceleration.AzValue > zthreshold)
                    {
                        currentState = GestureState.Z;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.Z)
                {
                    if (acceleration.AxValue > xthreshold)
                    {
                        currentState = GestureState.ZX;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.X)
                {

                    if (acceleration.AyValue > ythreshold)
                    {
                        currentState = GestureState.XY;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.XY)
                {
                    if (acceleration.AzValue > zthreshold)
                    {
                        currentState = GestureState.XYZ;
                        numPointsAfterEnteringState = 0;
                    }

                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }
            }
            return currentState;
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
