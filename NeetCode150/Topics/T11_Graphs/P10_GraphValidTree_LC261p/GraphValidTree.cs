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
        solver = new Attempt1();
        return solver.ValidTree(n, edges);
    }
}


public interface IGraphValidTree
{
    bool ValidTree(int n, int[][] edges);
}

public class Attempt1 : IGraphValidTree
{
    public bool ValidTree(int n, int[][] edges)
    {

    }
}