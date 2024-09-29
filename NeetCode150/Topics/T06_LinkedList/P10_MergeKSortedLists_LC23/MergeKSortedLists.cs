using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P10_MergeKSortedLists_LC23;

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
    public ListNode MergeKLists(ListNode[] lists) {
        return attempt1.mergeK(lists);
    }
}

public static class attempt1{
    public static ListNode merge2(ListNode head1, ListNode head2) //same as LC easy we did earlier.
    {
        var sortedDummy = new ListNode(-1);
        var n = sortedDummy;
        var n1 = head1;
        var n2 = head2;
        while(n1!=null&&n2!=null)
        {
            if(n1.val<n2.val)
            {
                n.next = n1;
                n1 = n1.next;
            }
            else
            {
                n.next = n2;
                n2 = n2.next;
            }
            n = n.next;
        }
        if(n1!=null)
            n.next = n1;
        else if (n2!=null)
            n.next = n2;
        return sortedDummy.next;
    }

    public static ListNode mergeK(ListNode[] lists)
    {
        //EDGE CASES:
        if(lists==null||lists.Length==0)
            return null;
        
        
        /// DON'T NEED A CASE FOR list.length==1 because of how we do things below!
        // int count = 20; //for debugging!
        while(lists.Length>1)// && count>0)
        {
            // count--;
            // Console.WriteLine($"===== {20-count} =====");
            var mergedLists = new ListNode[(lists.Length+1)/2]; //+1 INSIDE THE ROUND BRACKETS for the odd element out at the end of the list.
            //+1 MUST BE INSIDE THE BRACKETS BECAUSE WE NEED lists COUNT TO BE CORRECT TO MAKE A JUDGEMENT OF WHEN TO LEAVE!! Wrong way: (list.Length/2 +1) IS THE WRONG WAY! 
            //CAUSES INFINITE LOOP: when only 1 element is left, we still get an array of length 2 here, where the second element is null.
            //THEREFORE, we use the formula (lists.Length+1)/2, because it helps us get: (1+1)/2 = 1, (2+1)/2 = 2, (3+1)/2 = 2 [NOTE / IS INTEGER DIVISION, SO IT TURNCATES EVERYTHING AFTER DECIMAL POINT]
            for(int i=0;i<lists.Length;i+=2)
            {
                // Console.WriteLine($"{lists.Length}:{i},{i+1}");
                // string d2 = (i+1)<lists.Length && lists[i+1]!=null? lists[i+1].val.ToString() : "null_BecauseOutOfBound";
                // Console.WriteLine($"(vals: {lists[i].val},{d2})");
                var l1 = lists[i];
                ListNode l2 = (i+1) < lists.Length ? lists[i+1] : null; //null happens when the number of lists is null. We can see that setting it to null doesn't break our merge2 function, which ends up returning l1 itself in this case.
                mergedLists[i/2] = merge2(l1,l2); //i/2 is integer division, meaning it truncates, but that is fine because the array is 0 indexed.
            }
            lists = mergedLists;
        }
        return lists[0];
    }
}
