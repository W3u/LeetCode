/*
 * 589. N-ary Tree Preorder Traversal
 * Given an n-ary tree, return the preorder traversal of its nodes' values.
 * For example, given a 3-ary tree:
 *             1
 *          /  \   \
 *         3   2    4
 *        / \
 *       5   6
 * Return its preorder traversal as: [1,3,5,6,2,4].
 * 
 * Note:
 * Recursive solution is trivial, could you do it iteratively?
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCCommon;


namespace LC201810
{
    class No589
    {
        #region Recursion
        public IList<int> Preorder(Node root)
        {
            List<int> ret = new List<int>();
            Preorder_Recursion(root, ret);
            return ret;
        }
        private void Preorder_Recursion(Node root, List<int> ret)
        {
            if (root == null)
                return;

            ret.Add(root.val);
            foreach (var item in root.children)
            {
                ret.AddRange(Preorder(item));
            }
        }
        #endregion

        #region Iteration

        public IList<int> Preorder_Iteration(Node root)
        {
            List<int> ret = new List<int>();
            if (root == null)
                return ret;

            Stack<Node> stackNodes = new Stack<Node>();
            stackNodes.Push(root);
            while (stackNodes.Count > 0)
            {
                Node curNode = stackNodes.Pop();
                visitAlongLeftBranch(curNode, stackNodes, ret);
            }
            return ret;
        }

        private void visitAlongLeftBranch(Node curNode, Stack<Node> stackNodes, List<int> ret)
        {
            int cntCurLevel = curNode.children.Count;
            ret.Add(curNode.val);
            for (int i = cntCurLevel - 1; i >= 0; i--)
            {
                stackNodes.Push(curNode.children[i]);
            }
        }

        #endregion



    }
}
