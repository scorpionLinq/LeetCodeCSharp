using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "cbbd";
            string s2 = LongestPalindrome(s);
            Console.WriteLine(s2);
            Console.ReadKey();
        }

        public static string LongestPalindrome(string s)
        {
            string sTest = "";
            int n = s.Length;
            bool[,] p = new bool[n,n];
            for (int i = 0; i < n;++i)
            {
                for (int j = i; j>= 0;--j)
                {
                    if (s[i] != s[j])
                    {
                        p[i, j] = false;
                    }
                    else
                    {
                        int nLen = i-j;
                        if (nLen <= 1 ||(nLen > 1 && p[i - 1, j + 1] ))
                        {
                            p[i, j] = true;
                            if ( (nLen +1 ) > sTest.Length)
                            {
                                Console.WriteLine("j: " + j + " nLen: " + (nLen + 1));
                                sTest = s.Substring(j, nLen + 1);
                            }
                        }
                    }
                }
            }
            return sTest;
        }
    }
}
