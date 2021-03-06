﻿/*
 * 637. Average of Levels in Binary Tree
 * Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.
 * 
 * Example 1:
 * Input:
 *           3
 *          / \
 *         9  20
 *           /  \
 *          15   7
 * Output: [3, 14.5, 11]
 * Explanation:
 * The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].
 * 
 * Note:
 * The range of node's value is in the range of 32-bit signed integer.
 */

using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    //Definition for a binary tree node.
    

    class No637
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> ret = new List<double>();
            if (root == null)
                return ret;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);

            while (queueNodes.Count > 0)
            {
                double sum = 0.0;     //use double rather than int,avoid case like [2147483647,2147483647,2147483647]
                int cnt = queueNodes.Count;     //the nodes count of one level
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queueNodes.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                        queueNodes.Enqueue(node.left);
                    if (node.right != null)
                        queueNodes.Enqueue(node.right);
                }
                ret.Add(sum / cnt);
            }
            return ret;
        }


    }
}
