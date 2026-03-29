using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using Serilog.Sinks.File;

namespace Final_Task.Tests
{
    public class BaseTest : IDisposable
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        private const string BaseUrl = "https://automationteststore.com";

        public BaseTest()
        {
            var options = new ChromeOptions();

            options.AddArgument("--incognito");
            options.AddArgument("--disable-notifications");

            options.AddUserProfilePreference("autofill.profile_enabled", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            options.AddArgument("--auto-open-devtools-for-testing");
            options.AddArgument("--devtools-auto-open-on-launch");
            options.AddUserProfilePreference("devtools.preferences.currentDockState", "\"bottom\"");

            // Настраиваем логгер
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt")
                .CreateLogger();

            driver = new ChromeDriver(options);
            Log.Information("Start browser");

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
            Log.CloseAndFlush();
        }
    }
}
