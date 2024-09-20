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
        pairs = pairs.OrderByDescending(x=>x.p).ToArray();
        //A LESSON ON TUPLES:
        //Could also use (int p, int s)[] pairs =...; 
        //OR
        //(a,b)=>(p: a, s: b);
        //READ UP ON https://www.bytehide.com/blog/tuple-csharp
        //For loops, an also use: 
        //foreach (var (p, s) in myList) and access them separately
        // OR EVEN var (p, s) = myList[0] to use them separately.
        // Array.Sort(pairs, x=> x.Item1);
        var fleet = new Stack<(int p,int s)>();
        
        foreach(var (p, s) in pairs)
        {
            if(fleet.Count==0)
            {
                // Console.WriteLine($"{target}: {p},{s}");
                fleet.Push((p,s));
                continue;
            }
            var (lp, ls) = fleet.Peek();
            //REMEMBER: YOU GOTTA CAST THEM AS DOUBLES TO GET ACTUAL TIMES!!!
            double lastFleetTimeToDist = (double)(target-lp)/ls;
            double timeToDistCurrCar = (double)(target-p)/s;
            // Console.WriteLine($"{target}: {p},{s}={timeToDistCurrCar} -- {lp},{ls}={lastFleetTimeToDist}");
            if(lastFleetTimeToDist<timeToDistCurrCar)
                fleet.Push((p,s));
        }
        return fleet.Count;
    }
}