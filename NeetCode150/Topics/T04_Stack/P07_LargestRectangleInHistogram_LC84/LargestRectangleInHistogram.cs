using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P07_LargestRectangleInHistogram_LC84;

public class Solution {
    public int LargestRectangleArea(int[] heights) {
        return attempt1(heights);
    }
    
    public int attempt1(int[] heights) 
    {
        int maxArea = 0;
        //WE NEED TO KEEP HEIGHTS IN INCREASING ORDER FOR THE ALGORITHM! (because we can't extend the prior rectangle to the right anymore).
        //This means that for any element in the stack, we can extend its rectangle to the end of the stack (while keeping the height of the rectangle equal to it)
        //But, we can't extend towards the older/lower elements in the stack.
        //If it is not increasing, we pop (and calculate)
        //This is a monotonic increasing stack (because we go from low on bottom to high on top)

        //While we move to right and add elements to stack until we reach an element smaller than the current one (can't extend the rectangle to the right).
        //Then we pop elements from the stack (while the top element is bigger than current one) and calculate the area of the bar on top of the stack.
        //Then if the one before that is the same height, we calculate the area of that bar and the prior one (or until the last bar with same height) (won't have lesser height cuz we maintain monotonic increasing stack).
        //If we meet a smaller one, we just calculate the rectangle from it (with its height) until now.
        //If element on top of stack is smaller than the newly encountered element at any point, we stop and add that to the stack BUT we change the index to insert isntead of its index to the index of the last popped element because we could extend this one to the left until that point (because that's the last element >= this) and continue as we had before.
        //If we reach end of input, we can do the same thing we did for encountering a smaller element because that is our trigger for calculating rectangles thus far.
        //Since we are popping from the top (most recent) element, we will use stack. [the sentences above's references to 'stack' could just be replaced with 'from the storage']
        //Watch the neetcode video for better visualization.
        Stack<(int h,int i)>stack = new();
        for(int i=0; i<heights.Length;)
        {
            if(i==0)//there will always be at least one element in the stack except on first iteration.
            {
                maxArea = heights[i]*1;
                stack.Push((heights[i],i));
                i++;
                continue;
            }
            //stack.Count will always be >0 here.
            while(i<heights.Length && stack.Peek().h<=heights[i])//< ???
            {
                stack.Push((heights[i], i));
                i++;
            }
            //maxArea = stack.Peek().h*1; //last bar can not be extended and cannot be more than its width (1).
            int lastUsableI = i;
            while(stack.Count>0 && (i==heights.Length||heights[i]<stack.Peek().h))//<= ???
            {
                var (th, ti) = stack.Pop(); //th will be smaller than heights[i] or any bars on top of it, as it is in a monotonic increasing stack (from bottom to top)
                maxArea = (int)Math.Max((i-ti)*th, maxArea);
                lastUsableI = ti;
            }
            if(i<heights.Length)
            {
                stack.Push((heights[i],lastUsableI));
            }
            //LOGGING TUPLES:
            //var tup = (h: heights[i], i: i);
            // Console.WriteLine(tup); WOW YOU CAN PRINT TUPLES EASILY!!!
        }
        return maxArea;
    }
}