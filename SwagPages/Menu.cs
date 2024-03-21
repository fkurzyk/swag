using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagPages
{
    public class Menu : BaseSection
    {
        private readonly By openMenuButtonLocator = By.XPath("//button[text()='Open Menu']");
        private static readonly By menuElementLocator = By.ClassName("bm-menu-wrap");

        internal Menu(IWebDriver driver) : base(driver, menuElementLocator) { }

        internal Menu OpenMenu()
        {
            _driver.FindElement(openMenuButtonLocator).Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            wait.Until(wait => IsMenuOpen());
            return this;
        }

        public bool IsMenuOpen()
        {
            return _driver.FindElement(menuElementLocator).GetAttribute("hidden") != "true";
        }

        internal void SelectMenuOption(string option)
        {
            if (IsMenuOpen())
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
                wait.Until(wait => IsElementPresent(By.LinkText(option)));
                Content.FindElement(By.LinkText(option)).Click();
            }
        }
    }
}
