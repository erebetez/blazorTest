public class GetDataMock1 : IGetData
{
    public List<AssayItem> QueryAssays()
    {
        List<AssayItem> assayItems = new();

        assayItems = Enumerable.Range(1, 5).Select(index => new AssayItem
        {
            Id = index.ToString("D4")

        }).ToList();

        return assayItems;
    }
}


public class GetDataMock2 : IGetData
{
    public List<AssayItem> QueryAssays()
    {
        List<AssayItem> assayItems = new();

        assayItems = Enumerable.Range(2, 3).Select(index => new AssayItem
        {
            Id = index.ToString("D4")

        }).ToList();

        return assayItems;
    }
}