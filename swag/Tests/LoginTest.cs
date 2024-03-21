using FluentAssertions;
using SwagPages;

namespace swag.Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        [TestMethod]
        public void SuccessfulLogin()
        {
            // Given
            new LoginPage(driver)
            // When
                .InputUserName("standard_user")
                .InputPassword("secret_sauce")
                .ClickLoginButton()
            // Then
                .IsThisPage("inventory")
                .Should().BeTrue();
        }

        [TestMethod]
        public void UnsuccessfulLogin()
        {
            // Given
            new LoginPage(driver)
            // When
                .InputUserName("standard_user")
                .InputPassword("BETONOWE FAWORKI")
                .ClickLoginButton()
            // Then
                .IsThisPage("login")
                .Should().BeTrue();
        }

        [TestMethod]
        public void LogoutFromInventoryPage()
        {
            // Given
            new LoginPage(driver)
                .LoginUser("standard_user", "secret_sauce")
            // When
                .Logout()
            // Then
                .IsThisPage("login");
        }

        [TestMethod]
        public void LogoutFromCartPage()
        {
            // Given
            new LoginPage(driver)
                .LoginUser("standard_user", "secret_sauce")
                .GoToCart()
            // When
                .Logout()
            // Then
                .IsThisPage("login");
        }
    }
}