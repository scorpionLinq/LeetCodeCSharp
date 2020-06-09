using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*990. 等式方程的可满足性
给定一个由表示变量之间关系的字符串方程组成的数组，每个字符串方程 equations[i] 的长度为 4，并采用两种不同的形式之一："a==b" 或 "a!=b"。在这里，a 和 b 是小写字母（不一定不同），表示单字母变量名。

只有当可以将整数分配给变量名，以便满足所有给定的方程时才返回 true，否则返回 false。 

 

示例 1：
输入：["a==b","b!=a"]
输出：false
解释：如果我们指定，a = 1 且 b = 1，那么可以满足第一个方程，但无法满足第二个方程。没有办法分配变量同时满足这两个方程。

示例 2：
输出：["b==a","a==b"]
输入：true
解释：我们可以指定 a = 1 且 b = 1 以满足满足这两个方程。

示例 3：
输入：["a==b","b==c","a==c"]
输出：true

示例 4：
输入：["a==b","b!=c","c==a"]
输出：false

示例 5：
输入：["c==c","b==d","x!=z"]
输出：true

提示：
1 <= equations.length <= 500
equations[i].length == 4
equations[i][0] 和equations[i][3] 是小写字母
equations[i][1] 要么是'='，要么是 '!'
equations[i][2] 是'='
*/

namespace _990_Equation
{
    public class Solution
    {
        public bool EquationsPossible(string[] equations)
        {
            Dictionary<int, Dictionary<char, char>> dicEqation = new Dictionary<int, Dictionary<char, char>>();//等式里面的字符
            Dictionary<int, string> dicEqation2 = new Dictionary<int, string>();//不等式里面的字符
            int nCountNot = 0;
            int nCount = 0;
            foreach (string strItem in equations)
            {
                if (strItem[1] == '=')
                {
                    char ch1 = strItem[0];
                    char ch2 = strItem[3];
                    //bool bIsIn = false;
                    int nFirstKey = 0;
                    int nKeyCount = 0;
                    List<int> nRemoveKey = new List<int>();
                    foreach (int nKey in dicEqation.Keys)
                    {
                        Dictionary<char, char> dicItem = dicEqation[nKey];
                        if (dicItem.ContainsValue(ch1) || dicItem.ContainsValue(ch2))
                        {
                            nKeyCount++;
                            if (nKeyCount > 1)
                            {
                                Dictionary<char, char>  itemFirst = dicEqation[nFirstKey];
                                foreach (char ch in dicItem.Values)
                                {
                                    if (!itemFirst.ContainsValue(ch))
                                    {
                                        itemFirst.Add(ch, ch);
                                    }
                                }
                                nRemoveKey.Add(nKey);
                            }
                            else
                            {
                                nFirstKey = nKey;
                                if (!dicItem.ContainsValue(ch1))
                                {
                                    dicItem.Add(ch1, ch1);
                                }
                                if (!dicItem.ContainsValue(ch2))
                                {
                                    dicItem.Add(ch2, ch2);
                                }
                            }
                        }
                    }
                    if(nRemoveKey.Count > 0)
                    {
                        foreach (int nkey in nRemoveKey)
                        {
                            dicEqation.Remove(nkey);
                        }
                    }
                    if (nFirstKey == 0)
                    {
                        nCount++;
                        Dictionary<char, char> dicItem = new Dictionary<char, char>();
                        dicItem.Add(ch1, ch1);
                        if (!dicItem.ContainsValue(ch2)) dicItem.Add(ch2, ch2);
                        dicEqation.Add(nCount, dicItem);
                    }
                }
                else
                {
                    nCountNot++;
                    dicEqation2.Add(nCountNot, strItem);
                }
            }
            foreach (string item in dicEqation2.Values)
            {
                char ch1 = item[0];
                char ch2 = item[3];
                if (ch1 == ch2)
                {
                    return false;
                }
                foreach (Dictionary<char, char> dicItem in dicEqation.Values)
                {
                    if ((dicItem.ContainsValue(ch1) && dicItem.ContainsValue(ch2)))
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] lsStr = { "a==b","e==c","b==c","a!=e"};
            Solution so = new Solution();
            bool bIs = so.EquationsPossible(lsStr);
            Console.WriteLine(bIs.ToString());
            Console.ReadKey();
        }
    }
}
