using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    class TreeSearch
    {
        /// <summary>
        /// Breadth First Search
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        public TreeNode BFS(TreeNode root, int key)
        {
            if (root == null)
                return null;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);
            while (queueNodes.Count > 0)
            {
                int levelCnt = queueNodes.Count;
                for (int i = 0; i < levelCnt; i++)
                {
                    TreeNode curNode = queueNodes.Dequeue();
                    if (curNode.val == key)
                        return curNode;

                    if (curNode.left != null)
                        queueNodes.Enqueue(curNode.left);
                    if (curNode.right != null)
                        queueNodes.Enqueue(curNode.right);
                }
            }

            return null;
        }

        /// <summary>
        /// Depth First Search
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        public TreeNode DFS(TreeNode root, int key)
        {
            if (root == null)
                return null;

            Stack<TreeNode> stackNodes = new Stack<TreeNode>();
            stackNodes.Push(root);
            while (stackNodes.Count > 0)
            {

                TreeNode curNode = stackNodes.Peek();
                if (curNode.val == key)
                    return curNode;

                if (curNode.right != null)
                    stackNodes.Push(curNode.right);
                if (curNode.left != null)
                    stackNodes.Push(curNode.left);
                if (curNode.left == null && curNode.right == null)
                {
                    //while (curNode.IsVisited == true)
                    //{
                    //    stackNodes.Pop();
                    //    curNode = stackNodes.Peek();
                    //}
                }
            }

            return null;
        }
    }
}
