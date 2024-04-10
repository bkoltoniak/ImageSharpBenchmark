using SixLabors.ImageSharp;

namespace ImageSharpBenchmark;

public static class ImageProcessor
{
    public static void ProcessOnSamples(SampleCollection collection, Func<Image, Stream> callback)
    {
        string[] files = Directory.GetFiles("samples/" + collection.ToString().ToLower());
        foreach (string file in files)
        {
            using var image = Image.Load(file);
            using Stream stream = callback(image);
        }
    }
}
