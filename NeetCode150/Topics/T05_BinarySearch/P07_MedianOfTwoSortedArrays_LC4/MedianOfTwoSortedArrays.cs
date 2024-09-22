using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P07_MedianOfTwoSortedArrays_LC4;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        //My intuition (bruteforce):
        //the bruteforce solution would be O(m+n) with two pointers, one each on nums1 and nums2 which we can use to traverse these as if they were a single sorted array (by checking which pointer is currently at a smaller value and the using that for that iteration)
        //^^This bruteforce might be enough in an interview when followed up with just an explanation of how you would do it in O(log(m+n)) time instead.
        //^^^ ESPECIALLY GIVEN THE EDGECASE CODE (and the code as a whole)
        
        // IMPORTANT NOTES: (try reading the ones with ^ suffix above first!)
        // Just skim through the NeetCode video for a great explanation for the solution!
        return attempt1(nums1, nums2);
    }

    public double attempt1(int[] nums1, int[] nums2) 
    {
        var A = nums1;
        var B = nums2;

        int totalCount = A.Length + B.Length;
        int sizeOfHalves = totalCount/2; //Integer division => decimal is truncated.
        
        //Time complexity: O(log(min(n,m))) //min because we are running binary search on the smaller of the two?
        //We can binary search through B as we can calculate the remaining elements needed for each side after picking both the left and right subarrays for B.
        int l=0, r=A.Length-1;
        while(true) //There's guaranteed to be a median so we can just return from there when we find it!
        {
            int mA = (l+r)/2; //int division => truncate

            //IMPORTANT: sizeOfHalves - (mA+1) 
            //is the remaining length (of the left subarray
            // of B), then we -1 to get it as the index.
            int idxB = (sizeOfHalves - (mA+1))-1; 
            

            //[VERY IMPORTANT]: HANDLING EDGE CASES
            var Aleft = mA>=0 ? A[mA] : int.MinValue;
            var Aright = mA+1<A.Length ? A[mA+1] : int.MaxValue;
            var Bleft = idxB>=0 ? B[idxB] : int.MinValue;
            var Bright = idxB+1<B.Length ? B[idxB+1] : int.MaxValue;

            //Partition is correct:
            if(Aleft<=Bright && Bleft <= Aright)
            {
                if(totalCount%2==1) //odd:
                    return Math.Min(Aright, Bright); //There will never be a case where both will be MaxValue obviously.
                //even:
                return (Math.Max(Aleft,Bleft) + Math.Min(Aright, Bright))/2.0; //Gotta divide by 2.0 (instead of simply 2) to get decimal division
            }
            else if(Aleft>Bleft) //Aleft is too big, meaning we have many elements from B on the left side <=> not enough elements in A on the left side!
                r = mA - 1;
            else //Bleft <= Aright
                l = mA + 1;

        }
    }

}
