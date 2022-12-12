using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Megaprimes_Console
{
    /// <summary>
    /// Static class that contains Prime and Megaprime functionality
    /// </summary>
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
        private static List<uint> listMegaprimes = new List<uint>();

        /// <summary>
        /// Used to determine how many threads are currently still running
        /// </summary>
        private static uint countRemainingThreads = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Improved version of former 'GetMegaprimesUpTo' method
        /// Removes checking if they are prime and then checking if they are megaprime
        /// </summary>
        /// <param name="number"></param>
        public static List<uint> ReturnMegaprimesList(uint number)
        {
            DateTime end;
            DateTime start = DateTime.Now;

            List<uint> listMegaprimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsMegaprime(i))
                {
                    listMegaprimes.Add(i);
                }
            }

            end = DateTime.Now;

            TimeSpan timespan = end - start;
            Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return listMegaprimes;
        }

        /// <summary>
        /// BRAVO but returns TimeSpan
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static TimeSpan ReturnMegaprimesTimeSpan(uint number)
        {
            DateTime end;
            DateTime start = DateTime.Now;

            List<uint> listMegaprimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsMegaprime(i))
                {
                    listMegaprimes.Add(i);
                }
            }

            end = DateTime.Now;

            TimeSpan timespan = end - start;
            Console.WriteLine(listMegaprimes.Count);
            Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return timespan;
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

        /// <summary>
        /// Returns the amount of Megaprimes in the list
        /// </summary>
        /// <returns></returns>
        public static uint ReturnMegaprimeCount()
        {
            return (uint)listMegaprimes.Count;
        }

        /// <summary>
        /// Returns the private list of Megaprimes
        /// Used for displaying Megaprimes to users
        /// </summary>
        /// <returns></returns>
        public static List<uint> ReturnMegaprimeList()
        {
            return listMegaprimes;
        }

        #endregion

        #region Old Methods

        /// <summary>
        /// Checks if the number is prime and then checks if they are Megaprime
        /// Depracated due to being slower as it computes list twice
        /// </summary>
        /// <param name="number"></param>
        public static void GetMegaprimesUpTo(uint number)
        {
            List<uint> listPrimes = new List<uint>();
            List<uint> listMegaprimes = new List<uint>();

            for (uint i = 0; i < number; i++)
            {
                if (IsPrime(i))
                {
                    listPrimes.Add(i);
                }
            }

            foreach (uint prime in listPrimes)
            {
                if (ContainsOnlyMegaprimeNumbers(prime))
                {
                    listMegaprimes.Add(prime);
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
        private static bool ContainsOnlyMegaprimeNumbers(uint number)
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

        #region My Threaded Solution
        
        /// <summary>
        /// Divides numbers between 0 and max between threads to acquire Megaprimes
        /// </summary>
        /// <param name="iThreads"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static TimeSpan MegaprimeFinderThreaded(uint iThreads, uint max)
        {
            
            //Reset the list and thread count
            listMegaprimes = new List<uint>();
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
                    Console.WriteLine(listMegaprimes.Count);
                    break;
                }
            }
            end = DateTime.Now;

            TimeSpan timespan = end - start;
            //Console.WriteLine(timespan.TotalSeconds.ToString() + " seconds");

            return timespan;
        }

        /// <summary>
        /// Encased in its own function to ensure start and end do not change before thread is started
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static Thread CreateThread(uint id, uint start, uint end)
        {
            Thread thread = new Thread(p => ThreadMegaprimeFinder(id, start, end));
            return thread;
        }

        private static void ThreadMegaprimeFinder(uint thread, uint min, uint max)
        {
            List<uint> localListMegaprimes = new List<uint>();
            for (uint i = min; i <= max; i++)
            {
                if (IsMegaprime(i))
                {
                    localListMegaprimes.Add(i);
                }
                //Thread.Yield(); //Bad - do not do, slows it down a lot for no gain
            }
            foreach (uint i in localListMegaprimes)
            {
                listMegaprimes.Add(i);
            }
            countRemainingThreads--;
        }

        #endregion
    }
}
