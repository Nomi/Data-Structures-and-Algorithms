using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P15_SerializeAndDeserializeBinaryTree_LC297;

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

public class Codec {
    //READ MY COMMENTS FROM Attempt1 !!! (Both the notes outside functions and the comments inside the functions!!)
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        return (new Attempt1()).Serialize(root);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        return (new Attempt1()).Deserialize(data);
    }
}


public class Attempt1
{
    //NOTES: 
    //1. Partially based on NEETCODEIO, mostly done by myself
    //2. VERY EASY ONCE YOU KNOW THE TRICK, SORT OF (there's just some things to consider maybe??)
    //3. COMPARE SOLUTION WITH NEETCODEIO!
    //4. I HAD WATCHED NEETCODE'S VIDEO (the approach part only, not the code) A FEW DAYS AGO WHEN I WAS CONFUSED ON WHAT TO DO.
    //5. WATCH THE APPROACH PART OF NEETCODE's VIDEO???
    //6. Check/read_through the solution once?

    List<string> listElemStr;

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) 
    {
        listElemStr = new();
        dfsSerialize(root);
        return string.Join(',', listElemStr);
    }
    void dfsSerialize(TreeNode root)
    {
        if(root==null)
        {
            listElemStr.Add("N");
            return;
        }
        listElemStr.Add(root.val.ToString());
        dfsSerialize(root.left);
        dfsSerialize(root.right);
        return;
    }

    // Decodes your encoded data to tree.
    int curIdx;
    public TreeNode Deserialize(string serializedTree) 
    {
        curIdx = 0;
        listElemStr = serializedTree.Split(',').ToList(); //Can get rid of this ToList if we follow how NeetCodeIo does it!
        return dfsDeserialize();
    }
    public TreeNode dfsDeserialize() 
    {
        //due to our serialization covering every node and every leaf (and every null "child" of the leaf) 
        //the recursion will EXACTLY, COMPLETELY run through the whole array (not less nor more).

        if(listElemStr[curIdx]=="N")
        {
            curIdx++;
            return null;
        }

        var curNode = new TreeNode(int.Parse(listElemStr[curIdx]));
        curIdx++;
        curNode.left = dfsDeserialize();
        curNode.right = dfsDeserialize();

        return curNode;
    }   
}