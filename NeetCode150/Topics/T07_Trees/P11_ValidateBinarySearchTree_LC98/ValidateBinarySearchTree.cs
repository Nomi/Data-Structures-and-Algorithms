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
        return rec1Dfs(root);    
    }

    //TC: O(N)
    //SC: O(N) [worst case, best case log2(n)]
    public bool rec1Dfs(TreeNode root)
    {
        if(root==null)
            return true;

        bool isCurNodeValid = (root.left==null||root.left.val<root.val) && (root.right==null||root.right.val>root.val);

        return isCurNodeValid && rec1Dfs(root.left) && rec1Dfs(root.right);
    }
}
