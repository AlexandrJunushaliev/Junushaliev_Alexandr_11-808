using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        public Dictionary<int, string[]> Docs = new Dictionary<int, string[]>();
        public Dictionary<string,
            Dictionary<int,
                List<int>>> DictionaryOfWords = new Dictionary<string, Dictionary<int, List<int>>>();
        //словарь всех слов уникальных, который будет хранить в себе слова, 
        //id документов, в которых они встречаются и позиции,
        //с которых начинаются данные слова в конкретном документе 				

        //метод, заполняющий словарь по слову и возвращающий стартовую позицию следующего
        public int FillDictionary(string word, int startPos, int id)
        {
            if (!DictionaryOfWords.ContainsKey(word))
            {//если слова нет в словаре
                DictionaryOfWords[word] = new Dictionary<int, List<int>>();
                if (!DictionaryOfWords[word].ContainsKey(id))
                {//если по слову нет id
                    DictionaryOfWords[word][id] = new List<int> { startPos };
                    startPos += word.Length + 1;//добавляем позицию и сдвигаем
                }
                else
                {//если id по слову есть
                    DictionaryOfWords[word][id].Add(startPos);
                    startPos += word.Length + 1;
                }
            }
            else
            {//аналогично, если слово есть
                if (!DictionaryOfWords[word].ContainsKey(id))
                {
                    DictionaryOfWords[word][id] = new List<int> { startPos };
                    startPos += word.Length + 1;
                }
                else
                {
                    DictionaryOfWords[word][id].Add(startPos);
                    startPos += word.Length + 1;
                }
            }
           
            return startPos;//возвращаем позицию
        }

        public void Add(int id, string documentText)
        {

            var words = documentText.Split(' ', '.', ',', '!', '?', ':', '-', '\r', '\n');
            if (!Docs.ContainsKey(id)) Docs[id] = words;
            words.ToList();
            var startPos = 0;
            foreach (var word in words)//проходим по всем словам
            {
                startPos = FillDictionary(word, startPos, id);
            }
        }

        public List<int> GetIds(string word)
        {//возвращаем id документов, в которых есть слово, если оно было хоть в каком-то
            if (!DictionaryOfWords.ContainsKey(word))
                return new List<int>();
            return DictionaryOfWords[word].Keys.ToList();
        }

        public List<int> GetPositions(int id, string word)
        {//возвращаем позиции, с которых начинается слово в документе, если слово есть в доке
            if (!DictionaryOfWords.ContainsKey(word))
                return new List<int>();
            if (!DictionaryOfWords[word].ContainsKey(id))
                return new List<int>();
            return DictionaryOfWords[word][id];
        }

        public void Remove(int id)
        {//проходим по всем словам словаря и удаляем id, если слово по нему есть
            
            foreach (var word in Docs[id])
            {
                if (DictionaryOfWords[word].ContainsKey(id)) DictionaryOfWords[word].Remove(id);
            }

        }
    }
}
