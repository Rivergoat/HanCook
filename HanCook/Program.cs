﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HanCook
{
    class Program
    {
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
	   Coord test = new Coord();
	   testc.
        static void Main(string[] args)
        {
            SHA1 sha = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("Test");
            byte[] hash = sha.ComputeHash(inputBytes);
            Console.ReadKey();
        }
    }
}
