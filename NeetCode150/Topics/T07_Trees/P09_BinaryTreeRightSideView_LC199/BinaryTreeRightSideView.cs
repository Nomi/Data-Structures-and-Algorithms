using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P09_BinaryTreeRightSideView_LC199;

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
    public List<int> RightSideView(TreeNode root) {
        return itr1DfsRHS(root);
    }

    public List<int> itr1DfsRHS(TreeNode root)
    {
        List<int> res = new();
        while(root!=null)
        {
            res.Add(root.val);
            root = root.right;
        }
        return res;
    }
}
