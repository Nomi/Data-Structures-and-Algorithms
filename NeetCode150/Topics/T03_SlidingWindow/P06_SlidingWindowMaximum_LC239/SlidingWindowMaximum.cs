using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T03_SlidingWindow.P06_SlidingWindowMaximum_LC239;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        //Number of windows is obviously = 1+nums.Count()-k
        int[] output = new int[nums.Count()-k+1];
        var q = new LinkedList<int>();
        int l=0, r=0;
        int windowIdx=0;
        while(r<nums.Length)
        {
            //We check and remove from last because
            //e.g. the first element(maximum) is equal to the new 
            //element, so to keep position correct, we remove 
            //every value we met after that 
            //      (all smaller to it, and if there's
            //      another duplicate, those will be 
            //      right at the beginning because it has to 
            //      be max number by definition of monotonically
            //      increasing queue.)
            // and then later add the next instance of that number
            // to the deque. If new number is greater, then we
            // can just empty the dequeue (simulated by Linkedlist);
            while(q.Count!=0&&q.Last.Value<nums[r]) //To keep it a monotonically decreasing queue, we remove all elements smaller than this.
                q.RemoveLast();
            //Add last because nums[r] can possibly be:
            // 1. equal to first/largest element, in which case order doesn't matter (we cleared out any smaller numbers before it already).
            // 2. was bigger than the earlier largest element, which was removed earlier. (queue is empty).
            // 3. smaller, in which case we need to add it at end to keep monotonically increasing nature.
            q.AddLast(nums[r]);
            if(r-l+1==k) //Window is complete
            {
                //Note that first element of q is the 
                //largest element in this window.

                output[windowIdx]=q.First.Value;
                if(nums[l]==q.First.Value) //if the first element of the window (i.e. at nums[l]) is the same as the number we just removed, it is guaranteed to be that element and not affect any further calculations because even if we encounter a duplicate after that, we have stored them directly after it.
                    q.RemoveFirst();
                l++;
                windowIdx++;
            }
            r++;
        }
        return output;
    }
}
