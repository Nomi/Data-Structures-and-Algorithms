using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T04_Stack.P03_EvaluateReversePolishNotation_LC150;

public class Solution {
    public int EvalRPN(string[] tokens) {
        //are we guaranteed input is correct?
        return attempt1(tokens);
    }

    static readonly Dictionary<string, Func<int, int, int>> operations = new(){
        { "+", (x, y) => x + y },
        { "*", (x, y) => x * y },
        { "-", (x, y) => x - y },
        { "/", (x, y) => (int)((double)x / y) } //GOTTA REMEMBER!?!?!
    };

    public int attempt1(string[] tokens)
    {
        Stack<string> stk = new();
        foreach(string s in tokens) //Currently assuming the input is always correct.
        {
            if(int.TryParse(s, out int num))
            {
                stk.Push(s);
                continue;
            }
            //else:
            int.TryParse(stk.Pop(), out int b);//later number is on top of stack!
            int.TryParse(stk.Pop(), out int a);//earlier number will be deeper in the stack, of course!
            //[Important] the above order is because for [a,b,'-'],
            //the stack looks like [b,a] when we encounter '-', 
            //where top is on the left. Therefore, to get a-b as 
            //we want, we pop to get b first, then pop to get
            //a first and b second.
            stk.Push(operations[s](x,y).ToString());
            // Console.WriteLine($"{a} {s} {b} = {stk.Peek()}");
        }
        int.TryParse(stk.Pop(), out int res);
        return res;
    }
}
