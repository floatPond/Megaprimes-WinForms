using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megaprimes_WinForms
{
    internal class Megaprimes
    {
        /// <summary>
        /// Pre-determined array of single-digit non-prime numbers
        /// </summary>
        private static uint[] arrayNonPrime = new uint[] { 0, 1, 4, 6, 8, 9 };

        public static List<uint> ReturnMegaprimesList(uint maxnumber)
        {
            List<uint> listMegaprimes = new List<uint>();

            for (uint i = 0; i < maxnumber; i++)
            {
                if (IsMegaprime(i))
                {
                    listMegaprimes.Add(i);
                }
            }

            return listMegaprimes;
        }

        /// <summary>
        /// Contains both prime and mega prime checking
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMegaprime(uint input)
        {
            //Ensures input is great than, not divisible by 2, and whether it is a 2
            if (input < 2 || input % 2 == 0)
            {
                return (input == 2);
            }

            //Checks if number is greater than, and not divisible by 5
            //Reduces calculating all by 3-4 seconds (for max uint)
            if (input % 5 == 0)
            {
                return (input == 5);
            }

            foreach (char c in input.ToString())
            {
                foreach (uint prime in arrayNonPrime)
                {
                    if (prime == c - '0')
                    {
                        return false;
                    }
                }
            }

            //Checks if input is divisible by odd numbers up to its square-root
            uint root = (uint)Math.Sqrt((double)input);
            for (uint i = 3; i <= root; i += 2)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
