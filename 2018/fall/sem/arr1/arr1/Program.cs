using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arr1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[5];
            for (var i = 0; i < 5; i++)
                arr[i] = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            for (var i = 0; i < 5; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            Array.Reverse(arr, 0, arr.Length);
            Array.Reverse(arr, 0, k);
            Array.Reverse(arr, k, arr.Length-k);
            
            for (var i = 0; i < 5; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
