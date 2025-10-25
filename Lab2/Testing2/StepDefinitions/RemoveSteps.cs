using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Testing2.PageObjects;

namespace Testing2.StepDefinitions
{
    [Binding]
    public class RemoveSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private CartPage _cartPage;
        private LoginPage _loginPage;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _homePage = new HomePage(_driver);
            _cartPage = new CartPage(_driver);
            _loginPage = new LoginPage(_driver);
        }

        [AfterScenario]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Given(@"я залогінився на сайті як '(.*)'")]
        public void GivenЯЗалогінивсяНаСайтіЯк(string userName)
        {
            _loginPage.Login(userName, "secret_sauce");
        }

        [When(@"я додаю товар до кошика")]
        public void WhenЯДодаюТоварДоКошика()
        {
            _homePage.AddItemToCart();
        }

        [When(@"я переходжу на сторінку кошика")]
        public void WhenЯПереходжуНаСторінкуКошика()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
        }

        // ЦЕЙ КРОК ПОВЕРТАЄТЬСЯ В ТЕСТ
        [When(@"я натискаю кнопку видалення товару")]
        public void WhenЯНатискаюКнопкуВидаленняТовару()
        {
            _cartPage.RemoveItem();
        }

        [Then(@"кошик повинен бути порожнім")]
        public void ThenКошикПовиненБутиПорожнім()
        {
            _cartPage.VerifyCartIsEmpty();
        }
    }
}