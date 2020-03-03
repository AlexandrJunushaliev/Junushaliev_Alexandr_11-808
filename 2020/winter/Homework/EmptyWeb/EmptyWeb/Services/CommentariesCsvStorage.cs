using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmptyWeb.Models;

namespace EmptyWeb
{
    public class CommentariesCsvStorage : Storage<Commentary>
    {
        private const string CommentariesPath = "Commentaries";

        public override void LoadAll()
        {
            var commentaries = new List<Commentary>();
            var csvCommentaries = Directory.GetFiles(CommentariesPath, "*.csv", SearchOption.AllDirectories);
            foreach (var csvCommentary in csvCommentaries)
            {
                using (var sr = new StreamReader(csvCommentary))
                {
                    var text = sr.ReadToEnd();
                    commentaries.Add(new CsvParser(';').GetCommentary(text));
                }
            }

            Items = commentaries;
        }

        public override void Save(Commentary entry)
        {
            File.WriteAllLines(Path.Combine(CommentariesPath, $"{entry.Guid}.csv"),
                new[]
                {
                    new CsvParser(';').MakeCsv(entry.UserName, entry.DateTime.ToString(), entry.Guid, entry.RelatedPost, entry.Text)
                });
        }

        public override void Delete(Commentary entry)
        {
            var file = new FileInfo($"Commentaries/{entry.Guid}.csv");
            file.Delete();
        }

        public override void Update(Commentary updatedEntry, Commentary newEntry)
        {
            File.WriteAllLines(Path.Combine(CommentariesPath, $"{updatedEntry.Guid}.csv"),
                new[]
                {
                    new CsvParser(';').MakeCsv(newEntry.UserName, updatedEntry.DateTime.ToString(), newEntry.Text, updatedEntry.RelatedPost,
                        updatedEntry.Guid)
                });
        }
    }
}