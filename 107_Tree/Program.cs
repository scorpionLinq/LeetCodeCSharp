using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _107_Tree
{
   
     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
 

    public class Solution
    {
        IList<IList<int>> ls = new List<IList<int>>();

        public List<TreeNode> GetTreeNode(TreeNode root)
        {
            List<TreeNode> lsNum = new List<TreeNode>();
            if (root != null)
            {
                lsNum.Add(root.left);
                lsNum.Add(root.right);
            }
            return lsNum;
        }

        public List<List<TreeNode>> GetAllTreeNode(TreeNode root)
        {
            List<List<TreeNode>> lsAllTree = new List<List<TreeNode>>();
            List<TreeNode> ls = new List<TreeNode>();
            ls.Add(root);
            lsAllTree.Add(ls);
            int nCount = ls.Count;
            while (nCount > 0)
            {
                List<TreeNode> lsCur = new List<TreeNode>();
                foreach (TreeNode node in ls)
                {
                    List<TreeNode> ls1 = GetTreeNode(node);
                    foreach (TreeNode node1 in ls1)
                    {
                        lsCur.Add(node1);
                    }
                }
                ls = lsCur;
                lsAllTree.Add(ls);
                nCount = ls.Count;
            }
            return lsAllTree;
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<List<TreeNode>> lsSame = GetAllTreeNode(root);
            for (int i = lsSame.Count-1;i>=0;--i)
            {
                List<TreeNode> lsNode = lsSame[i];
                List<int> lsInt = new List<int>();
                foreach (TreeNode node in lsNode)
                {
                    if (node != null)
                    {
                        lsInt.Add(node.val);
                    }
                }
                if(lsInt.Count > 0)
                {
                    ls.Add(lsInt);
                }
            }
            return ls;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] lsInt = { 3, 9, 20, 15, 7 };
            TreeNode root = new TreeNode(lsInt[0])
            {
                left = new TreeNode(lsInt[1]),
                right = new TreeNode(lsInt[2])
                {
                    left = new TreeNode(lsInt[3]),
                    right = new TreeNode(lsInt[4])
                }
            };

            Solution su = new Solution();
            IList<IList<int>> ls = su.LevelOrderBottom(root);
            Console.WriteLine("XXXXX");
            Console.ReadKey();
        }
    }
}
