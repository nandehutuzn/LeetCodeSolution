using System;
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
            var ret1 = Solution2.RemoveNthFormEnd(CreateNode(), 2);
        }

        private static ListNode CreateNode()
        {
            ListNode head = new ListNode(0);

            for (int i = 1; i < 10; i++)
            {
                ListNode node = new ListNode(i);
                var end = head;
                while (end.Next != null)
                    end = end.Next;

                end.Next = node;
            }

            return head;
        }
    }
}
