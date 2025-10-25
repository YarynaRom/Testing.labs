using OpenQA.Selenium;

namespace Testing2.PageObjects // Перевірте назву вашого проєкту
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Селектори для полів вводу та кнопки
        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        // Метод, який виконує повний логін
        public void Login(string username, string password)
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}