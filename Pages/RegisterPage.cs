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

        public SuccessPage FillFormAndSubmit(UserData user)
        {
            FillFirstName(user.FirstName);
            Write(LastName, user.LastName);
            Write(Email, user.Email);
            Write(Address, user.Address);
            Write(City, user.City);
            var regionState = driver.FindElement(By.Id("AccountFrm_zone_id"));
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

        public RegisterPage FillFirstName(string name)
        {
            Write(FirstName, name);
            return this;
        }

        public string GetFirstNameError()
        {
            string xpath = "//div[contains(@class, 'form-group')][.//input[@id='AccountFrm_firstname']]//span[@class='help-block']";
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return element.Text;
            //return wait.Until(d => d.FindElement(By.XPath(xpath)).Text);
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
    }
}
