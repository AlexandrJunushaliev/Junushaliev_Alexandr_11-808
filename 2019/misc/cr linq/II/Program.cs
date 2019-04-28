using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_II
{
    public static class IEnumerableExt
    {
        public static IEnumerable<Tuple<TItem1,TItem2>> LOL<TItem,TItem1,TItem2>(this IEnumerable<TItem> items, IEnumerable<TItem1> first, IEnumerable<TItem2> second,Func<TItem1,TItem2,bool> predicate)
        {
            foreach (var elem1 in first)
            {
                foreach (var elem2 in second)
                {
                    if (predicate(elem1, elem2)) yield return Tuple.Create(elem1, elem2);
                }
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

        }
    }
}
