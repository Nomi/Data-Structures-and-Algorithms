using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P07_FindMedianFromDataStream_LC295;

public class MedianFinder {
    IMedianFinder solver;
    public MedianFinder() {
        solver = new attempt1();
    }
    
    public void AddNum(int num) {
        solver.AddNum(num);
    }
    
    public double FindMedian() {
        return solver.FindMedian();
    }
}


public interface IMedianFinder { 
    public void AddNum(int num);
    
    public double FindMedian();
}

public class attempt1 : IMedianFinder
{   
    //Space Complexity: O(N)
    PriorityQueue<int,int> leftHalf; //maxheap
    PriorityQueue<int,int> rightHalf; //minheap
    
    public attempt1()
    {
        leftHalf = new();
        rightHalf = new();
        // //Filling with dummy values to make our checks while adding easier (not checking if either are empty)
        // leftHalf.Enqueue(int.MinValue, int.MaxValue); //priority = int.MaxValue cuz priority queue has smalles priorty first (and -int.MinValue overflows)
        // rightHalf.Enqueue(int.MaxValue, int.MaxValue); //priority = int.MaxValue cuz priority queue has smalles priorty first
    }

    //IMPORTANT!!! TAKE A LOOK AT THIS FUNCTION (and how it's done)!!! (I had to take a peek at the NeetCodeIo solution initally a little to get how its done)
    //Time Complexity: O(nlog(n))
    public void AddNum(int num) //THIS FUNCTION REQUIRED ME TO TAKE A BRIEF LOOK AT THE NEETCODEIO SOLN!
    {
        if(rightHalf.Count != 0 && num > rightHalf.Peek()) // !=0 because we try to insert to left first, arbitrarily chosen. Could do right too.
            rightHalf.Enqueue(num, num); //minheap so we use num as prio
        else
            leftHalf.Enqueue(num, -num); //maxheap so we use -num as prio

        //Make sure the 'halves' are balanced:
        if(leftHalf.Count > rightHalf.Count+1) //+1 for when queue has odd number of elements
        {
            int largestOnLeft = leftHalf.Dequeue();
            rightHalf.Enqueue(largestOnLeft, largestOnLeft); //minheap so we keep smallestOnRight as priority
        }
        else if(rightHalf.Count > leftHalf.Count+1) //+1 for when queue has odd number of elements
        {
            int smallestOnRight = rightHalf.Dequeue();
            leftHalf.Enqueue(smallestOnRight, -smallestOnRight); //maxheap so we use (-largestOnLeft) as priority
        }
    }

    //Time Complexity: O(1)
    public double FindMedian()
    {
        //odd number of numbers:
        if(leftHalf.Count!=rightHalf.Count) 
            return leftHalf.Count>rightHalf.Count ? leftHalf.Peek() : rightHalf.Peek();
        
        //even number of numbers:
        return (((double)leftHalf.Peek()+rightHalf.Peek())/2.0);
    }
}