using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
// Including dependecies

namespace HanCook
{
    public static class Mapper
    {
        private static char[,] HideMap =
        {
            {'a','b','c','d','e'},
            {'f','g','h','i','j'},
            {'k','l','m','n','o'},
            {'p','q','r','s','t'},
            {'u','v','w','y','z'}
        };


        public static int[] FindInMap(char letter) //This function is used to find a specific character in our map
        {
            int[] Data = new int[2];    // Declaring a new Array with the length of two, one for
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (letter == HideMap[x, y])
                    {
                        Data[0] = x + 1;    
                        Data[1] = y + 1;
                    }
                }
            }
            return Data;
        }
        public static int[,] FindString(string ToFind)
        {
            int[,] Data = new int[ToFind.Length, 2];    //We init a new 2d array
            /*******************************
            * [X1, X2, X3, X4, X5, X6, X7]
            * [Y1, Y2, Y3, Y4, X5, X6, X7]
            *
            * This is our format for parsing later on
            * 
            ********************************/
            for (int letter = 0; letter < ToFind.Length; letter++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (ToFind[letter] == HideMap[x, y])
                        {
                            Data[letter, 0] = x + 1;
                            Data[letter, 1] = y + 1;
                        }
                    }
                }
            }
            return Data;
        }
        public static string Decrypt(int[,] Coords)
        {
            string result = null;
            for (int letter = 0; letter < Coords.Length / 2; letter++)
            {
                result += HideMap[Coords[letter, 0] - 1, Coords[letter, 1] - 1];
            }
            return result;
        }

        public static Bitmap HideCharacter(this Bitmap hidingmap, int x, int y, char character)
        {
            Bitmap local = hidingmap;
            Color oc = hidingmap.GetPixel(x, y);
            int r = oc.R; int g = oc.G; int b = oc.B;
            int rm = Nummod.RoundToLast(r); int gm = Nummod.RoundToLast(g); int bm = Nummod.RoundToLast(b);
            int[] result = FindInMap(character);
            rm += result[0]; gm += result[1];
            Color owncolor = Color.FromArgb(rm, gm, b);
            local.SetPixel(x, y, owncolor);
            return local;
        }
        //
        public static Bitmap HideLinear(this Bitmap bmp, int y, string Text)
        {
            Bitmap copybmp = bmp;
            int needed = bmp.Width / Text.Length + 1;
            int count = 0;
            for (int yn = y; yn < y + needed; yn++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    count++;
                    copybmp.HideCharacter(i, yn, Text[count]); //???
                }
            }
            return copybmp;
        }

    }
}
