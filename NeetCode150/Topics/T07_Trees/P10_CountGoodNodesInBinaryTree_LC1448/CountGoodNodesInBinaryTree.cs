using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P10_CountGoodNodesInBinaryTree_LC1448;

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
    public int GoodNodes(TreeNode root) {
        return rec1Dfs(root, int.MinValue);
    }

    public int rec1Dfs(TreeNode root, int maxThusFar)
    {
        if(root == null)
            return 0;
        int curSum = root.val>=maxThusFar ? 1 : 0; //IMPORTANT: DID NOT REALIZE I HAD TO DO >= instead of just > at first.
        
        curSum += rec1Dfs(root.left, (int)Math.Max(maxThusFar, root.val));
        curSum += rec1Dfs(root.right, (int)Math.Max(maxThusFar, root.val));

        return curSum;
    }
}
