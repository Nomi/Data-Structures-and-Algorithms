using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P03_KClosestPointsToOrigin_LC973;

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        return attempt1(points, k);
    }

    public int[][] attempt1(int[][] points, int k)
    {
        if(points.Length<=k)
            return points;
        PriorityQueue<int[], int> q = new();
        for(int i=0; i<points.Length; i++)
        {
            Console.WriteLine($"{points[i][0]}, {points[i][0]}, {DistanceFromOrigin(points[i])}");
            if(q.Count < k)
            {
                q.Enqueue(points[i], DistanceFromOrigin(points[i])); //MaxHeap
                continue;
            }
            var maxDistThusFar = DistanceFromOrigin(q.Peek());
            var curDist = DistanceFromOrigin(points[i]);
            if(maxDistThusFar>curDist)
            {
                q.Dequeue();
                q.Enqueue(points[i], curDist);
            }
        }

        int[][] res = new int[k][];
        for(int i=0;i<k;i++)
        {
            res[i] = q.Dequeue();
        }
        return res;
    }

    public static int DistanceFromOrigin(int[] point)
    {
        return (int) Math.Sqrt(Math.Pow(point[0],2)+Math.Pow(point[1], 2));
    }
}
