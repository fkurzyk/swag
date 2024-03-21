using OpenQA.Selenium;

namespace SwagPages.Inventory
{
    public class InventoryPage : BasePage
    {
        protected readonly string itemByNameXPath = "//div[@class='inventory_item' and .//div[text()='{0}']]";
        protected readonly By addToCartButtonLocator = By.XPath(".//button[text()='Add to cart']");
        protected readonly By itemNameLocator = By.XPath(".//div[@class='inventory_item_name ']");
        protected readonly By cartButtonLocator = By.ClassName("shopping_cart_link");

        public InventoryPage(IWebDriver driver) : base(driver) { }

        public ItemDetailsPage ClickItemName(string itemName)
        {
            var item = _driver.FindElement(By.XPath(
                string.Format(itemByNameXPath, itemName)));
            item.FindElement(itemNameLocator).Click();
            return new ItemDetailsPage(_driver);
        }

        public InventoryPage AddItemToCart(string itemName)
        {
            var item = _driver.FindElement(By.XPath(
                string.Format(itemByNameXPath, itemName)));
            item.FindElement(addToCartButtonLocator).Click();
            return this;
        }

        public CartPage GoToCart()
        {
            _driver.FindElement(cartButtonLocator).Click();
            return new CartPage(_driver);
        }

        public Item GetItem(string itemName)
        {
            return new Item(_driver, By.XPath(string.Format(itemByNameXPath, itemName)));
        }
    }
}
