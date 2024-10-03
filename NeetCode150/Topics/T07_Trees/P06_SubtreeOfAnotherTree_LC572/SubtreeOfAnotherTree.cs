using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P06_SubtreeOfAnotherTree_LC572;

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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        //USE THE NEETCODE SOLN AS REFERENCE!!! (compare to mine?)
        //Time Complexity is of course O(mainTreeLen * subTreeLen)

        // return Attempt1_MyOwn.rec1(root, subRoot);
        return NeetCodeIoBasedSoln.IsSubtree(root, subRoot);
    }
}

public static class NeetCodeIoBasedSoln
{
    public static bool IsSubtree(TreeNode root, TreeNode subRoot) { //Recursive function
        //EDGECASE - COULDN'T HAVE THOUGHT OF THIS: EMPTY TREE IS SUBTREE OF EVERY TREE.
        if (subRoot == null)
            return true;
        //ELSE (because of the return in the if)
        if (root == null) //we know root is not the same as subRoot when its null because of the if above.
            return false;
        //ELSE (because of the return in the if)
        if (SameTree(root, subRoot))  //recursive function used inside another recursive function!
        {
            return true;
        }
        //ELSE (because of the return in the if)
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    public static bool SameTree(TreeNode root, TreeNode subRoot) { //Recursive function
        //My attempt for this part was a little bit better so I used that!
        if(root == null && subRoot == null)
            return true;
        
        if(root?.val != subRoot?.val)
            return false;

        return SameTree(root.left, subRoot.left) && SameTree(root.right, subRoot.right);
    }
}

public static class Attempt1_MyOwn
{
    public static bool rec1(TreeNode root, TreeNode subRoot) 
    {
        bool found = false;
        if(root?.val==subRoot?.val)
            found = recEqCheck1(root, subRoot); //recursive function used inside another recursive function!
        else if(root==null) //above condition implies subRoot != null while here root is. Therefore, we'll be unable to find the subtree from here.
            return false;
        if(found)
            return true;
        else
        {
            if(rec1(root?.left, subRoot)||rec1(root?.right, subRoot))
                return true;
        }
        return false;
    }
    public static bool recEqCheck1(TreeNode root, TreeNode subRoot) //Recursive function
    {
        // Console.WriteLine($"{root?.val}, {subRoot?.val}");
        if(root == null && subRoot == null)
            return true;
        
        if(root?.val != subRoot?.val)
            return false;

        return recEqCheck1(root.left, subRoot.left) && recEqCheck1(root.right, subRoot.right);
    }
}
