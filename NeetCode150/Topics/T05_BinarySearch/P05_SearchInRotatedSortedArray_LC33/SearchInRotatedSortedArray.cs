using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P05_SearchInRotatedSortedArray_LC33;

public class Solution {
    public int Search(int[] nums, int target) {
        return attempt1(nums,target);
    }

    public int attempt1HelperFindMinElemIdx(int[] nums)
    {
        //Based on solution of Minimum in Rotated Sorted Array
        int l=0, r=nums.Length-1;
        while(l<r)
        {
            int m = (l+r)/2; //== l + (r-l)/2 = (2l-l+r)/2 = (l+r)/2
            if(nums[m]>nums[r])
                l=m+1;
            else
                r = m;
        }
        return l; //l==r
    }
    public int attempt1(int[] nums, int target)
    {
        int minElemIdx = attempt1HelperFindMinElemIdx(nums);
        int l = minElemIdx, r = minElemIdx+nums.Length-1;
        //we use modulo to pretend we copied the array and pasted it right at the end of it,
        //then we have the full array from l to the above r.
        while(l<=r)
        {
            int m = (l+r)/2; //== l + (r-l)/2 = (2l-l+r)/2 = (l+r)/2
            if(target<nums[m%nums.Length])
                r=m-1;
            else if(target>nums[m%nums.Length])
                l=m+1;
            else // ==
                return (m%nums.Length);
        }
        return -1;
    }
}
