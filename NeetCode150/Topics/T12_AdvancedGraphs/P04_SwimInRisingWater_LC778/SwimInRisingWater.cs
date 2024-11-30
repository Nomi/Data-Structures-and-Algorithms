using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P04_SwimInRisingWater_LC778;

public class Solution {
    public int SwimInWater(int[][] grid) {
        //[IMPORTANT!!!] JUST WATCHED THE NEETCODE VIDEO AND:
        //  - We can ignore the t in the question from the perspective of using it to calculate anything, it is just something used to explain the question.
        //  - INSTEAD, WE WILL SOLVE `WHAT IS THE MINIMUM AMOUNT OF TIME TO IT WOULD TAKE TO GET FROM START TO END`
        //  - ALLOWED TRAVEL: UP DOWN LEFT RIGHT (each of these could be considered edges with the weight being the elevation of the destination node)
        //  - WE WANT TO GO FROM GIVEN SOURCE (0,0) TO GIVEN DESTINATION (n-1, n-1) [FACT_1]
        //  - IN ORDER TO SWIM/TRAVEL FROM ONE NODE TO ANOTHER, WE NEED TO WAIT UNTIL t IS >= THAN ELEVATION/VALUE AT BOTH NODES (so there's water to swim),
        //  - SINCE WE CAN SWIM THROUGH ANY PATH IN 0 SECONDS, AS LONG AS ALL THE NODES IN THE PATH ARE <=t, WE CAN TRAVEL THROUGH IT IN 0 SECONDS
        //  - AS SUCH, THE BOTTLENECK IS THE MAXIMUM ELEVATION/VALUE OF ANY NODE IN THE PATH RATHER THAN THE SUM_OF_VALUES/DISTANCE OF WHOLE PATH. [FACT_2] 
        //      (This is because we can just wait at starting node for t = Elevation/Value of maximum node in the path, and then you can swim through the whole path in 0 seconds.)
        //  - From [FACT_1] IT FOLLOWS THAT WE DON'T WANT TO A MST (specific src and dest, and it doesn't matter if we travel all nodes (which could in fact only hurt)).
        //      IT SEEMS *LIKELY* TO BE SPT FROM THIS.
        //  - From [FACT_2] WE CAN CONFRIM WE WANT SHORTEST PATH BECAUSE: Since we want to minimize waiting time, we want to minimize the largest elevation in the path locally. 
        //          We don't care about the globally smallest sum of values/elevations (like we would in MST), but we care about minimizng the (local) elevation FOR EVERY 
        //          node in the path. Even if the sum of their elevations ends up being bigger (because we only wait for the time of the maximum elevation, then swim through that path in 0 seconds).
        //  - For more, read up on my Dijkstra vs MST related comments in `Network Delay Time`

                
    }
}
