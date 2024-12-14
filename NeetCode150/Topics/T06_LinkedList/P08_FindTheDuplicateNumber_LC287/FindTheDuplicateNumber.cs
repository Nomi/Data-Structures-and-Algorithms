using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P08_FindTheDuplicateNumber_LC287;

public class Solution {
    public int FindDuplicate(int[] nums) {
        //[IMPORTANT] WATCH NEETCODE VIDEO FOR THIS !!!!!
        return attempt1(nums);   
    }

    public int attempt1(int[] nums)
    {
        //NOTE: I'm only addding light comments. Watch Neetcode video for full explanation..
        //Clearly, we can treat it like a linked list.
        //Clearly, the start of a cycle would be one where are two arrows or more arrays to it. 
        //Therefore, the start of the cycle is the duplicate element.
        //Cuz we treat values in the array as the value of each node,
        //And the array is treated like a map from the current value (as an indice) to the next element (the value in the array).


        //Cycle can't start at 0 because we are guaranteed values are from 1-n, so no element points to 0.
        int slow = 0;
        int fast = 0;

        //finding where fast and slow intersect.
        do
        {
            slow = nums[slow]; //next
            fast = nums[nums[fast]]; //next-next
        }
        while(slow!=fast);


        //We get another pointer at the beginning (call it slow2) 
        //and we check when this pointer intersects with slow.
        //That point will be the start of the cycle (there are Mathematical proofs for this).
        //It is known as Floyd's Tortoise and Hare Cycle detection algorithm. (ALSO USEFUL FOR DETECTING WHERE CYCLES START)
        var slow2 = 0;
        while(slow!=slow2)
        {
            slow = nums[slow];
            slow2 = nums[slow2];
        }

        //"slow"/"slow2", not "nums[slow]"/"nums[slow2]",
        //because slow is the linked list node that is the beginning of the cycle! (the one that's repeating as explained above).
        //as when nums[slow] == nums[slow2] are the same, it means the we reached the node with more than 1 arrow.
        //as such, since slow and slow2 store these values from prior iteration, when we get here slow2 == slow == previousnumsatslow/slow2.
        return slow;
    }
}
