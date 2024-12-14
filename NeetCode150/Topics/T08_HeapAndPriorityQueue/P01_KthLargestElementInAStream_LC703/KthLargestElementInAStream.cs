using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P01_KthLargestElementInAStream_LC703;

public class KthLargest {
    Attempt1 atmpt1;
    public KthLargest(int k, int[] nums) {
        atmpt1 = new(k, nums);
    }
    
    public int Add(int val) {
        return atmpt1.Add(val);
    }
}


public class Attempt1
{
    PriorityQueue<int,int> pQ;
    int k;

    public Attempt1(int _k, int[] nums)
    {
        k=_k;
        pQ = new(k+1);
        foreach(int n in nums)
        {
            Add(n); //AddWithoutPeek(n);
        }
    }
    
    public int Add(int val) 
    {
        //If you look at the algorithm, you'll realize that this algorithm basically stores the k biggest numbers, 
        //with the first one being the smallest and the last one being the largest!
        pQ.Enqueue(val, val);
        if(pQ.Count>k)
            pQ.Dequeue();
        return pQ.Peek();
    }
}