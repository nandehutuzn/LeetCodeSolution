using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    class Solution3
    {
        /* 在给定的一个不含重复值得集合candidates，和target，在candidates中找出和为target的元素的集合，单个值可用多次
         *  所有元素不为负
         * For example, given candidate set [2, 3, 6, 7] and target 7, 
            A solution set is: 
                [
                    [7],
                    [2, 2, 3]
                ]
        */
        public static List<List<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<List<int>> result = new List<List<int>>();
            GetResult(result, new List<int>(), candidates, target, 0);

            return result;
        }

        private static void GetResult(List<List<int>> result, List<int> cur, int[] candidates, int target, int start)
        {
            if (target > 0)
            {
                for (int i = start; i < candidates.Length && target >= candidates[i]; i++)
                {
                    cur.Add(candidates[i]);
                    GetResult(result, cur, candidates, target - candidates[i], i);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
            else if (target == 0)
                result.Add(new List<int>(cur));
        }

        /* 和上题要求类似，不过数组中元素可重复，但每个元素在一个组合中只能出现一次
         * For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
            A solution set is: 
                [
                    [1, 7],
                    [1, 2, 5],
                    [2, 6],
                    [1, 1, 6]
                ]
        */
        public static List<List<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<List<int>> result = new List<List<int>>();
            GetResult1(result, new List<int>(), candidates, target, 0);
            return result;
        }

        private static void GetResult1(List<List<int>> result, List<int> cur, int[] candidates, int target, int start)
        {
            if (target > 0)
            {
                for (int i = start; i < candidates.Length && target >= candidates[i]; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1]) continue;
                    cur.Add(candidates[i]);
                    GetResult1(result, cur, candidates, target - candidates[i], i + 1);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
            else if (target == 0)
                result.Add(new List<int>(cur));
        }
        /* 给定一个未排序的数组，找出第一个失踪的正整数
         * For example,
            Given [1,2,0] return 3,
            and [3,4,-1,1] return 2.

            Your algorithm should run in O(n) time and uses constant space.
        */
        public static int FirstMissingPositive(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == i + 1 || nums[i] <= 0 || nums[i] > nums.Length) i++;
                else if (nums[nums[i] - 1] != nums[i]) Swap(nums, i, nums[i] - 1);
                else i++;
            }
            i = 0;
            while (i < nums.Length && nums[i] == i + 1) i++;
            return i + 1;
        }

        private static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        //https://leetcode.com/problemset/algorithms/

           
        public static int Trap(int[] height)
        {
            int a = 0;
            int b = height.Length - 1;
            int max = 0;
            int leftMax = 0;
            int rightMax = 0;
            while (a <= b)
            {
                leftMax = Math.Max(leftMax, height[a]);
                rightMax = Math.Max(rightMax, height[b]);
                if (leftMax < rightMax)
                {
                    max += (leftMax - height[a]);
                    a++;
                }
                else
                {
                    max += (rightMax - height[b]);
                    b--;
                }
            }

            return max;
        }

        /// <summary>
        /// 实现 num1 * num2
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string Multiply(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;
            int[] product = new int[len1 + len2];

            for (int i = len1 - 1; i >= 0; i--)
            {
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int index = len1 + len2 - i - j - 2;
                    product[index] += (num1[i] - '0') * (num2[j] - '0');
                    product[index + 1] += product[index] / 10;
                    product[index] %= 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = product.Length - 1; i > 0; i--)
            {
                if (sb.Length == 0 && product[i] == 0)
                    continue;
                sb.Append(product[i]);
            }
            sb.Append(product[0]);
            return sb.ToString();
        }
    }
}
