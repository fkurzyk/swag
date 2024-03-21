using OpenQA.Selenium;

namespace SwagPages
{
    public class ItemDetailsPage : BasePage
    {
        public ItemDetailsPage(IWebDriver driver) : base(driver) { }

        public bool IsThisDetailsPageForItem(string itemName)
        {
            return _driver.FindElement(By.XPath("//div[contains(@class, 'inventory_details_name')]"))
                .Text == itemName;
        }
    }
}
