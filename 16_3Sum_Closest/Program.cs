using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_3Sum_Closest
{
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            //Array.Reverse()
            int nSum = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int nCur = nums[i] + nums[left] + nums[right];

                    if (Math.Abs(nCur - target) < Math.Abs(nSum - target))
                    {
                        nSum = nCur;
                    }

                    if (nCur > target)
                    {
                        right--;
                    }
                    else if (nCur < target)
                    {
                        left++;
                    }
                    else
                    {
                        // 如果已经等于target的话, 肯定是最接近的
                        return target;
                    }
                }
            }
            return nSum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 5, 6, 7, 1, 2, 4, 681 };

            //升序
            Array.Sort(nums);
            //降序
            Array.Sort(nums,(x, y) => (-x.CompareTo(y)));
            //反转
            Array.Reverse(nums);
            foreach (int val in nums)
            {
                Console.WriteLine("   : "+ val);
            }
            Console.ReadKey();
        }
    }
}
