namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
            string s = "рублей";
            if (count % 10 == 1) s = "рубль";
            if (count % 10 >= 2 && count % 10 <= 4) s = "рубля";
            if (count % 100 >= 11 & count % 100 <= 20) s = "рублей";
            return s;           
		}
	}
}