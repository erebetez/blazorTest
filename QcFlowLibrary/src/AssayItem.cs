public class AssayItem
{
    public string? Id { get; set; }

    public string State { get; set; } = "initialized";

    public string Stage { get; set; } = "NONE";

    public List<RawDataItem>? RawData { get; set; }

    public List<ResultItem>? Results { get; set; }

    public string? Analyst { get; set; }

    public DateTime AnalysisDate { get; set; } = DateTime.Now;

}