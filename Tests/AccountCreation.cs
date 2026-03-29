using Final_Task.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Task.Tests
{
    public class AccountCreation : BaseTest
    {
        [Fact]
        public void CreateAccount()
        {
            var mainPage = new MainPage(driver);
            var user = new UserData();

            var accountPage = mainPage
                .GoToLoginOrRegister()
                .GoToRegister()
                .FillFormAndSubmit(user)
                .GoToAccount();

            //Assert.Equal("MY ACCOUNT", accountPage.GetHeaderText().ToUpper());
            //Assert.Equal($"{user.FirstName}".ToUpper(), accountPage.GetUserName().ToUpper());
            //Assert.Equal($"Welcome back {user.FirstName}".ToUpper(), accountPage.GetWelcomeMessage().ToUpper());

            Assert.Multiple(
                () => Assert.Equal("MY ACCOUNT", accountPage.GetHeaderText().ToUpper()),
                () => Assert.Equal($"{user.FirstName}".ToUpper(), accountPage.GetUserName().ToUpper()),
                () => Assert.Equal($"Welcome back {user.FirstName}".ToUpper(), accountPage.GetWelcomeMessage().ToUpper())
                );
        }
    }
}
