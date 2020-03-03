using System;
using System.Text;
using EmptyWeb.Models;

namespace EmptyWeb
{
    //наверное, это через рефлексию надо как-то делать?
    //публичные поля присваивать по порядку?
    //ну и класс соответственно дженерик
    public class CsvParser
    {
        public readonly char CsvSeparator;

        public CsvParser(char separator)
        {
            CsvSeparator = separator;
        }

        public string MakeCsv(params string[] fields)
        {
            var builder = new StringBuilder();
            foreach (var field in fields)
            {
                builder.Append($"{field};");
            }

            if (builder.Length > 0)
                builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public Blog GetBlog(string csvContent)
        {
            var constituents = csvContent.Split(CsvSeparator);
            return new Blog()
            {
                Guid = constituents[0], DateTime = DateTime.Parse(constituents[1]), Text = constituents[2],
                FileName = constituents[3], Name = constituents[4]
            };
        }

        public Commentary GetCommentary(string csvContent)
        {
            var constituents = csvContent.Split(CsvSeparator);
            return new Commentary()
            {
                UserName = constituents[0], DateTime = DateTime.Parse(constituents[1]), Text = constituents[4],
                RelatedPost = constituents[3], Guid = constituents[2]
            };
        }
    }
}