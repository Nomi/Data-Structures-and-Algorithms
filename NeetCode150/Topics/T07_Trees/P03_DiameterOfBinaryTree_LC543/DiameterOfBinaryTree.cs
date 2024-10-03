using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P03_DiameterOfBinaryTree_LC543;

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
    public int DiameterOfBinaryTree(TreeNode root) {
        return attempt1.rec1(root);
    }
}

public static class attempt1
{
    static int max;

    public static int rec1(TreeNode root)
    {
        max = 0;
        rec1Helper(root);
        return max;
    }

    static int rec1Helper(TreeNode root)
    {
        if(root==null)
            return 0;
        int maxEdgesBelowThisL = rec1Helper(root.left);
        int maxEdgesBelowThisR = rec1Helper(root.right);
        int currLocalMaxDiameter = maxEdgesBelowThisL + maxEdgesBelowThisR;
        // Console.WriteLine($"{root.val}: {maxEdgesBelowThisL} + {maxEdgesBelowThisR} = {currLocalMaxDiameter} [Global max: {max}]");

        if(currLocalMaxDiameter>max)
            max = currLocalMaxDiameter;

        return 1 + (int) Math.Max(maxEdgesBelowThisL, maxEdgesBelowThisR);    
    }
}
