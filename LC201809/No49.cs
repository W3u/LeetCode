/*
 * 49. Group Anagrams
 * 
 * Given an array of strings, group anagrams together.
 * 
 * Example:
 * Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
 * Output:
 * [
 *   ["ate","eat","tea"],
 *   ["nat","tan"],
 *   ["bat"]
 * ]
 * 
 * Note:
 * All inputs will be in lowercase.
 * The order of your output does not matter.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LC201809
{
    class No49
    {

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0) return new List<IList<string>>();
            // 26个素数分别表示各字母
            var primes = new int[] {
                2, 3, 5, 7, 11,
                13, 17, 19, 23, 29,
                31, 37, 41, 43, 47,
                53, 59, 61, 67, 71,
                73, 79, 83, 89, 97,
                101 };

            var dict = new Dictionary<int, IList<string>>();
            foreach (var str in strs)
            {
                var key = 1;
                foreach (var ch in str)
                    key *= primes[ch - 'a'];

                if (dict.ContainsKey(key))
                    dict[key].Add(str);
                else
                    dict.Add(key, new List<string>() { str });
            }
            return dict.Values.ToList();
        }



        //public IList<IList<string>> GroupAnagrams(string[] strs)
        //{
        //    IList<IList<string>> results = new List<IList<string>>();
        //    Dictionary<string, ArrayList> dic = new Dictionary<string, ArrayList>();


        //    for (int i = 0; i < strs.Length; i++)
        //    {
        //        char[] unsortedArray=strs[i].ToCharArray();
        //        Array.Sort(unsortedArray);
        //        string key = new string(unsortedArray);
        //        if(dic.ContainsKey(key))
        //        {
        //            ArrayList values = dic[key];
        //            values.Add(strs[i]);
        //        }
        //        else
        //        {
        //            ArrayList values = new ArrayList();
        //            values.Add(strs[i]);
        //            dic.Add(key, values);
        //        }
        //    }

        //    foreach(string key in dic.Keys)
        //    {
        //        ArrayList values = dic[key];
        //        IList<string> subList = new List<string>();
        //        foreach (string value in values)
        //        {
        //            subList.Add(value);
        //        }
        //        results.Add(subList);
        //    }
        //    return results;
        //}



        #region unsort, Time Limit Exceeded
        //public IList<IList<string>> GroupAnagrams(string[] strs)
        //{
        //    IList<IList<string>> results = new List<IList<string>>();

        //    for (int i = 0; i < strs.Length; i++)
        //    {
        //        bool notFound = true;
        //        for (int j = 0; j < results.Count; j++)
        //        {
        //            //compare with the first item in each sub list.
        //            if (isAnagram(results[j][0], strs[i]))
        //            {
        //                //if is anagram, then add this word to the matched sub list.
        //                results[j].Add(strs[i]);
        //                notFound = false;
        //                break;
        //            }
        //        }
        //        if(notFound)
        //        {
        //            //if not found, then add this new word to new sub list 
        //            IList<string> listNew = new List<string>();
        //            listNew.Add(strs[i]);
        //            results.Add(listNew);
        //        }
        //    }
        //    return results;
        //}

        //private bool isAnagram(string strA, string strB)
        //{
        //    bool isAna = true;

        //    IList<char> listA = new List<char>(strA.ToCharArray());
        //    IList<char> listB = new List<char>(strB.ToCharArray());

        //    if (strA.Length != strB.Length)
        //        isAna = false;
        //    else if (Sum(strA) != Sum(strB))
        //        isAna = false;
        //    else
        //    {
        //        while (listA.Count > 0)
        //        {
        //            //if exists a letter can not be found in listB, then we can stop check and return false.
        //            bool notFound = false;
        //            for (int i = 0; i < listB.Count; i++)
        //            {
        //                if (listA[0] == listB[i])
        //                {
        //                    //remove it in both array and check next letter
        //                    listA.RemoveAt(0);
        //                    listB.RemoveAt(i);
        //                    break;
        //                }
        //                else if (i == listB.Count - 1)
        //                {
        //                    //cannot find this letter
        //                    isAna = false;
        //                    notFound = true;
        //                }
        //            }
        //            if (notFound)
        //                break;
        //        }
        //    }
        //    return isAna;
        //}

        //private int Sum(string str)
        //{
        //    int sum = 0;
        //    foreach (char ch in str)
        //    {
        //        sum += ch;
        //    }
        //    return sum;
        //}
        #endregion
    }
}
