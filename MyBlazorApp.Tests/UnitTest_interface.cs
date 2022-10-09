using Xunit;
using System.Collections.Generic;
using System.Linq;


namespace MyBlazorApp.Tests;

public class UnitTest_interface
{
    [Fact]
    public void TestDicts()
    {
        var assay = new Dictionary<string, RawDataItem>()
        {
            {"first", new RawDataItem { Id = "Test1", ReplicateId = 1 }},
            {"seccond", new RawDataItem { Id = "Test2", ReplicateId = 2, DilutionId = 1 }},
            {"third", new RawDataItem { Id = "Test3", ReplicateId = 2, DilutionId = 1 }}
        };



        Assert.Equal("Test2", assay["seccond"].Id);
        Assert.Equal("default", assay.GetValueOrDefault("four", new RawDataItem { Id = "default", ReplicateId = 2 }).Id);

    }

    [Fact]
    public void TestInterface1()
    {
        GetDataMock1 getData = new GetDataMock1();
        List<AssayItem> retr = getData.QueryAssays();

        Assert.Equal(5, retr.Count);
        Assert.Equal("0005", retr.Last().Id);
    }
    [Fact]
    public void TestInterface2()
    {
        GetDataMock2 getData = new GetDataMock2();
        List<AssayItem> retr = getData.QueryAssays();

        Assert.Equal(3, retr.Count);
        Assert.Equal("0004", retr.Last().Id);
    }

    [Fact]
    public void TestAnon()
    {
        var anon = new { Name = "test1", Age = 22 };

        Assert.Equal(22, anon.Age);

        var anon2 = new
        {
            Name = "bla",
            SomeNew = new
            {
                Sub = "test2",
                Age = 22,
                AwesomeList = new List<int> { 1, 3, 5 }
            }
        };

        Assert.Equal(3, anon2.SomeNew.AwesomeList[1]);

    }

    [Fact]
    public void TestAnon2()
    {


        var raw = new
        {
            Final = new FormatedNumber { Value = 22, Unit = "%" },
            OD = new
            {
                r1 = new
                {
                    d1 = new FormatedNumber { Value = 2 },
                    d2 = new FormatedNumber { Value = 3 },
                    Age = 22,
                },
                r2 = new
                {
                    d1 = new FormatedNumber { Value = 4 },
                    d2 = new FormatedNumber { Value = 5 },
                    Age = 24,
                },
            }
        };

        Assert.Equal(4, raw.OD.r2.d1.Value);
    }

    [Fact]
    public void TestAnon3()
    {

        int[] repArr = new int[] { 1, 2, 3 };
        int[] dilArr = new int[] { 1, 2 };

        var resList = new List<int> { 10, 11, 12, 13, 14, 15 };



        Dictionary<int, Dictionary<int, int>> raw = new Dictionary<int, Dictionary<int, int>>();

        foreach (int rep in repArr)
        {
            Dictionary<int, int> dilDict = new Dictionary<int, int>();

            foreach (int dil in dilArr)
            {
                int res = resList[0];
                // System.Console.WriteLine("This res is {0}", res);
                dilDict.Add(dil, res);
                resList.RemoveAt(0);
            }
            raw.Add(rep, dilDict);
        }

        Assert.Equal(15, raw[3][2]);
    }
}