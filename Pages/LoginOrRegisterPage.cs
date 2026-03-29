using OpenQA.Selenium;
using Serilog;

namespace Final_Task.Pages
{
    public class LoginOrRegisterPage: BasePage
    {
        public LoginOrRegisterPage(IWebDriver driver) : base(driver) { }

        private static By ContinueButton => By.CssSelector("[title='Continue']");

        public RegisterPage GoToRegister()
        {
            Log.Information("Go to <Register> page");
            Click(ContinueButton);
            return new RegisterPage(driver);
        }
    }
}
