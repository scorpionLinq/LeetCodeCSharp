using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _371_SumOfTwoIntegers
{
    class Solution
    {
        public int getSum(int a, int b)
        {
            int x = a ^ b;
            int y = (a & b) << 1;
            while (y != 0)
            {
                a = x;
                b = y;
                y = (a & b) << 1;
                x = a ^ b;
            }
            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        Solution so = new Solution();

            int nSum = so.getSum(-1, 1);
            Console.Write("nSum: "+ nSum);
            Console.ReadKey();
        }

    }
}
