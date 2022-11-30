using System;
using System.Diagnostics;
using System.Threading;

public class Matrix
{

    private const int _width = 600;
    private const int _height = 300;

    private List<Pixel> _pixelList = new();

    private const int _pixelSize = 10; // TODO duble deffinition, see css file.

    private const int _pixelMaxCanvas = (_height / _pixelSize) * (_width / _pixelSize);

    private Stopwatch stopWatch = new Stopwatch();

    private Random rng = new Random();

    public List<Pixel> PixelList()
    {
        return _pixelList;
    }

    public int Width()
    {
        return _width;
    }

    public int Height()
    {
        return _height;
    }

    public void Rainbow()
    {
        for (int i = 0; i < _pixelMaxCanvas; i++)
        {
            _pixelList.Add(new Pixel
            {
                Color = $"hsl({i % 360}, 100%, 50%)",
                X = i * _pixelSize % _width,
                Y = i * _pixelSize / _width * _pixelSize
            });
        }
    }

    public void AddDot()
    {
        _pixelList.Add(new Pixel
        {
            Color = $"hsl(0, 100%, 30%)",
            X = _width / 2,
            Y = _height / 2
        });
    }

    public void Randomize()
    {
        stopWatch.Reset();
        stopWatch.Start();

        _pixelList = _pixelList.Select(px =>
            new Pixel
            {
                Color = px.Color,
                X = rng.Next(_width / _pixelSize) * _pixelSize,
                Y = rng.Next(_height / _pixelSize) * _pixelSize
            }
        ).ToList();

        stopWatch.Stop();

        Console.WriteLine("Time elapsed for randomize: {0}", stopWatch.Elapsed);
    }

    public void Clear()
    {
        _pixelList.Clear();
    }

}