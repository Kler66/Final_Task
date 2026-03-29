using Final_Task.Pages;

namespace Final_Task.Tests
{
    public class AccountCreation : BaseTest
    {
        [Fact]
        public void CreateAccount()
        {
            var bainPage = new BasePage(driver);
            var user = new UserData();

            var accountPage = bainPage
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
