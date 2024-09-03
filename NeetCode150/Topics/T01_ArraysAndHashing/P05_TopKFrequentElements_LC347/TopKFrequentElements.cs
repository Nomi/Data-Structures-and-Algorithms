using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P05_TopKFrequentElements_LC347;

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // var minHeap = new PriorityQueue<Tuple<int,int>>(Comparer<Tuple<int,int>>.Create((a,b)=>b.Item2-a.Item2)); 
        var minHeap = new PriorityQueue<Tuple<int,int>,int>(Comparer<int>.Create((a,b)=>a-b));
        var freqMap = new Dictionary<int,int>();
        foreach(var num in nums)
        {
            freqMap.TryAdd(num,0);
            freqMap[num]++;
        }
        foreach(var key in freqMap.Keys)
        {
            if(minHeap.Count==k)
            {
                if(minHeap.Peek().Item2<freqMap[key])
                    minHeap.Dequeue();
                else
                    continue;
            }
            minHeap.Enqueue(Tuple.Create(key,freqMap[key]), freqMap[key]);
        }
        var res = new int[minHeap.Count];
        int i=0;
        while(minHeap.Count>0)
        {
            res[i]=minHeap.Dequeue().Item1;
            i++;
        }
        return res;
    }
}
