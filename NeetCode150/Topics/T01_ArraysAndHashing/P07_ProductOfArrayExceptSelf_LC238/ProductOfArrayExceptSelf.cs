using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P07_ProductOfArrayExceptSelf_LC238;

public class Solution {
    // We are given Each product is guaranteed to fit in a 32-bit integer.
    //BUT it might serve as a GREAT CLARIFYING QUESTION!!
    public int[] ProductExceptSelf(int[] nums) {
        // return attempt1(nums);
        return attempt2(nums);
    }

    public int[] attempt1(int[] nums) {
        int[] output = new int[nums.Count()];
        int product = 1; //from right to here
        for(int i=nums.Count()-2;i>=0;i--)//-2 cuz we don't need the product there.
        {
            product*=nums[i+1];
            output[i]=product;
        }
        product = 1;//now from lhs
        for(int i=0;i<nums.Count()-1;i++)
        {
            output[i]=output[i]*product;
            product*=nums[i];
        }
        output[nums.Count()-1]=product;
        return output;
    }


    public int[] attempt2(int[] nums)
    {
        var res = new int[nums.Count()];

        res[0]=1;
        for(int i=1;i<nums.Count();i++) //we fill result array with product of nums from L.H.S (except itself)
        {
            res[i]=res[i-1]*nums[i-1];
        }

        int product = 1;
        for(int i=nums.Count()-1;i>=0;i--) //WE NEED PRODUCT CUZ WE AREN'T STORING THIS PRODUCT ANYWHERE (theoretically we could use nums array for it)
        {
            res[i]*=product;
            product*=nums[i];
        }
        
        return res;
    }
}
