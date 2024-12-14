using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P11_ReverseNodesInKGroup_LC25;

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
    public ListNode ReverseKGroup(ListNode head, int k) {
        // Console.WriteLine(attempt1.tupleTest().a);

        //WATCHED NEETCODE VIDEO WHILE DOING THIS!!
        //SO, USE THAT FOR REFERENCE!!! (Easy but remember the merge sort trick, and how it could apply to problems(like this one))
        //I ALSO HAVE A FEELING THAT DUE TO USING THE NEETCODE SOLUTION WHILE WRITING THIS, I MIGHT NOT BE ABLE TO SOLVE THIS OR A SIMILAR PROBLEM BY MYSELF IN AN INTERVIEW SETTING??
        return attempt1.ReverseKGroup(head, k);
    }
}

//WATCHED NEETCODE VIDEO WHILE DOING THIS!!
public static class attempt1
{
    public static (int a, int b) tupleTest()
    {//THESE ALL WORK!!!
        //Honestly, tested for no reason. (they still work tho!!)
        //Case 1:
        return (0,1);
        //Case 2:
        // return (a: 0,b: 1);
    }
    public static ListNode ReverseKGroup(ListNode head, int k) 
    {
        ListNode dummy = new(-1);
        dummy.next = head;
        ListNode prevGrpTail = dummy;

        //GENERAL TRICK: REMEMBER TO USE WHILE(TRUE) IN YOUR SOLUTIONS UNTIL YOU FIND THE BREAK CONDITION [If it exists and you don't know it already, or just use while(true) if that's more convenient].
        while(true)
        {
            var curTail = getKPlus1thFromNow(prevGrpTail, k);
            if(curTail==null)
                break; //not enough elements for a group of k elements, end of list.
            var nextGrpHead = curTail.next;

            var cur = prevGrpTail.next;
            var prev = nextGrpHead;
            while(cur != nextGrpHead) //IDK why, but this condition, even though extremely easy to come up with, didn't come to me immediately so I just checked the NC .io solution
            {
                var curNext = cur.next;
                cur.next = prev;
                prev = cur;
                cur = curNext;
            }

            //THE ABOVE DOESN'T CHANGE THE NEXT POINTER OF THE TAIL OF THE PREVIOUS GROUP!!!
            //SO WE HANDLE THAT HERE:
            var prevCurHeadNowCurTail = prevGrpTail.next;
            prevGrpTail.next = curTail; //curTail is now curHead (because of above reversing loop)
            prevGrpTail = prevCurHeadNowCurTail;
        }

        return dummy.next;
    }
    // public static void reverseK(ListNode lastElemOfPrevList, int k)
    // {
    //     var head = lastElemOfPrevList.next;
    //     var tail = getKth(curr, k);
    //     lastElemOf
    // }
    public static ListNode getKPlus1thFromNow(ListNode curr, int k)
    {
        while(curr != null && k>0)
        {
            curr = curr.next;
            k--;
        }
        return curr;
    }
}
