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
        private static readonly int ONE_G = 154 - 126;

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

        public static double getStandardDeviation(List<double> doubles) {
            double mean = doubles.Average();
            double numPoints = doubles.Count;

            double sumOfSquares = 0;
            foreach (double val in doubles) {
                sumOfSquares = sumOfSquares + (val - mean) * (val - mean);
            }

            return Math.Sqrt(sumOfSquares/numPoints);
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

        public static double convertToG(double accelerationValue) {
            return (accelerationValue - NEUTRAL_ACCELERATION_VAL) / ONE_G;
        }

        public static GestureState getGestureStateQueue(FixedSizedQueue<Acceleration> accelerationsQueue)
        {
            int positiveXThreshold = 170;
            int positiveYthreshold = 150;
            int negativeYthreshold = 100;
            int positiveZthreshold = 200;
            int negativeZthreshold = 100;
            int pointsToBreak = 30;

            GestureState currentState = GestureState.Null;
            int numPointsAfterEnteringState = 0;


            foreach (Acceleration acceleration in accelerationsQueue.ToList())
            {
                if (numPointsAfterEnteringState > pointsToBreak)
                {
                    if (currentState == GestureState.FreeFall || currentState == GestureState.GraveDigger || currentState == GestureState.Wave)
                    {
                        return currentState;
                    }
                    else {
                        return GestureState.Null;
                    }
                }

                if (currentState == GestureState.Null)
                {
                    if (acceleration.AzValue < negativeZthreshold)
                    {
                        currentState = GestureState.FreeFall;
                        numPointsAfterEnteringState = 0;
                    }
                    else if (acceleration.AzValue > positiveZthreshold)
                    {
                        currentState = GestureState.positiveZ;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.FreeFall)
                {
                    if (acceleration.AxValue > positiveXThreshold)
                    {
                        currentState = GestureState.GraveDigger;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.positiveZ)
                {

                    if (acceleration.AyValue > positiveYthreshold)
                    {
                        currentState = GestureState.positiveZPositiveY;
                        numPointsAfterEnteringState = 0;
                    }
                    else
                    {
                        numPointsAfterEnteringState = numPointsAfterEnteringState + 1;
                    }
                }

                else if (currentState == GestureState.positiveZPositiveY)
                {
                    if (acceleration.AyValue < negativeYthreshold)
                    {
                        currentState = GestureState.Wave;
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
