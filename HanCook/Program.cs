using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace HanCook
{
    class Program
    {
        //private bool IsInList(Byte[,] list, byte[] ToTest)
        //{
        //    bool status = false;
        //    for (int x = 0; x < list.GetLength(0); x++)
        //    {
        //        if (list[x, 0].ToString() + list[x, 1].ToString() == ToTest[0].ToString() + ToTest[1].ToString())
        //        {
        //            status = true;
        //        }
        //    }
        //    return status;
        //}
	   
	   
        static void Main(string[] args)
        {
		  //SHA1 sha = SHA1.Create();
		  //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("Test");
		  //byte[] hash = sha.ComputeHash(inputBytes);
		  Bitmap bmp = new Bitmap(100,100);

		  SHA1 sha = SHA1.Create();

		  byte[] inputBytes_X = System.Text.Encoding.ASCII.GetBytes("test");

		  byte[] X_Hash = sha.ComputeHash(inputBytes_X);
		  Console.ReadKey();
	   }
    }
}
