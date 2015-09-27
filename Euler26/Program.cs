using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler26
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCycle = 0;
            int maxRank = 0;

            foreach(int n in Enumerable.Range(1, 1000))
            {
                int cycle = GetCycleLength(n);
                if(cycle > maxCycle)
                {
                    maxCycle = cycle;
                    maxRank = n;
                }
            }

            Console.WriteLine(maxRank + " : " + maxCycle);
            Console.ReadLine();
        }


        //Loop through traditional base 10 division algorithm
        //If the remainder of a step has been seen before than a cycle has been found
        //If remainder of a step is 0, then the fraction has a finite decimal representation
        //Stops past 1000 steps (though this is actually small)
        static int GetCycleLength(int n)
        {
            Dictionary<int, int> terms = new Dictionary<int, int>();
            int denum = 1;
            int rank = 0;
            while (rank < 1000)
            {
                if (terms.ContainsKey(denum))
                {
                    return rank - terms[denum];
                }
                terms.Add(denum, rank);

                int remainder = denum % n;
                if(remainder == 0)
                {
                    return 0;
                }
                denum = remainder * 10;
                rank++;
            }
            return -1;
        }
    }
}
