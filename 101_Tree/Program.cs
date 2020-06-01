using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101_Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsSameTree(root.left, root.right);
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if (p == null || q == null)
            {
                return false;
            }
            if (p.val != q.val)
            {
                return false;
            }
            return IsSameTree(p.left, q.right) && IsSameTree(p.right, q.left);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] ls1 = { 1, 0, 3 };
            int[] ls2 = { 1, 0, 3 };
            TreeNode p = new TreeNode(ls1[0])
            {
                left = new TreeNode(ls1[1]),
                right = new TreeNode(ls1[2])
            };

            TreeNode q = new TreeNode(ls2[0])
            {
                left = new TreeNode(ls2[1]),
                right = new TreeNode(ls2[2])
            };


            Solution su = new Solution();
            bool bVal = su.IsSameTree(p, q);
            Console.WriteLine("XXX:  " + bVal.ToString());
            Console.ReadKey();
        }
    }
}
