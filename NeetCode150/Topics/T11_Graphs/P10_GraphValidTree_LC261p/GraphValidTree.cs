using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P10_GraphValidTree_LC261p;

public class Solution {
    IGraphValidTree solver;
    public bool ValidTree(int n, int[][] edges) {
        //Initial thoughts:
        //Trees are simply Connected and Acyclic graphs.
        
        // CANNOT use Kahn's/Topological_Sort algorithm here, even though it might be deceptively similar to Course Scheduler in terms of how the input is given.


        //WATCHED NEETCODE VIDEO!!!!
        //Also, BFS seems impossible (or unneccessarily complex) for this due to the need to pass parent/previous node


        //SOLUTION:
        solver = new DfsAttempt1(); //HAD TO WATCH NEETCOOE VIDEO.


        return solver.ValidTree(n, edges);
    }
}


public interface IGraphValidTree
{
    bool ValidTree(int n, int[][] edges);
}

public class DfsAttempt1 : IGraphValidTree
{
    HashSet<int> visited;

    public bool ValidTree(int n, int[][] edges)
    {
        //As commented previously, I just need to check if graph is CONNECTED AND ACYCLIC!

        visited = new();

        var nodeToNeighbor = new List<List<int>>(); //SC: O(V+E) where E is the edge count! (because we have a list edges for each vertex and each edge obviously appears only once (twice here because undirected but it doesn't really matter here))

        for(int i=0; i<n;i++) //O(V)
        {
            nodeToNeighbor.Add(new());
        }

        for(int i=0; i<edges.Length; i++) //TC: O(E) where E is the edge count!
        {
            nodeToNeighbor[edges[i][0]].Add(edges[i][1]);
            nodeToNeighbor[edges[i][1]].Add(edges[i][0]);
        }

        bool hasCycle = !checkCyclesAndBuildSetofNodesReachableFromCurDfs(0, -1, nodeToNeighbor); //TC: O(V) because we go through every node once
        // Console.WriteLine(hasCycle);
        if(hasCycle)
            return false;
    
        Console.WriteLine(visited.Count);

        return visited.Count == n;
    }

    public bool checkCyclesAndBuildSetofNodesReachableFromCurDfs(int cur, int parent, List<List<int>> nodeToNeighbor)
    {

        //CAUTION! keeping the visited set lines (checking and adding) inside the loop right after `if child==parent` condition by mistake initially, but it broke the whole thing BECAUSE for nodes with no other connection than its parent(because undirected), it would never get added to the visited set.
        if(visited.Contains(cur))
            return false;
        visited.Add(cur);
        foreach(var child in nodeToNeighbor[cur])
        {
            if(child==parent) //since it is undirected, we use this to prevent using the edge we got here from again so that we don't get a false-positive cycle.
                continue;
            if(!checkCyclesAndBuildSetofNodesReachableFromCurDfs(child, cur, nodeToNeighbor))
                return false;
        }
        return true;
    }

}