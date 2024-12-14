using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T06_LinkedList.P05_CopyListWithRandomPointer_LC138;

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {

        //USE NEETCODE IO SOLUTION AS REFERENCE? 
        //Because, even though my solution (attempt1) and that are both using the same logic,
        //that code is a little cleaner and less verbose (due to the structure).
        
        // return attempt1(head);
        return NeetCodeIoSoln(head);
    }
    
     public Node NeetCodeIoSoln(Node head) 
     {
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;
        while (cur != null) {
            Node copy = new Node(cur.val);
            oldToCopy[cur] = copy;
            cur = cur.next;
        }

        cur = head;
        while (cur != null) {
            Node copy = oldToCopy[cur];
            copy.next = cur.next != null ? oldToCopy[cur.next] : null;
            copy.random = cur.random != null ? oldToCopy[cur.random] : null;
            cur = cur.next;
        }

        return head != null ? oldToCopy[head] : null;
    }

    public Node attempt1(Node head)
    {
        Dictionary<Node, Node> orig2new = new();
        Node dummy = new(-1);
        Node newNode = dummy;
        while(head!=null)
        {
            if(orig2new.ContainsKey(head))
            {
                newNode.next=orig2new[head];
            }
            else
            {
                newNode.next = new(head.val);
                orig2new.Add(head, newNode.next);
            }

            newNode = newNode.next;
            
            if(head.random!=null)
            {
                if(orig2new.ContainsKey(head.random))
                {
                    newNode.random = orig2new[head.random];
                }
                else
                {
                    newNode.random = new(head.random.val);
                    orig2new.Add(head.random, newNode.random);
                }
            }
            
            Console.WriteLine(head.val);

            head = head.next;
        }

        return dummy.next;
    }
}
