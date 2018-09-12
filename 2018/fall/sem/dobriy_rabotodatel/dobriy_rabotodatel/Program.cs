using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dobriy_rabotodatel
{
    class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            //return "Hello, " + name + ", your salary is " + Math.Ceiling(salary).ToString();
            //return String.Format("Hello, {0}, your salary is {1}", name, Math.Ceiling(salary));
            return $"Hello, {name}, your salary is {Math.Ceiling(salary)}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
        }
    }
}
