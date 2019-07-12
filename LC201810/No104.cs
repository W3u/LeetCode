/*
 * https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
 * 104. Maximum Depth of Binary Tree
 * Given a binary tree, find its maximum depth.
 * The maximum depth is the number of nodes along the longest path from 
 * the root node down to the farthest leaf node.
 * Note: A leaf is a node with no children.
 * Example:
 * Given binary tree [3,9,20,null,null,15,7],
 *           3
 *          / \
 *         9  20
 *           /  \
 *          15   7
 * return its depth = 3.
 */

using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    public class No104
    {
        public int MaxDepth_BFS(TreeNode root)
        {
            if (root == null)
                return 0;


            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);
            int maxDepth = 0;
            while (queueNodes.Count > 0)
            {
                maxDepth++;
                int cntOfNodesInCurLevel = queueNodes.Count;
                for (int i = 0; i < cntOfNodesInCurLevel; i++)
                {
                    TreeNode curNode = queueNodes.Dequeue();
                    if (curNode.left != null)
                        queueNodes.Enqueue(curNode.left);
                    if (curNode.right != null)
                        queueNodes.Enqueue(curNode.right);
                }
            }

            return maxDepth;
        }

        int answer = 0;
        public int MaxDepth_Recursion(TreeNode root)
        {
            if (root == null)
                return 0;

            GetMaxDepth(root, 1);

            return answer;
        }

        private void GetMaxDepth(TreeNode node, int level)
        {
            if (node.left == null && node.right == null)
            {
                answer = Math.Max(answer, level);
            }
            if (node.left != null)
                GetMaxDepth(node.left, level + 1);
            if (node.right != null)
                GetMaxDepth(node.right, level + 1);
        }

        public int MaxDepth_DFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int maxDepth = 0;

            Stack<KeyValuePair<TreeNode, int>> stackNodes = new Stack<KeyValuePair<TreeNode, int>>();
            stackNodes.Push(new KeyValuePair<TreeNode, int>(root, 1));
            while (stackNodes.Count > 0)
            {
                var curPair = stackNodes.Pop();
                TreeNode curNode = curPair.Key;
                int curHigh = curPair.Value;

                if (curNode.left == null && curNode.right == null)
                    maxDepth = Math.Max(maxDepth, curHigh);
                if (curNode.left != null)
                    stackNodes.Push(new KeyValuePair<TreeNode, int>(curNode.left, curHigh + 1));
                if (curNode.right != null)
                    stackNodes.Push(new KeyValuePair<TreeNode, int>(curNode.right, curHigh + 1));
            }

            return maxDepth;
        }

    }
}
