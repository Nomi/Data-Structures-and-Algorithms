using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P06_AddTwoNumbers_LC2;

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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return attempt1(l1, l2);
    }

    public ListNode attempt1(ListNode l1, ListNode l2)
    {
        ListNode dummy = new(-1);
        var node = dummy;
        bool isCarry = false;
        while(l1!=null || l2!=null || isCarry) //IMPORTANT: ALMOST FORGOT ABOUT isCarry NEEDING TO BE HERE!!! BE CAREFUL!!!
        {
            // Console.WriteLine(l1?.val); Console.WriteLine(l2?.val); Console.WriteLine(isCarry);
            int currSum = 0;
            if(l1!=null)
                currSum+=l1.val;
            if(l2!=null)
                currSum+=l2.val;
            if(isCarry)
            {
                currSum+=1;
                isCarry = false;
            }
            isCarry = (currSum>9); //notice that the biggest that carry can ever be is 1. (because max sum of any two digit is 9+9+1(carry)=19)
            if(isCarry)
                currSum -= 10; //notice how this gives us the number we need in the current place (check comment above for information on why)
            node.next = new(currSum);
            node = node.next;
            Console.WriteLine(node.val);

            //Forgot this earlier:
            l1 = l1?.next; //Need the ?. to concisely handle the case where it might be l1 might be null
            l2 = l2?.next; //Need the ?. to concisely handle the case where it might be l2 might be null
        }
        return dummy.next;
    }
}
