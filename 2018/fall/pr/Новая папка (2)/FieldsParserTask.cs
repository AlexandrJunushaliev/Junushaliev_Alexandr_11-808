using System.Collections.Generic;
using System.Text;

namespace TableParser
{
    public class FieldsParserTask
    {
        public static List<string> ParseLine(string line)
        {
            List<string> words = new List<string>();
            Token token = new Token("", 0, 0);
            //Пока токен не последний, ищем следующий и добавляем его в список слов
            do
            {
                token = ReadField(line, token.StartIndex + token.Length);
                if (token.Value != null)
                {
                    words.Add(token.Value);
                }
            } while (token.StartIndex + token.Length < line.Length);
            return words;
        }
        //Словарь, который ставит в соответствие букву и управляющий символ, который можно получить из этой буквы
        public static Dictionary<char, char> ControlChars = new Dictionary<char, char>() {
            {'t', '\t'},
            {'n', '\n'},
            {'r', '\r'},
        };
        //Метод, обрабатывающий символы в том случае, если ReadField не обрабатывает никакое поле
        private static FieldType NoneField(string line, int index, StringBuilder word)
        {
            if (line[index] == '\'')
            {
                return FieldType.Apostrophe;
            }
            else if (line[index] == '\"')
            {
                return FieldType.Quote;
            }
            else if (line[index] != ' ')
            {
                word.Append(line[index]);
                return FieldType.Simple;
            }
            return FieldType.None;
        }
        //Метод, обрабатывающий символы в том случае, если ReadField обрабатывает простое поле
        private static Token SimpleField(string line, int index, int startIndex, StringBuilder word)
        {
            if (line[index] == ' ' || line[index] == '\'' || line[index] == '\"')
            {
                return new Token(word.ToString(), startIndex, index - startIndex);
            }
            else
            {
                word.Append(line[index]);
            }
            return null;
        }
        //Метод, обрабатывающий символы в том случае, если ReadField обрабатывает поле в кавычках
        private static Token QuotesField(
            string line,
            int index,
            int startIndex,
            ref bool isBackslash,
            StringBuilder word,
            char quoteSymbol
        )
        {
            if (line[index] == '\\')
            {
                if (isBackslash)
                {
                    word.Append(line[index]);
                    isBackslash = false;
                }
                else
                    isBackslash = true;
            }
            else if (ControlChars.ContainsKey(line[index]) && isBackslash)
            {
                word.Append(ControlChars[line[index]]);
                isBackslash = false;
            }
            else if (line[index] == quoteSymbol)
            {
                if (isBackslash)
                {
                    word.Append(line[index]);
                    isBackslash = false;
                }
                else
                    return new Token(word.ToString(), startIndex, index - startIndex + 1);
            }
            else
                word.Append(line[index]);
            return null;
        }
        //Метод, получающий токен на текущей итерации цикла в зависимости от типа поля, обрабатываемого методом ReadField
        private static Token GetToken(
            string line,
            int startIndex,
            int index,
            StringBuilder word,
            ref bool isBackslash,
            ref int typeOfField
        )
        {
            if ((FieldType)typeOfField == FieldType.None)
            {
                typeOfField = (int)NoneField(line, index, word);
                return null;
            }
            else if ((FieldType)typeOfField == FieldType.Simple)
            {
                Token tok = SimpleField(line, index, startIndex, word);
                return tok;
            }
            else if ((FieldType)typeOfField == FieldType.Quote)
            {
                Token tok = QuotesField(line, index, startIndex, ref isBackslash, word, '\"');
                return tok;
            }
            else
            {
                Token tok = QuotesField(line, index, startIndex, ref isBackslash, word, '\'');
                return tok;
            }л
        }

        //Метод, посимвольно проверяющий строку со startIndex на наличие полей
        private static Token ReadField(string line, int startIndex)
        {
            FieldType typeOfField = FieldType.None;
            bool isBackslash = false;
            StringBuilder word = new StringBuilder();
            for (int i = startIndex; i < line.Length; i++)
            {
                //В случае нахождения полного поля возвращаем его из метода, иначе продолжаем цикл
                int fieldType = (int)typeOfField;
                Token token = GetToken(line, startIndex, i, word, ref isBackslash, ref fieldType);
                typeOfField = (FieldType)fieldType;
                if (token != null)
                {
                    return token;
                }
            }
            //Если цикл дошел до конца, а поле так и не началось,
            //то возвращаем такой токен, чтобы метод ReadField закончил работу со строкой
            if (typeOfField == FieldType.None)
                return new Token(null, 0, int.MaxValue);
            return new Token(word.ToString(), startIndex, line.Length - startIndex);
        }
        //Перечисление, твечающее за то, поле какого типа в текущий момент обрабатывает ReadField
        public enum FieldType
        {
            None,
            Simple,
            Quote,
            Apostrophe
        }
    }
}