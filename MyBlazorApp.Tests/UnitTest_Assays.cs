using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace MyBlazorApp.Tests;

public class UnitTest_Assays
{
    [Fact]
    public void TestAssays1()
    {
        string testStr = "My ID 123";

        AssayItem assayItem = new AssayItem { Id = testStr };

        Assert.Equal(testStr, assayItem.Id);
        Assert.IsType<string>(assayItem.Id);

        Assert.Equal("initialized", assayItem.State);

        assayItem.Analyst = "Me";

        Assert.Equal("Me", assayItem.Analyst);
        Assert.IsType<System.DateTime>(assayItem.AnalysisDate);
    }


    [Fact]
    public void TestAssaysList()
    {

        List<AssayItem> assayItems = new();


        assayItems = Enumerable.Range(1, 5).Select(index => new AssayItem
        {
            Id = index.ToString("D4")

        }).ToList();

        Assert.Equal(5, assayItems.Count);
        Assert.Equal("0001", assayItems.First().Id);
        Assert.Equal("0005", assayItems.Last().Id);


        foreach (AssayItem assay in assayItems)
        {
            List<RawDataItem> rawDataList = new();

            rawDataList.Add(new RawDataItem()
            {
                Id = "Consumption",
                ReplicateId = 1,
                DilutionId = 1,
                Number = new FormatedNumber() { Value = 1, Unit = "mL" }
            });

            rawDataList.Add(new RawDataItem()
            {
                Id = "Consumption",
                ReplicateId = 2,
                DilutionId = 1,
                Number = new FormatedNumber() { Value = 2, Unit = "mL" }
            });

            rawDataList.Add(new RawDataItem()
            {
                Id = "Consumption",
                ReplicateId = 1,
                DilutionId = 2,
                Number = new FormatedNumber() { Value = 3, Unit = "mL" }
            });

            rawDataList.Add(new RawDataItem()
            {
                Id = "Consumption",
                ReplicateId = 2,
                DilutionId = 2,
                Number = new FormatedNumber() { Value = 4, Unit = "mL" }
            });

            assay.RawData = rawDataList;
        }

        AssayItem? foundAssayItem = assayItems.Find(assay => assay.Id.Equals("0002"));

        Assert.NotNull(foundAssayItem);

        Assert.Equal("0002", foundAssayItem.Id);

        List<RawDataItem>? foundRawDataList = foundAssayItem.RawData.FindAll(raw => raw.ReplicateId == 1);

        Assert.Equal(2, foundRawDataList.Count);

        RawDataItem? foundRawData = foundAssayItem.RawData.Find(raw =>
        {
            return raw.ReplicateId == 1 && raw.DilutionId == 2;
        });

        Assert.NotNull(foundRawData);

        if (foundRawData is not null)
        {
            Assert.Equal(3, foundRawData.Number.Value);
        }

        List<RawDataItem> consumptions = foundAssayItem.RawData.FindAll(raw => raw.Id.Equals("Consumption"));

        float sumResult = consumptions.Aggregate(0, (float acc, RawDataItem next) => acc + next.Number.Value, sum => sum);

        Assert.Equal(10, sumResult);


        foundAssayItem.RawData.Add(new RawDataItem()
        {
            Id = "Sum",
            Number = new FormatedNumber() { Value = sumResult, Unit = "mL" }
        });


        Assert.Equal(10, foundAssayItem.RawData.Find(raw => raw.Id.Equals("Sum")).Number.Value);


        float[] addList = consumptions.Select(c => c.Number.Value + 1).ToArray();

        Assert.Equal(new float[] { 2, 3, 4, 5 }, addList);

    }
}