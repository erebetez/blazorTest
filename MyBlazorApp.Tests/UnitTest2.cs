using Xunit;

namespace MyBlazorApp.Tests;

public class UnitTest2
{
    [Fact]
    public void BooleanStuff()
    {
        Assert.False(false, "no brainer");

        Assert.True(true, "also easy");



        // Assert.IsType<String>("a string", "is this true?");

    }

    [Fact]
    public void BooleanStuff2()
    {
        Assert.False(false, "this is not true");
    }

    [Fact]
    public void NumberStuff()
    {
        Assert.Equal(1, 1);

        Assert.NotEqual(2, 3);
    }


}