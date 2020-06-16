using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*297. 二叉树的序列化与反序列化
序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。

请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。

示例: 

你可以将以下二叉树：

    1
   / \
  2   3
     / \
    4   5

序列化为 "[1,2,3,null,null,4,5]"
提示: 这与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。

说明: 不要使用类的成员 / 全局 / 静态变量来存储状态，你的序列化和反序列化算法应该是无状态的。
*/
namespace _297_Tree
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
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            int nNum = 0;
            bool bHaveNum = true;
            //将二叉树放入字典，每一层一个key
            Dictionary<int, List<TreeNode>> dicNum = new Dictionary<int, List<TreeNode>>();
            do
            {
                List<TreeNode> lsBefore = new List<TreeNode>();
                //将当前成放入列表中，直至该层都为null
                List<TreeNode> ls = new List<TreeNode>();
                if (nNum > 0)
                {
                    lsBefore = dicNum[nNum];
                    for (int i = 0; i < lsBefore.Count; ++i)
                    {
                        TreeNode node = lsBefore[i];
                        TreeNode nodeLeft = null;
                        TreeNode nodeRight = null;
                        if (node != null)
                        {
                            nodeLeft = node.left;
                            nodeRight = node.right;
                        }
                        ls.Add(nodeLeft);
                        ls.Add(nodeRight);
                    }
                }
                else
                {
                    ls.Add(root);
                }
                //判断当前是否还存在数值
                bHaveNum = false;
                foreach (TreeNode node in ls)
                {
                    if (node != null)
                    {
                        bHaveNum = true;
                        break;
                    }
                }
                nNum++;
                dicNum.Add(nNum, ls);

            } while (bHaveNum);

            //转换为字符串（最后一行全部为空，不转换）
            List<string> lsStr = new List<string>();
            string str = "[";
            for (int i = 1; i < dicNum.Count; ++i)
            {
                List<TreeNode> lsBefore = dicNum[i];
                foreach (TreeNode node in lsBefore)
                {
                    string strNode = "null";
                    if(node != null)
                    {
                        strNode = node.val.ToString();
                    }
                    str += strNode + ",";
                    //lsStr.Add(strNode);
                }
            }
            //删除最右一个逗号转换成  ]
            str = str.Substring(0, str.Length - 1);
            str += "]";
            return str;
        }

        public List<string> stringToList(string data)
        {
            List<string> lsStr = new List<string>();
            if(data != "[]")
            {
                //掐头去尾 去除方括号 []
                //string strNum = data.Substring(1, data.Length - 2);
                int nStart = 0;
                int nLen = 0;
                for(int i = 0; i<data.Length; ++i)
                {
                    char ch = data[i];
                    if (ch == '[')
                    {
                        nStart++;
                    }
                    else if (ch == ']' || ch == ',')
                    {
                        lsStr.Add(data.Substring(nStart, nLen));
                        nStart = i + 1;
                        nLen = 0;
                    }
                    else
                    {
                        nLen++;
                    }

                }
            }
            return lsStr;
        }
        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            //字符串解析为字符串列表
            List<string> lsStr = stringToList(data);

            //将字符串按层解析插入字典
            int nAllNum = 0;
            int nKey = 0;
            Dictionary<int,List<string>> dicNum = new Dictionary<int,List<string>>();
            while (nAllNum < lsStr.Count)
            {
                nKey++;
                int nCurNum = (int)Math.Pow(2, nKey - 1);
                List<string> ls = new List<string>();
                for (int i = nAllNum; i < (nAllNum + nCurNum); ++i )
                {
                    if (i < lsStr.Count)
                    {
                        ls.Add(lsStr[i]);
                    }
                }
                dicNum.Add(nKey, ls);
                nAllNum += nCurNum;
            }
            TreeNode root = null;
            List<TreeNode> lsBeforeNode = new List<TreeNode>();
            List<TreeNode> lsCurNode = new List<TreeNode>();
            foreach (int nKeys in dicNum.Keys)
            {
                List<string> lsCurStr = dicNum[nKeys];
                if (nKeys == 1)
                {
                    if (lsCurStr[0] == "null")
                    {
                        return root;
                    }
                    else
                    {
                        int nValue = Convert.ToInt32(lsCurStr[0]);
                        root = new TreeNode(nValue);
                        lsCurNode.Add(root);
                    }
                }
                else
                {
                    //循环上一层数据，记录数据
                    int nNum = 0;
                    foreach (TreeNode node in lsBeforeNode)
                    {
                        //左侧/右侧 赋值
                        TreeNode nodeLeft = null;
                        TreeNode nodeRight = null;
                        if (node != null)
                        {
                            if (lsCurStr[nNum]!= "null")
                            {
                                nodeLeft = new TreeNode(Convert.ToInt32(lsCurStr[nNum]));
                            }
                            if (lsCurStr[nNum+1] != "null")
                            {
                                nodeRight = new TreeNode(Convert.ToInt32(lsCurStr[nNum + 1]));
                            }
                            node.left = nodeLeft;
                            node.right = nodeRight;
                        }
                        lsCurNode.Add(nodeLeft);
                        lsCurNode.Add(nodeRight);
                        nNum += 2;
                    }

                }
                //记录下当前层
                lsBeforeNode.Clear();
                foreach (TreeNode node in lsCurNode)
                {
                    lsBeforeNode.Add(node);
                }
                lsCurNode.Clear();
            }
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] lsInt = { 1, 2, 3, 4,5 };
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
            //string str = su.serialize(root);
            //Console.WriteLine("XXXXX:"+ str);
            string str  = "[]";
            TreeNode root1 = su.deserialize(str);
            Console.ReadKey();
        }
    }
}
