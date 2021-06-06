using Xunit;
using BackEndChallenge.UseCases;
using BackEndChallenge.Domain.Models;
using BackEndChallenge.Domain.Services;

namespace BackEndChallenge.Test.Tests
{
    public class ValidatePasswordUseCaseTests
    {
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
            var validatePasswordUseCase = new ValidatePasswordUseCase(new DefaultPasswordValidation());

            var actual = validatePasswordUseCase.Validate(password);

            Assert.False(actual.IsValid);
        }

        [Fact]
        public void Assert_ValidPassword_ReturnIsValid_True()
        {
            var validatePasswordUseCase = new ValidatePasswordUseCase(new DefaultPasswordValidation());

            var actual = validatePasswordUseCase.Validate("AbTp9!fok");

            Assert.True(actual.IsValid);
        }
    }
}