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

    // First run SeleniumDemoApi BE server in another window as well as selenium-demo-frontend FE client app. Otherwise:
    // Expected: "Hello from .NET 8 Web API!"... But was:  "Loading..."
    [Test]
    public void TestReactApp()
    {
        // Arrange & Act
        _driver.Navigate().GoToUrl("http://localhost:3000");

        // Assert
        var heading = _driver.FindElement(By.TagName("h1"));
        
        Assert.That(heading.Text, Is.EqualTo("Hello from .NET 8 Web API!"));
    }

    [Test]
    public void TestButtonClick()
    {
        // Arrange & Act
        _driver.Navigate().GoToUrl("http://localhost:3000");

        var button = _driver.FindElement(By.TagName("button"));

        // Act
        button.Click();

        // Assert
        var header = _driver.FindElement(By.TagName("h2"));

        Assert.That(header.Text, Is.EqualTo("Button was clicked!"));
    }
}