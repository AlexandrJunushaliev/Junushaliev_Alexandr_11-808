using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            return BinSearchLeftBorder(phrases, prefix, -1, phrases.Count);
        }

        public static int BinSearchLeftBorder(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (left == right - 1) return left; //при достижении этого равенства возвращаем левую границу
            var middle = left + (right - left) / 2;
            if (string.Compare(phrases[middle], prefix, StringComparison.OrdinalIgnoreCase) < 0)
                return BinSearchLeftBorder(phrases, prefix, middle, right); //принимаем левую границу за m
            return BinSearchLeftBorder(phrases, prefix, left, middle); //иначе правую за m
        }
    }
}
