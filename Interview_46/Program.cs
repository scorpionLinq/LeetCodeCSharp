using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 面试题46.把数字翻译成字符串
    给定一个数字，我们按照如下规则把它翻译为字符串：0 翻译成 “a” ，
    1 翻译成 “b”，……，11 翻译成 “l”，……，25 翻译成 “z”。
    一个数字可能有多个翻译。请编程实现一个函数，用来计算一个数字有多少种不同的翻译方法。

示例 1:

输入: 12258
输出: 5
解释: 12258有5种不同的翻译，分别是"bccfi", "bwfi", "bczi", "mcfi"和"mzi"
 

提示：

0 <= num< 231
*/

namespace Interview_46
{
    public class Solution
    {
        public int TranslateNum(int num)
        {
            int nResoult = 0;
            if (num >= 10 && num <= 25)
            {
                nResoult += 1;
            }
            else if(num % 100 <= 25 && num % 100 >= 10) //数值必须在10到25之间
            {
                nResoult += TranslateNum(num / 100);
            }

            if(num < 10)
            {
                nResoult += 1;
            }
            else
            {
                nResoult += TranslateNum(num / 10);
            }
            return nResoult;
        }

        public int TranslateNum2(int num)
        {
            if (num < 10)return 1;

            if (num % 100 <= 25 && num % 100 >= 10) //数值必须在10到25之间
            {
                return TranslateNum2(num / 100) + TranslateNum2(num / 10);
            }
            else
            {
                return TranslateNum2(num / 10);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int nNum = 12258;
            Solution so = new Solution();
            int nResoult = so.TranslateNum2(nNum);
            Console.WriteLine(nResoult);
            Console.ReadKey();
        }
    }
}
