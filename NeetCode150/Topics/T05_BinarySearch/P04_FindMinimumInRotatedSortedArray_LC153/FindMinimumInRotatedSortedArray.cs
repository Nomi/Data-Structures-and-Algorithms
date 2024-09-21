using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P04_FindMinimumInRotatedSortedArray_LC153;

public class Solution {
    public int FindMin(int[] nums) {
        //SINCE WE HAVE SORTED INPUT (almost)
        //AND WE ARE LOOKING FOR AN O(log(n)) solution,
        //IT MUST BE LOOKING FOR BINARY SEARCH!

        //Greg Hogg's solution (better than NeetCode's)
        return attempt1(nums);  //READ THE COMMENTS!

        //Check NeetCode's solution as well as that might be useful for other problems as well (e.g. Search in Rotated Sorted Array)
        
    }
    public int attempt1(int[] nums)
    {
        //My observations:
        //Clearly, we can identify max when the next element is smaller than current.
        //Clearly, the min element will be right after the max one.
        //(Could also do it the other way around, I guess.)

        //Greg Hogg's solution: (better than NeetCode's tbh):
        //Example: First mid in [3,4,5,6,1,2] is 5.
        //Then from 5>2 and input being sorted increasing order (not mid/5 because it is already bigger than at least 1 element (2))
        //=> that there is break in the order somewhere 
        //to the right (the pivot from maximum element to minumum element)
        //Then, we move left ptr to 6, and similarly, we get l to 1.
        //Then, since 2 is bigger than 1, it means order is preserverd so no pivot is present.
        //Therefore, it is somewhere between left to mid (COULD be mid too, because we haven't seen a bigger element here unlike in the first case)
        

        //At l==r we have our solution because our loop works as follows:
        // -> every one to the left of it had a smaller element on the right.
        // -> every one to its right had a number smaller than them on the left.
        //So, when we get l==r, it meets the above criteria which is the criteria for being a minimum.
        //To get the max you either do the opposite or return the element before this one.
        int l = 0, r = nums.Length-1;
        while(l<r)
        {
            int m = l+(r-l)/2;
            //Console.WriteLine($"l:{l},r:{r},m:{m},numAtM:{nums[m]},numAtR:{nums[r]}");
            if(nums[m]>nums[r]) //it means the pivot is towards the right subarray.
                l = m+1;
            else //otherwise, pivot must be in the left subarray.
                r = m; //m could still be max so we don't -1
            //The above else block only triggers when number is strictly lesser. This is because the numbers are guaranteed to be unique.
        }
        //AT l==r, we have our solution (we can return either nums[l] or nums[r])!
        return nums[l];


        //OLD TRY:
        //Clearly, we can identify max when the next element is smaller than current.
        //Clearly, the min element will be right after the max one.
        //(Could also do it the other way around, I guess.)
        //This is to be done via using the modulo (%) operator to avoid going out of bounds of array.

        // int l=0, r=(2*nums.Length)-1; 
        // //^^ SHOUTOUT TO NeetCode'S SHORTS!
        // // I JUST RANDOMLY REMEMBERED SEEING THIS IN ONE OF HIS VIDEOS AFTER BANGING MY HEAD AGAINST THE WALL FOR 15 MINUTES NOW!
        // // WE USE THIS TO MIRROR THE ARRAY (alongside the use of a modulo)
        // // THEN WE CAN PRETEND THAT EVERYTHING IS SORTED BECAUSE DOING THIS WILL GIVE US THE CORRECT ARRAY IN THE MIDDLE OF THE DUPLICATED ARRAY.
        // //e.g. : [4,1,2,3]+[4,1,2,3] has the correct subarray inside it!
        // while(l<=r)
        // {
        //     int mid = l + (r-l);
        //     int midPlus1 = (mid+1)%nums.Length;
        //     if(nums[mid]>nums[midPlus1])
        //         return nums[midPlus1];
        //     else(nums[mid]==nums[midPlus1])
        //     {
        //         nu
        //     }
        // }
    }


    // public int neetCodeBasedSoln(int[] nums)
    // {
    //     int l=0,r=(2*nums.Length)-1;
    //     while(l<r)
    //     {

    //     }
    // }
}
