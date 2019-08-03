using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC201907
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] vs = { 7, 2, 5, 3, 6, 4, 9, 1 };
            //No121 no121 = new No121();
            //no121.MaxProfit(vs);

            //No264 no264 = new No264();
            //no264.NthUglyNumber(10);

            //No279 no279 = new No279();
            //no279.NumSquares_BFS_V2(12);

            int[] vs = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 100 };//{ 1, 8, 9, 9, 15, 20 };//{ 9, 8, 2, 10, 6, 1 };//{ 1, 5, 11, 5 };//
            No416 no416 = new No416();
            no416.CanPartition(vs);

            //No1025 no1025 = new No1025();
            //no1025.DivisorGame_Recursion(877);
        }
    }
}
