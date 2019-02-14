// Вставьте сюда финальное содержимое файла GrayscaleTask.cs
namespace Recognizer
{
    public static class GrayscaleTask
    {
        /* 
		 * Переведите изображение в серую гамму.
		 * 
		 * original[x, y] - массив пикселей с координатами x, y. 
		 * Каждый канал R,G,B лежит в диапазоне от 0 до 255.
		 * 
		 * Получившийся массив должен иметь те же размеры, 
		 * grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
		 *
		 * Используйте формулу:
		 * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
		 * 
		 * Почему формула именно такая — читайте в википедии 
		 * http://ru.wikipedia.org/wiki/Оттенки_серого
		 */

        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var length1 = original.GetLength(0);
            var length2 = original.GetLength(1);
            var grayscale = new double[length1, length2];
            for (var i = 0; i < length1; i++)
            {
                for (var j = 0; j < length2; j++)
                {
                    var red = original[i, j].R;
                    var green = original[i, j].G;
                    var blue = original[i, j].B;
                    grayscale[i, j] = (0.299 * red + 0.587 * green + 0.114 * blue) / 255;
                }
            }

            return grayscale;
        }
    }
}