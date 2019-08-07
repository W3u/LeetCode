/*
 416. Partition Equal Subset Sum
Medium

Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Note:
Each of the array element will not exceed 100.
The array size will not exceed 200.

Example 1:
Input: [1, 5, 11, 5]
Output: true
Explanation: The array can be partitioned as [1, 5, 5] and [11].
 
Example 2:
Input: [1, 2, 3, 5]
Output: false
Explanation: The array cannot be partitioned into equal sum subsets.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC201907
{
    class No416
    {
        struct Number
        {
            public int Num;
            public bool Used;

            public Number(int num)
            {
                Num = num;
                Used = false;
            }
        }

        #region Approach #1 Recursion: Debug version
        //public bool CanPartition(int[] nums)
        //{
        //    Console.Write("Input: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");

        //    int sum = nums.Sum();
        //    Console.WriteLine("1. Sum of elements is {0}, {1}", sum, sum % 2 == 0 ? "even" : "odd");
        //    if (sum % 2 == 1)
        //    {
        //        Console.WriteLine("The array cannot be partitioned into equal sum subsets");
        //        return false;
        //    }

        //    Console.WriteLine("2. Sort the elements in the array...");
        //    Array.Sort(nums);
        //    Console.Write("Sorted Array: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");

        //    Number[] numbers = new Number[nums.Length];
        //    for (int i = 0; i < nums.Length; i++)
        //        numbers[i] = new Number(nums[i]);

        //    Console.WriteLine("3. Try to partition the elements in the array...");
        //    int k = 0;
        //    bool flag = false;
        //    for (int i = numbers.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine("================= Round[{0}] =================", k++);
        //        flag = AbleToSumToN_Recursion(sum / 2, numbers, i);
        //        if (flag == true)
        //            break;
        //        else
        //        {
        //            Console.WriteLine("Reset the flag...");
        //            for (int j = 0; j < numbers.Length; j++)
        //                numbers[j].Used = false;
        //        }
        //        Console.WriteLine("");
        //    }
        //    if (flag)
        //    {
        //        Console.Write("==> The array can be partitioned as [");
        //        for (int i = 0; i < numbers.Length; i++)
        //        {
        //            if (numbers[i].Used == false)
        //                Console.Write("{0} ", nums[i]);
        //        }
        //        Console.Write("] and [");
        //        for (int i = 0; i < numbers.Length; i++)
        //        {
        //            if (numbers[i].Used)
        //                Console.Write("{0} ", nums[i]);
        //        }
        //        Console.Write("]");
        //    }
        //    else
        //    {
        //        Console.WriteLine("==> The array cannot be partitioned into equal sum subsets");
        //    }

        //    return flag;
        //}

        //private bool AbleToSumToN_Recursion(int n, Number[] numbers, int rightIdx)
        //{
        //    Console.WriteLine("n = {0}; rightIdx = {1}", n, rightIdx);
        //    Console.Write("Number:\t");
        //    for (int i = 0; i < numbers.Length; i++)
        //        Console.Write("{0}\t", numbers[i].Num);
        //    Console.WriteLine();
        //    Console.Write("Used:\t");
        //    for (int i = 0; i < numbers.Length; i++)
        //        Console.Write("{0}\t", numbers[i].Used ? "Y" : "N");
        //    Console.WriteLine("");

        //    if (n == 0)
        //        return true;
        //    for (int i = rightIdx; i >= 0; i--)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine(">> i = {0}", i);
        //        if (numbers[i].Used == false)
        //        {
        //            if (n < numbers[i].Num)
        //            {
        //                Console.WriteLine(">> {0} < {1}, skip this element", n, numbers[i].Num);
        //                continue;
        //            }
        //            else
        //            {
        //                Console.WriteLine(">> numbers[{0}].Used = {1}; n = {2} - {3} = {4}", i, true, n, numbers[i].Num, n - numbers[i].Num);

        //                numbers[i].Used = true;
        //                n -= numbers[i].Num;
        //                return AbleToSumToN_Recursion(n, numbers, i - 1);
        //            }
        //        }
        //    }
        //    return false;
        //}
        #endregion

        #region Approach #1 Recursion: Release version
        //public bool CanPartition(int[] nums)
        //{
        //    int sum = nums.Sum();
        //    if (sum % 2 == 1)
        //    {
        //        return false;
        //    }
        //    Array.Sort(nums);
        //    Number[] numbers = new Number[nums.Length];
        //    for (int i = 0; i < nums.Length; i++)
        //        numbers[i] = new Number(nums[i]);

        //    bool flag = false;
        //    for (int i = numbers.Length - 1; i >= 0; i--)
        //    {
        //        flag = AbleToSumToN_Recursion(sum / 2, numbers, i);
        //        if (flag == true)
        //            break;
        //        else
        //        {
        //            for (int j = 0; j < numbers.Length; j++)
        //                numbers[j].Used = false;
        //        }
        //    }
        //    return flag;
        //}

        //private bool AbleToSumToN_Recursion(int n, Number[] numbers, int rightIdx)
        //{
        //    if (n == 0)
        //        return true;
        //    for (int i = rightIdx; i >= 0; i--)
        //    {
        //        if (numbers[i].Used == false)
        //        {
        //            if (n < numbers[i].Num)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                numbers[i].Used = true;
        //                n -= numbers[i].Num;
        //                return AbleToSumToN_Recursion(n, numbers, i - 1);
        //            }
        //        }
        //    }
        //    return false;
        //}

        #endregion


        #region Approach #2 Iteration + Stack


        //struct StackNode
        //{
        //    public int Value;

        //    public List<int> UsedIdxes;

        //    public StackNode(int value)
        //    {
        //        Value = value;
        //        UsedIdxes = new List<int>();
        //    }

        //    public StackNode(int value, List<int> usedIdxes)
        //    {
        //        Value = value;
        //        UsedIdxes = new List<int>();
        //        UsedIdxes.AddRange(usedIdxes);
        //    }
        //}


        //public bool CanPartition(int[] nums)
        //{
        //    Console.Write("Input: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");

        //    int sum = nums.Sum();
        //    Console.WriteLine("1. Sum of elements is {0}, {1}", sum, sum % 2 == 0 ? "even" : "odd");
        //    if (sum % 2 == 1)
        //    {
        //        Console.WriteLine("The array cannot be partitioned into equal sum subsets");
        //        return false;
        //    }

        //    Console.WriteLine("2. Sort the elements in the array...");
        //    Array.Sort(nums);
        //    Console.Write("Sorted Array: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");

        //    Stack<StackNode> tmpResults = new Stack<StackNode>();
        //    StackNode root = new StackNode(sum / 2);
        //    tmpResults.Push(root);

        //    List<int> failedList = new List<int>();

        //    while (tmpResults.Count > 0)
        //    {
        //        StackNode curNode = tmpResults.Pop();
        //        Console.WriteLine("N = {0}", curNode.Value);

        //        if (failedList.Contains(curNode.Value))
        //        {
        //            Console.WriteLine("this item was failed earlier, skipped");
        //            continue;
        //        }

        //        Console.Write("Number:\t");
        //        for (int i = 0; i < nums.Length; i++)
        //            Console.Write("{0}\t", nums[i]);
        //        Console.WriteLine();
        //        Console.Write("Used:\t");
        //        for (int i = 0; i < nums.Length; i++)
        //            Console.Write("{0}\t", curNode.UsedIdxes.Contains(i) ? "Y" : "N");
        //        Console.WriteLine("");

        //        for (int i = 0; i < nums.Length; i++)
        //        {
        //            if (curNode.UsedIdxes.Contains(i))
        //            {
        //                Console.WriteLine(">> num[{0}] = {1} is used, skipped", i, nums[i]);
        //                continue;
        //            }
        //            if (curNode.Value == nums[i])
        //            {
        //                Console.WriteLine(">> n = {0} - {1} = {2}, return true", curNode.Value, nums[i], curNode.Value - nums[i]);
        //                return true;
        //            }
        //            else if (curNode.Value < nums[i])
        //            {
        //                Console.WriteLine(">> {0} < {1}, skip this element", curNode.Value, nums[i]);
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine(">> n = {0} - {1} = {2}", curNode.Value, nums[i], curNode.Value - nums[i]);
        //                StackNode newNode = new StackNode(curNode.Value - nums[i], curNode.UsedIdxes);
        //                newNode.UsedIdxes.Add(i);
        //                tmpResults.Push(newNode);
        //            }
        //        }
        //        failedList.Add(curNode.Value);
        //    }
        //    return false;
        //}

        #endregion


        #region Approach # 3 Dynamic Programming

        //public bool CanPartition(int[] nums)
        //{
        //    Console.Write("Input: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");

        //    int sum = nums.Sum();
        //    Console.WriteLine("1. Sum of elements is {0}, {1}", sum, sum % 2 == 0 ? "even" : "odd");
        //    if (sum % 2 == 1)
        //    {
        //        Console.WriteLine("The array cannot be partitioned into equal sum subsets");
        //        return false;
        //    }

        //    int maxNum = nums.Max();
        //    Console.WriteLine("2. The max number is {0}", maxNum);
        //    if (maxNum > sum / 2)
        //    {
        //        Console.WriteLine("The array cannot be partitioned into equal sum subsets");
        //        return false;
        //    }

        //    Console.WriteLine("3. Sort the elements in the array...");
        //    Array.Sort(nums);
        //    Console.Write("Sorted Array: [");
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i == nums.Length - 1)
        //            Console.Write("{0}", nums[i]);
        //        else
        //            Console.Write("{0}, ", nums[i]);
        //    }
        //    Console.WriteLine("]");


        //    int N = sum / 2;
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        Number[] usedNumTable = InitialUsedTable(nums);
        //        int tmpSum = 0;

        //        for (int j = i; j >= 0; j--)
        //        {
        //            Number curNum = usedNumTable[j];
        //            if (curNum.Used)
        //                continue;

        //            if (tmpSum == N)
        //            {
        //                return true;
        //            }
        //            else if (tmpSum + curNum.Num > N)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                tmpSum += curNum.Num;
        //                curNum.Used = true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private Number[] InitialUsedTable(int[] nums)
        //{
        //    Number[] numbers = new Number[nums.Length];
        //    for (int i = nums.Length - 1; i >= 0; i--)
        //    {
        //        numbers[i] = new Number(nums[i]);
        //    }

        //    return numbers;
        //}


        #endregion


        #region Approach #4 DP 2D Array
        //public bool CanPartition(int[] nums)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        sum += nums[i];
        //    }
        //    if ((sum & 1) == 1)
        //    {
        //        return false;
        //    }
        //    sum /= 2;

        //    int n = nums.Length;
        //    bool[,] dp = new bool[n + 1, sum + 1];
        //    //for (int i = 0; i < n + 1; i++)
        //    //    for (int j = 0; j < sum + 1; j++)
        //    //        dp[i, j] = false;

        //    dp[0, 0] = true;
        //    for (int i = 1; i < n + 1; i++)
        //    {
        //        dp[i, 0] = true;
        //    }
        //    //for (int j = 1; j < sum + 1; j++)
        //    //{
        //    //    dp[0, j] = false;
        //    //}

        //    for (int i = 1; i < n + 1; i++)
        //    {
        //        for (int j = 1; j < sum + 1; j++)
        //        {
        //            dp[i, j] = dp[i - 1, j];
        //            if (j >= nums[i - 1])
        //            {
        //                dp[i, j] = (dp[i, j] || dp[i - 1, j - nums[i - 1]]);
        //            }
        //        }
        //    }

        //    return dp[n, sum];
        //} 
        #endregion

        #region Approach #4 DP 1D Array

        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];

            if ((sum & 1) == 1)
                return false;

            sum /= 2;
            int n = nums.Length;
            bool[] dp = new bool[sum + 1];
            dp[0] = true;

            foreach (int num in nums)
            {
                Console.WriteLine("num = {0}", num);
                for (int i = sum; i > 0; i--)
                {
                    Console.WriteLine("i = {0}", i);
                    if (i >= num)
                    {
                        Console.WriteLine("> dp[{0}] = {1}", i, dp[i]);
                        Console.WriteLine("> dp[i - num] = dp[{0} - {1}] = {2}", i, num, dp[i - num]);
                        dp[i] = dp[i] || dp[i - num];
                        Console.WriteLine("=> dp[{0}] = {1}", i, dp[i]);
                    }
                }
                Console.WriteLine("=============================================");
            }

            return dp[sum];
        }


        public bool CanPartitionV2(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 == 1)
                return false;

            sum /= 2;
            if (nums.Max() > sum)
                return false;

            bool[] dp = new bool[sum + 1];
            dp[0] = true;
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("num = {0}", nums[i]);
                for (int s = sum; s > 0; s--)
                {
                    Console.WriteLine("s = {0}", s);
                    if (s >= nums[i])
                    {
                        Console.WriteLine("> dp[{0}] = {1}", s, dp[s]);
                        Console.WriteLine("> dp[s - nums[i]] = dp[{0} - {1}] = {2}", s, nums[i], dp[s - nums[i]]);
                        dp[s] = dp[s] || dp[s - nums[i]];
                        Console.WriteLine("=> dp[{0}] = {1}", s, dp[s]);
                    }
                }
                Console.WriteLine("=============================================");
            }
            return dp[sum];
        }
        #endregion

    }
}
