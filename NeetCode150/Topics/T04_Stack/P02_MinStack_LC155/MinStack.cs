using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P02_MinStack_LC155;

public class MinStack {
    //THESE PROVIDED CONSTRAINTS MIGHT SERVE AS GOOD CLARIFYING QUESTIONS???
    //-2^31 <= val <= 2^31 - 1. //fits in int32?
    //pop, top and getMin will always be called on non-empty stacks.
    LinkedList<int> values;
    LinkedList<int> minimums;
    public MinStack() {
        values = new();
        minimums=new();
    }
    
    public void Push(int val) {
        values.AddLast(val);
        if(minimums.Count==0)
            minimums.AddLast(val);
        else
            minimums.AddLast((int)Math.Min(val,minimums.Last.Value));
    }
    
    public void Pop() {
        values.RemoveLast();
        minimums.RemoveLast();
    }
    
    public int Top() {
        return values.Last.Value;
    }
    
    public int GetMin() {
        return minimums.Last.Value;
    }
}
