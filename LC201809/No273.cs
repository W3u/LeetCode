/* 273. Integer to English Words
 * Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1(2,147,483,647).
 * 
 * Example 1:
 * Input: 123
 * Output: "One Hundred Twenty Three"
 * 
 * Example 2:
 * Input: 12,345
 * Output: "Twelve Thousand Three Hundred Forty Five"
 * 
 * Example 3:
 * Input: 1,234,567
 * Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
 * 
 * Example 4:
 * Input: 1,234,567,891
 * Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
 * 		
 * 
 *	1		2		3			4			5			6		7			8			9		10
 *	One		Two		Three		Four		Five		Six		Seven		Eight		Nine	Ten					10
 *	----------------------------------------------------------------------------------------------------------------
 *	11		12		13			14			15			16			17			18			19
 *	Eleven	Twelve	Thriteen	Fourteen	Fifteen		Sixteen		Seventeen	Eighteen	Nineteen				9
 *	-----------------------------------------------------------------------------------------------------------------
 *	20			30			40			50			60			70			80			90
 *	Twenty		Thirty		Forty		Fifty		Sixty		Seventy		Eighty		Ninety						8
 *	----------------------------------------------------------------------------------------------------------------
 *	100			1,000			1,000,000       1,000,000,000
 *	Hundred		Thousand		Million		    Billion																4
 * -----------------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace LC201809
{
    class No273
    {
        string[] oneToNine = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };    //10
        string[] tenToNineteen = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };  //10
        string[] twentyToNinety = { "NULL", "NULL", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };   //10

        int[] baseNum = { 100, 1000, 1000000, 1000000000 };
        string[] baseCardinal = { "Hundred", "Thousand", "Million", "Billion" };

        Stack<string> result = new Stack<string>();

        public string NumberToWords(int num)
        {
            string words = string.Empty;
            Process(num);

            while (result.Count > 1)
                words += result.Pop() + " ";
            words += result.Pop();

            Console.WriteLine(words);
            return words;
        }

        private void Process(int num)
        {
            if (num < 100)
            {
                result.Push(ConvertToEnglishString(num));
                return;
            }

            for (int i = baseNum.Length - 1; i >= 0; i--)
            {
                if (num / baseNum[i] > 0)
                {
                    int left = num / baseNum[i];
                    int right = num % baseNum[i];

                    if (right != 0)
                        Process(right);
                    result.Push(baseCardinal[i]);
                    Process(left);
                    break;
                }
            }
        }

        /// <summary>
        /// Convert the num(less than 100) to its english words representation
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string ConvertToEnglishString(int num)
        {
            if (num > 99)
                return "NotValid";
            if (num < 10)
            {
                return oneToNine[num];
            }
            else if (num < 20)
            {
                return tenToNineteen[num - 10];
            }
            else
            {
                if (num % 10 == 0)
                    return twentyToNinety[num / 10];
                return twentyToNinety[num / 10] + " " + oneToNine[num % 10];
            }
        }

    }
}
