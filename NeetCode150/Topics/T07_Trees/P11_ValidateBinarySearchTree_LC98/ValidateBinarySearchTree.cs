using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P11_ValidateBinarySearchTree_LC98;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public bool IsValidBST(TreeNode root) {
        //EASY BUT TRICKY (Important: read comments on the `rec1Dfs` function.)
        //COULDN'T COME UP WITH MY OWN SOLUTION AND HAND TO WATCH THE FIRST ~5 MINUTES OF Greg Hogg's VIDEO ABOUT IT TO COME UP WITH THE CODE (the basic idea was from the video itself, obviously)
        return rec1Dfs(root, int.MinValue, int.MaxValue); // Given the constraints, could've also done: -1001, 1001);
    }

    //TC: O(N)
    //SC: O(N) [worst case, best case log2(n)]
    public bool rec1Dfs(TreeNode root, int min, int max) //Clearly in-order is more efficient because it ends quickly.
    {
        //Base case:
        if(root==null)
            return true;

        //The exclusive range (min, max) is such that: 
        //- `min` is the value of the most recent node from which the direction of our traversal was to the right (meaning all elements
        //from the subtree starting at that right child had to be bigger than that).
        //- `max` is the value we have seen at the most recent node from which we travel left (meaning all elements of the subtree starting
        //at the left child are smaller than that).
        bool isCurNodeValid = (min < root.val) && (root.val < max); //min and max are exclusive because of how it's implemented.

        return isCurNodeValid &&  
            rec1Dfs(root.left, min, root.val) &&  
            rec1Dfs(root.right, root.val, max);
        //For an explanation of how/why this works, either read the comments on isCurNodeValid evaluation or watch Greg Hogg's video.
    }
}
