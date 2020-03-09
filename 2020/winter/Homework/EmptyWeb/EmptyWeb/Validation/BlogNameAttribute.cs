using System.Text.RegularExpressions;

namespace EmptyWeb
{
    public class BlogNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var regex = new Regex($"^[^:,;. ]+$");
            return value != null && regex.IsMatch(value.ToString());
        }
    }
}