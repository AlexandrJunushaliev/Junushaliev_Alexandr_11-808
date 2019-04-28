using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите регулярное выражение (шаблон)(^ - звездочка Клини, + - плюс, * - умножить):");
            var n = Console.ReadLine();           
            var exp = RPN.GetExpression(n);
            Console.WriteLine("Регулярное выражение в обратной польской нотации: " + exp);
            var nfa = EpsilonNFA.BuildEpsilonNFAByExp(exp);
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();
            var index = EpsilonNFA.ByPassENFA(nfa, text);           
            if (index==-1)
            {
                Console.WriteLine("Индекса нет");
            }
            else Console.WriteLine("Минимальный индекс j = " + index);
        }
    }
}