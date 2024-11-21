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
        soln = new DfsAttempt1();
        return soln.CanFinish(numCourses, prerequisites);
    }
}

public interface ICourseSchedule
{
    bool CanFinish(int numCourses, int[][] prerequisites);
}

public class DfsAttempt1 : ICourseSchedule
{
    Dictionary<int, List<int>> prereqMap;
    HashSet<int> visiting;

    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        prereqMap = new(numCourses);
        visiting = new();
        
        //Fill prereqMap:
        for(int i=0; i<prerequisites.Length;  i++)
        {
            prereqMap.TryAdd(prerequisites[i][0], new());
            prereqMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            // prereqMap.TryAdd(prerequisites[i][1], new()); //Uncomment this if you either: 1. don't initialize hashmap for every course already in a loop above this one 2. in dfs, return true if prereqMap does not contain the course as a Key (because otherwise the program breaks/throws_exception because of the key not being present)
        }

        //DFS to find cycles (meaning you can't take courses in that cycle):
        for(int course=0; course<numCourses; course++) //Given that that the courses will be numbered 0 to numCourses-1, we can manually use a normal for loop to do that instead of looping over prereqMap keys.
        {
            if(false == dfsCycleDetector(course))
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

        return true;
    }
}
// public class DEPRECATED_DfsAttempt1 : ICourseSchedule //I WAS OVERCOMPLICATING IT BECAUSE I DIDN'T EVEN NEED A NODE CLASS!! CHECK THE NEW `DfsAtt1emp1`!!!
// {
//     const UNVISITED = 1;
//     const VISITING = 1;
//     const VISITED = 2;
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