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
            }
        }
        return res;
    }
}
