using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P06_CheapestFlightsWithinKStops_LC787;

public class Solution {

    //[IMPORTANT] THIS IS A SPECIAL CASE BECAUSE WE HAVE TO CONSTRAINTS: 
    //  - CHEAPEST FLIGHTS (meaning dijkstra shortest path over this as weight)
    //  - LESS THAN K STOPS (meaning you have to check more than one / just the 
    //      lowest cost path)
    //  - We can't use `visited` HashSet to avoid infinite loop here because
    //      we might want to visit a node multiple times through different paths.
    //  - We still want to keep it greedy via dijkstra, so minheap over cost stays.
    //  - We can use a cost[{dstNode}][{numberOfStops}] array where for each node
    //      we keep track of if we have been there with this number of stops before,
    //      if not, we do as if it wasn't in visited. BUT if it isn't, we check if 
    //      the current cost we reached it with was lesser than the one we reached 
    //      it with previously (compare cur.cost to value of the cost array with appropriate indexes),
    //      and if it is lesser, then we do as if it wasn't in visited. But, if it
    //      is greater, we continue as if it was in visited and skip adding any of 
    //      its neighbors to the priority queue.
    //[NOTE] I WROTE THIS STUFF JUST BASED ON NEETCODEIO SOLN. PLEASE WATCH HIS VIDEO
    //too. I know I will right now.
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        //Since it says AT MOST k steps, it means we want the Shortest Path (by weight), and not an MST.
        
        //I DID THIS WRONG AT FIRST BECAUSE I JUST USED THE NORMAL DIJKSTRA WITH JUST THE STOPS BEING PASSED.
        //FOR THIS APPROACH, I READ THROUGH THE NEETCODEIO SOLN, BUT I FELT PRETTY SLEEPY TOWARDS THE END SO I'M NOT SURE I FULLY UNDERSTAND.
        //I WILL WATCH THE NEETCODE VIDEO NOW, JUST TO MAKE SURE I UNDERSTAND.
        return Dijkstra1(n, flights, src, dst, k);
    }

    int Dijkstra1(int n, int[][] flights, int src, int dst, int k)
    {
        // JUST WATCH THE NEETCODE VIDEO (and read the comment next to the ocst array)

        //Conditions imply no cycles.
        // The fact that we have another constraint (for k) means...
        
        var cost = new int[n][]; //READ FULLY: JUST CHECKED THE NEETCODEIO SOLN AND WATCHED NEETCODE VIDEO AND REALIZED WE NEED THIS INSTEAD OF VISITED TO ENSURE THAT WE CAN CHECK IF EACH NODE HAS BEEN VISITED AFTER THIS MANY STOPS (and with what cost)
        List<List<(int cost, int dst)>> neighbors = new(n);
        for(int i=0; i<n;i++) //O(n*k)
        {
            cost[i] = new int[k+2]; //+2 because first step is src and last is node, the STOPS we want are inbetween.
            Array.Fill(cost[i], int.MaxValue);
            neighbors.Add(new());
        }

        foreach(var flight in flights)
        {
            neighbors[flight[0]].Add((flight[2], flight[1]));
        }

        // HashSet<int> visited = new();
        cost[src][0] = 0; //<=> cost from src to src at 0 steps is 0.
        PriorityQueue<(int cost, int dst, int stops), int> minHeap = new();
        minHeap.Enqueue((0, src, 0), 0);
        while(minHeap.Count>0)
        {
            var cur = minHeap.Dequeue();
            if(cur.dst == dst) //ORDER MATTERS! I think...
                return cur.cost;
            // if(visited.Contains(cur.dst))
            //     continue;
            // visited.Add(cur.dst);
            
            if(cur.stops == k+1) //order of this matters because dst is allowed to be k+1th because technically only the stops inbetween src and dst count. //Basically, we put this after checking whether current node is destination.
                continue;

            // if(!neighbors.ContainsKey(cur.dst)) 
            //     continue;

            foreach(var nei in neighbors[cur.dst])
            {
                var newCost = cur.cost+nei.cost;
                var newStops = cur.stops+1;
                if(cost[nei.dst][newStops] > newCost)
                {
                    //this condition acts somewhat like visited set due to initially being 
                    //set to int.MaxValue:
                    // - Ensures we calculate shortest path from the neighbor nei at least once 
                    //      for all different number of steps (<=k) we get to the nei with. 
                    //      (the <= k condition is maintained by one of the if conditions above).
                    // - Ensures we ONLY calculate shortest path for same number of steps at 
                    //      nei again if the new cost is lower than previous one.
                    cost[nei.dst][newStops] = newCost;
                    minHeap.Enqueue((newCost, nei.dst, newStops), newCost);
                }
            }
        }

        return -1;
    }
}
