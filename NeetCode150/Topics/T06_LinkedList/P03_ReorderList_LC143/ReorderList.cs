using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P03_ReorderList_LC143;

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
    public void ReorderList(ListNode head) {
        //READ MY COMMENTS!!! 
        //Easy but a bit tricky. Just need to know what to do (big picture) and some minor implementation tips/tricks.
        attempt1(head);
    }

    public void attempt1(ListNode head)
    {
        //We can reverse the linkedlist from halfway through.
        //And for odd length, the element in the middle
        //is put at the end, i.e. it remains where it is
        //because only every even element is replaced clearly
        //We could also figure this out by a look at the example and seeing the 3 at the end.
        
        //Step 1: calculate length
        int len = 0;
        var node = head;
        while(node!=null) //The length here is correct because for each non-null node that exists, we add 1 (starting from node=head). It is different from what happens below!
        {
            len++;
            node=node.next;
        }

        //[IMPORTANT] EDGE CASE:
        //I think I thought of this edge case before but decided not to care until I had something?
        if(len<=2)
            return;
        
        
        //Step 2: Go halfway (include the middle element for odd length lists)
        var rightSubHead = head;
        int currLeftLen = 1; //IMP!! WE START AT 1 BECAUSE WE HAVE one ELEMENT ALREADY (head)! Then we increase it as we add more. //Different from the above loop where we calculate len because there we are adding 1 for each element in the loop, but here we consider one of these already finished.
        //currLeftLen being 1 when rightSubHead is 
        //at the 1st position (head), this makes sure that
        //at n, rightSubHead will be at the n-th node!
        int targetLeftLen = (len+1)/2; //e.g. int div of (2+1)/2=1 but (3+1)/2 = 2, and this helps us include exactly the elements we want for both even and odd length
        while(currLeftLen<targetLeftLen) //we go the last element of the target left list before we try getting the right sub-list that we want to reorder and have its elements appended.
        {
            rightSubHead = rightSubHead.next;
            currLeftLen++;
        }
        node = rightSubHead.next; //This is the beginning of the second sub-list. We store it here before we cut the list here.
        rightSubHead.next = null; //we have broken off the list at the middle.
        rightSubHead = node;
        
        //Step 3: Reverse right sublist
        var prevNext = rightSubHead.next;
        rightSubHead.next = null;
        while(prevNext!=null)
        {
            var temp = rightSubHead; //we store the value of the previous node, so we can link it from the current element later.
            rightSubHead = prevNext; //we move rightSubHead to what was the previous next, which is our current element.
            prevNext = rightSubHead.next;//prevNext now contains next of the current element (which is our previousNext)
            rightSubHead.next = temp; //we set the next of our current node to the one that was before it (set above).
        }

        //Step 4: Merge the two sublists in the intended order.
        ListNode l = head, r = rightSubHead;
        while(r!=null) //since we didn't change the left side of the list, we only need to keep going until all the r are inserted (generally, they would only end separately if the original list had odd count so the left list had one extra node, but the left list has its original connections intact until we change it so it is fine to just insert the rs we have)
        {
            var temp = r;
            r=r.next;
            var lOldNext = l.next;
            l.next = temp;
            temp.next = lOldNext;
            l = lOldNext;//obviously.
        }
    }
}
