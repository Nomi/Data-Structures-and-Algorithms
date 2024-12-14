using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P04_KthLargestElementInAnArray_LC215;

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        return attempt1(nums, k);
    }

    //Space complexity: O(K)
    //Time complexity: O(n*log2(k))
    public int attempt1(int[] nums, int k)
    {
        PriorityQueue<int, int> q = new();
        
        int i;
        for(i=0;i<k;i++)
        {
            q.Enqueue(nums[i],nums[i]);
        }
        for(;i<nums.Length;i++)
        {
            if(nums[i]>q.Peek())
            {
                q.Dequeue();
                q.Enqueue(nums[i],nums[i]);
            }
        }
        return q.Peek();
    }
}
