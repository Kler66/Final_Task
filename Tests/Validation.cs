using Final_Task.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Task.Tests
{
    public class Validation : IClassFixture<BaseTest>
    {
        private readonly IWebDriver driver;

        public Validation(BaseTest fixture)
        {
            driver = fixture.driver;
        }

        [Theory]
        [InlineData("")]
        [InlineData("333333333333333333333333333333333")]
        public void ValidationLoginName(string input)
        {
            string expectedError = "First Name must be between 1 and 32 characters!";

            var error = new RegisterPage(driver)
                .Open()
                .FillFirstName(input)
                .ClickSubmitExpectError()
                .GetFirstNameError();
            /*
            registerPage
                .FillFirstName(input).ClickSubmitExpectError();
            */
            Assert.Contains(expectedError, error);
        }
    }
}
