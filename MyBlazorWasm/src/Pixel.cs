public class Pixel
{
    public string Color { get; set; } = "red";
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public override string ToString() => $"top: {Y}px; left: {X}px; background-color: {Color};";

}