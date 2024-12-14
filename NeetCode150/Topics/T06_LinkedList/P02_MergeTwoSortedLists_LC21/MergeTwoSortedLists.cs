using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P02_MergeTwoSortedLists_LC21;

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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        //ONLY REALLY USEFUL TO REVIEW FOR THE NIFTY TRICKS
        //IT USES! (marked by the comment "//NIFTY!" )
        return attempt1(list1, list2);
    }

    public ListNode attempt1(ListNode list1, ListNode list2)
    {
        var dummy = new ListNode(-1); //NIFTY!
        var node = dummy;

        while(list1!=null && list2!=null) //NIFTY! //earlier I had || instead of && and a bunch of if conditions inside the loop! Clearly this is better (check the part after the loop for where we put it when one of them runs out!)
        {
            if(list1.val<=list2.val)
            {
                node.next = list1;
                list1=list1.next;
            }
            else
            {
                node.next = list2;
                list2=list2.next;
            }
            node = node.next;
        }

        if(list1!=null) //NIFTY!
            node.next = list1;
        else //list2 may or may not be null but result will still be fine cuz last element's next should be null anyway.
            node.next = list2;
            
        return dummy.next;
    }
}