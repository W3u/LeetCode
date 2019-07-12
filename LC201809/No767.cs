/*
 * 767. Reorganize String
 * Given a string S, check if the letters can be rearranged so that two characters that are adjacent to 
 * each other are not the same.
 * If possible, output any possible result.  If not possible, return the empty string.
 * 
 * Example 1:
 * Input: S = "aab"
 * Output: "aba"
 * 
 * Example 2:
 * Input: S = "aaab"
 * Output: ""
 * 
 * Note:
 * S will consist of lowercase letters and have length in range [1, 500].
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LC201809
{
    class No767
    {
        public String ReorganizeString(string S)
        {
            if (string.IsNullOrEmpty(S))
                return "";
            char[] ret = new char[S.Length];
            int[] arrCh = new int[26];
            foreach (char ch in S.ToCharArray())
            {
                arrCh[ch - 'a'] += 100;
            }
            for (int i = 0; i < 26; i++)
            {
                arrCh[i] += i;
            }
            //encode: arrCh[i] = 100 * cnt + i;
            Array.Sort(arrCh);

            int t = 1;
            int cnt = 0;
            char letter;
            for (int i = 0; i < 26; i++)
            {
                cnt = arrCh[i] / 100;
                letter = (char)(arrCh[i] % 100 + 97);
                if (cnt > (S.Length + 1) / 2)
                    return "";
                while (cnt > 0)
                {
                    if (t >= S.Length)
                        t = 0;
                    ret[t] = letter;
                    t += 2;
                    cnt--;
                }
            }
            return new string(ret);
        }

    }
}
