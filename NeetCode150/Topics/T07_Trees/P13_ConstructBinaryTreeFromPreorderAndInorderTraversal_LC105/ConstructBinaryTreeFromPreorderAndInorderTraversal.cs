using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P13_ConstructBinaryTreeFromPreorderAndInorderTraversal_LC105;

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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        //Since we are not making changes to the values of the sub-arrays, we can use the ArraySegment wrapper (otherwise it would change the original array as well).
        ReadOnlySpan<int> preo = new(preorder);
        ReadOnlySpan<int> ino = new(inorder);
        //ARRAY SLICING IN C#: https://code-maze.com/csharp-array-slicing/
        //SHOULD HAVE USED ReadOnlySpan!!
        return rec1(preo, ino);
    }

    public TreeNode rec1(ReadOnlySpan<int> preorder, ReadOnlySpan<int> inorder)
    {
        //ACCORDING TO THE NEETCODE VIDEO, WE NEED THE FOLLOWING:   (WATCH THE NEETCODE VIDEO!!!)
        //Note that it's given every value in tree is unique.
        //Fact 1: First value in preorder traversal is always the root. 
        //        This can be done for each subtree after that (as long as we disregard/remove the prevcious root).
        //Fact 2: Every value to the left of an elemen in the in-order traversal array is on the left sub tree 
        //        and every element after that goes in right subtree. (we got through the tree inorder (left to right.))
        
        if(preorder.IsEmpty || inorder.IsEmpty)
            return null;

        var curRoot = new TreeNode(preorder[0]);
        Console.WriteLine(preorder[0]);
        int curPosInInorder = inorder.IndexOf(curRoot.val);

        curRoot.left = rec1(preorder[1..(1+curPosInInorder)], inorder[..curPosInInorder]); //rec1(preorder.Slice(1,1+curPosInOrder), inorder.Slice(0, curPosInOrder));
        //NOTES FOR THE LINE DIRECTLY ABOVE THIS COMMENT:
        //??? (1+curPosInOrder) because the second parameter is length and we want to include the same number of elements in inorder as we do in preorder (i.) We start from 1 because we don't want it as we're done with creating it.
        curRoot.right = rec1(preorder[(1+curPosInInorder)..], inorder[(1+curPosInInorder)..]); //rec1(preorder.Slice(1+curPosInOrder));
        
        return curRoot;
     }

    public static int GetIndexOf(ArraySegment<int> arraySegment, int target)
    {
        int i=0;
        while(true)
        {
            if(arraySegment[i]==target)
                return i;
            i++;
        }
    }
}


//## Thinking out loud: 
//           1
//          /
//         2
//        / \
//       3   5
//      /
//     4
// Preorder: 1, 2, 3, 4, 5
// Inorder:  4, 3, 2, 5, 1
//
// Clearly, when we reach the end of the list, in preorder, the element at the left-most end will be in the beginning.
// That is to say, we can know when a tree ends when we reach the element at the beginning.
// Also, any unseen nodes from then on, are on the right node.