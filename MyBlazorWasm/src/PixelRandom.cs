using System;
using System.Diagnostics;
using System.Threading;

public class PixelRandom
{

    private static Stopwatch stopWatch = new Stopwatch();

    private static Random rng = new Random();

    public static List<Pixel> Randomize(List<Pixel> lst, int _width, int _height, int _pixelSize)
    {

        stopWatch.Reset();
        stopWatch.Start();

        // for (int i = 0; i < lst.Count; i++)
        // {

        //     Pixel px = lst[i];

        //     lst.RemoveAt(i);

        //     //Console.WriteLine("{0} before: {1}", i, px);

        //     px.X = rng.Next(_width - _pixelSize + 1); ;
        //     px.Y = rng.Next(_height - _pixelSize + 1); ;

        //     //Console.WriteLine("{0} after: {1}", i, px);

        //     lst.Insert(i, px);
        // }

        lst = lst.Select(px =>
            new Pixel
            {
                Color = px.Color,
                X = rng.Next(_width - _pixelSize + 1),
                Y = rng.Next(_height - _pixelSize + 1)
            }
        ).ToList();

        stopWatch.Stop();

        Console.WriteLine("Time elapsed for randomize: {0}", stopWatch.Elapsed);

        return lst;
    }

}