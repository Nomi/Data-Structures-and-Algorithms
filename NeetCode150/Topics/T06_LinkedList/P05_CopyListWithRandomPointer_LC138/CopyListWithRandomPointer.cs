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
        return attempt1(head);
    }
 
    public Node attempt1(Node head)
    {
        Dictionary<Node, Node> orig2new = new();
        Node dummy = new(-1);
        Node newNode = dummy;
        while(head!=null)
        {
            Console.WriteLine(head.val);
            if(orig2new.ContainsKey(head))
            {
                newNode.next=orig2new[head];
            }
            else
            {
                newNode.next = new(head.val);
                orig2new.Add(head, newNode.next);
            }
            Console.WriteLine(head.val);

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
