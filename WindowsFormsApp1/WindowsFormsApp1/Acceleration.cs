using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public class Acceleration
    {   
        public int AxValue = 0;
        public int AyValue = 0;
        public int AzValue = 0;

        public Acceleration(int AxValue, int AyValue, int AzValue) {
            this.AxValue = AxValue;
            this.AyValue = AyValue;
            this.AzValue = AzValue;
        }

        public Acceleration() { 
        }
        public override string ToString() {
            return AxValue.ToString() + "," + AyValue.ToString() + "," + AzValue.ToString();
        }
    }
}
