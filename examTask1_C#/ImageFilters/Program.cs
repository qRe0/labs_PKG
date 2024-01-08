class Program
{
    static void Main(string[] args)
    {
        string imagePath = @"C:\Users\qRe\RiderProjects\ImageFilters\Images\test.jpg";
        ImageProcessor processor = new ImageProcessor(imagePath);

        string negativePath = @"C:\Users\qRe\RiderProjects\ImageFilters\Images\негатив.jpg";
        processor.ApplyNegative(negativePath);

        string blurPath = @"C:\Users\qRe\RiderProjects\ImageFilters\Images\размытость.jpg";
        processor.ApplyBlur(blurPath);

        string sharpenPath = @"C:\Users\qRe\RiderProjects\ImageFilters\Images\резкость.jpg";
        processor.ApplySharpen(sharpenPath);

        Console.WriteLine("Operations completed and images saved.");
        Console.ReadLine();
    }
}