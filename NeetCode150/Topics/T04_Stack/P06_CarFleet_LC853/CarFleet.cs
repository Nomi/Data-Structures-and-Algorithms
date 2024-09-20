using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P06_CarFleet_LC853;

public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        return attempt1(target, position, speed);
    }

    public int attempt1(int target, int[] position, int[] speed)
    {
        var pairs = position.Zip(speed,(p,s)=>(p,s)).ToArray(); //tuple has .first/.second????
        pairs = pairs.OrderBy(x=>x.p).ToArray();
        // Array.Sort(pairs, x=> x.Item1);

        var fleet = new Stack<(int,int)>();
        
        return -1;
    }
}
