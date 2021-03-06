﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode ret1 = Solution2.RemoveNthFormEnd(CreateNode(1), 2);
            bool bl = Solution2.IsValid("([]){}");
            ret1 = Solution2.MergeTwoLists(CreateNode(1), CreateNode(2));
            List<string> list1 = Solution2.GenerateParenthesis(4);
            ret1 = Solution2.SwapPairs(CreateNode(1));
            ret1 = Solution2.ReverseKGroup(CreateNode(1), 3);
            int i1 = Solution2.RemoveDuplicates(new[] { 1, 1, 2, 2, 3 });
            i1 = Solution2.RemoveElement(new[] { 1, 3, 4, 2, 3, 5, 3 }, 3);
            i1 = Solution2.StrStr("hello", "ll0");
            i1 = Solution2.Divide(17, 2);
            i1 = Solution2.LongestValidParentheses(")(())(");
            i1 = Solution2.Search(new[] {  5, 6, 7, 1, 2, 3 ,4}, 3);
            int[] arr1 = Solution2.SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 8);
            i1 = Solution2.SearchInsert(new[] { 1, 2, 3, 4, 6, 7 }, 5);
            string str1 = Solution2.CountAndSay(7);
            var v2 = Solution3.CombinationSum(new[] { 2, 3, 6, 7 }, 7);
            v2 = Solution3.CombinationSum2(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            i1 = Solution3.FirstMissingPositive(new[] { 3, 4, -1,1 });
            i1 = Solution3.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 1, 2, 1, 2, 1 });
            str1 = Solution3.Multiply("25", "25");
        }

        private static ListNode CreateNode(int start)
        {
            ListNode head = new ListNode(0);

            for (; start < 10; start +=2)
            {
                ListNode node = new ListNode(start+2);
                var end = head;
                while (end.Next != null)
                    end = end.Next;

                end.Next = node;
            }

            return head;
        }
    }
}
