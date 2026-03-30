using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace Final_Task.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        private static By FirstName => By.Id("AccountFrm_firstname");
        private static By LastName => By.Id("AccountFrm_lastname");
        private static By Email => By.Id("AccountFrm_email");
        private static By Address => By.Id("AccountFrm_address_1");
        private static By City => By.Id("AccountFrm_city");
        private static By ZIPCode => By.Id("AccountFrm_postcode");
        private static By LoginName => By.Id("AccountFrm_loginname");
        private static By Password => By.Id("AccountFrm_password");
        private static By PasswordConfirm => By.Id("AccountFrm_confirm");
        private static By SubmitButton => By.CssSelector(".btn-orange.pull-right");
        private static By DoNotSubscribe => By.Id("AccountFrm_newsletter0");
        private static By AcceptPolicy => By.Id("AccountFrm_agree");
        private static By LoginNameError => By.CssSelector(".input-group:has(#AccountFrm_loginname) + .help-block");
        private static By RegionState => By.Id("AccountFrm_zone_id");

        public SuccessPage FillFormAndSubmit(UserData user)
        {
            Write(FirstName, user.FirstName);
            Write(LastName, user.LastName);
            Write(Email, user.Email);
            Write(Address, user.Address);
            Write(City, user.City);
            var regionState = driver.FindElement(RegionState);
            var selectElement = new SelectElement(regionState);
            selectElement.SelectByText(user.RegionState);
            Write(ZIPCode, user.ZIPCode);
            Write(LoginName, user.LoginName);
            Write(Password, user.Password);
            Write(PasswordConfirm, user.Password);
            Click(DoNotSubscribe);
            Click(AcceptPolicy);
            Click(SubmitButton);
            return new SuccessPage(driver);
        }

        public RegisterPage ClickSubmitExpectError()
        {
            Click(SubmitButton);
            return this;
        }

        public RegisterPage FillLoginName(string name)
        {
            Write(LoginName, name);
            return this;
        }

        public string GetLoginNameError()
        {
            return GetText(LoginNameError);
        }

        public RegisterPage Open()
        {
            if (!driver.Url.Contains("account/create"))
            {
                new BasePage(driver).GoToLoginOrRegister().GoToRegister();
                Log.Information("Go to <Register> page");
            }
            return this;
        }

        public bool IsLoginNameErrorInvisible()
        {
            try
            {
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(LoginNameError));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
