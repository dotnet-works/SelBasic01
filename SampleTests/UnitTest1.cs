namespace SelBasic01.SampleTests;

using SelBasic01.SelUtil;

public class UnitTest1
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Console.WriteLine("Hello World");
        Console.WriteLine(Util.GetProjectBaseDir().Split("bin")[0]);
        Assert.Pass();
    }
}