using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P09_LongestConsecutiveSequence_LC128;

public class Solution {
    public int LongestConsecutive(int[] nums) {
        // return attempt1(nums); //READ COMMENTS FROM THIS ONE!
        return attempt2(nums);
    }

    public int attempt1(int[] nums)
    {
        int maxLength = 0;
        //TC - O(N):
        HashSet<int> hs = new(nums);

        //TC - O(N) [because there's N elements in HS and we only go over any sequence once by skipping any non-starting elements.]
        foreach(var n in hs)
        {
            if(hs.Contains(n-1))
                continue; //Not the start of a series. This skipping is the reason the algorithm TC is O(N) and NOT O(N^2)
            
            int length=1;
            int next = n+1;
            while(hs.Contains(next))
            {
                next+=1;
                length++;
            }

            maxLength = length>maxLength ? length : maxLength;
        }

        return maxLength;
    }


    public int attempt2(int[] nums)
    {
        HashSet<int> hs = new(nums);
        
        var maxLength = 0;
        foreach(var num in hs)
        {
            if(hs.Contains(num-1)) //not the starting point of a sequence (an element exists before this).
                continue;
            var length=1;
            var nextNum = num+1;
            while(hs.Contains(nextNum))
            {
                length++;
                nextNum++;
            }
            if(length>maxLength)
                maxLength=length;
        }
        return maxLength;
    }
}
