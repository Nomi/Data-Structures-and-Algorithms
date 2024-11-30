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
        //[IMPORTANT] THIS IS NOT MST PROBLEM, UNLIKE WHAT I INITIALLY THOUGHT!!
        // ### Example:
        //  Example of why MST does NOT necessarily give shortest path between 2 vertices.
        // Graph:
        // (A)----5---(B)----5---(C)
        //  |                     |
        //  |----------7----------| 
        //
        // - For MST, edges A-B and B-C will be on MST with total weight of 10. 
        //      So cost of reaching A to C in MST is 10.
        // - But in Shortest Path (SPT) case, shortest path between A to C is A-C, 
        //      which is 7. So, A-C here is 7. But, A-C was never on MST.
        // - So, we can see that SPT in our problem would act as we want, because for
        //      this case it would make max time for the signal to reach all nodes = 7.
        //      Because right from the start, the same signal would be sent through multiple lines at once/concurrently.
        // - MST would NOT work because it would make the max time = 10 (to reach all nodes), 
        //      it would have worked if we had some limitation stating a signal cannot 
        //      be cloned/split.

        // ## MST VS. SPT:
        // ### SPT usecases: [Shortest Path from Source to Any Node]
        //  - When you have want to go from a single point to another final point, 
        //      without needing to visit any other nodes specifically.
        //  - Or When you want to connect all points in a way that the distance of 
        //      all of them to A is minimum. (We don't care about total length of path)
        //  - Or when you need to visit all points (from a source node), but can traverse 
        //      multiple branches at the same time (e.g. the same signal in a network is sent through all the wires) [same time == concurrently].
        //  - Dijkstra can work on DIRECTED OR UNDIRECTED graphs.
        // ### MST usecases: [Shortest Path with All Nodes Included]
        //  - When you have to go to all nodes at least once, but you can only traverse 
        //      one branch at a time.
        //  - The goal of this is algorithm is to minimize the cost to connect all the points 
        //      (e.g. minimizing length or cost of wire used for a telecommunications company trying to lay cable in a new neighborhood. If it is constrained to bury the cable only along certain paths (e.g. roads), then there would be a graph containing the points (e.g. houses) connected by those paths. The length or cost of buring wire along each road would be its weight.)
        //  - Prim can work ONLY ON DIRECTED graphs.
        // ### Observations: 
        // - It does seem SPT prefers performance (connection from source to each 
        //      node is minimized), 
        // - whereas MST prefers efficiency (total cost is minimized).
        // - In this problem especially, since we can just send the same signal through
        //      multiple branches parallely/concurrently and we want to minimize 
        //      the time it takes for all nodes to get the signal, we simply want to pick
        //      paths such that all nodes receive the signal as fast as possible, even if
        //      the overall cost (sum of all weights) is not minimzed.

        // Example for MST vs Dijkstra:
        // ```
        // Nodes: 1, 2, 3, 4
        // Edges:
        // 1 -> 2 (weight = 1)
        // 1 -> 3 (weight = 2)
        // 2 -> 4 (weight = 1)
        // 3 -> 4 (weight = 1)
        //```
        // Shortest Path Tree (SPT) from Node 1:
        // Dijkstra's Algorithm:
        // 1 -> 2 (cost = 1)
        // 1 -> 3 (cost = 2)
        // 2 -> 4 (cost = 2 via node 2)
        // Total weight = 1+1+2 = 4
        // SPT focuses on the shortest path from node 1 to all others.
        // Prim's Algorithm from Node 1:
        // 1 -> 2 (cost = 1)
        // 1 -> 3 (cost = 2)
        // 2 -> 4 (cost = 2 via node 2)
        // Total weight = 1+1+2 = 4
        // SPT focuses on the shortest path from node 1 to all others.


        // MST (e.g. Prim's algorithm) is used to get the shortest path that connects all nodes, but not neccessarily the shortest distance to each node. Because at each
        // Shortest Path (SPT) (e.g. Djikstra's Algorithm) is used to get shortest path FROM 1 node.
        
        // MST ensures a global minimum (sum of all weights) across the entire graph.
        // SPT ensures a local minimum (shortest path) from the source node to each individual node.
        
        // MST may include edges that are not part of any shortest path but are necessary for minimizing the total connection cost.
        // SPT only includes edges that lie along the shortest paths from the source.
        
        // The SPT is rooted at the source node, and the structure is DIRECTED (if the graph is directed).
        // MST is an UNDIRECTED structure, focusing solely on connection without regard to direction or specific paths. (because it's a tree)

        //

        //(From the following resource: https://courses.cs.washington.edu/courses/cse373/23au/lessons/graph-algorithms/#:~:text=Dijkstra%27s%20algorithm%20gradually%20builds%20a,cost%20of%20its%20shortest%20path.)
        // Just as Prim’s algorithm built on the foundation of BFS, Dijkstra’s algorithm can be seen as a variation of Prim’s algorithm.
        // Dijkstra’s algorithm gradually builds a shortest paths tree on each iteration of the while loop. 
        // But whereas Prim’s algorithm selects the next unvisited vertex based on edge weight (of each edge)
        // alone, Dijkstra’s algorithm selects the next unvisited vertex based on the 
        // sum total cost of its shortest path.

        //Dijkstra's focus is on minimizing the weight from 1 vertex to all others (getting shortest paths to them, or to just one index)
        //Prim's focus is minimizing total weight. (e.g.)
        
        return dijkstraAlgo1(times, n, k);
    }

    int dijkstraAlgo1(int[][] times, int n, int k)
    {
        HashSet<int> visited =  new(n);
        Dictionary<int, List<(int time, int node)>> neighbors = new();
        buildNeighborsDict1(neighbors, times);
        
        int maxTime = 0; //WE NEED maxTime, BECAUSE MAX OF THE MIN PATHS WILL BE THE MINIMUM AMOUNT OF TIME TO FOR ALL TO RECEIVE SIGNALS. //WRONG: int minTime = int.MaxValue;
        PriorityQueue<(int time, int node), int> pq = new();
        //k is the source:
        pq.Enqueue((0, k), 0);// DEPRECATED:: //DEPRECATED::since we're looking for minTime, we put first node to int.MaxValue because otherwise minTime b
        while(visited.Count!=n && pq.Count>0)
        {
            var cur = pq.Dequeue();
            if(visited.Contains(cur.node)) //I was doing `!neighbors.ContainsKey(cur.node) || visited.Contains(cur.node)` BUT that makes no sense and would break the program BECAUSE THAT NODE IS VISITABLE, just that there's no nodes to visit from it. If we do this, we won't get the correct cost and we won't stop early from the visited.Count condition either. Better to do it before the for loop.
                continue;
            visited.Add(cur.node);

            if(maxTime < cur.time)
                maxTime = cur.time;

            if(!neighbors.ContainsKey(cur.node))
                continue;

            foreach(var nei in neighbors[cur.node])
            {
                var pathTime = cur.time + nei.time;
                pq.Enqueue((pathTime, nei.node), pathTime);
            }
        }

        return visited.Count == n ? maxTime : -1; 
    }

    void buildNeighborsDict1(Dictionary<int, List<(int time, int node)>> neighbors, int[][] times)
    {
        foreach(var time in times)
        {
            neighbors.TryAdd(time[0], new());
            neighbors[time[0]].Add((time[2], time[1]));
        }
    }
}
