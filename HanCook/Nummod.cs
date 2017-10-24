using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanCook
{
    class Nummod
    {
        public static int RoundToLast(int toround)
        {
            string toruoundStr = toround.ToString();
            int soos = Int32.Parse(toruoundStr[toruoundStr.Length - 1].ToString());
            toround = toround - soos;
            return toround;
        }
    }
}
