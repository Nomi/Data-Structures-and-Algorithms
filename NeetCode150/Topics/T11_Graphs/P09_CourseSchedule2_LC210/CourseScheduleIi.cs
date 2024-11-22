using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T11_Graphs.P09_CourseSchedule2_LC210;

public class Solution {
    ICourseScheduleIISolver solver;
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        //DID IT MYSELF RIGHT AFTER DOING THE FIRST/ORIGINAL VERSION OF THIS PROBLEM (Course Scheduler)
        solver = new KahnTopoSortSolver();
        return solver.FindOrder(numCourses, prerequisites);
    }
}

public interface ICourseScheduleIISolver
{
    int[] FindOrder(int numCourses, int[][] prerequisites);
}

public class KahnTopoSortSolver : ICourseScheduleIISolver
{
    //Check my solution to Course Schedule (the original) for explanations/comments.
    List<int> indegree; //indegree[i] == number of courses that depend on i (number of incoming edges to i)
    List<List<int>> adj;
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        adj = new(numCourses);
        indegree = new(numCourses);

        //Readying our collections, just C# things (could've used int[] for indegree but chose not to)
        for(int i=0; i<numCourses; i++)
        {
            adj.Add(new());
            indegree.Add(0);
        }

        //Build up adjacency list:
        foreach(var pre in prerequisites)
        {
            adj[pre[0]].Add(pre[1]);
            indegree[pre[1]]++;
        }

        //BFS using Topological Sort / Kahn's Algorithm [using indegrees]
        return bfs(numCourses);
    }

    public int[] bfs(int numCourses)
    {
        //BFS using Topological Sort / Kahn's Algorithm [using indegrees]
        Queue<int> q = new(); //we always store courses we can finish right now here (i.e. indegree = 0)
        int[] topoOrderedResult = new int[numCourses];
        int finishedCourses=0;
        
        for(int crs=0; crs<numCourses; crs++)
        {
            if(indegree[crs]==0)
                q.Enqueue(crs);
        }

        while(q.Count>0)
        {
            var cur = q.Dequeue();

            topoOrderedResult[numCourses-1 - finishedCourses] = cur;
            finishedCourses++;

            foreach(var prereq in adj[cur])
            {
                indegree[prereq]--;
                if(indegree[prereq] == 0)
                    q.Enqueue(prereq);
            }
        }

        return numCourses == finishedCourses ? topoOrderedResult : new int[0];
    }
}