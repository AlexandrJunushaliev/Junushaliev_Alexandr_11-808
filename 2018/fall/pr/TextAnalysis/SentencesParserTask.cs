using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<string> GettingWordsList(string sentence)
        {
            var wordsList = new List<string>(); //создание листа слов предложения
            var word = new StringBuilder(); //одно слово в предложении
            foreach (var chr in sentence)
            {
                //если символ ' или символ, то добавляем его в слово
                if (char.IsLetter(chr) || chr == '\'') word.Append(char.ToLower(chr));
                else
                {
                    if (word.Length != 0)
                    { //если слово не пустое, то добавляем его в лист слов и очищаем слово
                        wordsList.Add(word.ToString());
                        word.Clear();
                    }
                }
            }

            if (word.Length != 0) //проверка на добавление последнего слова
                wordsList.Add(word.ToString());
            return wordsList;
        }

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentences = text.Split('.', '!', '?', '(', ')', ':', ';');
            //разбивка исходного текста на предложения по символам-разделителям

            foreach (var sentence in sentences) //прогон по предложениям
            {
                if (String.IsNullOrWhiteSpace(sentence)) //если предложение пустое, то переходим к следующему
                {
                    continue;
                }

                var wordsList = GettingWordsList(sentence);
                if (wordsList.Count != 0)
                    sentencesList.Add(wordsList);
            }
            return sentencesList;
        }
    }
}