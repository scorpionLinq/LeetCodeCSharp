using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//寻找重复数
namespace _287_FindDuplicate
{
    class Program
    {
        /* 方法1
         public static int FindDuplicate(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int val in nums)
            {
                if (!map.ContainsKey(val))
                {
                    map.Add(val, val);
                }
                else
                {
                    return val;
                }
            }
            return -1;
        }*/

        public static int FindDuplicate(int[] nums)
        {
            int left = 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                int cnt = 0;
                foreach (int num in nums)
                {
                    if (num <= mid)
                    {
                        cnt += 1;
                    }
                }

                // 根据抽屉原理，小于等于 4 的个数如果严格大于 4 个
                // 此时重复元素一定出现在 [1, 4] 区间里

                if (cnt > mid)
                {
                    // 重复元素位于区间 [left, mid]
                    right = mid;
                }
                else
                {
                    // if 分析正确了以后，else 搜索的区间就是 if 的反面
                    // [mid + 1, right]
                    left = mid + 1;
                }
            }
            return left;
        }

        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 3, 4, 2 };
            int nNum = FindDuplicate(nums);
            Console.WriteLine("xxxxx: {0}", nNum);
            Console.ReadKey();
        }
    }
}
