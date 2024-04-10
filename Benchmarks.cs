using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageSharpBenchmark;

[MemoryDiagnoser]
[NativeMemoryProfiler]
public class Benchmarks
{
    [Benchmark]
    public void ConvertJpgToPng() => ImageProcessor.ProcessOnSamples(SampleCollection.JPG, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsPng(stream);
        return stream;
    });

    [Benchmark]
    public void ConvertJpgToGif() => ImageProcessor.ProcessOnSamples(SampleCollection.JPG, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsGif(stream);
        return stream;

    });

    [Benchmark]
    public void ConvertPngToJpg() => ImageProcessor.ProcessOnSamples(SampleCollection.PNG, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsJpeg(stream);
        return stream;
    });

    [Benchmark]
    public void ConvertPngToGif() => ImageProcessor.ProcessOnSamples(SampleCollection.PNG, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsGif(stream);
        return stream;
    });

    [Benchmark]
    public void ConvertGifToJpg() => ImageProcessor.ProcessOnSamples(SampleCollection.GIF, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsJpeg(stream);
        return stream;
    });

    [Benchmark]
    public void ConvertGifToPng() => ImageProcessor.ProcessOnSamples(SampleCollection.GIF, image =>
    {
        Stream stream = new MemoryStream();
        image.SaveAsPng(stream);
        return stream;
    });

    [Benchmark]
    public void ResizeJpg() => ImageProcessor.ProcessOnSamples(SampleCollection.JPG, image =>
    {
        Stream stream = new MemoryStream();
        int width = image.Width / 2;
        int height = image.Height / 2;
        image.Mutate(x => x.Resize(width, height));
        image.Save(stream, image.Metadata.DecodedImageFormat!);
        return stream;
    });

    [Benchmark]
    public void ResizePng() => ImageProcessor.ProcessOnSamples(SampleCollection.PNG, image =>
    {
        Stream stream = new MemoryStream();
        int width = image.Width / 2;
        int height = image.Height / 2;
        image.Mutate(x => x.Resize(width, height));
        image.Save(stream, image.Metadata.DecodedImageFormat!);
        return stream;
    });

    [Benchmark]
    public void ResizeGif() => ImageProcessor.ProcessOnSamples(SampleCollection.GIF, image =>
    {
        Stream stream = new MemoryStream();
        int width = image.Width / 2;
        int height = image.Height / 2;
        image.Mutate(x => x.Resize(width, height));
        image.Save(stream, image.Metadata.DecodedImageFormat!);
        return stream;
    });
}