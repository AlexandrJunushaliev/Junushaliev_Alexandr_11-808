using System.Collections.Generic;
using System.Text;

namespace TableParser
{
    public class FieldsParserTask
    {
        private static Token DifficultField(string line, int startIndex)
        {   //узнаем является ли символ началом сложного поля
            if ((line[startIndex] == '\'') || (line[startIndex] == '\"'))
            {
                var value = new StringBuilder();
                var i = startIndex + 1;
                GetDifficultField(line, value, ref i, line[startIndex]);//если да, то используем метод, получающий значение
                //сложного поля, которое начинается этим символом
                return new Token(value.ToString(), startIndex, i - startIndex + 1);
            }
            return new Token(null, startIndex, 0);//если нет, то возвращаем пустой токен
        }

        private static void GetDifficultField(string line, StringBuilder value,
        ref int i, char quote)
        {
            var backslash = false;
            for (; i < line.Length; i++)
                if (line[i] == '\\')
                {
                    if (backslash)
                    {
                        backslash = false;
                        value.Append("\\");
                    }
                    else backslash = true;
                }
                else if (line[i] == 't' && backslash)//проверка на табуляцию
                {
                    backslash = false;
                    value.Append('\t');
                }
                else if (line[i] == quote)
                {
                    if (backslash)//если символ - кавычка того же вида, что и та, которая открыла сложное поле, и стоит бэкслэш
                        //добавляем в значение символ кавычки
                    {
                        backslash = false;
                        value.Append(quote);
                    }
                    else break;//иначе поле закончилось и мы заканчиваем обрабатывать его
                }
                else value.Append(line[i]);//если нет условий завершения, то продолжаем добавлять значение
        }

        private static Token NoField(string line, int startIndex)
        {//обрабатываем случай, когда нет полей, чтобы получить впоследствии индекс какого-либо поля
            if (line[startIndex] == ' ')
            {
                var i = startIndex;
                var value = new StringBuilder();
                for (; i < line.Length; i++)
                    if (line[i] == ' ') value.Append(line[i]);
                    else break;
                return new Token(value.ToString(), startIndex, value.ToString().Length);
            }
            return new Token(null, startIndex, 0);
        }

        private static Token SimpleField(string line, int startIndex)
        {//если символ не открывает сложное поле и не пробел, то это просто поле
            var value = new StringBuilder();
            var i = startIndex;
            while (i < line.Length)
            {   //поле простое до тех пор, пока не встретится символ, заканчивающий его, или пока строка не кончится
                if ((line[i] == ' ') || (line[i] == '\'') || (line[i] == '"')) break;
                else value.Append(line[i]);
                i++;
            }
            if (value.Length > 0)
            {
                return new Token(value.ToString(), startIndex, value.ToString().Length);
            }
            else return new Token(null, startIndex, 0);
        }

        public static List<string> ParseLine(string line)
        {
            var fields = new List<string>();
            for (int i = 0; i < line.Length;)
            {
                var difficultField = DifficultField(line, i);//проверяем, является ли символ открывающим сложное поле и, если да, получаем токен сложного поля
                var noField = NoField(line, i);//получаем токен отсутствия поля
                var simpleField = SimpleField(line, i);//получаем токен простого поля
                if (difficultField.Value != null)
                {
                    fields.Add(difficultField.Value);
                    i = difficultField.GetIndexNextToToken();//добавляем сложное поле
                }
                else if (noField.Value != null)
                    i = noField.GetIndexNextToToken();//если где-то в строке отсутствовало поле, то получаем индекс следующего
                else if (simpleField.Value != null)
                {
                    fields.Add(simpleField.Value);
                    i = simpleField.GetIndexNextToToken();//добавляем простое поле
                }
            }
            return fields;
        }
    }
}
