using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T06_LinkedList.Common;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P09_LruCache_LC146;

public class LRUCache {
    //Read my solution Attempt1 as it is uses some nifty and useful tricks!!!!
    Attempt1 attempt1;
    public LRUCache(int capacity) {
        attempt1 = new(capacity);
    }
    
    public int Get(int key) {
        return attempt1.Get(key);
    }
    
    public void Put(int key, int value) {
        attempt1.Put(key, value);
    }
}


public class Attempt1
{
    public class Node 
    {
        public Node prev;
        public Node next;
        
        //key is important for removal from dictionary.
        public int key;
        public int val;
        public Node(int _key, int _val)
        {
            key = _key;
            val = _val;
            prev = null;
            next = null;
        }
    }
    Dictionary<int, Node> cache;
    int cap;
    Node left;
    Node right;

    public Attempt1(int capacity) {
        cap = capacity;
        cache = new(cap);
        left = new(-1,-1);
        right = new(-1,-1);
        left.next = right;
        right.prev = left;
    }

    public void RemoveNode(Node node)
    {
        var nodePrev = node.prev;
        var nodeNext = node.next;
        nodePrev.next = nodeNext;
        nodeNext.prev = nodePrev;
    }
    
    public void InsertNodeAtEnd(Node node)
    {
        var rightPrev = right.prev;
        rightPrev.next = node;
        node.prev = right.prev;
        node.next = right;
        right.prev = node;
    }


    
    public int Get(int key) {
        if(cache.TryGetValue(key, out var node))
        {
            RemoveNode(node);
            InsertNodeAtEnd(node);
            return node.val;
        }
        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if(cache.TryGetValue(key, out var existingNode))
        {
            RemoveNode(existingNode);
            InsertNodeAtEnd(existingNode);
            existingNode.val = value;
            return;
        }
        if(cache.Count==cap)
        {
            //Order matters:
            cache.Remove(left.next.key);
            RemoveNode(left.next);
        }
        Node node = new(key, value);
        InsertNodeAtEnd(node);
        cache.Add(key, node);
    }
}