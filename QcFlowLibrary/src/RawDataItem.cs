public class RawDataItem
{
    public string? Id { get; set; }

    public string? Context { get; set; }

    public int ReplicateId { get; set; } = 0;

    public int DilutionId { get; set; } = 0;

    public int TimePoint { get; set; } = 0;

    public int Position { get; set; } = 0;

    public string? PositionName { get; set; }

    public FormatedNumber? Number { get; set; }

}