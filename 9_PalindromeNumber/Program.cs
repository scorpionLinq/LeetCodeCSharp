using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*9. 回文数
判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

示例 1:
输入: 121
输出: true

示例 2:
输入: -121
输出: false
解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。

示例 3:
输入: 10
输出: false
解释: 从右向左读, 为 01 。因此它不是一个回文数。
*/
namespace _9_PalindromeNumber
{
    public class Solution
    {
        //方法1：
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            Dictionary<int,int> dicNum = new Dictionary<int,int>();
            int nKey = 0;
            while (x > 0)
            {
                int nNum = x % 10;
                dicNum.Add(nKey, nNum);
                nKey++;
                x /= 10;
            }
            int nLen = dicNum.Count;
            if (nLen > 1)
            {
                int nMid = nLen / 2 + 1;
                for (int i = 0; i < nMid; ++i)
                {
                    int nLeft = dicNum[i];
                    int nRight = dicNum[nLen - 1 - i];
                    if (nLeft != nRight)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //方法2
        public bool IsPalindrome2(int x)
        {
            int num = 0;
            if (x < 0 || (x % 10 == 0 && x != 0)) //个位数为0或者小于0
            {
                return false;
            }
            while (x > num)//num为右侧逆反数值  x剩余左侧数值
            {
                int pop = x % 10;
                num = num * 10 + pop;
                x = x / 10;
            }
            if (x == num || x == num / 10) //偶/奇 数位判断
            {
                return true;
            }
            return false;
        }
                
    }

    class Program
    {
        static void Main(string[] args)
        {
            int nNum = 121;
            Solution so = new Solution();
            bool bIsPalind = so.IsPalindrome2(nNum);
            Console.WriteLine(bIsPalind.ToString());
            Console.ReadKey();
        }
    }
}
