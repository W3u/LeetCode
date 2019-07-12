/* 12. Integer to Roman
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 *      Symbol       Value
 *      I             1
 *      V             5
 *      X             10
 *      L             50
 *      C             100
 *      D             500
 *      M             1000
 * For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, 
 * which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
 * 
 * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. 
 * Instead, the number four is written as IV. Because the one is before the five we subtract it making four. 
 * The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
 * 
 * -> I can be placed before V (5) and X (10) to make 4 and 9. 
 * -> X can be placed before L (50) and C (100) to make 40 and 90. 
 * -> C can be placed before D (500) and M (1000) to make 400 and 900.
 * 
 * Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
 * 
 * Example 1:
 * Input: 3         Output: "III"
 * 
 * Example 2:
 * Input: 4         Output: "IV"
 * 
 * Example 3:
 * Input: 9         Output: "IX"
 * 
 * Example 4:
 * Input: 58        Output: "LVIII"  
 * Explanation: C = 100, L = 50, XXX = 30 and III = 3.
 * 
 * Example 5:
 * Input: 1994      Output: "MCMXCIV"
 * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * 
 */


using System;
using System.Collections.Generic;
using System.Text;

namespace LC201809
{
    class No12
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            //{ 1,      5,      10,     50,     100,    500,    1000 };
            //{ 'I',    'V',    'X',    'L',    'C',    'D',    'M' };
            int[] values = { 1, 5, 10, 50, 100, 500, 1000 };
            char[] symbols = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            string str = string.Empty;


            int i = values.Length - 1;
            while (true)
            {
                if (num == 0)
                    break;

                int digit = num.ToString().Length;
                int pow = (int)Math.Pow(10, digit - 1);

                if (num - values[i] >= 0)
                {
                    if (i - 1 >= 0 && num / pow == 9)
                    {
                        str += symbols[i - 1].ToString() + symbols[i + 1].ToString();
                        num = num % pow;
                    }
                    else if (num / pow == 4)
                    {
                        str += symbols[i].ToString() + symbols[i + 1].ToString();
                        num = num % pow;
                    }
                    else
                    {
                        str += symbols[i];
                        num = num - values[i];
                    }

                }
                else if (num - values[i] < 0)
                {
                    i--;
                }
            }
            //Console.WriteLine(str);
            return str;
        }
    }
}
