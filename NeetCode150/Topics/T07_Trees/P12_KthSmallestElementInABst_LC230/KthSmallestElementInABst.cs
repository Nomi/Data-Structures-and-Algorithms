using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P12_KthSmallestElementInABst_LC230;

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
    public int KthSmallest(TreeNode root, int k) {
        //READ COMMENTS OF rec1Dfs!!!!
        nodesTraversedInOrder = 0;
        return rec1Dfs(root, k);
    }

    //Came up with the solution on my own but faced a few minor hiccups that I resolved by myself.
    int nodesTraversedInOrder;
    public int rec1Dfs(TreeNode root, int k)
    {
        if(root == null)
            return -404;
        
        var left = rec1Dfs(root.left, k);
        if(left!=-404)
            return left;
        
        //ELSE we still need to look at this node and, if needed, its right subtree
        ///The following comment is DEPRECATED/invalid due to changes abovee. // if(left == -404) //Clearly we don't need to check for this because if we don't then even if we find the node, we will end up with the nodesTraversedInOrder stuck at =k and as such every node after that as we traverse back up to the beginning of the recursive stack will overwrite the correct result in our program.
        nodesTraversedInOrder++;
        if(nodesTraversedInOrder == k) //Found k-th smallest element.
            return root.val;
            
        var right = rec1Dfs(root.right, k);
        return right; //right will be -404 if we don't actually find it in this branch, so we continue our search in that case.
    }
}
