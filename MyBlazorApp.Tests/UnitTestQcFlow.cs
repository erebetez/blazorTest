using Xunit;
using QcFlowLibrary;

namespace MyBlazorApp.Tests;

public class UnitTestQcFlow
{
    [Fact]
    public void TestNormalizer()
    {


        Assert.True(Normalizer.FromLimsA("My"));


    }



}