using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P02_MinCostToConnectAllPoints_LC1584;

public class Solution {
    IMinCostToConnectPointsCalculator soln;
    public int MinCostConnectPoints(int[][] points) {
        //Basically shortest path in an undirected AND weighted graph problem, so I'm thinking Djikstra's algorithm (I remember a little bit about it from a video I watched a long time ago)
        //OKAY, IT MIGHT NOT BE THE CORRECT APPROACH. AT LEAST Neetcodeio solns don't use it.
        
        //OKAY, I WAS DUMB, DJIKSTRA IS LOWEST_COST PATH TO A NODE (or all nodes) IN DIRECTED and WEIGHTED GRAPHS 
        //BUT IT DOESN'T ACCOUNT FOR HAVING TO GO THROUGH ALL NODES!!
        
        // This problem is ACTUALLY more like finding the Minimum Spanning Tree (MST), 
        
        // What is an MST?
        //      - Recall that Trees are Acyclical, Connected, & Undirected graphs (well, technically they are directed from parent to child, but that's besides the point).
        //      - MST is the smallest set of edges from a graph that still connects all of its nodes but also forms a Tree (Acyclical, Connected, & Undirected Graph as discussed in the point above)
        //      - For some Trees (like binary trees) we usually ignore the fact that they're directed (only parent has pointers to its children), but here it is more strict than that. 
        //          Meaning the edges really will not have any direction.

        // Since we want the MST, we can use the following algorithms:
        //  * Prim's Algorithm: [for Undirected Graphs] 
        //          
        //              
        //  * Kruskal's Algorithm:
        //          .

        soln = new PrimsAlgo_1();

        return soln.MinCostConnectPoints(points);
    }

}


public interface IMinCostToConnectPointsCalculator
{
    int MinCostConnectPoints(int[][] points);
}

public class PrimsAlgo_1 : IMinCostToConnectPointsCalculator
{
    int Abs(int num) => (int) Math.Abs(num);
    int Cost(int x1, int y1, int x2, int y2) => Abs(x1-x2) + Abs(y1-y2); //returns ManhattanCost

    public int MinCostConnectPoints(int[][] points)
    {

    }
}