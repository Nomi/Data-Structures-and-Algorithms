using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P07_FindMedianFromDataStream_LC295;

public class MedianFinder {

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        
    }
    
    public double FindMedian() {
        
    }
}


public interface IMedianFinder { 
    public void AddNum(int num);
    
    public double FindMedian();
}

public class attempt1 : IMedianFinder
{
    PriorityQueue leftHalf;
    PriorityQueue rightHalf;
    public attempt1()
    {
        
    }

    public void AddNum(int num)
    {

    }

    public double FindMedian()
    {

    }
}