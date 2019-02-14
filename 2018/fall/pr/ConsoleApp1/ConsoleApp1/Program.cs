using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "\'";
            var s2 = "a";
            if (String.CompareOrdinal(s2, s1) > 0) Console.WriteLine(s2);
        }
    }
}
