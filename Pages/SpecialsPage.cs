using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Task.Pages
{
    public class SpecialsPage : BasePage
    {
        public SpecialsPage(IWebDriver driver) : base(driver) { }

        private static By AllProducts => By.CssSelector(".thumbnails.grid .col-md-3");

        public IReadOnlyCollection<IWebElement> GetAllProducts()
        {
            return driver.FindElements(AllProducts);
        }

        public bool HasSaleBadge(IWebElement card)
        {
            return card.FindElements(By.CssSelector("span.sale")).Any();
        }

        public bool HasNewPrice(IWebElement card)
        {
            return card.FindElements(By.CssSelector("div.pricenew")).Any();
        }
    }
}
