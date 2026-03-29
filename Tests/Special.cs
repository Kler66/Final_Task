using Final_Task.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Task.Tests
{
    public class Special : BaseTest
    {
        [Fact]
        public void AllProductsHaveDiscount()
        {
            var mainPage = new MainPage(driver);
            var specialsPage = mainPage.GoSpecials();
            var cards = specialsPage.GetAllProducts();

            foreach (var card in cards)
            {
                Assert.True(specialsPage.HasSaleBadge(card), "Sale sticker missing");
                Assert.True(specialsPage.HasNewPrice(card), "Discount missing");
            }
        }
    }
}
