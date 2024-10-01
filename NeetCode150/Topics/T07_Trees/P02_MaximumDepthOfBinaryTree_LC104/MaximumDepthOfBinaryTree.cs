using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P02_MaximumDepthOfBinaryTree_LC104;

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
    public int MaxDepth(TreeNode root) {
        // return recDfs1(root); //Best solution?
        return itrBfs1(root);
    }

    public int recDfs1(TreeNode root) //Best solution?
    {
        if(root == null)
            return 0;
        return (int) Math.Max(1+recDfs1(root.left), 1+recDfs1(root.right));
    }

    public int itrBfs1(TreeNode root) 
    {
        if(root==null)
            return 0;
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        int maxDepth = 0;

        while(q.Count>0)
        {
            maxDepth++;
            var countAtThisDepth = q.Count;
            for(int i=0;i<countAtThisDepth;i++)
            {
                var cur = q.Dequeue();
                if(cur.left!=null)
                    q.Enqueue(cur.left);
                if(cur.right!=null)
                    q.Enqueue(cur.right);
            }
        }
        return maxDepth;
    }
}
