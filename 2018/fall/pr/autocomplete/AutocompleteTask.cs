// Вставьте сюда финальное содержимое файла AutocompleteTask.cs
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];

            return null;
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);

            count = Math.Min(GetCountByPrefix(phrases, prefix), count);
            var topPhrases = new string[count];
            for (var i = 0; i < count; i++)
            {
                topPhrases[i] = phrases[index + i + 1];
            }
            return topPhrases;
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index1 = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var index2 = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            return index2 - index1 - 1;
        }
    }
}

[TestFixture]
public class AutocompleteTests
{
    [Test]
    public void TopByPrefix_IsEmpty_WhenNoPhrases()
    {
        List<string> phrase = new List<string> { };
        var res = Autocomplete.AutocompleteTask.GetTopByPrefix(phrase, "a", 10);
        Assert.AreEqual(0, res.Length, $"Failed on TopByPrefix_IsEmpty_WhenNoPhrases: expected length: 0, but was {res.Length}");
    }

    [Test]
    public void TopByPrefix_WhenPhraseAndPrefixNonEmpty_And_CountMoreThenWords()
    {
        List<string> phrase = new List<string> { "aa", "ab", "c" };
        var res = Autocomplete.AutocompleteTask.GetTopByPrefix(phrase, "a",10);
        Assert.AreEqual(new List<string> {"aa","ab" }, res, $"TopWord_WhenPhraseAndPrefixNonEmpty: expected phrases: \"aa\",\"ab\", but was \"{res[0]}\",\"{res[1]}\"");
    }
    [Test]
    public void TopByPrefix_WhenPhraseAndPrefixNonEmpty_And_CountLessThenWords()
    {
        List<string> phrase = new List<string> { "aa", "ab", "c" };
        var res = Autocomplete.AutocompleteTask.GetTopByPrefix(phrase, "a", 1);
        Assert.AreEqual(new List<string> { "aa" }, res, $"TopWord_WhenPhraseAndPrefixNonEmpty: expected phrases: \"aa\", but was \"{res[0]}\"");
    }

    [Test]
    public void TopByPrefix_IsPhrases_WhenEmptyPrefix()
    {
        List<string> phrase = new List<string> {"a","bb" };
        var res = Autocomplete.AutocompleteTask.GetTopByPrefix(phrase, "", 10);
        Assert.AreEqual(phrase, res, $"Failed on TopByPrefix_IsPhrases_WhenEmptyPrefix: expected phrases: \"a\",\"bb\", but was \"{res[0]}\",\"{res[1]}\"");
    }

    [Test]
    public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
    {
        List<string> phrase = new List<string> {"aaa", "bb", "c" };
        var res = Autocomplete.AutocompleteTask.GetCountByPrefix(phrase, "");
        Assert.AreEqual(phrase.Count, res, $"Failed on CountByPrefix_IsTotalCount_WhenEmptyPrefix: expected count: {phrase.Count}, but was {res}");
    }
}

