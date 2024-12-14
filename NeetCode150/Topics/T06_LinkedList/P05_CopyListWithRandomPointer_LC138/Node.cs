namespace DSA.NeetCode150.Topics.T06_LinkedList.P05_CopyListWithRandomPointer_LC138;

public class Node 
{
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) 
    {
        val = _val;
        next = null;
        random = null;
    }
}