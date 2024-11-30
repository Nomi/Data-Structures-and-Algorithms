using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P06_CheapestFlightsWithinKStops_LC787;

public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        //Since it says AT MOST k steps, it means we want the Shortest Path (by weight), and not an MST.
        return Dijkstra1(n, flights, src, dst, k);
    }

    int Dijkstra1(int n, int[][] flights, int src, int dst, int k)
    {
        //Conditions imply no cycles.
        // The fact that we have another constraint here
        Dictionary<int, List<(int cost, int dst)>> neighbors = new(n);
        foreach(var flight in flights)
        {
            neighbors.TryAdd(flight[0], new());
            neighbors[flight[0]].Add((flight[2], flight[1]));
        }

        HashSet<int> visited = new();
        PriorityQueue<(int cost, int dst, int stops), int> pq = new();
        pq.Enqueue((0, src, 0), 0);
        while(pq.Count>0)
        {
            var cur = pq.Dequeue();
            if(visited.Contains(cur.dst))
                continue;
            visited.Add(cur.dst);
            
            if(cur.dst == dst)
                return cur.cost;
            
            if(cur.stops==k+1) //order of this matters because dst is allowed to be k+1th because technically only the stops inbetween src and dst count.
                continue;

            if(!neighbors.ContainsKey(cur.dst)) 
                continue;

            foreach(var nei in neighbors[cur.dst])
            {
                pq.Enqueue((cur.cost+nei.cost, nei.dst, cur.stops+1), cur.cost+nei.cost);
            }
        }

        return -1;
    }
}
