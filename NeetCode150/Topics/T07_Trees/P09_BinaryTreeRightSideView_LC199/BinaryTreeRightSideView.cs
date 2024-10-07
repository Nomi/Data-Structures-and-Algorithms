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
        // IMPORTANT!! BE CAREFUL!!
        // I DID NOT THINK IF THE TREE COULD BE LARGER TOWARDS THE LEFT SIDE (until I ran into a breaking test case)!!
        return itr1BFS(root);
    }

    public List<int> itr1BFS(TreeNode root)
    {
        List<int> res = new();
        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while(q.Count>0)
        {
            int lastElem = -1;
            for(int i=0, len = q.Count; i<len; i++)
            {
                var cur =  q.Dequeue();
                lastElem = cur.val;
                if(cur.left!=null) q.Enqueue(cur.left);
                if(cur.right!=null) q.Enqueue(cur.right);
            }
            res.Add(lastElem);
        }

        return res;
    }
    
    //THE FOLLOWING IS WRONG BECAUSE A BRANCH ON THE LEFT CAN BE LONGER THAN THE RIGHT MOST BRANCH FROM THE ROOT!!!
    // public List<int> itr1DfsRHS(TreeNode root)
    // {
    //     List<int> res = new();
    //     while(root!=null)
    //     {
    //         res.Add(root.val);
    //         root = root.right??root.left;
    //     }
    //     return res;
    // }
}
