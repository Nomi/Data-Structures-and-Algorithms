using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P08_CourseSchedule_LC207;

public class Solution 
{
    ICourseSchedule soln;
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        //I SHOULD HAVE REALIZED THAT numCourses was to get all the course names because there was no other relaible way to do it (AS ALWAYS, LEARN TO CAREFULLY READ THE FKIN PROBLEM!!!)
        
        //[!!!IMPORTANT!!!] 
        //NEED TO PRACTICE!!! 
        //I had done this approximately 3 months ago but forgot.
        //I started by trying an overcomplicated method (using Nodes and building adjacency lists, etc.),
        //but when it got too complicated I checked the solution on neetcodeio and remembered we could do it the way I finally ended up doing it in DfsAttempt1.
        //I think I have heard of Kahn's algorithm but forgot.
        
        //[!!!IMPORTANT!!!] 
        //CHECK THE [OPTIMIZATION] comment IN DfsAttempt1.dfsCycleDetector
        //I DID NOT REALIZE UNTIL THE END WHEN I WAS CALCULATING TIMECOMPLEXITY THAT WE COULD OPTIMIZE THIS WAY!!!
        //I did refer(sneak a peak at) to neetcodeio soln how they did it for inspiration.

        //[!!!IMPORTANT!!!] 
        // I didn't know how to do it with Topological sort / Kahn's algorithm before. BUT:
        // Watched TakeUForward's YouTube video about Kahn's algorithm/Topological sort for it (Title: "G-22. Kahn's Algorithm | Topological Sort Algorithm | BFS")
        // It was extremely helpful and intuitive!!
        // Read the [CAUTION!] message in the bfs function!
        
        /////// SOLUTION:
        // soln = new DfsAttempt1();
        soln = new TopologicalSortKahnsAlgorithmAttempt1();
        return soln.CanFinish(numCourses, prerequisites);
    }
}

public interface ICourseSchedule
{
    bool CanFinish(int numCourses, int[][] prerequisites);
}

public class DfsAttempt1 : ICourseSchedule
{
    //DEPRECATED_DfsAttempt1 to see how convoluted I was making this, even though I could do it so simply!
    Dictionary<int, List<int>> prereqMap;
    HashSet<int> visiting;

    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        prereqMap = new(numCourses);
        visiting = new();
        
        //Fill prereqMap:
        for(int i=0; i<prerequisites.Length;  i++) //O(N) where N is numCourses
        {
            prereqMap.TryAdd(prerequisites[i][0], new());
            prereqMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            // prereqMap.TryAdd(prerequisites[i][1], new()); //Uncomment this if you either: 1. don't initialize hashmap for every course already in a loop above this one 2. in dfs, return true if prereqMap does not contain the course as a Key (because otherwise the program breaks/throws_exception because of the key not being present)
        }

        //DFS to find cycles (meaning you can't take courses in that cycle):
        //O(N*())
        for(int course=0; course<numCourses; course++) //Given that that the courses will be numbered 0 to numCourses-1, we can manually use a normal for loop to do that instead of looping over prereqMap keys.
        {
            if(false == dfsCycleDetector(course)) //CHECK THE [OPTIMIZATION] comment IN dfsCycleDetector
                return false;
        }

        return true;
    }

    bool dfsCycleDetector(int course)
    {
        if(visiting.Contains(course))
            return false;

        if(false == prereqMap.ContainsKey(course)) //Has no prerequisites.
            return true;
        
        visiting.Add(course);

        foreach(var prereq in prereqMap[course])
        {
            if( false == dfsCycleDetector(prereq))
                return false;
        }
        
        visiting.Remove(course);
        prereqMap.Remove(course); //[OPTIMIZATION] DAMN! I WAS CALCULATING TIME COMPLEXITY AND ONLY THEN DID I REALIZE OF THIS IMPROVEMENT!!! (since we already found it doesn't need prerequisites), this way we will never go through it again, saving us time.
        return true;
    }
}

public class TopologicalSortKahnsAlgorithmAttempt1 : ICourseSchedule //topoSort
{
    //[IMPORTANT] 
    // Watched TakeUForward's YouTube video about Kahn's algorithm/Topological sort for this (Title: "G-22. Kahn's Algorithm | Topological Sort Algorithm | BFS")
    // It was extremely helpful and intuitive!!

    List<List<int>> adjList;
    //Number of incoming edges (here, indegree[i] number of courses that depend on the course `i`):
    // List<int> indegree;
    int[] indegree; 

    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        Queue<int> q = new();
        adjList = Enumerable.Repeat(new List<int>(), numCourses).ToList();
        // indegree = Enumerable.Repeat(0, numCourses).ToList();
        indegree = new int[numCourses]; //For arrays, values are initialized to their default value (here 0) by default.
        
        //Fill prereqMap:
        for(int i=0; i<prerequisites.Length;  i++) //O(N) where N is numCourses
        {
            adjList[prerequisites[i][0]].Add(prerequisites[i][1]);
            indegree[prerequisites[i][1]]++;
        }

        //1. Add to queue all courses with indegree == 0
        for(int i=0;i<numCourses ; i++)//[CAUTION!] I WAS USING `i<prerequisites.Length` for the loop condition WHEN IT SHOULD HAVE BEEN `i<numCourses` (spent ~10 mins debugging!)
        {
            if(indegree[i]==0) //We set this up here to eventually basically multi-source bfs from these
                q.Enqueue(i);
        }

        //2. bfs:
        int coursesFinished = bfs(q);
        return (coursesFinished == numCourses);
    }

    int bfs(Queue<int> q)
    {
        int coursesFinished = 0;
        while(q.Count>0) //Each loop continues bfs over all nodes that have 0 indegree at that time (indegree == number of courses that depend on it)
        {
            var curCourse = q.Dequeue();
            coursesFinished++;
            foreach(var prereq in adjList[curCourse])
            {
                indegree[prereq]--;
                if(indegree[prereq]==0)
                    q.Enqueue(prereq);
            }
        }
        return coursesFinished;
    }
}

// public class DEPRECATED_DfsAttempt1 : ICourseSchedule //I WAS OVERCOMPLICATING IT BECAUSE I DIDN'T EVEN NEED A NODE CLASS!! CHECK THE NEW `DfsAtt1emp1`!!!
// {
//     const UNVISITED = 1;
//     const VISITING = 1; //If you encounter a node with this state again, there's a cycle.
//     const VISITED = 2; //Confirmed no cycles.
//     internal class Node
//     {
//         public int course;
//         public int state;
//         public List<int> prereqs;
//         public Node(int _course)
//         {
//             course = _course;
//             dependancyOf = new();
//             state = UNVISITED;
//         } 
//     }
//     public bool CanFinish(int numCourses, int[][] prerequisites)
//     {
//         //1. Make an adjacency list
//         Dictionary<int, Node> adjList = new(n);
//         for(int r = 0; r<prerequisites.Length; r++) //O(numCourses^2)
//         {
//             //READ THE QUESTION PROPERLY!!! I WAS DOING IT THE OTHER WAY AROUND!!!
//             adjList.TryAdd(prerequisites[r][0], new(prerequisites[r][0]));
//             adjList.TryAdd(prerequisites[r][1], new(prerequisites[r][1]));
//             adjlist[prerequisites[r][0]].dependancyOf.Add(prerequisites[r][1]);
//         }

//         //2. DFS to find any cycles
//         foreach((int key, Node node) in adjList)
//         {
//             if(node.state != VISITED)

//         }
//     }

//     bool dfs(node)
//     {
//         if(node==VISITING) //CYCLE
//             return false;
//         foreach(int )
//     }
// }