using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _104_Tree_Deep
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
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] ls = {3,9,20,15,7 };
            TreeNode root = new TreeNode(ls[0]) {
                left = new TreeNode(ls[1]),
                right = new TreeNode(ls[2])
                {
                    left = new TreeNode(ls[3]),
                    right = new TreeNode(ls[4])
                }
            };
            Solution su = new Solution();
            int nMax = su.MaxDepth(root);
            Console.WriteLine("XX: "+ nMax.ToString());
            Console.ReadKey();
        }
    }
}
