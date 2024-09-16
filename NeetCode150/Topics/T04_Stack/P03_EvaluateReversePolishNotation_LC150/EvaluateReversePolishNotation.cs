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
            int.TryParse(stk.Pop(), out int x);
            int.TryParse(stk.Pop(), out int y);
            stk.Push(operations[s](x,y).ToString());
        }
        int.TryParse(stk.Pop(), out int res);
        return res;
    }
}
