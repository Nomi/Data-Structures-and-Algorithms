using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P02_MinCostToConnectAllPoints_LC1584;

//## Problem statement Breakdown:
//GIVEN: An array of DISTINCT points on a 2D graph
//RESULT: Minimum cost to connect points
//INPUT: int[][] points, representing the graph, where points[i] == [x,y]
//OUTPUT: int
//TO DO: 
//  - Calculate ways to connect all the points such that:
//      - There's EXACTLY 1 path between 2 points.
//      - While keeping the manhattan distance (cost) minimum.
//FACTS: 
//  - cost == |x1 - x2| + |y1 - y2| (maybe this would need to be asked as a clarification in an interview?)
//CLARIFICATIONS:
//CONSTRAINTS:
// * 1 <= points.length <= 1000
// * -1000 <= xi, yi <= 1000
//EXAMPLES:
// - Input: points = [[0,0],[2,2],[3,3],[2,4],[4,2]]
// - Output: 10

public class Solution {
    IMinCostToConnectPointsCalculator soln;
    public int MinCostConnectPoints(int[][] points) {
        //Basically shortest path in an undirected AND weighted graph problem, so I'm thinking Djikstra's algorithm (I remember a little bit about it from a video I watched a long time ago)
        //OKAY, IT MIGHT NOT BE THE CORRECT APPROACH. AT LEAST Neetcodeio solns don't use it.
        
        //OKAY, I WAS DUMB, DJIKSTRA IS LOWEST_COST PATH FROM A NODE TO ANOTHER NODE (or all nodes) IN DIRECTED and WEIGHTED GRAPHS 
        //BUT IT DOESN'T ACCOUNT FOR HAVING TO GO THROUGH ALL NODES!!
        
        // This problem is ACTUALLY more like finding the Minimum Spanning Tree (MST), 

        // Watched the NeetCode Advanced Algorithms course's video about Prim's and Kruskal's (only a little for this one, for now) algorithms for finding MST (without the code examples)
        
        // What is an MST?
        //      - Recall that Trees are Acyclical, Connected, & Undirected graphs (well, technically they are directed from parent to child, but that's besides the point).
        //      - Recall that since a tree are connected and acyclical, for a tree of N nodes, there are N-1 edges (because to connect N points, you need N-1 lines. If you use N lines, you end up with a cycle (e.g. a square has 4 vertices and 4 edges, or two points with two edges between them, or one point with one edge to itself, etc.)).
        //      - MST is the smallest subset of edges from a graph that still connects all of its nodes but also forms a Tree (Acyclical, Connected, & Undirected Graph as discussed in the point above).
        //      - If the edges are weighted, then we minimize the total cost by taking a subset of the edges such that the cost is minimized while still satisfying the other conditions of the MST.
        //          For unweighted, we just assume the weights to be 1 for all edges.
        //      - There CAN be multiple valid solutions/MSTs (with same cost). We just return 1 of them, like in shortest path algorithms.
        //      - The result will be one of the valid MSTs but in the form of an edge list.
        //      - Unlike for Shortest path (where we start from source node), for MST it doesn't matter which node we start from (because all node need to be included anyway).
        //      - For some Trees (like binary trees) we usually ignore the fact that they're directed (only parent has pointers to its children), but here it is more strict than that. 
        //          Meaning the edges really will not have any direction.

        // Since we want the MST, we can use the following algorithms (read the MST section above first):
        //  * Prim's Algorithm: [for Undirected & Connected Graphs] 
        //      - We use a `visited` HashSet because we don't want to visit a node more than once,
        //          because that would lead to a cycle.
        //      - We also use a MinHeap<weight, n1, n2>, which sorts based on weight/cost of the edges
        //          because we want to pop/dequeue the minimum weight/cost edges first. (where n1 and n2 are the nodes for the edges)
        //      - We start at any node and add its edges to the MinHeap AND add the node to the Visited set.
        //      - Then keep iterating and for the current edge for each iteration, use the n2 as the node
        //          and take all neighbors of the current node and add its edges them to the MinHeap (alongside their total weights (combined with how much it took get there))
        //      - { At this point, the algorithm works almost exactly like Djikstra's algorithm. (Side note: I watched the video about the algorithm from NeetCode's Advanced Graphs course but the problem for it on NC150 comes after this one (without the code example).) }
        //      - { Also, we could run the algorithm to keep the loop running until the MinHeap is empty, but we could also add a different condition to continue the algorithm
        //          to avoid extra processing once we're done finding it. For example:
        //              1. Run until MinHeap empty (as we discussed above, this is a little inefficient but it works)
        //              2. Run while Visited.Count < numOfNodes (if we know what the numOfNodes is),
        //              3. While number/count of edges in list of edges in our results is < n-1 (as we discussed above, it being n-1 means we're done).
        //          Just remember that visited.Count is number of nodes processed thus far, and result.Count is number of edges thus far.
        //          To keep it simple, we will run until MinHeap is empty. }
        //      - By the way, while the edges are undirected, the order we put n1 and n2 in the MinHeap
        //          matters because that's the direction of our traversal (not the edge) [where n1 is where we are at, and n2 is where we will go] 
        //          and reversing it suddenly would just lead to going back to previous nodes.
        //      - If there are equal weights at some point, we can pop any of those and still get a valid MST (no cycle and minimum cost) 
        //          because as discussed earlier, there can be many valid solution, and this will be one of them.
        //      - Since the algorithm is so similar to Dikstra's alogirthm, the complexities are the same:
        //          * TC: O(E*log2(E)) where E <= V^2 (E==V^2 when every node is connected to every other node and itself)
        //              [Also, O(E*log2(v^2)) == O(E*2*log2(v)) == O(E*log2(v))]
        //              (Note: E*log2(E) comes from adding AT MOST E edges to the MinHeap)
        //          * SC: O(E) where E<=V^2 (E==V^2 when every node is connected to every other node and itself)
        //              [because we only store Edges]
        //      - Watch the video about this algorithm from the NeetCode Advanced Algorithms 
        //          course to find WHY this algorithm works and get more details about it.
        //
        //              
        //  * Kruskal's Algorithm:
        //      - Just another way to find the MST of a connected graph.
        //      - Maybe if Prim's algorithm is too confusing for you, you might prefer Kruskal's algorithm.
        //      - In fact, in NeetCode's opinion, it is conceptually it is a much easier algorithm to understand.
        //      - BUT, coding it might actually be more difficult/complicated because it uses the Union Find datastructure (which you might also need to implement yourself) and the implementation even if Union Find were to be given might be at least somewhat difficult/complicated.
        //      - Due to above reason, I stopped learning this, at least for now, because I have limited time and clearly this doesn't seem to be worth it given the tight schedule for my upcoming interview.

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