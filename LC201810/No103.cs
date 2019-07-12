/*
 * 103. Binary Tree Zigzag Level Order Traversal
 * Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, 
 * then right to left for the next level and alternate between).
 * 
 * For example:
 * Given binary tree [3,9,20,null,null,15,7],
 *           3
 *          / \
 *         9  20
 *           /  \
 *          15   7
 * return its zigzag level order traversal as:
 * [
 *   [3],
 *   [20,9],
 *   [15,7]
 * ]
 */

using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    class No103
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;

            bool leftToRight = true;
            Stack<TreeNode> stackNodes = new Stack<TreeNode>();
            stackNodes.Push(root);

            while (stackNodes.Count > 0)
            {
                Stack<TreeNode> tempNodes = new Stack<TreeNode>();
                IList<int> levelNodes = new List<int>();
                while (stackNodes.Count > 0)
                {
                    TreeNode curNode = stackNodes.Pop();
                    levelNodes.Add(curNode.val);

                    if (leftToRight)
                    {
                        if (curNode.left != null)
                            tempNodes.Push(curNode.left);
                        if (curNode.right != null)
                            tempNodes.Push(curNode.right);
                    }
                    else
                    {
                        if (curNode.right != null)
                            tempNodes.Push(curNode.right);
                        if (curNode.left != null)
                            tempNodes.Push(curNode.left);
                    }
                }
                leftToRight = !leftToRight;
                stackNodes = tempNodes;
                ret.Add(levelNodes);
            }
            return ret;
        }
    }
}
