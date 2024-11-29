using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P03_NetworkDelayTime_LC743;

//## BREAKDOWN:
//### Given: 
//A network of n nodes, labeled from 1 to n. You are also given times, a list of directed edges where `times[i] = (ui, vi, ti)`.
// - ui is the source node (an integer from 1 to n)
// - vi is the target node (an integer from 1 to n)
// - ti is the time it takes for a signal to travel from the source to the target node (an integer greater than or equal to 0).
// Finally, we have k, the label of the Node that sends the signal
//### Input format: 
//int[][] times, int n, int k
//### Output format: int
//### Result:
//  minumum time it takes for all of the nodes to receive signal.
//  -1 if it is impossible
//### Example: ?
//### Clarifications:
//### Edge cases: ?
//### Constraints:
//### Observations: It is a directed, weighted graph.
//### Approach: basically find the minimum spanning tree

public class Solution {
    
    public int NetworkDelayTime(int[][] times, int n, int k) {
        return primsAlgo1(times, n, )
    }

    int primsAlgo1(int[][] times, int n, int k)
    {
        HashSet<int> visited =  new(n);
        Dictionary<int, List<(int time, int node)> neighbors;
        buildNeighborsDict1(neighbors, times);
        
        int time = 0;
        PriorityQueue<(int time, int node), int> pq = new();
        //k is the source:
        pq.Enqueue((0, k));
        while(visited.Count!=n && pq.Count>0)
        {
            var cur = pq.Dequeue();
            if(visited.Contains(cur.node)) //I was doing `!neighbors.ContainsKey(cur.node) || visited.Contains(cur.node)` BUT that makes no sense and would break the program BECAUSE THAT NODE IS VISITABLE, just that there's no nodes to visit from it. If we do this, we won't get the correct cost and we won't stop early from the visited.Count condition either. Better to do it before the for loop.
                continue;
            visited.Add(cur.node);

            time += cur.time;

            if(!neighbors.ContainsKey(cur.node))
                continue;

            foreach(var nei in neighbors[cur.node])
            {
                pq.Enqueue(nei);
            }
        }

        return visit.Count == n ? time : -1; 
    }

    void buildNeighborsDict1(Dictionary<int, List<(int time, int node)> neighbors, int[][] times)
    {
        foreach(var time in times)
        {
            neighbors.TryAdd(time[0], new());
            neighbors[time[0]].Add((time[2], time[1]));
        }
    }
}
