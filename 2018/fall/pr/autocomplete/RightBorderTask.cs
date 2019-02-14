using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            while (right - left != 1)
            {
                var middle = left + (right-left) / 2;
                if (string.Compare(phrases[middle], prefix,StringComparison.OrdinalIgnoreCase) < 0 ||
                    phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = middle;//аналогично поиску левой границы, но при равенстве смещается левая граница
                else right = middle;
            }
            return right;//если элемента нет в словаре, right за проход цикла не изменится и вернет длину списка
        }
    }
}