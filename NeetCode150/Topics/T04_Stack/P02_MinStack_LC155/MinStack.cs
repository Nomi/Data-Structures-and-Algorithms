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
    

    //Solution: We clearly just use another place that keeps
    // track of the minimum at each level of insertions,
    // so that when Pop is done, instead of recalculating
    // we can just remove the last value from both values
    // and minumum and have the last elements be the up to date
    // without having to recalculate maximum.
    
    // LinkedList<int> values;
    // LinkedList<int> minimums;
    Stack<int> values;
    Stack<int> minimums;
    public MinStack() {
        values = new();
        minimums = new();
    }
    
    public void Push(int val) {
        values.Push(val);
        if(minimums.Count==0)
            minimums.Push(val);
        else
            minimums.Push((int)Math.Min(val,minimums.Peek()));
    }
    
    public void Pop() {
        values.Pop();
        minimums.Pop();
    }
    
    public int Top() {
        return values.Peek();
    }
    
    public int GetMin() {
        return minimums.Peek();
    }
}
