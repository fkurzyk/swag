using OpenQA.Selenium;

namespace SwagPages
{
    public class CartPage : BasePage
    {
        protected readonly string cartItemByNameXPath = "//div[@class='cart_item' and .//div[@class='inventory_item_name' and text()='{0}']]";

        public CartPage(IWebDriver driver) : base(driver) { }

        public bool IsItemInCart(string itemName)
        {
            return IsElementPresent(By.XPath(
                string.Format(cartItemByNameXPath, itemName)));
        }
    }
}
