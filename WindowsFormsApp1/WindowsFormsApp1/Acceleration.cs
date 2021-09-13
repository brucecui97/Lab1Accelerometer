using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class Acceleration
    {   
        public int AxValue = 0;
        public int AyValue = 0;
        public int AzValue = 0;

        public override string ToString() {
            return AxValue.ToString() + "," + AyValue.ToString() + "," + AzValue.ToString();
        }
    }
}
