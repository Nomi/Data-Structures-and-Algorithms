using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P07_LowestCommonAncestorOfABinarySearchTree_LC235;

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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {

        //IMPORTANT! USE NEETCODEIO ITERATIVE SOLUTION 
        // BECAUSE IT IS BETTER DUE TO SAME TIME COMPLEXITY BUT O(1) SPACE COMPLEXITY 
        // (recursive has O(log(n) space complexity)!!!!
        //READ THE COMMENTS FOR rec1 (and rec1Helper) 
        // return rec1(root, p, q);
        return itr1_NeetCodeBasedSoln(root, p, q);
    }

    public TreeNode itr1_NeetCodeBasedSoln(TreeNode root, TreeNode p, TreeNode q) //Should modify to bigger and smaller precalculated like in rec1 to simplify conditions!
    {
        while(true)
        {
            if(root.val < p.val && root.val < q.val) //Checking both here because we don't know which one is bigger or smaller, but we could modify it that way (like in the recursive solution!)
                root = root.right;
            else if (root.val > p.val && root.val > q.val)
                root = root.left;
            else
                return root; // Check comments in rec1Helper to check why this works!
        }
    }
    //TC: O(log(n))
    //SC: O(log(n))
    public TreeNode rec1(TreeNode root, TreeNode p, TreeNode q)
    {
        var bigger = p.val>=q.val ? p : q;
        var smaller = p.val>=q.val ? q : p;
        return rec1Helper(root, smaller, bigger);
    }
    public TreeNode rec1Helper(TreeNode root, TreeNode smaller, TreeNode bigger)
    {
        // Console.WriteLine($"{root?.val} : {smaller.val}, {bigger.val}");

        if(root.val>bigger.val)
            return rec1Helper(root.left, smaller, bigger);
        if(root.val<smaller.val)
            return rec1Helper(root.right, smaller, bigger);

        //IF root.val >= smaller.val && root.val <= bigger.val (because of above if conditions) 
        
        //Notice how because of the conditions above we will only ever get here when in the following cases:
        //
        //1. When `root`'s value is between smaller and bigger and as such,
        //this is where the paths diverge (smaller on left and bigger on right).
        //Therefore, this point would be the LOWEST common ancestor.
        //
        //2. If the above condition is untrue, this means that the `root` is either the `smaller` or `bigger` node.
        // and since we haven't found the other one yet and it is guaranteed [clarification question???] that
        // both the values exist in there, we can be sure that this is the lowest common ancestor because this element won't be anywhere after here.
        return root;
    }
}
