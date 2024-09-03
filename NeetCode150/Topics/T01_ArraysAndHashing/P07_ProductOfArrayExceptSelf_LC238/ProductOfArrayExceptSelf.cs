using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P07_ProductOfArrayExceptSelf_LC238;

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
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
}
