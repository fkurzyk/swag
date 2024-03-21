using FluentAssertions;
using SwagPages.Inventory;

namespace swag.Tests
{
    [TestClass]
    public class ItemDetailsTest : BaseTest
    {
        [TestInitialize]
        public void ItemDetailsInitialize()
        {
            Console.WriteLine("=== ItemDetailsTestInitialize ===");
            Login();
        }

        [DataRow("Sauce Labs Backpack")]
        [DataRow("Sauce Labs Fleece Jacket")]
        [DataRow("Test.allTheThings() T-Shirt (Red)")]
        [TestMethod]
        public void DisplayItemDetails(string itemName)
        {
            //When
            var itemDetailsPage = new InventoryPage(driver)
                .ClickItemName(itemName);
            //Then
            itemDetailsPage
                .IsThisPage("item details")
                .Should().BeTrue();
            itemDetailsPage
                .IsThisDetailsPageForItem(itemName)
                .Should().BeTrue();
        }

        [DataRow("Sauce Labs Backpack")]
        [DataRow("Sauce Labs Fleece Jacket")]
        [DataRow("Test.allTheThings() T-Shirt (Red)")]
        [TestMethod]
        public void DisplayItemDetailsGAIDEN(string itemName)
        {
            //When
            new InventoryPage(driver)
                .GetItem(itemName)
                .GoToDetailsPage()
            //Then
                .IsThisDetailsPageForItem(itemName)
                .Should().BeTrue();
        }
    }
}
