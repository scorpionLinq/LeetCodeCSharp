using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*108. 将有序数组转换为二叉搜索树
将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。

本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

示例:

给定有序数组: [-10,-3,0,5,9],

一个可能的答案是：[0,-3,9,-10,null,5]，它可以表示下面这个高度平衡二叉搜索树：

      0
     / \
   -3   9
   /   /
 -10  5
 */
namespace _108_Tree
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    class Solution
    {
        int[] lsNum;
        public TreeNode SortByLeftAndRight(int nLeft,int nRight)
        {
            if (nLeft > nRight) return null;
            int nMid = (nLeft + nRight) / 2;
            TreeNode root = new TreeNode(lsNum[nMid]);
            root.left = SortByLeftAndRight(nLeft,nMid -1);
            root.right = SortByLeftAndRight(nMid + 1,nRight);
            return root;
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            lsNum = nums;
            TreeNode root = SortByLeftAndRight(0,nums.Length-1);
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution so = new Solution();
            int[] lsNum = { -10, -3, 0, 5, 9 };
            TreeNode root = so.SortedArrayToBST(lsNum);
            Console.ReadKey();
        }
    }
}
