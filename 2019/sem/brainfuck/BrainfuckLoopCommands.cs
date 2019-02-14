using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static void RegisterTo(IVirtualMachine vm)
        {
            
            var beginEnd = FindBeginEnds(vm.Instructions);
            vm.RegisterCommand('[', b => OpenBracket(b,beginEnd));
            vm.RegisterCommand(']', b => CloseBracket(b,beginEnd));
        }
        private static void OpenBracket(IVirtualMachine b, Dictionary<int,int> beginEnd)
        {
            if (b.Memory[b.MemoryPointer] == 0) b.InstructionPointer = beginEnd[b.InstructionPointer];

        }
        private static void CloseBracket(IVirtualMachine b, Dictionary<int, int> beginEnd)
        {
            if (b.Memory[b.MemoryPointer] != 0) b.InstructionPointer = beginEnd[b.InstructionPointer];

        }

        private static Dictionary<int, int> FindBeginEnds(string instructions)
        {
            var beginEnd = new Dictionary<int, int>();
            var stack = new Stack<int>();
            for (var i = 0; i < instructions.Length; i++)
            {
                if (instructions[i] == '[')
                    stack.Push(i);

                if (instructions[i] == ']')
                {
                    var beginPosition = stack.Pop();
                    var endPosition = i;

                    beginEnd.Add(beginPosition, endPosition);
                    beginEnd.Add(endPosition, beginPosition);
                }
            }
            return beginEnd;
        }
    }
}