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
                if (n <= 0)
                    slowNode = slowNode.Next;
                fastNode = fastNode.Next;
                n--;
            }
            if (slowNode.Next != null)
                slowNode.Next = slowNode.Next.Next;

            return headNode.Next;
        }
    }
}
