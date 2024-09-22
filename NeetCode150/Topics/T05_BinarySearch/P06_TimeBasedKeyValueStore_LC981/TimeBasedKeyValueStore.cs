using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P06_TimeBasedKeyValueStore_LC981;

public class TimeMap {
    Dictionary<string, List<(string val, int ts)>> map;
    public TimeMap() {
        map = new();
    }
    
    public void Set(string key, string value, int timestamp) {
        map.TryAdd(key, new());
        map[key].Add((value, timestamp));
    }
    
    public string Get(string key, int timestamp) {
        if(!map.ContainsKey(key)) //EDGE CASE I ONLY FIGURED OUT BECAUSE OF CODE PROVIDED ON NC.io
            return "";
        var list = map[key];
        int l = 0, r = list.Count-1;
        string res = "";
        while(l<=r)
        {
            int m = (l+r)/2;
            Console.WriteLine(list[m]);
            var (mVal, mTs) = list[m];
            if(mTs>timestamp)
                r = m-1;
            else if (mTs<=timestamp)
            {
                res = mVal; 
                l = m+1;
                //[IMPORTANT NOTE]
                //we don't need Math.Max because any further 
                //ones matching this condition will be the 
                //most recent because we increase l.

                //e.g. considering only timestamps: [0,1,2,4,6] 
                //At timestamp 5 as input, we use bs:
                //first check mid at m=2, which is 2 and 2<=5
                //so either it is the newest timestamp that we can consider
                //or there's one or more after it <=5. We don't consider anything to its left including itself (by setting left to mid+1) because we already know there's one <=5 that's newer than those (as for 2 itself, we already set it as the newest and it won't change unless we find a newer timestamp <=5)
                //Then m=3, which is 4, and just like above, we set timestamp to this because it is newer than all those considered before it (by definition).
                //Then m = 4, which is 6, but 6 is > 5, so we don't consider and move r to mid-1.
            }
        }
        return res;
    }
}
