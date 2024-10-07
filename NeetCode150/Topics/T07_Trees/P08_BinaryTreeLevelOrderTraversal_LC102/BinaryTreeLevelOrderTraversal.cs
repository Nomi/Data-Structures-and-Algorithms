using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P08_BinaryTreeLevelOrderTraversal_LC102;

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
    public List<List<int>> LevelOrder(TreeNode root) {
        return bfs1(root);   
    }

    public List<List<int>> bfs1(TreeNode root) 
    {
        if(root == null)
            return new();
        List<List<int>> res = new();
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while(q.Count>0)
        {
            List<int> curLevel = new();
            var curLevelCount = q.Count;
            for(int i=0; i<curLevelCount; i++)
            {
                var node = q.Dequeue();
                curLevel.Add(node.val);

                if(node.left!=null) q.Enqueue(node.left);
                if(node.right!=null) q.Enqueue(node.right);
            }
            res.Add(curLevel);
        }
        return res;
    }
}
