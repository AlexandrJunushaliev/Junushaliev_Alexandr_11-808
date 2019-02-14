using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        private static void UpdateDictionary(Dictionary<string, Dictionary<string, int>> dictionary, string key, string value)
        {
            if (dictionary.ContainsKey(key))
            {
                if (dictionary[key].ContainsKey(value))
                {
                    dictionary[key][value]++;
                }
                else
                {
                    dictionary[key].Add(value, 1);
                }
            }
            else
            {
                dictionary.Add(key, new Dictionary<string, int>() { { value, 1 } });
            }
        }


        public static Dictionary<string, Dictionary<string, int>> GetBigrammAndThreegramm(Dictionary<string, Dictionary<string, int>> dictWithNGramms, List<string> sentence)
        {
            //получение ключей и всех возможных значений окончаний биграмм и триграмм при этих ключах
            for (var i = 0; i < sentence.Count - 1; i++)
            {
                UpdateDictionary(dictWithNGramms, sentence[i], sentence[i + 1]);

                if (i < sentence.Count - 2)
                {
                    UpdateDictionary(dictWithNGramms, sentence[i] + " " + sentence[i + 1], sentence[i + 2]);
                }
            }
            return dictWithNGramms;
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var ans = new Dictionary<string, string>();
            var dictWithNGramms = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                dictWithNGramms = GetBigrammAndThreegramm(dictWithNGramms, sentence);
            }
            //нахождение самой частовстречающейся нграммы по словарю 
            foreach (var e in dictWithNGramms)
            {
                int max = -1;
                string value = "";
                foreach (var e1 in e.Value)
                {
                    if(e1.Value == max && string.CompareOrdinal(e1.Key, value) < 0 || e1.Value > max)
                    {
                        value = e1.Key;
                        max = e1.Value;
                    }
                }
                ans.Add(e.Key, value);
            }
            return ans;
        }
    }
}