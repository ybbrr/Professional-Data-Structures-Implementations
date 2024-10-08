﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Stack'imin dizini
using DataStructures.Stack;

namespace Apps
{
    public class PostFixExamples
    {
        private string expression;
        Stack_<string> S = new Stack_<string>();

        private string Expression()
        {
            int val1, val2, ans;
            for (int i = 0; i < expression.Length; i++)
            {
                String c = expression.Substring(i, 1); //i'inci karakterden itibaren 1 karakter al demektir.

                if (c == " ")
                {
                    continue;
                }

                if (c.Equals("*"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 * val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("/"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 / val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("+"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 + val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("-"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 - val1;
                    S.Push(ans.ToString());
                }
                else
                {
                    S.Push(c);
                }
            }
            return S.Pop();
        }

        public static string Run(string expression)
        {
            PostFixExamples e = new PostFixExamples();
            e.expression = expression;
            return e.Expression();
        }

    }
}
