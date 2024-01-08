using System.Drawing;

namespace MorphologicalProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь к изображению
            string imagePath = @"C:\Users\qRe\RiderProjects\ImageMorphologyApp\Images\image1.jpg";

            // Загрузка изображения в память
            Bitmap image = new Bitmap(imagePath);

            // Применение морфологической операции (расширение)
            Bitmap processedImageD = MorphologicalOperationDilation(image);
            Bitmap processedImageE = MorphologicalOperationErosion(image);

            // Сохранение результата
            processedImageD.Save(@"C:\Users\qRe\RiderProjects\ImageMorphologyApp\Images\image1_Dilation.jpg");
            processedImageE.Save(@"C:\Users\qRe\RiderProjects\ImageMorphologyApp\Images\image1_Erosion.jpg");
            
            Console.WriteLine("Обработка завершена. Новое изображение сохранено.");
        }

        // Метод для морфологической операции расшиения
        static Bitmap MorphologicalOperationDilation(Bitmap image)
        {
            // Размер ядра для операции (пиксель 3х3)
            // При изменении значения в большую сторону, результат будет более размытым и пикселизированным
            int kernelSize = 3;

            // Создание нового изображения для результата - копия исходного изображения
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            // Проход по каждому пикселю изображения
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Применение операции только к пикселям внутри области изображения
                    if (x >= kernelSize / 2 && y >= kernelSize / 2 && x < image.Width - kernelSize / 2 && y < image.Height - kernelSize / 2)
                    {
                        // Выполнение операции расширения (в данном случае - просто копирование значения пикселя)
                        Color maxPixelValue = Color.FromArgb(0, 0, 0);

                        for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                        {
                            for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                            {
                                Color currentPixel = image.GetPixel(x + i, y + j);
                                if (currentPixel.R > maxPixelValue.R)
                                {
                                    maxPixelValue = currentPixel;
                                }
                            }
                        }

                        // Установка нового значения пикселя в результате
                        resultImage.SetPixel(x, y, maxPixelValue);
                    }
                }
            }

            return resultImage;
        }
        
        // Метод для морфологической операции сужения
        static Bitmap MorphologicalOperationErosion(Bitmap image)
        {
            int kernelSize = 3;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (x >= kernelSize / 2 && y >= kernelSize / 2 && x < image.Width - kernelSize / 2 && y < image.Height - kernelSize / 2)
                    {
                        // Инициализация цвета максимального значения для нахождения минимума
                        Color minPixelValue = Color.FromArgb(255, 255, 255);

                        for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                        {
                            for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                            {
                                Color currentPixel = image.GetPixel(x + i, y + j);
                                if (currentPixel.R < minPixelValue.R)
                                {
                                    minPixelValue = currentPixel;
                                }
                            }
                        }

                        resultImage.SetPixel(x, y, minPixelValue);
                    }
                }
            }

            return resultImage;
        }

    }
}
