using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanCook
{
    public class Coord
    {
	   public Byte[] X { get; private set; }
	   public Byte[] Y { get; private set; }

	   private int[] RMlist = null;

	   public Coord()
	   {
		  this.X = X;
		  this.Y = Y;
	   }

	   public void AddToRemove(int index /*call rm() next*/)    // We arent in C, so no dynamic memory access
	   {
		  this.X[index] = 0;
		  this.Y[index] = 0;
	   }
	   public void rm()
    }
