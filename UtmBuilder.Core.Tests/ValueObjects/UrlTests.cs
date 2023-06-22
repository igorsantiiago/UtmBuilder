using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    private string ValidUrl = "https://balta.io";
    private string InvalidUrl = "balta";

    [TestMethod]
    public void Should_Return_Exception_When_Url_Is_Invalid()
    {
        try
        {
            var url = new Url(InvalidUrl);
            Assert.Fail();
        }
        catch (InvalidUrlException)
        {
            Assert.IsTrue(true);
        }
    }

    [TestMethod]
    public void Should_Not_Return_Exception_When_Url_Is_Valid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }
}