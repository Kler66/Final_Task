using OpenQA.Selenium;

namespace Final_Task.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver) { }

        private static By Header => By.CssSelector("h1.heading1 span.maintext");

        private static By UserName => By.CssSelector("h1.heading1 span.subtext");

        private static By WelcomeMessage => By.Id("customer_menu_top");

        public string GetHeaderText()
        {
            return driver.FindElement(Header).Text;
        }

        public string GetUserName()
        {
            return driver.FindElement(UserName).Text;
        }
        public string GetWelcomeMessage()
        {
            return driver.FindElement(WelcomeMessage).Text;
        }
    }
}
