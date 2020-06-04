using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _238_Multiply
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int nLen = nums.Length;
            int[] mulLeft = new int[nLen]; //左侧乘积
            int[] mulRight = new int[nLen]; //右侧乘积
            for(int i = 0; i < nLen; ++i)
            {
                int nRight = nLen - 1 - i;
                if(i == 0)
                {
                    mulLeft[i] = nums[i];
                    mulRight[nRight] = nums[nRight];
                }
                else
                {
                    mulLeft[i] = mulLeft[i - 1] * nums[i];
                    mulRight[nRight] = mulRight[nRight+ 1] * nums[nRight];
                }
            }

            int[] val = new int[nLen];
            for (int i = 0; i < nLen; ++i)
            {
                if (i == 0) //最左侧
                {
                    val[i] = mulRight[i + 1];
                }
                else if (i ==(nLen -1)) //最右侧
                {
                    val[i] = mulLeft[i - 1];
                }
                else
                {
                    val[i] = mulLeft[i - 1] * mulRight[i + 1];
                }
            }
            return val;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 4 };
            Solution so = new Solution();
            int[] resoult = so.ProductExceptSelf(test);
            foreach (int x in resoult)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }
    }
}
