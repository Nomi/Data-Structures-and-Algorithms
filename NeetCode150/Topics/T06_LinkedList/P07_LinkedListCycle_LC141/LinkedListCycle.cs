using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P07_LinkedListCycle_LC141;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public bool HasCycle(ListNode head) {
        //Here's why it works: https://github.com/Chanda-Abdul/Several-Coding-Patterns-for-Solving-Data-Structures-and-Algorithms-Problems-during-Interviews/blob/main/%E2%9C%85%20%20Pattern%2003:%20Fast%20%26%20Slow%20pointers.md
        //You can also check on paper for even and odd lengths.
        return attempt1(head);
    }

    public bool attempt1(ListNode head)
    {
        var fast = head?.next; //Hare
        var slow = head; //Tortoise

        while(fast!=null)
        {
            fast = fast.next?.next;
            slow = slow.next;
            if(fast==slow)
                return true;
        }
        return false;
    }
}
