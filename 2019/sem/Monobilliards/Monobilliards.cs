using System;
using System.Collections.Generic;

namespace Monobilliards
{
    public class Monobilliards : IMonobilliards
    {

        public bool IsCheater(IList<int> inspectedBalls)
        {
            var stack = new Stack<int>();
            var j = 0;
            for (var i = 1; i <= inspectedBalls.Count; i++)
            {
                stack.Push(i);
                while (stack.Count != 0 && stack.Peek() == inspectedBalls[j])
                {
                    stack.Pop();
                    j++;
                }
            }
            if (stack.Count != 0)
            {
                while (j != inspectedBalls.Count && stack.Peek() == inspectedBalls[j])
                {
                    stack.Pop();
                    j++;

                }
            }
            return stack.Count != 0;
        }
    }
}