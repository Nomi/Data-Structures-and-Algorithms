using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P04_BalancedBinaryTree_LC110;

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
    public bool IsBalanced(TreeNode root) {
        return rec1(root).bal;
    }

    public (int h, bool bal) rec1(TreeNode root)
    {
        //Clearly suited to a Post-Order DFS!
        if(root==null)
            return (0, true);
        var (lh, lbal) = rec1(root.left);
        if(!lbal) return (-1, false);
        var (rh, rbal) = rec1(root.right);
        if(!rbal) return (-1, false);

        if(1<(int)Math.Abs(lh-rh))
            return (-1, false);

        return (1 + (int)Math.Max(lh, rh), true);
    }
}
