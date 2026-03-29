using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;
using Serilog.Sinks.File;

namespace Final_Task.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        private static By LoginOrRegister => By.Id("customer_menu_top");
        private static By Specials => By.CssSelector(".top.menu_specials");
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public LoginOrRegisterPage GoToLoginOrRegister()
        {
            Click(LoginOrRegister);
            Log.Information("Go to <Login or register> page");
            return new LoginOrRegisterPage(driver);
        }

        public SpecialsPage GoSpecials()
        {
            Click(Specials);
            Log.Information("Go to <Specials> page");
            return new SpecialsPage(driver);
        }

        protected void Click(By locator)
        {
            try 
            {
                Log.Information("Click on: {Locator}", locator);
                wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click(); 
            }
            catch (Exception ex)
            {
                Log.Error("CLICK FAILED: {Locator}. Error: {Message}", locator, ex.Message);
                throw;
            }
        }

        protected void Write(By locator, string text)
        {
            try
            {
                Log.Information("Write: {Text}. In: {Locator}", text, locator);
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                element.Clear();
                element.SendKeys(text); 
            }
            catch (Exception ex)
            {
                Log.Error("WRITE FAILED: {Locator}. Error: {Message}", locator, ex.Message);
                throw;
            }
        }

    }
}
