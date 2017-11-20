using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    class LeetCode
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            int[] hashtable = new int[256];

            int i = 0;
            for (i = 0; i < hashtable.Length; i++)
            {
                hashtable[i] = -1;
            }

            int longest = 0;
            int substringStartPosition = 0;
            i = 0;
            while (i < s.Length)
            {
                char c = s[i];
                if (hashtable[c] != -1)
                {
                    longest = System.Math.Max(longest, i - substringStartPosition);

                    for (int j = substringStartPosition; j < hashtable[c]; j++)
                    {
                        hashtable[s[j]] = -1;
                    }

                    substringStartPosition = hashtable[c] + 1;
                }

                hashtable[c] = i;
                ++i;
            }

            return Math.Max(longest, i - substringStartPosition);
        }

        public static int Reverse(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int tail = x % 10;
                int newResult = result * 10 + tail;

                if ((newResult - tail) / 10 != result)
                    return 0;
                result = newResult;
                x = x / 10;
            }
            return result;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1?.Length == 0 || nums2?.Length == 0)
                return 0;

            return (FindMedianSortedArrays(nums1) + FindMedianSortedArrays(nums2)) / 2.0;
        }

        private static double FindMedianSortedArrays(int[] nums1)
        {
            int length = nums1.Length;
            if (length % 2 == 0)
            {
                return (nums1[length / 2 - 1] + nums1[length / 2]) / 2.0;
            }
            else
                return nums1[(length) / 2];
        }

        public static string LongestPalindrome(string s) //  "gjafsaef" -> "fsaef"
        {
            int[] hashtable = new int[256];
            for (int i = 0; i < 256; i++)
            {
                hashtable[i] = -1;
            }

            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (hashtable[s[i]] != -1)
                {
                    string sub = s.Substring(hashtable[s[i]], i - hashtable[s[i]] + 1);
                    if (result.Length < sub.Length)
                        result = sub;
                }
                hashtable[s[i]] = i;
            }

            return result;
        }

        public static int MyAtoi(string str)  //字符串转整形  "123456" -> 123456
        {
            int index = 0, sign = 1, total = 0;

            if (string.IsNullOrEmpty(str)) return 0;

            while (str[index] == ' ' && index < str.Length)
                index++;

            if (str[index] == '+' || str[index] == '-')
            {
                sign = str[index] == '+' ? 1 : -1;
                index++;
            }

            while (index < str.Length)
            {
                int digit = str[index] - '0';
                if (digit < 0 || digit > 9) break;

                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                    return sign == 1 ? int.MaxValue : int.MinValue;

                total = 10 * total + digit;
                index++;
            }

            return total * sign;
        }

        public static bool IsPalindrome(int x)  //是否为回文
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;

            int rev = 0;
            while (x > rev)
            {
                rev = rev * 10 + x % 10;
                x = x / 10;
            }

            return (x == rev || x == rev / 10);
        }

        /* 字符串匹配  '.'匹配单个字符   '*'匹配任意字符
         * Some examples:
            isMatch("aa","a") → false
            isMatch("aa","aa") → true
            isMatch("aaa","aa") → false
            isMatch("aa", "a*") → true
            isMatch("aa", ".*") → true
            isMatch("ab", ".*") → true
            isMatch("aab", "c*a*b") → true
         */
        public static bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
                return false;

            if (p[0] == '*') return true;

            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;

            for (int i = 0; i < p.Length; i++)
            {

                if (p[i] == '*' && dp[0, i - 1])
                {
                    dp[0, i + 1] = true;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '.')
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    if (p[j] == s[i])
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    if (p[j] == '*')
                    {
                        if (p[j - 1] != s[i] && p[j - 1] != '.')
                        {
                            dp[i + 1, j + 1] = dp[i + 1, j - 1];
                        }
                        else
                        {
                            dp[i + 1, j + 1] = (dp[i + 1, j] || dp[i, j + 1] || dp[i + 1, j - 1]);
                        }
                    }
                }
            }

            return dp[s.Length, p.Length];
        }

        /// <summary>
        /// 数组值非负，作为y轴值，索引为x轴值，返回任意两个值与x轴组成的池子装水最大量
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int maxArea = 0;
            while (left < right)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[left], height[right]) * (right - left));
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }

        /// <summary>
        /// 将整形数字转为罗马数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] strs = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(strs[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 查找字符串数组中最长公共前缀
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommandPrefix(string[] strs)
        {
            if (strs?.Length == 0)
                return null;
            string commandPrefix = strs[0];
            int i = 0;
            while (i < strs.Length)
            {
                while (strs[i].IndexOf(commandPrefix) != 0)
                    commandPrefix = commandPrefix.Substring(0, commandPrefix.Length - 1);

                i++;
            }

            return commandPrefix;
        }

        /*
         * For example, given array S = [-1, 0, 1, 2, -1, -4],

            A solution set is:
            [
                [-1, 0, 1],
                [-1, -1, 2]
            ]
        */
        public static List<List<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> res = new List<List<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || i > 0 && nums[i] != nums[i - 1])
                {
                    int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                    while (lo < hi)
                    {
                        if (nums[lo] + nums[hi] == sum)
                        {
                            res.Add(new List<int> { nums[i], nums[lo], nums[hi] });

                            while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                            while (lo < hi && nums[hi] == nums[hi - 1]) hi--;

                            lo++;
                            hi--;
                        }
                        else
                            hi--;
                    }
                }
            }


            return res;
        }

        //给定数组中找出三个数，使得和最接近target
        /*
         * For example, given array S = {-1 2 1 -4}, and target = 1.

            The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        */
        public static int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int start = i + 1, end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];
                    if (sum > target)
                        end--;
                    else
                        start++;

                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                        result = sum;
                }
            }

            return result;
        }

        // 给定一个数字字符串，返回根据对应手机按键上所有可能字符串组合
        /*
         * Input:Digit string "23"
            Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
        */
        public static List<string> LetterCombinations(string digits)
        {
            Queue<string> result = new Queue<string>();
            string[] mapping = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            result.Enqueue("");
            for (int i = 0; i < digits.Length; i++)
            {
                int x = digits[i] - '0';
                while (result.Peek().Length == i)
                {
                    string t = result.Dequeue();
                    for (int j = 0; j < mapping[x].Length; j++)
                    {
                        result.Enqueue(t + mapping[x][j]);
                    }
                }
            }

            return result.ToList();
        }

        //从给定数组中选出四个数，和为target
        /*
         * For example, given array S = [1, 0, -1, 0, -2, 2], and target = 0.

            A solution set is:
            [
                [-1,  0, 0, 1],
                [-2, -1, 1, 2],
                [-2,  0, 0, 2]
            ]
        */
        public static List<List<int>> FourSum(int[] nums, int target)
        {
            List<List<int>> res = new List<List<int>>();
            if (nums?.Length < 4) return res;

            Array.Sort(nums);

            int len = nums.Length;
            int max = nums[len - 1];
            if (4 * nums[0] > target || 4 * max < target)
                return res;

            int i, z;
            for (i = 0; i < len; i++)
            {
                z = nums[i];
                if (i > 0 && z == nums[i - 1]) continue;

                if (z + 3 * max < target) continue;

                if (4 * z > target) break;

                if (4 * z == target)
                {
                    if (i + 3 < len && nums[i + 3] == z)
                        res.Add(new List<int> { z, z, z, z });
                    break;
                }

                ThreeSumForFourSum(nums, target - z, i + 1, len - 1, res, z);
            }

            return res;
        }

        private static void ThreeSumForFourSum(int[] nums, int target, int low, int high, List<List<int>> fourSumList, int z1)
        {
            if (low + 1 >= high)
                return;

            int max = nums[high];
            if (3 * nums[low] > target || 3 * max < target)
                return;

            int i, z;
            for (i = low; i < high - 1; i++)
            {
                z = nums[i];
                if (i > low && z == nums[i - 1]) continue;

                if (z + 2 * max < target) continue;

                if (3 * z > target) break;

                if (3 * z == target)
                {
                    if (i + 1 < high && nums[i + 2] == z)
                        fourSumList.Add(new List<int> { z1, z, z, z });
                    break;
                }

                TwoSumFourSum(nums, target - z, i + 1, high, fourSumList, z1, z);
            }
        }

        private static void TwoSumFourSum(int[] nums, int target, int low, int high, List<List<int>> fourSumList, int z1, int z2)
        {
            if (low >= high) return;

            if (2 * nums[low] > target || 2 * nums[high] < target) return;

            int i = low, j = high, sum, x;
            while (i < j)
            {
                sum = nums[i] + nums[j];
                if (sum == target)
                {
                    fourSumList.Add(new List<int> { z1, z2, nums[i], nums[j] });

                    x = nums[i];
                    while (++i < j && x == nums[i]) ;

                    x = nums[j];
                    while (i < --j && x == nums[j]) ;
                }

                if (sum < target) i++;

                if (sum > target) j--;
            }
        }
    }
}
