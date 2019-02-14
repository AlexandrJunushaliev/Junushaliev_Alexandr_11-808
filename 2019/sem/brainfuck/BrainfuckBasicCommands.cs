using System;

namespace func.brainfuck
{

    public class BrainfuckBasicCommands
    {
        public static void RegisterConstants(IVirtualMachine vm, char first, char last)
        {
            for (var i = first; i <= last; i++)
            {
                var j = i;
                vm.RegisterCommand(j, b => b.Memory[b.MemoryPointer] = (byte)j);
            }

        }
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            vm.RegisterCommand('+', b => Increase(b));

            vm.RegisterCommand('-', b => Decrease(b));

            vm.RegisterCommand('>', b => MoveToNextCell(b));

            vm.RegisterCommand('<', b => MoveToPreviousCell(b));

            vm.RegisterCommand('.', b => write((char)b.Memory[b.MemoryPointer]));

            vm.RegisterCommand(',', b => b.Memory[b.MemoryPointer] = (byte)read());
            RegisterConstants(vm, 'A', 'Z');
            RegisterConstants(vm, 'a', 'z');
            RegisterConstants(vm, '0', '9');
        }

        private static void Increase(IVirtualMachine vm)
        {
            if (vm.Memory[vm.MemoryPointer] == 255)
                vm.Memory[vm.MemoryPointer] = 0;
            else vm.Memory[vm.MemoryPointer]++;
        }

        private static void Decrease(IVirtualMachine vm)
        {
            if (vm.Memory[vm.MemoryPointer] == 0)
                vm.Memory[vm.MemoryPointer] = 255;
            else vm.Memory[vm.MemoryPointer]--;
        }

        private static void MoveToNextCell(IVirtualMachine vm)
        {
            if (vm.MemoryPointer == vm.Memory.Length - 1)
                vm.MemoryPointer = 0;
            else
                vm.MemoryPointer++;
        }
        private static void MoveToPreviousCell(IVirtualMachine vm)
        {
            if (vm.MemoryPointer == 0)
                vm.MemoryPointer = vm.Memory.Length - 1;
            else
                vm.MemoryPointer--;
        }
    }    
}