using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Megaprimes_Console
{
    public static class PrimeNumberController
    {
        #region Variables
        /// <summary>
        /// Pre-determined array of single-digit non-prime numbers
        /// </summary>
        private static uint[] arrayNonPrime = new uint[] { 1, 4, 6, 8, 9 };

        /// <summary>
        /// Stores all of the mega primes from the threaded mega-prime acquiring
        /// Needs to use a list outside as all threads feed into it once they are finished
        /// </summary>
        private static List<uint> listMegaPrimes = new List<uint>();

        /// <summary>
        /// Used to determine how many threads are currently still running
        /// </summary>
        private static uint countRemainingThreads = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Condenced version
        /// Removes acquiring all prime numbers and then determining whether they are prime
        /// </summary>
        /// <param name="number"></param>
        public static List<uint> ReturnMegaPrimesList(uint number)
        {
            DateTime end;
            DateTime start = DateTime.Now;

            List<uint> listMegaPrimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsMegaPrime(i))
                {
                    listMegaPrimes.Add(i);
                }
            }

            end = DateTime.Now;

            TimeSpan timespan = end - start;
            Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return listMegaPrimes;
        }

        /// <summary>
        /// BRAVO but returns TimeSpan
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static TimeSpan ReturnMegaPrimesTimeSpan(uint number)
        {
            DateTime end;
            DateTime start = DateTime.Now;

            List<uint> listMegaPrimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsMegaPrime(i))
                {
                    listMegaPrimes.Add(i);
                }
            }

            end = DateTime.Now;

            TimeSpan timespan = end - start;
            Console.WriteLine(listMegaPrimes.Count);
            Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return timespan;
        }

        /// <summary>
        /// Contains both prime and mega prime checking
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMegaPrime(uint input)
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

        #endregion

        #region Old Methods

        /// <summary>
        /// Checks if the number is prime and then checks if they are megaprime
        /// Depracated due to being slower as it computes list twice
        /// </summary>
        /// <param name="number"></param>
        public static void GetMegaPrimesUpTo(uint number)
        {
            List<uint> listPrimes = new List<uint>();
            List<uint> listMegaPrimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsPrime(i))
                {
                    listPrimes.Add(i);
                }
            }

            foreach (uint prime in listPrimes)
            {
                if (ContainsOnlyMegaPrimeNumbers(prime))
                {
                    listMegaPrimes.Add(prime);
                }
            }

        }

        /// <summary>
        /// Returns whether the number is prime
        /// Inefficient for BIG primes as also checks 5 in Sqrt which takes longer for giant numbers
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(uint number)
        {
            if (number < 2)
            {
                return false;
            }

            if (number % 2 == 0)
            {
                return (number == 2);
            }

            uint root = (uint)Math.Sqrt((double)number);
            for (uint i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Contains Mega Prime checking against array
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool ContainsOnlyMegaPrimeNumbers(uint number)
        {
            foreach (char c in number.ToString())
            {
                foreach (uint prime in arrayNonPrime)
                {
                    if (prime == c - '0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region My Threading Solution
        //Threading - mine
        
        public static TimeSpan MegaPrimeFinderThreaded(uint iThreads, uint max)
        {
            
            //Reset the list and thread count
            listMegaPrimes = new List<uint>();
            countRemainingThreads = iThreads;

            DateTime end;
            DateTime start = DateTime.Now;


            uint dividedmax = max / iThreads;
            uint dividedmaxholder = dividedmax;

            uint[] workChunk = new uint[iThreads];
            List<Thread> listThreads = new List<Thread>();

            uint previous = 0;
            for (uint i = 0; i < iThreads; i++)
            {
                workChunk[i] = dividedmaxholder;
                Thread thread = CreateThread(i + 1, previous, workChunk[i]);
                listThreads.Add(thread);
                dividedmaxholder += dividedmax;
                previous = workChunk[i];
            }
            foreach (Thread t in listThreads)
            {
                t.Start();
            }
            while (true)
            {
                if (countRemainingThreads != 0)
                {
                    Thread.Yield();
                }
                else
                {
                    Console.WriteLine(listMegaPrimes.Count);
                    break;
                }
            }
            end = DateTime.Now;

            TimeSpan timespan = end - start;
            //Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return timespan;
        }

        private static Thread CreateThread(uint id, uint start, uint end)
        {
            Thread thread = new Thread(p => ThreadMegaPrimeFinder(id, start, end));
            return thread;
        }

        private static void ThreadMegaPrimeFinder(uint thread, uint min, uint max)
        {
            List<uint> localListMegaPrimes = new List<uint>();
            for (uint i = min; i <= max; i++)
            {
                if (IsMegaPrime(i))
                {
                    localListMegaPrimes.Add(i);
                }
                //Thread.Yield(); //Bad - do not do, slows it down a lot
            }
            foreach (uint i in localListMegaPrimes)
            {
                listMegaPrimes.Add(i);
            }
            countRemainingThreads--;
        }

        #endregion
    }
}
