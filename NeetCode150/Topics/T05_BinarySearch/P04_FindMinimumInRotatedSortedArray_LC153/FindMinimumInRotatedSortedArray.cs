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
        // return attempt1(nums);  //READ THE COMMENTS!

        //Check NeetCode's solution as well as that might be useful for other problems as well (e.g. Search in Rotated Sorted Array)
        return neetCodeBasedSoln(nums);
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
    }


    public int neetCodeBasedSoln(int[] nums)
    {
        //After any rotation, the array can have
        //Left sorted portion and Right sorted portion
        //Where left sorted portion is the elements that 
        //were orignally towards the end but now 
        //rotation brought them to the left side.
        //Clearly, our minimum will be somewhere in the right sorted portion.
        //Next, as long as our nums[mid] has value >= than nums[l],
        //it means that the minimum must be towards the right (because mid is in right sorted array),
        //BUT, if nums[mid]<nums[l] (mid is in right sorted array),
        // it means that either this is minimum, or minimum is to its left.
        // so we do keep it there and then move right to mid (or mid-1?);

        //Basically, if mid ptr is in right sorted portion, we search to the left. (to find if there's an element smaller than the one at current mid)
        //else, when mid ptr is in left sorted portion, we search the right. (to find minimum)
        int l=0,r=nums.Length-1;
        int min = int.MaxValue;
        while(l=<r)
        {
            //It also handles the case where original array was rotated by n, giving back the original sorted array.
            if(nums[l]<nums[r]) //We are in a sorted subarray. 
                return (int)Math.Min(nums[l],min); //We use min to make sure we haven't seen a smaller value before this (e.g. when subarray between l and r is just the whole left sorted array)
            int m = (l+r)/2;
            if(nums[m]>=nums[l]) //We are in left sorted array.
            {
                l=m+1; //search right of m to go to the right sorted array.
            }
            else //nums[m]<nums[l] => we are in right sorted array.
            {
                min = nums[m]; //(int)Math.Min(nums[m], min);
                r=m-1;//we search to the left of m to go see if there are any elements smaller than this there.
                //Not that there will never be an element smaller than it to the right because it is a sorted sub array (specifically the right sorted array)
            }
            //we gotta handle the edgecase where m==l (which is possible) //Only got this because of NeetCode
        }
        return min;
    }
}
