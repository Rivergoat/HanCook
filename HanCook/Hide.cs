using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;


namespace HanCook
{
    public class Coord
    {
	   public Byte[] X { get; set; }
	   public Byte[] Y { get; set; }

	   public Coord()
	   {
		  this.X = X;
		  this.Y = Y;
	   }

	   public void AddRemove(int index /*call rm() next*/)	// We arent in C, so no dynamic memory access
	   {
		  this.X[index] = 0;
		  this.Y[index] = 0;
		  this.
		  
		  }
	   }
	   
    }
    public static class Hide
    {
        /*
	    
	    ********************************************************************************
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
         ********************************************************************************
         
         ****************************************
         *~	~	~   The Golden	  ~	  ~	  ~*
         *			 TODOs			   *
         *	===========================	   *
         *   0. Seperation	into chunks	   *
         *   1. Key Update non-backchaineable   *
         ****************************************
	    
	    */
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

	   public static Bitmap GenerateNoise(this Bitmap bmp, int density, int strength=6)
	   {
		  strength = ((bmp.Width * bmp.Height) / 255) * strength;
		  Random change = new Random();
		  Random X_Value = new Random(64);
		  Random y_value = new Random(256);

		  for (int i = 0; i < strength; i++)
		  {
			 Color pixelcolor = bmp.GetPixel(x, y);

			 int nr = pixelcolor.R + change.Next(strength); int ng = pixelcolor.G + change.Next(strength); int nb = pixelcolor.B + change.Next(strength);

			 if (nr > 254) nr = 255;
			 if (ng > 254) ng = 255;
			 if (nb > 254) nb = 255;

			 Color newcolor = Color.FromArgb(nr, ng, nb);
			 bmp.SetPixel(X_Value.Next(19), y_value.Next(15),newcolor);

		  }
		  return null;
	   }

	   public static byte[,] GenerateInitialCoordPair(string Passphrase)
	   {
		  /****************************************************
		   * Hash-algorithm is Secure Hash Algrotithm 1
		   *				   (NSA)
		   *				   
		   *	Passphrase length minimum is 14 characters
		   *	
		   *	|0|1|2|3|4|5|6|7|8|9|	Passphrase is divided
		   *	|T|e|s|t|T|e|s|t|F|i|	into two strings, each
		   *	|   |   |   |   |   |	consisting of every
		   *	|X|Y|X|Y|X|Y|X|Y|X|Y|	second char. (+1)
		   *	
		   * **************************************************/

		  string X_Pass = null;
		  string Y_Pass = null;

		  for (int i = 0; i < Passphrase.Length; i += 2)	//seperate 
		  {
			 X_Pass += Passphrase[i];
			 Y_Pass += Passphrase[i + 1];
		  }
		  SHA1 sha = SHA1.Create();

		  byte[] inputBytes_X = System.Text.Encoding.ASCII.GetBytes(X_Pass);
		  byte[] inputBytes_Y = System.Text.Encoding.ASCII.GetBytes(Y_Pass);

		  byte[] X_Hash = sha.ComputeHash(inputBytes_X);
		  byte[] Y_Hash = sha.ComputeHash(inputBytes_Y);

		  byte[,] Returneable = new byte[X_Pass.Length, 2];
		  for (int i = 0; i < X_Hash.Length; i += 2)
		  {
			 Returneable[i, 0] = X_Hash[i / 2];
			 Returneable[i, 1] = Y_Hash[i / 2];
		  }

		  return Returneable;
	   }
	   
	   public static 
    }
}
