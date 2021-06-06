using Xunit;
using BackEndChallenge.UseCases;
using BackEndChallenge.Domain.Models;
using BackEndChallenge.Domain.Services;

namespace BackEndChallenge.Test
{
    public class ValidatePasswordUseCaseTests
    {
        private readonly IPasswordValidationService _passwordValidationService;
        private readonly IValidatePasswordUseCase _validatePasswordUseCase;

        public ValidatePasswordUseCaseTests(IPasswordValidationService passwordValidationService,
            IValidatePasswordUseCase validatePasswordUseCase)
        {
            _passwordValidationService = passwordValidationService;
            _validatePasswordUseCase = validatePasswordUseCase;
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
            var actual = _validatePasswordUseCase.Validate(password);

            Assert.False(actual.IsValid);
        }

        [Fact]
        public void Assert_ValidPassword_ReturnIsValid_True()
        {
            var actual = _validatePasswordUseCase.Validate("AbTp9!fok");

            Assert.True(actual.IsValid);
        }
    }
}