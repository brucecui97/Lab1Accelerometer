using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public enum GestureState
    {
        negativeZ,
        negativeZPositiveX,
        positiveZ,
        positiveZPositiveY,
        positiveZPositiveYNegativeY,
        positiveY,
        negativeY,
        X,
        Z,
        ZX,
        XY,
        XYZ,
        Null,
        SimplePunchX,
        HighPunchZX,
        RightHookXYZ,
        Waiting,
    }
}
