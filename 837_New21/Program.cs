using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//新21点
namespace _837_New21
{
    class Solution
    {
        //方法1
        public double New21Game(int N, int K, int W)
        {
            double[] dp = new double[K + W];
            int nEnd = Math.Min(N, K + W-1);//结束点，包含
            for (int i = 0; i < dp.Length; ++i)
            {
                if (i>(K-1) && i <= nEnd )
                {
                    dp[i] = 1f;
                }
                else
                {
                    dp[i] = 0f;
                }
            }
            double S = Math.Min(N-(K-1),W);
            for(int i = K - 1; i >= 0; --i)
            {
                dp[i] = S / (double)W;
                S += dp[i] - dp[i+W];//往前移动一位，要减去末尾数的概率
                Console.WriteLine("i: " + i + " : " + dp[i] + " S:" + S);
            }
            return dp[0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = 21, K = 17, W = 10;
            Solution so = new Solution();
            double x = so.New21Game(N, K, W);
            Console.WriteLine("XXXXXXXXX: " + x.ToString());
            Console.ReadKey();
        }
    }
}
