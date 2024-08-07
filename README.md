# PT_Demo_Testing_Selenium

## Contents

- [Demo Selenium](#demo-selenium)
    - [Prerequisites](#prerequisites)
    - [Backend](#backend)
    - [Frontend](#frontend)
    - [Selenium Testing](#selenium-testing)
- [Known Issues](#known-issues)
- [Links](#links)

## Demo Selenium

### Prerequisites

Create new blank Solution `PT_Demo_Testing`.

### Backend

1. Create new .NET 8 Web API project `DemoSeleniumApi` in `.src/server` directory.

2. Create new `ValuesController` that has a simple GET endpoint returning some text:

```
[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Hello from .NET 8 Web API!" });
    }
}
```

3. Enable CORS. In `Program.cs` add the following:

```
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ...

        // Configure CORS (1/2)
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000") // Allow React app
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        ...

        // Enable CORS (2/2)
        app.UseCors();

        app.MapControllers();

        app.Run();
    }
```

### Frontend

1. Create new `selenium-demo-frontend` React client app in `.src/client` directory, by running the following commands:

```
npx create-react-app selenium-demo-frontend
cd selenium-demo-frontend
```

2. Update `App.js` in order to call the Backend. 

### Selenium Testing

1. Create new .NET 8 NUnit project `DemoSeleniumTests` in the existing `PT_Demo_Testing` solution.

2. Install the following NuGet packages:
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver

3. In a new `ReactAppTests.cs` test class, implement unit tests that use Selenium:

```
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoTests;

public class ReactAppTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup() { _driver = new ChromeDriver(); }

    [TearDown]
    public void Teardown() { _driver.Quit(); _driver.Dispose(); }

    [Test]
    public void TestReactApp() {
        _driver.Navigate().GoToUrl("http://localhost:3000");
        var heading = _driver.FindElement(By.TagName("h1"));
        Assert.That(heading.Text, Is.EqualTo("Hello from .NET 8 Web API!"));
    }

    [Test]
    public void TestButtonClick() {
        _driver.Navigate().GoToUrl("http://localhost:3000");
        var button = _driver.FindElement(By.TagName("button"));
        button.Click();
        var header = _driver.FindElement(By.TagName("h2"));
        Assert.That(header.Text, Is.EqualTo("Button was clicked!"));
    }
}
```

## Known Issues

1. CORS not enabled in Backend.

2. _driver.Dispose() missing in unit tests using Selenium.

## Links