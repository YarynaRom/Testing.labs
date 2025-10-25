using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Testing2.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement AddToCartButton => _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));

        public void GoToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void AddItemToCart()
        {
            AddToCartButton.Click();
        }
    }
}
