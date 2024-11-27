using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P01_ReconstructItinerary_LC332;

public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        //[IMPORTANT!!] PLEASE WATCH THE FOLLOWING FOR BETTER UNDESTANDING:
        //  [William Fisset (YouTube Channel): "Eulerian Path/Circuit algorithm (Hierholzer's algorithm) | Graph Theory"](https://www.youtube.com/watch?v=8MpoO2zA2l4)
        
        //Also, read my comments.


        //My first thought is topological sort.
        //NOW THAT I THINK ABOUT IT, THAT PROBABLY WON'T WORK BECAUSE WE WANT TO GET THE ONE WITH MINIMUM LEXOGICAL ORDER.
        
        //Watched the Neetcode video of the solution (except the implementation/code part),
        //and found out that we CAN visit the same node twice, BUT NOT THE SAME EDGE (ticket), so we remove from adjacencyList when done.
        
        //READ COMMENTS IN ACTUAL SOLUTION (dfsHierholzersAlgorithm_1)!!
        return INTENTIONALLY_BREAKING_SO_I_CAN_REWRITE_WITHOUT_KNOWING_IF_CURRENT_ANSWER_IS_CORRECT_dfsHierholzersAlgorithm_1(tickets);
    }

    Dictionary<string, List<string>> graph; //adjacency list
    List<string> itnry;
    const string startingPoint = "JFK";
    
    List<string> dfsHierholzersAlgorithm_1(List<List<string>> tickets)
    {
        //[EXTRA IMPORTANT NOTE] Hierholzer's algorithm basically asks for any nodes with unused edges
        //after first branch of DFS, what path should we have taken before to include those edges. Whenever all edges have been visited for a node, it means that we haven't left out anything, and as such it can be safely added to the result at the correct position (there's nothing left to visit before it)
        // - Here, we are guaranteed an itenerary [here, Eulerian path but also works for cycles/circuits (Eulerian circuits/cycles)]
        //  exists, so we do NOT need to check using `indegree-outdegree <= 1` ONLY AT 1 NODE
        //  && `outdegree-indegree <= 1` ONLY AT 1 NODE (different from the previous one, obviously).
        // - We also don't need to maintain a separate outdegree count when using adjacency list because we can just get the list's count.
        // - PLEASE WATCH THE FOLLOWING FOR BETTER UNDESTANDING:
        //  [William Fisset (YouTube Channel): "Eulerian Path/Circuit algorithm (Hierholzer's algorithm) | Graph Theory"](https://www.youtube.com/watch?v=8MpoO2zA2l4)
        graph = new();
        itnry = new();
        
        //[EXREMELY_IMPORTANT_NOTE] Two things going on below:
        // 1. [GREAT_TRICK] Ordering tickets here by destination means the adjacency list we create using it will be ordered correctly.
        // 2. [GREAT_TRICK] Ordering Descending (in Lexicographical terms) means that we iterate from the end of the list, which not only
        //      makes it O(1) to remove the element at each level of DFS so we don't consider it anymore in that branch, but also
        //      makes it O(1) to add elements back at their index (at the end of the list at each level). //Credit to some random LeetCode C# solution I saw.
        tickets = tickets.OrderByDescending(arr => arr[1]).ToList(); //O(E*log2(E))


        foreach(var ticket in tickets) //O(E)
        {
            graph.TryAdd(ticket[0], new());

            graph[ticket[0]].Add(ticket[1]);
        }
        
        dfs1(startingPoint); //O(E) because we go through all the edges once (and can visit a vertex multiple times)

        itnry.Reverse(); //O(E) //Since we append airports post-recursion (post-order), the itinerary is built in reverse. Reverse the itinerary list before returning it.

        return itnry;
    }

    void dfs1(string src) //DFS with Backtracking.
    {
        //Due to the sorted neighbor lists in adjList, the itinerary we get the 
        //first time we exhaust all tickets(edges) is the lexicographically smallest and 
        //as such can be returned without needing to compare it with others.
        while(graph.ContainsKey(src) && graph[src].Count > 0) //also skips this and returns in case of base case (no tickets from here / Final destination? (case 1: there never were any(containskey) case 2: already used up in current branch(graph[cur].Count==0)))
        {
            var dest = graph[src][graph[src].Count-1]; //the next lexicographically smallest destination
            graph[src].RemoveAt(graph[src].Count-1); //Remove `dest` of this iteration from the adjacecny list
            dfs1(dest);
            //We don't add back dest to the adjacency list because:
            //As soon as we can't go back from any branch, we add it to the result 
        }
        itnry.Add(src);

        //IMPORTANT NOTE: Since we don't care about where we end up after all the flights,
        // at each airport we are at, we can simply always pick the next to be the
        // lexicographically smallest one that exists in the list of available destinations
        // from that airport (using the Adjacency List).
    }
    
}
