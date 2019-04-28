using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_I
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>();
            var i = 0;
            var b = l.Select(v =>
            {
                i++;
                return v * i;
            })
            .Where(v => v / 10 >= 0).Reverse();
        }
    }
}
