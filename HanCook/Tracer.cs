using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace HanCook
{
    class Tracer
    {
        // This class is only used to demonstrate non static classes
        // Pelle Hänel

        /* the hash is setting the coords, if a coorfinate is already used,
        */
        public string Passphrase { get; set; }

        private byte[] Hash { get; set; }
        public byte[,] CoordsList { get; set; }
        public int[,] Coords { get; set; }
        public Tracer()
        {
            this.Passphrase = Passphrase;
            this.Hash = C();
            this.Coords = CoordMaker();
        }

        private byte[] C()
        {
            SHA1 sha = SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(this.Passphrase);
            byte[] hash = sha.ComputeHash(inputBytes);
            return hash;
        }
        private int[,] CoordMaker()
        {
            int
            for (int i = 0; i < this.Hash.Length; i++)
            {

            }
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
