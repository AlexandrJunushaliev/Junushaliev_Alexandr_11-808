using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Programm
    {
        //Вызывать будут этот метод
        static void MakePermutations(int[] permutation, int position, List<int[]> result)
        {
            if (position == permutation.Length)
            {
                result.Add(permutation.ToArray());
            }
            else
            {
                for (int i = 1; i < permutation.Length; i++)
                {
                    var index = Array.IndexOf(permutation, i, 0, position);
                    if (index != -1)
                    {
                        continue;
                    }
                    permutation[position] = i;
                    MakePermutations(permutation, position + 1, result);
                }
            }
        }

        static void TestOnSize(int size)
        {
            var result = new List<int[]>();
            MakePermutations(new int[size], 1, result);
            foreach (var permutation in result)
                WritePermutation(permutation);
        }
        static void WritePermutation(int[] permutation)
        {
            for (var i=0;i<permutation.Length;i++)
            {
                Console.Write(permutation[i] + " ");
            }
            Console.WriteLine();
        }
        public static void Main()
        {
            TestOnSize(1);
            TestOnSize(2);
            TestOnSize(0);
            TestOnSize(3);
            TestOnSize(4);
        }

    }

    
}
