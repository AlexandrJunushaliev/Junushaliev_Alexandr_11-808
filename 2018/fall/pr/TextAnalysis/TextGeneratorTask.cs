using System.Collections.Generic;
using System.Text;
namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string>
            nextWords, string phraseBeginning, int wordsCount)
        {
            var firstWords = phraseBeginning.Split();//получение массива первых слов
            var phraseList = new List<string>();
            foreach (var e in firstWords)
                phraseList.Add(e);//добавление этих слов в лист со словами итоговой фразы
            for (var i = 0; i < wordsCount; i++)
                if (firstWords.Length + wordsCount >= 2 && phraseBeginning != null)
                {
                    var lengthOfList = phraseList.Count;
                    var secondWord = "";//слово2 ключа
                    var firstWord = "";//слово1 ключа
                    //если длина фразы на данный момент больше, чем 1, то добавляем слово2 ключа
                    if (lengthOfList >= 2) secondWord = phraseList[phraseList.Count - 2];
                    firstWord = phraseList[phraseList.Count - 1];//добавляем слово1 ключа
                    var key = secondWord + " " + firstWord;//собираем ключ триграммы
                    if (secondWord != "" && nextWords.ContainsKey(key)) phraseList.Add(nextWords[key]);
                    else if (nextWords.ContainsKey(firstWord)) phraseList.Add(nextWords[firstWord]);
                    //если нет триграммы, то делаем про биграмме
                }
            var result = new StringBuilder();
            result.Append(phraseBeginning);
            for (var i = firstWords.Length; i < phraseList.Count; i++)//перевод листа в обычную строку
                result.Append(" " + phraseList[i]);
            return result.ToString();
        }
    }
}