using System.Drawing;

public class ImageProcessor
{
    private Bitmap image; // Используем Bitmap для работы с изображением

    public ImageProcessor(string filePath)
    {
        image = new Bitmap(filePath); // Загружаем изображение из файла
    }

    // Метод для применения операции негатива к изображению
    public void ApplyNegative(string savePath)
    {
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                image.SetPixel(i, j, newPixel);
            }
        }
        image.Save(savePath); // Сохраняем изображение после применения негатива
    }

    // Метод для применения операции размытия к изображению
    public void ApplyBlur(string savePath)
    {
        // Реализация размытия будет зависеть от ваших требований
        // Ниже приведен простой пример среднего размытия
        Bitmap blurredImage = new Bitmap(image.Width, image.Height);

        for (int i = 1; i < image.Width - 1; i++)
        {
            for (int j = 1; j < image.Height - 1; j++)
            {
                int red = 0, green = 0, blue = 0;
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        Color pixel = image.GetPixel(i + k, j + l);
                        red += pixel.R;
                        green += pixel.G;
                        blue += pixel.B;
                    }
                }
                red /= 9;
                green /= 9;
                blue /= 9;
                blurredImage.SetPixel(i, j, Color.FromArgb(red, green, blue));
            }
        }
        blurredImage.Save(savePath); // Сохраняем изображение после применения размытия
    }

    // Метод для применения операции резкости к изображению
    public void ApplySharpen(string savePath)
    {
        // Реализация увеличения резкости будет зависеть от ваших требований
        // Ниже приведен простой пример увеличения резкости
        float[,] sharpenMatrix = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        Bitmap sharpenedImage = new Bitmap(image.Width, image.Height);

        for (int i = 1; i < image.Width - 1; i++)
        {
            for (int j = 1; j < image.Height - 1; j++)
            {
                float red = 0, green = 0, blue = 0;
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        Color pixel = image.GetPixel(i + k, j + l);
                        red += pixel.R * sharpenMatrix[k + 1, l + 1];
                        green += pixel.G * sharpenMatrix[k + 1, l + 1];
                        blue += pixel.B * sharpenMatrix[k + 1, l + 1];
                    }
                }
                red = Math.Min(Math.Max(red, 0), 255);
                green = Math.Min(Math.Max(green, 0), 255);
                blue = Math.Min(Math.Max(blue, 0), 255);
                sharpenedImage.SetPixel(i, j, Color.FromArgb((int)red, (int)green, (int)blue));
            }
        }
        sharpenedImage.Save(savePath); // Сохраняем изображение после применения увеличения резкости
    }
}
