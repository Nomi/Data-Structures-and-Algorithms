using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T08_HeapAndPriorityQueue.P06_DesignTwitter_LC355;

public class Twitter {
    ITwitter backend;
    public Twitter() {
        //CHECK ATTEMPT1 COMMENTS!!!
        //Watch neetcode video?
        //maybe compare with neetcodeio c# soln?
        backend = new attempt1();
    }
    
    public void PostTweet(int userId, int tweetId) {
        backend.PostTweet(userId, tweetId);
    }
    
    public List<int> GetNewsFeed(int userId) {
        return backend.GetNewsFeed(userId);
    }
    
    public void Follow(int followerId, int followeeId) {
        backend.Follow(followerId, followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        backend.Unfollow(followerId, followeeId);
    }
}

public interface ITwitter 
{
    public void PostTweet(int userId, int tweetId);
    
    public List<int> GetNewsFeed(int userId);
    
    public void Follow(int followerId, int followeeId);
    
    public void Unfollow(int followerId, int followeeId);
}


public class attempt1 : ITwitter
{
    Dictionary<int, HashSet<int>> followMap; //EDGE CASE: INITIALLY HAD List<int> for followed users because I didn't consider the possiblity of keeping followers unique (and constant time unfollow)
    Dictionary<int, List<(int content, int time)>> tweetMap;
    int time;
    const int MAX_TWEETS_IN_FEED = 10;

    public attempt1() {
        followMap = new();
        tweetMap = new();
        time = 0; 
    }
    
    public void PostTweet(int userId, int tweetId) {
        Follow(userId, userId);//this is to make sure a user sees tweets they made //HAD MISSED THIS EARLIER (didn't read description properly I guess?)
        time++;
        tweetMap.TryAdd(userId, new List<(int,int)>(){});
        tweetMap[userId].Add((tweetId, time));
    }
    
    public List<int> GetNewsFeed(int userId) {         
        if(!followMap.ContainsKey(userId))
            return new(){};
        
        PriorityQueue<(int content, int time),int> minHeap = new(MAX_TWEETS_IN_FEED);
        foreach(int followeeId in followMap[userId])
        {
            if(!tweetMap.ContainsKey(followeeId))
                continue;
            foreach(var tweet in tweetMap[followeeId])
            {
                if(minHeap.Count<MAX_TWEETS_IN_FEED)
                {
                    minHeap.Enqueue(tweet, tweet.time);
                }
                else if(minHeap.Peek().time<tweet.time)
                {
                    minHeap.Dequeue();
                    minHeap.Enqueue(tweet, tweet.time);
                }
            }
        }

        //IMPORTANT NOTE!!!!
        //MISSED THE LINE : "Tweets IDs should be ordered from most recent to least recent." earlier.
        //If the input wasn't so small, MAYBE? we should have used SortedSet (like in NeetCodeIo C# example) to avoid making a redundant int[] which gets copied to create a List<int> to return.
        int[] res = new int[minHeap.Count];
        while(minHeap.Count>0)
        {
            res[minHeap.Count-1] = minHeap.Dequeue().content;
        }
        return new List<int>(res);
    }
    
    public void Follow(int followerId, int followeeId) {
        followMap.TryAdd(followerId, new HashSet<int>());
        followMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followerId==followeeId) //FORGOT ABOUTT THIS EDGE CASE AS WELL UNTIL LATE INTO THE GAME!! (maybe because I added the functionality to follow the user themselves autmatically just recently / a minute ago as well)
            return;
        if(followMap.ContainsKey(followerId)) //forgot about checking for this edge case earlier
            followMap[followerId].Remove(followeeId);
    }
}
