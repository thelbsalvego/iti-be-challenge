using Xunit;
using BackEndChallenge.Domain.Services;

namespace BackEndChallenge.Test
{
    public class PasswordValidationServiceTests
    {
        private readonly IPasswordValidationService _passwordValidationService;

        public PasswordValidationServiceTests(IPasswordValidationService passwordValidationService)
        {
            _passwordValidationService = passwordValidationService;
        }

        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void Assert_InvalidPasswords_ReturnIsValid_False(string password)
        {
            var actual = _passwordValidationService.IsValid(password);

            Assert.False(actual);
        }

        [Fact]
        public void Assert_ValidPassword_ReturnIsValid_True()
        {
            var actual = _passwordValidationService.IsValid("AbTp9!fok");

            Assert.True(actual);
        }
    }
}