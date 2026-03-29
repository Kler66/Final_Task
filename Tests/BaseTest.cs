using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using static System.Net.WebRequestMethods;

namespace Final_Task.Tests
{
    public class BaseTest : IDisposable
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        private readonly string BaseUrl = ConfigReader.Configuration["BaseUrl"] ?? "https://automationteststore.com";

        public BaseTest()
        {
            string browser = ConfigReader.Configuration["BrowserSettings:DefaultBrowser"] ?? "chrome";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt")
                .CreateLogger();

            driver = WebDriverFactory.CreateDriver(browser);
            Log.Information(Environment.NewLine + new string('=', 100));
            Log.Information("Start <{Browser}> browser", browser);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            Log.Information("FINISHED TEST");
            Log.Information(new string('=', 50));
            if (driver != null)
            {
                driver?.Quit();
                driver?.Dispose();
            }
            Log.CloseAndFlush();
        }
    }
}
