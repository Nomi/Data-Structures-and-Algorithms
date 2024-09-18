using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P05_DailyTemperatures_LC739;

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        return attempt1(temperatures);
    }
    public int[] attempt1(int[] temperatures)
    {
        //Monotonic increasing stack (big elements on top)
        //If we start from the back, and encounter a bigger element than the others,
        //definitely the ones after that can't be the next bigger element
        //considering that at least this 1 element is bigger than them
        //and is before them. As such, we remove all those from stack
        //in that case (which also keeps the stack monotonically increasing). 
        //Therefore,
        Stack<int> idxStk = new();
        int[] res = new int[temperatures.Length];
        idxStk.Push(temperatures.Length-1);
        res[temperatures.Length-1]=0;
        
        for(int i=temperatures.Length-2;i>=0;i--)
        {
            while(idxStk.Count>0&&temperatures[i]>temperatures[idxStk.Peek()])
            {
                idxStk.Pop();
            }
                        
            if(idxStk.Count==0)
            {
                res[i]=0;
            }
            else
            {
                //days AFTER => not inclusive => no need to +1
                res[i] = idxStk.Peek()-i;
            }

            idxStk.Push(i);
        }

        return res;
    }
}
