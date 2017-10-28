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

        private bool IsInList(Byte[,] list, byte[] ToTest)
        {
            bool status = false;
            for (int x = 0; x < list.GetLength(0); x++)
            {
                if (list[x, 0].ToString() + list[x, 1].ToString() == ToTest[0].ToString() + ToTest[1].ToString())
                {
                    status = true;
                }
            }
            return status;
        }
    }
}
