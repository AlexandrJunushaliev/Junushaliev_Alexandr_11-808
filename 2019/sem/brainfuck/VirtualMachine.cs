using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
        public VirtualMachine(string program, int memorySize)
		{
            Instructions = program;
            Memory = new byte[memorySize];
            InstructionPointer = 0;
            MemoryPointer = 0;
		}

        private Dictionary<char, Action<IVirtualMachine>> interpretator = new Dictionary<char, Action<IVirtualMachine>>();

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            interpretator.Add(symbol, execute);
        }

		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
		public void Run()
		{
            for (InstructionPointer=0; InstructionPointer < Instructions.Length; InstructionPointer++)
                if (interpretator.ContainsKey(Instructions[InstructionPointer]))
                    interpretator[Instructions[InstructionPointer]](this);
        }
	}
}