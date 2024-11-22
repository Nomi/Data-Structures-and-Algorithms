using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P11_NumberOfConnectedComponentsInAnUndirectedGraph_LC323p;

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        IComponentsCounter soln;

        //Did it by myself since I had done a similar problem Graph Valid Tree an hour or two ago. (though that one took me a long while, this one was done in ~20 minutes)
        //Refer to Graph Valid Tree if needed.
        soln = new Dfs1();

        // For Union Find using Disjoin Union Set, watch Union Find in 5 minutes by Potato Coders on YouTube
        // According to a comment on the video: He does forget to mention that you have to union the shorter tree into the longer tree, otherwise the trees is in a set of n elements can be up to n elements long (just a straight chain, instead of branching) and you don't get log(n) complexity.
        // Also, watch Neetcode's video on this problem to see how it applies here. I plan to watch it before solving.
        // soln = new UnionFind_DisjointUnionSet_1();


        return soln.CountComponents(n, edges);
    }
}


public interface IComponentsCounter
{
    int CountComponents(int n, int[][] edges);
}

public class Dfs1 : IComponentsCounter
{
    public int CountComponents(int n, int[][] edges)
    {
        //1. Make adjacency list:
        List<List<int>> nodeEdges = new(n); //SC: O(V+E) [V==n]  because there are V List<ints>, and the sum of all the nodes in those lists is E (because the lists contain the vertex on the other end of the edges from the V indices)
        for(int i=0; i<n; i++) //O(n)==O(V)
        {
            nodeEdges.Add(new());
        }

        foreach(var edge in edges)
        {
            nodeEdges[edge[0]].Add(edge[1]);
            nodeEdges[edge[1]].Add(edge[0]);
        }

        //2. Graph traversal to mark connected components:

        int numConnectedComponents = 0;
        HashSet<int> visited = new(n); //To track nodes already visited (helps with cycle detection and also checking if a node is a part of a connected component discovered before)

        for(int node = 0; node<n; node++) //TC (including DFS): O(V+E) where V==n, because we only visit each node once and the number of other nodes we visit from each node sums up to the total number of edges because we only traverse each edge only once using the hashset's power (obvious / by definition).
        {
            if(visited.Contains(node))
                continue;
            numConnectedComponents++;
            dfsMarkThisAndConnectedNodesAsVisited(node, -1, visited, nodeEdges); //assuming we can use -1 as a dummy parent node for first level of recursion.
        }
        return numConnectedComponents;
    }

    void dfsMarkThisAndConnectedNodesAsVisited(int curNode, int parentNode, HashSet<int> visited, List<List<int>> nodeEdges) //O(V+E) because we go through each node at most once and the total sum of all paths from one node to another (edges) will sum up to E because 1 edge only occurs between 1 pair of vertices. (I think I phrased it shitty, but give me a break. I have a headache.)
    {
        if(visited.Contains(curNode))
            return; //We don't need to process this branch anymore as it is a cycle (it can't be something we visited for a different connected component exactly because then that and this connected component would be connected and would actually be only one connected component, but that's not true)
        visited.Add(curNode);
        foreach(int childNode in nodeEdges[curNode])
        {
            if(childNode == parentNode) //Since we came from there, we don't need to process it again. In fact that would lead to a false-positive detection of a cycle.
                continue;
            dfsMarkThisAndConnectedNodesAsVisited(childNode, curNode, visited, nodeEdges);
        }
    }
}

public class UnionFind_DisjointUnionSet_1 : IComponentsCounter
{
    public int CountComponents(int n, int[][] edges)
    {
    }
    private class DSU
    {
        public 
    }
}