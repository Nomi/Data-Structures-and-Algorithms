using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P05_TopKFrequentElements_LC347;

public class Solution {
    //WHERE MY BUCKET SORT (frequency based buckets) AT????

    //Bruteforce: TC = O(nlog(n))
    //
    //MaxHeap: TC = O(n+klog(n)) (at the end you just pop k times after heapifying in linear time using heapify)
    //         SC = O(n)=O(n)
    //
    //MinHeap(best SC): 
    //         TC = O(nlog(k)), where n is the number of elements in nums 
    //         SC = O(k)
    //BucketSort(best TC):  
    //             TC= O(n)
    //             SC = O(n) 
    //FUCK QUICKSELECT, BUCKETSORT BETTER
    public int[] TopKFrequent(int[] nums, int k) {
        //INSTEAD OF MINHEAP WE USE BUCKETSORT (not even LeetCode's stupid quickselect can beat it)

        //return BucketSort(nums, k);
        // return MinHeapAttempt(nums, k);
        ///* can also do maxheap, which will decrease time complexity when used with heapify (heapify is O(N) when we the data is pre-existing) so we can just pop k elements. */
        ///* minheap decreases the spacecomplexity by making sure there's only at most k elements in the heap at any given time. */


        // ===== PRACTICE FROM HERE: =====
        return bs2(nums,k);
    }

    // public int[] BucketSort(int[] nums, int k)
    // {
    //     List<int>[] freqToNums = new List<int>[nums.Count()+1]; //+1 as the biggest frequency is nums.Count() itself (because possible frequencies are IN [0,nums.Count()])!
    //     var freqMap = new Dictionary<int,int>();
    //     foreach(var num in nums)
    //     {
    //         freqMap.TryAdd(num,0);
    //         freqMap[num]++;
    //     }
    //     foreach(var key in freqMap.Keys) //key is the value
    //     {
    //         if(freqToNums[freqMap[key]]==null)
    //             freqToNums[freqMap[key]]=new();
    //         freqToNums[freqMap[key]].Add(key);
    //     }
    //     int countAdded = 0;
    //     int[] res = new int[k];
    //     for(int i=freqToNums.Count()-1;i>=0&&countAdded<k;i--)
    //     {
    //         for(int j=0;freqToNums[i]!=null&&j<freqToNums[i].Count&&countAdded<k;j++)
    //         {
    //             res[countAdded]=(freqToNums[i][j]);
    //             countAdded++;
    //         }
    //     }
    //     return res;
    // }
    // public int[] QuickSelect(int[] nums, int k)
    // {

    // }

    // public int[] MinHeapAttempt(int[] nums, int k)
    // {
    //     // var minHeap = new PriorityQueue<Tuple<int,int>>(Comparer<Tuple<int,int>>.Create((a,b)=>b.Item2-a.Item2)); 
    //     var minHeap = new PriorityQueue<Tuple<int,int>,int>(Comparer<int>.Create((a,b)=>a-b));
    //     var freqMap = new Dictionary<int,int>();
    //     foreach(var num in nums)
    //     {
    //         freqMap.TryAdd(num,0);
    //         freqMap[num]++;
    //     }
    //     foreach(var key in freqMap.Keys)
    //     {
    //         if(minHeap.Count==k)
    //         {
    //             if(minHeap.Peek().Item2<freqMap[key])
    //                 minHeap.Dequeue();
    //             else
    //                 continue;
    //         }
    //         minHeap.Enqueue(Tuple.Create(key,freqMap[key]), freqMap[key]);
    //     }
    //     var res = new int[minHeap.Count];
    //     int i=0;
    //     while(minHeap.Count>0)
    //     {
    //         res[i]=minHeap.Dequeue().Item1;
    //         i++;
    //     }
    //     return res;
    // }


    public int[] bs2(int[] nums, int k)
    {
        int maxFreq = nums.Count(); //max possible frequency (when array only has 1 element)
        List<int>[] freqBuckets = new List<int>[maxFreq+1]; //+1 is for 0 frequency, which technically isn't needed, but makes indexing easier.
        Dictionary<int, int> numToFreq = new();
        foreach(var num in nums)
        {
            numToFreq.TryAdd(num,0);
            numToFreq[num]++;
        }
        foreach(var num in numToFreq.Keys)
        {
            if(freqBuckets[numToFreq[num]]==null)
                freqBuckets[numToFreq[num]]=new();
            freqBuckets[numToFreq[num]].Add(num);
        }
        var result = new int[k];
        int count = 0;
        for(int i=freqBuckets.Count()-1;i>=0&&count<k;i--)
        {
            if(freqBuckets[i]==null)
                continue;
            foreach(var num in freqBuckets[i])
            {
                result[count]=num;
                count++;
                if(count==k)
                    break;
            }
        }
        return result;
    }
}
