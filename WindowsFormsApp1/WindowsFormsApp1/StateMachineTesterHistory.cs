using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class StateMachineTesterHistory
    {
        public Acceleration acceleration;
        public GestureState previousState;

        public override string ToString()
        {
            return "(" + acceleration.ToString() + "," + previousState.ToString() + ")";
        }

        public StateMachineTesterHistory(Acceleration acceleration, GestureState previousState) {
            this.acceleration = acceleration;
            this.previousState = previousState;
        }
    }

 
}
