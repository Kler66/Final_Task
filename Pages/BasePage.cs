using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using Serilog.Sinks.File;

namespace Final_Task.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void Click(By locator)
        {
            try 
            {
                Log.Information("Click on: {Locator}. Error: {Message}", locator);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(locator)).Click(); 
            }
            catch (Exception ex)
            {
                Log.Error("CLICK FAILED: {Locator}. Error: {Message}", locator, ex.Message);
                throw;
            }
        }

        // Базовый метод для ввода текста
        protected void Write(By locator, string text)
        {
            try
            {
                Log.Information("Write: {Text}. In: {Locator}", text, locator);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(d => d.FindElement(locator));
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
