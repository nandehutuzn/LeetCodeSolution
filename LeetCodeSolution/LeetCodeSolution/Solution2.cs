using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class Solution2
    {
        /// <summary>
        /// 移除链表中倒数第n个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFormEnd(ListNode head, int n)
        {
            ListNode headNode = new ListNode(9527);
            headNode.Next = head;

            ListNode fastNode = headNode;
            ListNode slowNode = headNode;
            while (fastNode.Next != null)
            {
                if (n <= 0) //找到倒数第n+1个节点
                    slowNode = slowNode.Next;
                fastNode = fastNode.Next;
                n--;
            }
            if (slowNode.Next != null) //移除倒数第n个节点
                slowNode.Next = slowNode.Next.Next;

            return headNode.Next;
        }

        /*
         Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

         The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
        */
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, int> leftDic = new Dictionary<char, int>();
            leftDic.Add('(', 0); //值为 对应')'在数组中的索引 
            leftDic.Add('[', 1);
            leftDic.Add('{', 2);
            char[] rights = { ')', ']', '}' };

            for (int i = 0; i < s.Length; i++)
            {
                if (leftDic.Keys.Contains(s[i]))
                    stack.Push(s[i]);
                else if (rights.Contains(s[i]))
                {
                    char left = stack.Pop();
                    
                    if (rights[leftDic[left]] != s[i])
                        return false;
                }
            }

            if (stack.Count == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 拼接两个已排序的链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.Val < l2.Val)
            {
                l1.Next = MergeTwoLists(l1.Next, l2);
                return l1;
            }
            else
            {
                l2.Next = MergeTwoLists(l1, l2.Next);
                return l2;
            }
        }

        /*
         * 对给定的n对()， 生成所有的()组合 ，例如：
         * [
                "((()))",
                "(()())",
                "(())()",
                "()(())",
                "()()()"
            ]
        */
        public static List<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            BackTrack(list, "", 0, 0, n);
            return list;
        }

        private static void BackTrack(List<string> list, string str, int open, int close, int max)
        {
            if (str.Length == max * 2)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                BackTrack(list, str + "(", open + 1, close, max);
            if (close < open)
                BackTrack(list, str + ")", open, close + 1, max);
        }

        /// <summary>
        /// 对n条有序链表合并成一条
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            return Partion(lists, 0, lists.Length - 1);
        }

        private static ListNode Partion(ListNode[] lists, int s, int e)
        {
            if (s == e) return lists[s];

            if (s < e)
            {
                int q = (s + e) / 2;
                ListNode l1 = Partion(lists, s, q);
                ListNode l2 = Partion(lists, q + 1, e);
                return MergeTwoLists(l1, l2);
            }
            else
                return null;
        }

        /// <summary>
        /// 对于给定的一个链表，交换每两个相邻的节点，如 ：Given 1->2->3->4, you should return the list as 2->1->4->3.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.Next == null) return head;
            ListNode n = head.Next;

            head.Next = SwapPairs(head.Next.Next);
            n.Next = head;

            return n;
        }

        /*
        Given this linked list: 1->2->3->4->5

        For k = 2, you should return: 2->1->4->3->5

        For k = 3, you should return: 3->2->1->4->5
        */
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            {
                curr = curr.Next;
                count++;
            }

            if (count == k)
            {
                curr = ReverseKGroup(curr, k);
                while (count-- > 0)
                {
                    ListNode tmp = head.Next;
                    head.Next = curr;
                    curr = head;
                    head = tmp;
                }
                head = curr;
            }

            return head;
        }

        /// <summary>
        /// 给定一个已排序的数组，删除重复的元素，返回新数组长度，注意：在原数组上操作
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != nums[j])
                    nums[++j] = nums[i];
            }
            return ++j;
        }

        /// <summary>
        /// 给定一个数组和 一个值，删除该值在数组中的元素，返回新数组的长度
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j++] = nums[i];
                }
            }
            return j;
        }

        /* 实现 IndexOf
         * Example 1:
                Input: haystack = "hello", needle = "ll"
                Output: 2

            Example 2:
                Input: haystack = "aaaaa", needle = "bba"
                Output: -1
        */
        public static int StrStr(string haystack, string needle)
        {
            for (int i = 0; ; i++)
            {
                for (int j = 0; ; j++)
                {
                    if (j == needle.Length) return i;

                    if (i + j == haystack.Length) return -1;

                    if (needle[j] != haystack[i + j]) break;
                }
            }
        }

        /// <summary>
        /// 实现除法
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static int Divide(int dividend, int divisor)
        {
            long result = DivideLong(dividend, divisor);
            return result > int.MaxValue ? int.MaxValue : (int)result;
        }

        private static long DivideLong(long dividend, long divisor)
        {
            bool negative = dividend < 0 != divisor < 0;

            if (dividend < 0) dividend = -dividend;
            if (dividend < 0) divisor = -divisor;

            if (dividend < divisor) return 0;

            long sum = divisor;
            long divide = 1;
            while ((sum + sum) <= dividend)
            {
                sum += sum;
                divide += divide;
            }

            return negative ? -(divide + DivideLong((dividend - sum), divisor)) : (divide + DivideLong((dividend - sum), divisor));
        }

        /*  给定字符串s只包含‘(’和')',找出有效的最长长度括号
         *   "()", which has length = 2.

                Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4
        */
        public static int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int max = 0;
            int left = -1;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '(') stack.Push(j);
                else
                {
                    if (stack.Count == 0) left = j;
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0) max = Math.Max(max, j - left);
                        else max = Math.Max(max, j - stack.Peek());
                    }
                }
            }

            return max;
        }

        /* 在给定数组中找出 target值得索引，未找到返回-1
         * 
         * 该数组由一组按升序排列好的数字截断成两组，调换顺序而成
         * [0,1,2,3,4,5,6,7] become [4,5,6,7,0,1,2]
         */
        public static int Search(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] == target) return mid;

                if (nums[lo] <= nums[mid])
                {
                    if (target >= nums[lo] && target < nums[mid])
                        hi = mid - 1;
                    else
                        lo = mid + 1;
                }
                else
                {
                    if (target > nums[mid] && target <= nums[hi])
                        lo = mid + 1;
                    else
                        hi = mid - 1;
                }
            }

            return nums[lo] == target ? lo : -1;
        }

        /* 给定一个升序排列数组，找出数组中target值得起始位置及结束位置  ,找不到返回[-1,-1]
         * For example,
                Given [5, 7, 7, 8, 8, 10] and target value 8,
                return [3, 4].
        */
        public static int[] SearchRange(int[] nums, int target)
        {
            int lo = 0, hi = nums.Length - 1;
            int index = -1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] == target)
                {
                    index = mid;
                    break;
                }

                else if (nums[mid] < target)
                    lo = mid + 1;
                else
                    hi = mid - 1;

            }
            if (index == -1) return new[] { -1, -1 };
            int left,right;
            left = right = index;
            while (left >= 0 && nums[left] == target) left--;
            while (right <= nums.Length - 1 && nums[right] == target) right++;

            return new[] { ++left, --right };
        }
    }
}
