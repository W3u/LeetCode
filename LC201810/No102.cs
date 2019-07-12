using System;
using System.Collections.Generic;
using System.Text;
using LCCommon;

namespace LC201810
{
    class No102
    {
        public IList<IList<int>> LevelOrder_Queue(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;
            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(root);
            while (queueNodes.Count > 0)
            {
                int cnt = queueNodes.Count;
                IList<int> levelNodes = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode curNode = queueNodes.Dequeue();
                    levelNodes.Add(curNode.val);
                    if (curNode.left != null)
                        queueNodes.Enqueue(curNode.left);
                    if (curNode.right != null)
                        queueNodes.Enqueue(curNode.right);
                }
                ret.Add(levelNodes);
            }
            return ret;
        }

        public IList<IList<int>> LevelOrder_BFS(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;


            


            return ret;
        }


        public IList<IList<int>> LevelOrder_Recursion(TreeNode root)
        {
            var list = new List<IList<int>>();
            LevelOrder(root, list, 0);
            return list;
        }

        void LevelOrder(TreeNode root, IList<IList<int>> list, int depth)
        {
            if (root == null) return;
            while (list.Count < depth + 1) list.Add(new List<int>());
            list[depth].Add(root.val);
            LevelOrder(root.left, list, depth + 1);
            LevelOrder(root.right, list, depth + 1);
        }

    }
}
