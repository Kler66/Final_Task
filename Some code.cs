using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
/*
namespace Final_Task
{
    public static class WebDriverExtensions
    {
        // Универсальный метод ожидания видимости
        public static IWebElement WaitElement(this IWebDriver driver, By by, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        // Ожидание кликабельности + сразу возврат элемента
        public static IWebElement WaitClickable(this IWebDriver driver, By by, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

    // 'this' привязывает метод к типу IWebElement
        public static bool HasSaleBadge(this IWebElement element)
        {
            // Теперь внутри метода 'element' — это та самая карточка (card)
            return element.FindElements(By.CssSelector("span.sale")).Any();
        }

        public static bool HasNewPrice(this IWebElement element)
        {
            return element.FindElements(By.CssSelector("div.pricenew")).Any();
        }

        private IWebElement Header => driver.WaitElement(By.CssSelector("h1.heading1 span.maintext"));
        private IWebElement SubHeader => driver.WaitElement(By.CssSelector("h1.heading1 span.subtext"));

        public string GetHeaderText() => Header.Text;
        public string GetUserName() => SubHeader.Text;

IgnoreExceptionTypes v BasePage Click and Write

    }
}
*/