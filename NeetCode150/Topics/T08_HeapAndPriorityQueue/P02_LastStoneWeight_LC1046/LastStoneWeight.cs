using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P02_LastStoneWeight_LC1046;

public class Solution {
    public int LastStoneWeight(int[] stones) {
        return Attempt1.LastStoneWeight(stones);
    }
}

public static class Attempt1
{
    public static int LastStoneWeight(int[] stones) 
    {
        PriorityQueue<int, int> pQ = new(stones.Length);
        foreach(int s in stones)
            pQ.Enqueue(s, -s); // (-s) helps get biggest elements on front!
        while(pQ.Count>1)
        {
            int bigger = pQ.Dequeue();
            int smaller = pQ.Dequeue();
            if(bigger==smaller)
                continue;
            int biggerNewWeight = bigger-smaller;
            pQ.Enqueue(biggerNewWeight, -biggerNewWeight);
        }
        if(pQ.Count==0)
            return 0;
        else //==1
            return pQ.Dequeue();
    }
}
