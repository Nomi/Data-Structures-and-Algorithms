using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P01_InvertBinaryTree_LC226;

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
    public TreeNode InvertTree(TreeNode root) {
        //REMEMBER TO CHECK FOR NULL (leafs)!!!
        return attempt1(root);
    }


    public TreeNode attempt1(TreeNode root)
    {
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while(q.Count>0)
        {
            var cur = q.Dequeue();
            if(cur==null) //I FORGOT THIS SOMEHOW!!! :'(
                continue;
            var l = cur.left;
            var r = cur.right;
            q.Enqueue(l);
            q.Enqueue(r);
            cur.left = r;
            cur.right = l;
        }
        return root;
    }
}
