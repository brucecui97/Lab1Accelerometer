using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class StateMachineTesterHistory
    {
        public Acceleration acceleration;
        public int previousState;

        public override string ToString()
        {
            return "(" + acceleration.ToString() + "," + previousState.ToString() + ")";
        }
    }

 
}
