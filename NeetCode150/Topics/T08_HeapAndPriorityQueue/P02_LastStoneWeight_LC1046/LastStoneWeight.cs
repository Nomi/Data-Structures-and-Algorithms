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
        PriorityQueue<int, int> minHeap = new(stones.Length);
        foreach(int s in stones)
            minHeap.Enqueue(s, -s); // (-s) helps get biggest elements on front!
        while(minHeap.Count>1)
        {
            int bigger = minHeap.Dequeue();
            int smaller = minHeap.Dequeue();
            if(bigger==smaller)
                continue;
            int biggerNewWeight = bigger-smaller;
            minHeap.Enqueue(biggerNewWeight, -biggerNewWeight);
        }
        if(minHeap.Count==0)
            return 0;
        else //==1
            return minHeap.Dequeue();
    }
}
