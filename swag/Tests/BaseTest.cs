using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SwagPages;

namespace swag.Tests
{
    public abstract class BaseTest
    {
        internal IWebDriver driver;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public void BaseClassInitialize()
        {
            Console.WriteLine("=== BaseClassInitialize ===");
        }
        
        [TestInitialize]
        public void BaseTestInitialize()
        {
            Console.WriteLine("=== BaseTestInitialize ===");
            driver = GetDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            Console.WriteLine("=== BaseTestCleanup ===");
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string screenshotPath = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}_{TestContext.TestName}.png";
                ((ITakesScreenshot)driver)
                    .GetScreenshot()
                    .SaveAsFile(screenshotPath);
                TestContext.AddResultFile(screenshotPath);
            }
            driver.Quit();
        }

        [ClassCleanup]
        public void BaseClassCleanup()
        {
            Console.WriteLine("=== BaseClassCleanup ===");
        }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            Edge
        }

        internal IWebDriver GetDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver(new ChromeOptions());
                case BrowserType.Firefox:
                    return new FirefoxDriver(new FirefoxOptions());
                case BrowserType.Edge:
                    return new EdgeDriver(new EdgeOptions());
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }

        internal IWebDriver GetDriver()
        {
            string browserString = TestContext.Properties["browser"] as string;
            Console.WriteLine("=== Browser from TestRunParameters: " + browserString);
            return GetDriver(ParseBrowserType(browserString));
        }

        internal BrowserType ParseBrowserType(string browserString)
        {
            if (Enum.TryParse(browserString, ignoreCase: true, out BrowserType browserType))
            {
                return browserType;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(browserString), browserString, null);
            }           
        }

        internal void Login()
        {
            new LoginPage(driver)
                .LoginUser("standard_user", "secret_sauce")
                .IsThisPage("inventory")
                .Should().BeTrue();
        }
    }
}
