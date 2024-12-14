using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P01_ReverseLinkedList_LC206;

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
    public ListNode ReverseList(ListNode head) {
        return attempt1(head);
    }

    public ListNode attempt1(ListNode head) 
    {
        if(head==null)
            return null;
        var prevNext = head.next;
        var prev = head;
        prev.next = null;
        while(prevNext!=null)
        {
            var temp = prevNext.next;
            prevNext.next = prev;
            prev = prevNext;
            prevNext = temp;
        }
        return prev;
    }
}
