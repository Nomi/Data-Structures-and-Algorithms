using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P05_SameTree_LC100;

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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        return rec1Dfs(p,q);
    }

    public bool rec1Dfs(TreeNode p, TreeNode q)
    {
        if(null == p && null == q)
            return true;
        if(p?.val != q?.val)
            return false;
        return (rec1Dfs(p.left, q.left) && rec1Dfs(p.right, q.right));
    }
}
