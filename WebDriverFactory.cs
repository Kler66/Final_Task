using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Final_Task
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(GetChromeOptions()),
                "firefox" => new FirefoxDriver(GetFirefoxOptions()),
                _ => throw new ArgumentException($"Browser {browserName} not supported")
            };
        }

        private static ChromeOptions GetChromeOptions()
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
            return options;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            var options = new FirefoxOptions();
            string? path = ConfigReader.Configuration["BrowserSettings:FirefoxBinaryPath"];

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                options.BinaryLocation = path;
            }

            options.SetPreference("dom.webnotifications.enabled", false);
            options.SetPreference("geo.enabled", false);
            options.SetPreference("signon.rememberSignons", false);
            options.SetPreference("dom.forms.autocomplete.formautofill", false);
            options.SetPreference("extensions.formautofill.addresses.enabled", false);
            options.SetPreference("extensions.formautofill.creditCards.enabled", false);
            return options;
        }
    }
}
