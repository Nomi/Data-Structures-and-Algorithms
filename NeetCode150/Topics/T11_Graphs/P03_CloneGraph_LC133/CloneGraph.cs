using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P03_CloneGraph_LC133;

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        //GO THROUGH MY bfs1 ATTEMPT (AND MAYBE WATCH NEETCODE VIDEO???)
        //KINDA EASY BUUUT TRICKYYYY
        return bfs1(node);
    }

    //TC: O(V+E)
    //SC: O(V)
    public Node bfs1(Node start)
    {
        if(start == null) return null; //I DID NOT EVEN THINK ABOUT IT!!! BE CAREFUL!!!!!!!
        
        var oldToNew = new Dictionary<Node, Node>();

        var q = new Queue<Node>();
        
        oldToNew[start] = new Node(start.val); //So, before we even process an unseen node, as soon as we encounter it, we add its clone here.
        q.Enqueue(start);

        while(q.Count>0)
        {
            var curOld = q.Dequeue();
            foreach(var nei in curOld.neighbors)
            {
                if(oldToNew.TryAdd(nei, new Node(nei.val))) //If it doesn't exist already, it means that it hasn't had its neighbors array filled yet. 
                {
                   q.Enqueue(nei); //queue it up to fill neighbors
                }
                oldToNew[curOld].neighbors.Add(oldToNew[nei]); //fill curOld's current neighbor nei
            }
        }
        return oldToNew[start];
    }
    // public Node bfs1(Node node) //I WAS TRYING TO DO IT IN SUCH A CONVOLUTED WAY!!
    // {
    //     if(node == null) return null; //I DID NOT EVEN THINK ABOUT IT!
    //     HashSet<int> seen = new();

    //     Node dummy = new(-1, new List<int>());
    //     Node parent = dummy;
        
    //     Queue<Node> q = new();
    //     q.Enqueue(node);
    //     while(q.Count>0)
    //     {
    //         var curToClone = q.Dequeue();
    //         var curNew = new Node(curToClone.val, new());
    //         parent.neighbours.Add(curNew);

    //     }
    // }
}
