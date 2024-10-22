using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P03_KClosestPointsToOrigin_LC973;

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        //Wasn't really that hard.

        //NOTE: We don't do it like neetcode does because C# does not have an alternative to heapq.heapify!
        return attempt1(points, k);
    }

    //Space complexity: O(K)
    //Time complexity: O(n*log2(k))
    public int[][] attempt1(int[][] points, int k)
    {
        if(points.Length<=k)
            return points;
        PriorityQueue<(int[] pt,double dist), double> q = new();
        for(int i=0; i<points.Length; i++)
        {
            var curDist = DistanceFromOrigin(points[i]);
            // Console.WriteLine($"{points[i][0]}, {points[i][1]}, {curDist}");
            if(q.Count < k)
            {
                q.Enqueue((points[i],curDist), -1*curDist); //MaxHeap
                continue;
            }
            var maxDistThusFar = q.Peek().dist;
            if(maxDistThusFar>curDist)
            {
                q.Dequeue();
                q.Enqueue((points[i],curDist), -1*curDist);
            }
        }

        int[][] res = new int[k][];
        for(int i=0;i<k;i++)
        {
            res[i] = q.Dequeue().pt;
        }
        return res;
    }

    public static double DistanceFromOrigin(int[] point)
    {
        return Math.Sqrt(Math.Pow(point[0],2)+Math.Pow(point[1], 2));
    }
}
