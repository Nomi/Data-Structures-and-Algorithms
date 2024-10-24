using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P05_TaskScheduler_LC621;

public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        return attempt1(tasks, n);
    }

    //[IMPORTANT NOTES] READ THE COMMENTS!!! (and maybe watch neetcodeio video? because I had to watch his video too{the intuition and solution explanation part, not the code})
    //time complexity: O(tasks.Length)
    
    //space complexity: O(tasks.Length)
    public int attempt1(char[] tasks, int n)
    {
        // >>> Starting out with the most frequent ones first gives us more opportunity to reduce idle time
        //e.g. AB_AB_A (n=2, tasks=a,a,a,b,b) is better than BA_BA__A [where'_' represents idle time]
        //or for tasks=a,a,a,b,b,c,c, n=1: ABCABCA is better than CBCBA_A_A

        // >>> We fill the ones with more elements (that aren't finished waiting for cooldown) because that way we can fill more of the blanks. 
        // >>> We maintain a cooldown Queue that stores all the elements (and when we can execute them next) in order of execution, using this we can execute only the max ones that aren't finished coolingdown.
        // >>> We remove elements from PriorityQueue until they haven't finished coolingdown, and put them back when they have.
        // This is how we achieve only executing the ones with most element that don't need to cooldown yet.

        // >>> As such, at any point, we try to pick the remaining character with the most remaining letters at the time (that isn't in the cooldown queue).
        //e.g. for tasks=a,a,a,b,b,c,c, n=1: ABCABCA is better than ABABAC_C (but equally good/same as ABABCAC, but that doesn't matter because it still can't be smaller than picking most frequent first so we can fill more of the blanks)
        
        ////// SOLUTION (code) :::
        int cpuCycles = 0;
        int[] charCountMap = new int[26];
        PriorityQueue<int, int> maxHeap = new(26);
        Queue<(int count, int nextAvailableTime)> q = new(26);

        //Count tasks count and populate inital maxheap:
        for(int i=0; i<tasks.Length; i++)
        {
            charCountMap[tasks[i] - 'A']++;
        }

        for(int i=0; i<charCountMap.Length;i++)
        {
            if(charCountMap[i]>0)
            {
                maxHeap.Enqueue(charCountMap[i],-charCountMap[i]);
            }
        }

        //Simulate cycles:
        while(maxHeap.Count>0 || q.Count>0)
        {            
            //Any tasks finsihed cooldown?
            if(q.Count>0 && q.Peek().nextAvailableTime <= cpuCycles) //we don't need to make this into a while loop because only 1 task runs at a time, so only 1 task can finish at a time (cuz n is fixed)
            {
                int temp = q.Dequeue().count;
                maxHeap.Enqueue(temp, -temp);
            }
            
            //Are there any tasks that aren't in cooldown?
            if(maxHeap.Count > 0)
            {
                int curCnt = maxHeap.Dequeue(); //Gives the max count becuz it's a MaxHeap //Note: Since we only have 26 possible characters, the time complexity of minheap part is O(log2(26)) which is <=> O(1) (asymptotically bound).
                if(--curCnt > 0)
                    q.Enqueue((curCnt,(cpuCycles+1)+n));//(n+1) because we want to exclude the current (cpuCycles+1)+n in this count.      //can avoid if we move the cpuCycle increment between this and the above condition.
            }

            //increment cycles count
            cpuCycles++;
        }

        return cpuCycles;
    }
}
