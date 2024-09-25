using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P04_RemoveNthNodeFromEndOfList_LC19;

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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        return attempt1(head, n);
    }



    public ListNode attempt1(ListNode head, int n)
    {

        //[ ! ! ! IMPORTANT ! ! ! ] 
        // ENABLES HANDLING OF THE EDGE CASE
        // WHERE WE DELETE THE HEAD ITSELF!
        ListNode dummy = new ListNode(-1, head); //Dummy node to store the result  
        
        //First, let's get a pointer to the (n+1)th element FROM THE FRONT
        var nPlus1ThElemFromFront = head;
        int pos = 1;
        while(pos<=n)
        {
            nPlus1ThElemFromFront = nPlus1ThElemFromFront.next;
            pos++;
        }
        
        //Now, notice that the difference in position (distance) between head (1st element) and the (n+1)th element is n. So, let
        ListNode l = dummy, r = nPlus1ThElemFromFront; //NOTICE THAT l=dummy HELPS US WITH THE CASE WHERE WE'RE DELETING THE HEAD.
        //From earlier comment, we can see that the distance between the l.next and r is n.
        //Therefore, we can see that if we keep incrementing l and r together at the same time,
        //when r is at the last element, l.next will be n+1 elements before that.
        //Which also means, that when you include the last element, 
        //l.next is the n+1-th element from the end of the list (null).

        //To make it handle the new l = dummy based approach for the edge case where we're deleting the head,
        // we should just check r!=null, because when r=null (the end of the list), the distance of
        // l.next from the end of the list is n and the distance of l from the end of the list is n+1.
        // Which is what we need. 
        while(r!=null)
        {
            l=l.next;
            r=r.next;
        }
        // Console.WriteLine(l?.val);
        // Console.WriteLine(r?.val);
        // Console.WriteLine(l?.next?.val);
        // Console.WriteLine(l?.next?.next?.val);

        //as discussed above, l is the n+1-th element fromt he end of the list.
        var lNextNext = l?.next?.next;//this is the n-1-th element from the end of the list.
        l.next = lNextNext; //this removes the reference to the n-th node from the end and as such the garbage collector will eventually clean it up.
        
        return dummy.next;
    }
}
