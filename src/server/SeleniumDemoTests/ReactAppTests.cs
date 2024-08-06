using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoTests;

[TestFixture]
public class ReactAppTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    public void TestReactApp()
    {
        // Arrange & Act
        _driver.Navigate().GoToUrl("http://localhost:3000");

        // Assert
        var heading = _driver.FindElement(By.TagName("h1"));
        
        Assert.That(heading.Text, Is.EqualTo("Hello from .NET 8 Web API!"));
    }
}