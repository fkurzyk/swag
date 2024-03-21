using OpenQA.Selenium;

namespace SwagPages.Inventory
{
    public class Item : BaseSection
    {
        protected readonly By nameLocator = By.XPath(".//div[@class='inventory_item_name ']");
        protected readonly By descriptionLocator = By.XPath(".//div[@class='inventory_item_desc']");
        protected readonly By priceLocator = By.XPath(".//div[@class='inventory_item_price']");
        protected readonly By addToCartButtonLocator = By.XPath(".//button[text()='Add to cart']");
        protected readonly By removeFromCartButtonLocator = By.XPath(".//button[text()='Remove']");

        internal string Name => Content.FindElement(nameLocator).Text;
        internal string Description => Content.FindElement(descriptionLocator).Text;
        internal string Price => Content.FindElement(priceLocator).Text;

        internal Item(IWebDriver driver, By by) : base(driver, by) { }

        public ItemDetailsPage GoToDetailsPage()
        {
            Content.FindElement(nameLocator).Click();
            return new ItemDetailsPage(_driver);
        }

        public void AddToCart()
        {
            Content.FindElement(addToCartButtonLocator).Click();
        }

        public bool IsAddToCartButtonAvailable()
        {
            return IsElementPresent(addToCartButtonLocator);
        }

        public void RemoveFromCart()
        {
            Content.FindElement(removeFromCartButtonLocator).Click();
        }

        public bool IsRemoveFromCartButtonAvailable()
        {
            return IsElementPresent(removeFromCartButtonLocator);
        }
    }
}
