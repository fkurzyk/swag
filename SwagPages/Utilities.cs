using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagPages
{
    public abstract class Utilities
    {
        protected IWebDriver _driver;

        protected Utilities(IWebDriver driver)
        {
            _driver = driver;
        }

        internal bool IsElementPresent(By locator)
        {
            try
            {
                _driver.FindElement(locator);
            }
            catch (WebDriverException)
            {
                return false;
            }
            return true;
        }

        internal void EnterIntoElement(By locator, string inputString)
        {
            var element = _driver.FindElement(locator);
            element.Click();
            element.Clear();
            element.SendKeys(inputString);
        }
    }
}
