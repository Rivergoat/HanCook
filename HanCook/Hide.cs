using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;


namespace HanCook
{
    public static class Hide
    {
        /********************************************************************************
         *                  How to write ImageMapping file                              *
         *      Two hashes are calculated, one for X values and one for Y               *
         *      *       *       *       *       *       *       *       *       *       *
         *      Ploblem 1: Coordinate Collision, -unlikely, but present                 *
         *      Problem 2: Linear Matrix (To avoid collisions) search is                *
         *          computational Expensive                                             *
         *                                                                              *
         *      Seperate the image into part with a size of 100x100 and calculate hi-   *
         *      ding hashes for each segment                                            *
         *                                                                              *
         *      look up how many letters go in each quadrant. Seperate this             *
         *                                                                              *
         *      ALSO TODO:  Generate artificial Image noise                             *
         *      FIXME:  Save as png file                                                *      
         *                                                                              *
         ********************************************************************************/
         
        /****************************************
         *		   The Golden			   *
         *			TODOs			   *
         *							   *
         *   0. Seperation	into chunks	   *
         *   1. Key Update non-backchaineable   *
         ****************************************/

        public static Bitmap GenerateArtificialNoise(this Bitmap bmp, int density ,int strength = 6)
        {
            int y = 0;
            int x = 0;
            Random step = new Random();
            Random change = new Random();

            while (y < bmp.Height)
            {
                while (x < bmp.Width)
                {
                    Color pixelcolor = bmp.GetPixel(x, y);

                    int nr = pixelcolor.R + change.Next(strength); int ng = pixelcolor.G + change.Next(strength); int nb = pixelcolor.B + change.Next(strength);

                    if (nr > 254) nr = 255;
                    if (ng > 254) ng = 255;
                    if (nb > 254) nb = 255;

                    Color newcolor = Color.FromArgb(nr,ng,nb);
                    x += step.Next(density);
                    bmp.SetPixel(x, y, newcolor);
                }
                y++;
            }

            return null;
        }


	   public static byte[] GenerateInitialCoordPair(string Passphrase)
	   {
		  SHA1 sha = SHA1.Create();
		  byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Passphrase);
		  byte[] hash = sha.ComputeHash(inputBytes);
		  return hash;
	   } 
    }
}
