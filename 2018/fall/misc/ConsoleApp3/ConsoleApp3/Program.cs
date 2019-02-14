using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }
        static Array Combine(params Array[] arrays)
        {
            var typeList = new List<Type>();
            foreach(var array in arrays)
            {
                typeList.Add(array.GetType().GetElementType());
            }
            var summaryLength = 0;
            foreach(var array in arrays)
            {
                summaryLength += array.Length;
            }
            
            
            if (Compare(typeList))
            {
                var result = Array.CreateInstance(typeList[0], summaryLength);
                var k = 0;
                foreach (var array in arrays)
                {
                    for (var i = 0; i < array.Length; i++)
                    {
                        result.SetValue(array.GetValue(i), i+k);
                    }
                    k += array.Length;
                }
                return result;
            }
            else return null;
            
        }
        static bool Compare(List<Type> typeList)
        {
            if (typeList.Count == 0) return false;
            else
            {
                var firstType = typeList[0];
                foreach (var type in typeList)
                {
                    if (type != firstType) return false;
                }
                return true;
            }
        }
            
        
    }
}
