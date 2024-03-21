using OpenQA.Selenium;
using SwagPages.Inventory;
using System.ComponentModel.Design;

namespace SwagPages
{
    public class LoginPage : BasePage
    {
        protected readonly By userNameInputLocator = By.Id("user-name");
        protected readonly By passwordInputLocator = By.Id("password");
        protected readonly By loginButtonLocator = By.Id("login-button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage InputUserName(string userName)
        {
            EnterIntoElement(userNameInputLocator, userName);
            return this;
        }

        public LoginPage InputPassword(string password)
        {
            EnterIntoElement(passwordInputLocator, password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            _driver.FindElement(loginButtonLocator).Click();
            return this;
        }

        public InventoryPage LoginUser(string userName, string password)
        {
            InputUserName(userName);
            InputPassword(password);
            ClickLoginButton();
            return new InventoryPage(_driver);
        }
    }
}
