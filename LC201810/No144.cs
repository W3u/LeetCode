/*
 * 144. Binary Tree Preorder Traversal
 * Given a binary tree, return the preorder traversal of its nodes' values.
 * Input: [1,null,2,3]
 *    1
 *     \
 *      2
 *     /
 *    3
 * 
 * Output: [1,2,3]
 * 
 * Follow up: Recursive solution is trivial, could you do it iteratively?
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCCommon;

namespace LC201810
{
    class No144
    {
        #region Recursion

        List<int> retRecursion = new List<int>();
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return retRecursion;

            retRecursion.Add(root.val);
            if (root.left != null)
                PreorderTraversal(root.left);
            if (root.right != null)
                PreorderTraversal(root.right);

            return retRecursion;
        }

        #endregion


        #region Iteration

        public IList<int> PreorderTraversal_Iteration(TreeNode root)
        {
            IList<int> ret = new List<int>();
            if (root == null)
                return ret;

            Stack<TreeNode> stackNodes = new Stack<TreeNode>();
            stackNodes.Push(root);
            while (stackNodes.Count>0)
            {
                TreeNode curNode = stackNodes.Pop();
                ret.Add(curNode.val);
                if (curNode.right != null)
                    stackNodes.Push(curNode.right);
                if (curNode.left != null)
                    stackNodes.Push(curNode.left);
            }

            return ret;
        }


        #endregion
    }
}
