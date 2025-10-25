using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Testing2.PageObjects
{
    public class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Знаходимо всі товари в кошику, щоб порахувати їх
        private IReadOnlyCollection<IWebElement> CartItems => _driver.FindElements(By.ClassName("cart_item"));

        // Знаходимо кнопку видалення за її унікальним ID
        private IWebElement RemoveButton => _driver.FindElement(By.ClassName("cart_button"));

        // Метод, який натискає на кнопку видалення
        public void RemoveItem()
        {
            RemoveButton.Click();
        }

        // Метод, який перевіряє, що кількість товарів дорівнює 0
        public void VerifyCartIsEmpty()
        {
            Assert.AreEqual(0, CartItems.Count, "Кошик не став порожнім після видалення товару!");
        }
    }
}