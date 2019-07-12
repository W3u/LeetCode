/* 107. Binary Tree Level Order Traversal II
 * Given a binary tree, return the bottom-up level order traversal of its nodes' values. 
 * (ie, from left to right, level by level from leaf to root).
 * For example:
 * Given binary tree [3,9,20,null,null,15,7],
 * For example:
 * Given binary tree [3,9,20,null,null,15,7],
 *           3
 *          / \
 *         9  20
 *           /  \
 *          15   7
 * return its bottom-up level order traversal as:
 * [
 *   [15,7],
 *   [9,20],
 *   [3]
 * ]
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    public class No107
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);
            while (queueNodes.Count > 0)
            {
                IList<int> levelNodes = new List<int>();
                int cnt = queueNodes.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode curNode = queueNodes.Dequeue();
                    levelNodes.Add(curNode.val);
                    if (curNode.left != null)
                        queueNodes.Enqueue(curNode.left);
                    if (curNode.right != null)
                        queueNodes.Enqueue(curNode.right);
                }
                ret.Insert(0, levelNodes);
            }
            return ret;
        }

    }
}
