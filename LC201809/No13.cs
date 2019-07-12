/* 13. Roman to Integer
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
 * Input: "III"         Output: 3
 * 
 * Example 2:
 * Input: "IV"          Output: 4
 * 
 * Example 3:
 * Input: "IX"          Output: 9
 * 
 * Example 4:
 * Input: "LVIII"       Output: 58      
 * Explanation: L = 50, V= 5, III = 3.
 * 
 * Example 5:
 * Input: "MCMXCIV"     Output: 1994
 * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC201809
{
    public class No13
    {
        public static int RomanToInt(string s)
        {
            int[] values    = { 1,      5,      10,     50,     100,    500,    1000 };
            char[] symbols  = { 'I',    'V',    'X',    'L',    'C',    'D',    'M' };

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char curSymbol = s[i];
                int curSymbolIndex = IndexOf(symbols, curSymbol);
                if (i == s.Length - 1)
                {
                    sum += values[curSymbolIndex];
                    break;
                }
                char nextSymbol = s[i + 1];       
                int nextSymbolIndex = IndexOf(symbols, nextSymbol);

                if (curSymbolIndex >= nextSymbolIndex)
                {
                    sum += values[curSymbolIndex];
                }
                else
                {
                    sum += values[nextSymbolIndex] - values[curSymbolIndex];
                    i++;
                }
            }
            Console.WriteLine(sum);
            return sum;
        }

        private static int IndexOf(char[] array, char key)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (key == array[i])
                    return i;
            }
            return -1;
        }

    }
}
