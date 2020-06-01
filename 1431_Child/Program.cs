using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1431_Child
{
    public class Solution
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> ls = new List<bool>();
            int nMax = 0;
            foreach (int nNum in candies)
            {
                if (nMax < nNum)
                {
                    nMax = nNum;
                }
            }
            for (int i = 0; i < candies.Length; ++i)
            {
                bool bVal = candies[i] + extraCandies >= nMax;
                ls.Insert(i,bVal);
            }
            return ls;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            int[] candies = { 2, 3, 5, 1, 3 };
            int nExtra = 3;
            Solution pro = new Solution();
            IList<bool> ls = pro.KidsWithCandies(candies, nExtra);
        }
    }
}
