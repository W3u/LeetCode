using System;
using System.Collections.Generic;
using System.Text;

namespace LCCommon
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }

        public static TreeNode Init()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            return root;
        }

        public static TreeNode InitRightTree()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            return root;
        }

        public static TreeNode InitLeftTree()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.left.left = new TreeNode(20);

            return root;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("cur: {0}", this.val);
            sb.AppendFormat(";left: {0}", this.left == null ? "NULL" : this.left.val.ToString());
            sb.AppendFormat(";right: {0}", this.right == null ? "NULL" : this.right.val.ToString());
            return sb.ToString();
        }
    }
}
