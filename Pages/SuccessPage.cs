using OpenQA.Selenium;
using Serilog;

namespace Final_Task.Pages
{
    public class SuccessPage : BasePage
    {
        public SuccessPage(IWebDriver driver) : base(driver) { }

        private static By ToAccount => By.CssSelector(".mr10");

        public AccountPage GoToAccount()
        {
            Click(ToAccount);
            Log.Information("Go to <Account> page");
            return new AccountPage(driver);
        }
    }
}
