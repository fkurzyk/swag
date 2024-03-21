using OpenQA.Selenium;

namespace SwagPages
{
    public abstract class BasePage : Utilities
    {
        protected Menu Menu { get; set; }

        protected BasePage(IWebDriver driver) : base(driver)
        {
            Menu = new Menu(driver);
        }

        public LoginPage Logout()
        {
            Menu
                .OpenMenu()
                .SelectMenuOption("Logout");
            return new LoginPage(_driver);
        }

        public bool IsThisPage(string pageName)
        {
            switch (pageName.ToLower())
            {
                case "login":
                    {
                        return IsElementPresent(By.ClassName("login-box"));
                    }
                case "inventory":
                    {
                        bool urlMatches = _driver.Url.Contains("inventory");
                        bool titleMatches = _driver
                            .FindElement(By.XPath("//*[@class='title']"))
                            .Text == "Products";
                        if (urlMatches && titleMatches) { return true; }
                        if (!urlMatches && !titleMatches) { return false; }
                        throw new Exception("Inconclusive");
                    }
                case "cart":
                    {
                        bool urlMatches = _driver.Url.Contains("cart");
                        bool titleMatches = _driver
                            .FindElement(By.XPath("//*[@class='title']"))
                            .Text == "Your Cart";
                        if (urlMatches && titleMatches) { return true; }
                        if (!urlMatches && !titleMatches) { return false; }
                        throw new Exception("Inconclusive");
                    }
                //class="inventory_details"
                case "item details":
                    {
                        bool urlMatches = _driver.Url.Contains("inventory-item");
                        bool divMatches = IsElementPresent(By.XPath("//div[@class='inventory_details']"));
                        if (urlMatches && divMatches) { return true; }
                        if (!urlMatches && !divMatches) { return false; }
                        throw new Exception("Inconclusive");
                    }
                default:
                    throw new Exception("Unknown page");
            }
        }

        /*public bool IsElementPresent(By locator)
        {
            try
            {
                _driver.FindElement(locator);
            }
            catch (WebDriverException e)
            {
                return false;
            }
            return true;
        }*/
    }
}
