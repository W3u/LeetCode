/* 
 * 111. Minimum Depth of Binary Tree
 * Given a binary tree, find its minimum depth.
 * The minimum depth is the number of nodes along the shortest path 
 * from the root node down to the nearest leaf node.
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * Given binary tree [3,9,20,null,null,15,7],
 *           3
 *          / \
 *         9  20
 *           /  \
 *          15   7
 * return its minimum depth = 2.
 */

using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    class No111
    {
        public int MinDepth_BFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int minDepth = 0;
            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);

            while (queueNodes.Count > 0)
            {
                minDepth++;
                int levelCnt = queueNodes.Count;
                for (int i = 0; i < levelCnt; i++)
                {
                    TreeNode curNode = queueNodes.Dequeue();    //dequeue all nodes at this level
                    if (curNode.left == null && curNode.right == null)
                        return minDepth;
                    else
                    {
                        if (curNode.left != null)
                            queueNodes.Enqueue(curNode.left);
                        if (curNode.right != null)
                            queueNodes.Enqueue(curNode.right);
                    }
                }
            }
            return -1;
        }

        public int MinDepth_Recursion(TreeNode root)
        {
            #region MyRegion
            if (root == null)
            {
                return 0;
            }

            if ((root.left == null) && (root.right == null))
            {
                return 1;
            }

            int min_depth = int.MaxValue;
            if (root.left != null)
            {
                min_depth = Math.Min(MinDepth_Recursion(root.left), min_depth);
            }
            if (root.right != null)
            {
                min_depth = Math.Min(MinDepth_Recursion(root.right), min_depth);
            }

            return min_depth + 1;
            #endregion
        }


        public int MinDepth_DFS(TreeNode root)
        {
            if (root == null)
                return 0;

            Stack<KeyValuePair<TreeNode, int>> stackNodes = new Stack<KeyValuePair<TreeNode, int>>();
            stackNodes.Push(new KeyValuePair<TreeNode, int>(root, 1));
            int minDepth = int.MaxValue;
            while (stackNodes.Count != 0)
            {
                KeyValuePair<TreeNode, int> curPair = stackNodes.Pop();
                TreeNode curNode = curPair.Key;
                int curDepth = curPair.Value;

                if (curNode.left == null && curNode.right == null)
                    minDepth = Math.Min(minDepth, curDepth);
                if (curNode.left != null)
                    stackNodes.Push(new KeyValuePair<TreeNode, int>(curNode.left, curDepth + 1));
                if (curNode.right != null)
                    stackNodes.Push(new KeyValuePair<TreeNode, int>(curNode.right, curDepth + 1));
            }

            return minDepth;
        }

    }
}
