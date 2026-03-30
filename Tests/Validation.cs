using Final_Task.Pages;
using OpenQA.Selenium;
using FluentAssertions;

namespace Final_Task.Tests
{
    public class Validation : IClassFixture<BaseTest>
    {
        private readonly IWebDriver driver;

        public Validation(BaseTest fixture)
        {
            driver = fixture.driver;
        }

        public static TheoryData<string, bool> LoginValidationData => new()
        {
            { "", true },
            { "4444", true },
            { new string('a', 65), true },
            { "user123@#$", true },
            { "+_-+_$@#^!*",  true },
            { "user" + Guid.NewGuid().ToString("N").Substring(0, 8), false },
            { "5fiv5", false },
            { (Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N")), false },
        };

        [Theory]
        [MemberData(nameof(LoginValidationData))]
        public void ValidationLoginName(string input, bool isError)
        {
            string expectedError = "Login name must be alphanumeric only and between 5 and 64 characters!";

            var error = new RegisterPage(driver)
                .Open()
                .FillLoginName(input)
                .ClickSubmitExpectError();


            if (isError)
            {
                string errorMessage = error.GetLoginNameError();
                errorMessage.Should().Be(expectedError);
            }
            else
            {
                bool isInvisible = error.IsLoginNameErrorInvisible();
                isInvisible.Should().BeTrue();
            }
        }
    }
}
