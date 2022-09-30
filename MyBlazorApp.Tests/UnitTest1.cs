using Xunit;

namespace MyBlazorApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        string testStr = "My Title";

        TodoItem todoItem = new TodoItem { Title = testStr };

        Assert.Equal(testStr, todoItem.Title);
        Assert.False(todoItem.IsDone);
    }
}