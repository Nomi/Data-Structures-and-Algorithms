using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P12_RedundantConnection_LC684;

public class Solution {
    IRedundantConnectionFinder soln;
    public int[] FindRedundantConnection(int[][] edges) {
        //My first thoughts: Naieve solution would be doing a loop starting from the end of the array and for each edge we see if removing it removes the cycle (by doing a DFS from 0). 
        //Checked NeetCode's Naieve solution, and it basically checks if the graph //Note that the solution is not practically efficient since new int[n] used for `visited` is an O(n) operation since it sets all values to default value of the thing. But then again, we do another O(x) 
        //Actually, the first edge that adds the cycle is the last edge that removes the cycle (because there were no cycles before it). //Adding one edge to a tree will always create exactly one cycle. Thus, the redundant edge is the one that closes this cycle.
        //Watched the neetcode video (except the implementation part) and now I know the best solution would 

        //Union Find by Size using Disjoint Union Sets:
        soln = new UnionFind_BySize_WithPathCompression_1();

        return soln.FindRedundantConnection(edges);
    }
}


public interface IRedundantConnectionFinder
{
    int[] FindRedundantConnection(int[][] edges);
}


public class UnionFind_BySize_WithPathCompression_1 : IRedundantConnectionFinder
{
    public int[] FindRedundantConnection(int[][] edges) 
    {
        DisjointUnionSets dsu = new(edges.Length);

        foreach(var edge in edges)
        {
            if(!dsu.Union(edge[0], edge[1]))
                return edge;
        }

        throw new Exception("No cycle found.");
    }

    private class DisjointUnionSets
    {
        int[] parent;
        int[] size; //number of children + 1(for itself)

        public DisjointUnionSets(int numNodes)
        {
            //we use numNodes+1 so that we can have a 1-1 mapping from node to its size or parent. The 0th index is just an extra that's never used. (we even start the loops from 1)
            parent = new int[numNodes+1];
            size = new int[numNodes+1];
            parent[0] = size[0] = int.MinValue; //Never used, so I could've kept them as is, but I just decided to keep it a negative number (int.MinValue) for no reason.
            for(int i=1; i<numNodes+1; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }

        public bool Union(int u, int v) //Returns false if the members are already connected, which means the last node to induce a cycle will return false right away.
        {
            int rootToAttach = Find(u);
            int rootTarget = Find(v);

            if(rootToAttach == rootTarget)
                return false; //Already in the connected set.

            if(size[rootToAttach] > size[rootTarget])
            {
                int temp = rootTarget;
                rootTarget = rootToAttach;
                rootToAttach = temp;
            }

            parent[rootToAttach] = rootTarget;

            return true;
        }

        public int Find(int child) //Due to the nature of Path Compression (and since find is also called in union), the maximum height/depth of any tree representing a set is 2 (as explained in my solution to `Number of Connected Components In An Undirected Graph`)
        {
            if(child != parent[child]) //Root's parent is itself.
                parent[child] = Find(parent[child]); //Path compression/
            return parent[child];
        }

    }
}