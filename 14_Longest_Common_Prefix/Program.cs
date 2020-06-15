using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//14. 最长公共前缀
//编写一个函数来查找字符串数组中的最长公共前缀。

//如果不存在公共前缀，返回空字符串 ""。

//示例 1:

//输入: ["flower","flow","flight"]
//输出: "fl"
//示例 2:

//输入: ["dog","racecar","car"]
//输出: ""
//解释: 输入不存在公共前缀。

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string strF = "";
        for (int i = 0; i < strs.Length; i++)
        {
            if (strF == "")
            {
                strF = strs[i];
            }
            else
            {
                string strA = strs[i];
                for (int j = 0; j < strF.Length; j++)
                {
                    if (j >= strA.Length || strF[j] != strA[j])
                    {
                        strF = strF.Substring(0, j);
                        break;
                    }
                }

            }
        }
        return strF;
    }
}
namespace _14_Longest_Common_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution so = new Solution();
            string[] str = { "aaa","aa","aaa"};
            string strF =  so.LongestCommonPrefix(str);
            Console.WriteLine(strF);
            Console.ReadKey();
        }
    }
}
