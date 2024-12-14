using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P05_DailyTemperatures_LC739;

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        return attempt1(temperatures); //USE FOR COMMENTS/LEARNING
        //REFER TO NC.IO SOLUTION FOR CLEANER SOLUTION (good learning opportunity to improve my style as well!)
    }
    public int[] attempt1(int[] temperatures)
    {
        //Monotonic increasing stack (big elements on top)
        //If we start from the back, and encounter bigger elements than the previous ones,
        //those definitely can't be the next bigger element
        //considering that at least this 1 element is bigger than them
        //and is before them. As such, we remove all (and ONLY) those from stack
        //in that case (which also keeps the stack monotonically increasing). 
        
        Stack<int> idxStk = new();
        int[] res = new int[temperatures.Length];
        
        for(int i=temperatures.Length-1;i>=0;i--)
        {
            //Removes all indexes NOT bigger than it.
            //NEEDS >= BECAUSE THE TEMPERATURE NEEDS TO BE
            //STRICTLY BIGGER (on the later day, not on i)
            while(idxStk.Count>0&&temperatures[i]>=temperatures[idxStk.Peek()])
            {
                idxStk.Pop();
            }
            
            //Happens if this is the index with biggest temp thus far.
            if(idxStk.Count==0)
            {
                res[i]=0;
            }
            else //There's a bigger index.
            {
                //days AFTER => not inclusive => no need to +1
                res[i] = idxStk.Peek()-i; //peek gives us the next biggest element.
            }

            idxStk.Push(i); //we add the element on the top (the while loop above guarantees that the stack remains monotonically decreasing).
        }

        return res;
    }
}
