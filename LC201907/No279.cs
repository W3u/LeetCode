/*
279. Perfect Squares
Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

1   2   3   4   5   6   7   8   9   10  11  12
1   4   9   16  25  36  49  64  81  100 121 132

Example 1:
Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.

Example 2:
Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCCommon;

namespace LC201907
{
    class No279
    {
        Dictionary<int, int> dicLeast = new Dictionary<int, int>();

        public int NumSquares(int n)
        {
            dicLeast.Add(1, 1);
            dicLeast.Add(2, 2);
            dicLeast.Add(3, 3);

            List<int> squareList = new List<int>();
            for (int i = 1; i * i <= n; i++)
            {
                squareList.Add(i * i);
            }

            int leastNum = LeastSquareNumber(n, squareList);
            return leastNum;
        }

        private int LeastSquareNumber(int n, List<int> squareList)
        {
            if (n <= 0)
                return 0;

            if (dicLeast.ContainsKey(n))
            {
                Console.WriteLine($"Read from cache: {n} : {dicLeast[n]}");
                return dicLeast[n];
            }


            Console.WriteLine($"n = {n}, list = [{squareList.JoinToString(",")}]");

            List<int> leastList = new List<int>();
            int mid = squareList.Count / 2;
            for (int i = squareList.Count - 1; i >= mid; i--)
            {
                int value = n;
                Console.WriteLine($"========================================");
                Console.WriteLine($"Input = {value}");
                Console.WriteLine($"{value} - {squareList[i]} = {value - squareList[i]}");

                value -= squareList[i];
                List<int> curSquareList = squareList.Where(s => s <= value).ToList();
                int least = LeastSquareNumber(value, curSquareList) + 1;
                Console.WriteLine($"n = {n}; Least = {least}");
                leastList.Add(least);

                Console.WriteLine($"========================================");
            }
            Console.WriteLine($"=> n = {n}; Least List = {leastList.JoinToString(",")}");
            Console.WriteLine($"=> n = {n}; Least = {leastList.Min()}");

            dicLeast.Add(n, leastList.Min());

            return leastList.Min();
        }

        public int NumSquares_BFS(int n)
        {
            var squares = new int[(int)Math.Floor(Math.Sqrt(n))];
            for (int i = 0; i < squares.Length; ++i) squares[i] = (i + 1) * (i + 1);

            var level = new Queue<int>();
            level.Enqueue(n);
            level.Enqueue(-1);
            var height = 0;
            while (level.Count > 0)
            {
                ++height;
                while (level.Peek() != -1)
                {
                    var node = level.Dequeue();
                    for (int j = 0; j < squares.Length; j++)
                    {
                        if (squares[j] == node)
                        {
                            return height;
                        }

                        else if (squares[j] < node)
                        {
                            level.Enqueue(node - squares[j]);
                        }

                        else
                        {
                            break;
                        }
                    }
                }
                level.Enqueue(-1);
                level.Dequeue();
            }

            return height;
        }

        public int NumSquares_DP(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"Input = {i}");
                dp[i] = int.MaxValue;
                for (int j = 1; j * j <= i; j++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Round{j}: square = {j * j}");
                    Console.WriteLine($"min(dp[{i}] , dp[{i} - {j} * {j}] + 1) = min(dp[{i}] , dp[{i - j * j}] + 1) = min({dp[i]}, {dp[i - j * j]} + 1)");
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                    Console.WriteLine($"dp[{i}] = {dp[i]}");
                }
            }
            return dp[n];
        }

        public int NumSquares_DP_V2(int n)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>(n + 1);
            dict.Add(0, 0);
            dict.Add(1, 1);
            dict.Add(2, 2);
            dict.Add(3, 3);

            List<int> squares = new List<int>();
            for (int i = 1; i * i <= n; i++)
            {
                squares.Add(i * i);
            }

            int j = 1;
            while (j <= n)
            {
                if (dict.ContainsKey(j) == false)
                {
                    var curSquares = squares.Where(s => s <= j);
                    curSquares = curSquares.Skip(curSquares.Count() / 2 - 1);
                    foreach (int square in curSquares)
                    {
                        Console.WriteLine();
                        int least = dict[j - square] + 1;
                        if (dict.ContainsKey(j) == false)
                        {
                            dict.Add(j, least);
                        }
                        else
                        {
                            if (least < dict[j])
                            {
                                dict[j] = least;
                            }
                        }
                    }
                }
                j++;
            }
            return dict[n];
        }

        /// <summary>
        /// [Runtime:]
        /// Dictionary  :   1164ms
        /// Int[]       :   96ms
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares_DP_V2_Optimized(int n)
        {
            //Dictionary<int, int> dict = new Dictionary<int, int>(n + 1);
            //dict.Add(0, 0);
            //int j = 1;
            //while (j <= n)
            //{
            //    dict[j] = int.MaxValue;
            //    for (int i = 1; i * i <= j; i++)
            //    {
            //        dict[j] = Math.Min(dict[j], dict[j - i * i] + 1);
            //    }
            //    j++;
            //}
            //return dict[n];

            int[] dp = new int[n + 1];
            int j = 1;
            while (j <= n)
            {
                dp[j] = int.MaxValue;
                for (int i = 1; i * i <= j; i++)
                {
                    dp[j] = Math.Min(dp[j], dp[j - i * i] + 1);
                }
                j++;
            }
            return dp[n];

        }



    }
}
