using FluentAssertions;
using SwagPages.Inventory;

namespace swag.Tests
{
    [TestClass]
    public class InventoryTest : BaseTest
    {
        [TestInitialize]
        public void InventoryTestInitialize()
        {
            Console.WriteLine("=== InventoryTestInitialize ===");
            Login();
        }

        [DataRow("Sauce Labs Backpack")]
        [DataRow("Sauce Labs Fleece Jacket")]
        [DataRow("Test.allTheThings() T-Shirt (Red)")]
        [TestMethod]
        public void ItemCanBeAddedToCart(string itemName)
        {
            //When
            new InventoryPage(driver)
                .AddItemToCart(itemName)
            //Then
                .GoToCart()
                .IsItemInCart(itemName)
                .Should().BeTrue();
        }

        [DataRow("Sauce Labs Backpack")]
        [DataRow("Sauce Labs Fleece Jacket")]
        [DataRow("Test.allTheThings() T-Shirt (Red)")]
        [TestMethod]
        public void ItemCanBeAddedToCartGAIDEN(string itemName)
        {
            //When
            var inventoryPage = new InventoryPage(driver);
            inventoryPage
                .GetItem(itemName)
                .AddToCart();
            //Then
            inventoryPage
                .GoToCart()
                .IsItemInCart(itemName)
                .Should().BeTrue();
        }

        [DataRow("Sauce Labs Bike Light", "Test.allTheThings() T-Shirt (Red)", "Sauce Labs Onesie")]
        [DataRow("Sauce Labs Bolt T-Shirt", "Sauce Labs Backpack")]
        [TestMethod]
        public void MultipleItemsCanBeAddedToCart(params string[] itemNames)
        {
            //When
            var inventoryPage = new InventoryPage(driver);
            itemNames.ToList().ForEach(i => inventoryPage.AddItemToCart(i));
            //Then
            var cartPage = inventoryPage.GoToCart();
            itemNames.ToList().ForEach(i => cartPage.IsItemInCart(i));
        }

        [DataRow("Sauce Labs Bike Light", "Test.allTheThings() T-Shirt (Red)", "Sauce Labs Onesie")]
        [DataRow("Sauce Labs Bolt T-Shirt", "Sauce Labs Backpack")]
        [TestMethod]
        public void MultipleItemsCanBeAddedToCartGAIDEN(params string[] itemNames)
        {
            //When
            var inventoryPage = new InventoryPage(driver);
            itemNames.ToList().ForEach(i => inventoryPage.GetItem(i).AddToCart());
            //Then
            var cartPage = inventoryPage.GoToCart();
            itemNames.ToList().ForEach(i => cartPage.IsItemInCart(i).Should().BeTrue());
        }

        [DataRow("Sauce Labs Fleece Jacket")]
        [DataRow("Test.allTheThings() T-Shirt (Red)")]
        [TestMethod]
        public void ItemCanBeRemovedFromCart(string itemName)
        {
            //Given
            var inventoryPage = new InventoryPage(driver);
            var item = inventoryPage.GetItem(itemName);
            item.AddToCart();
            //When
            item.RemoveFromCart();
            //Then
            inventoryPage
                .GoToCart()
                .IsItemInCart(itemName)
                .Should().BeFalse();
        }
    }
}
