using Xunit;
using BackEndChallenge.Controllers;
using BackEndChallenge.UseCases;
using BackEndChallenge.Domain.Models;
using BackEndChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndChallenge.Test
{
    public class PasswordControllerTests
    {
        private readonly PasswordController _passwordController;

        public PasswordControllerTests(IPasswordValidationService passwordValidationService,
            IValidatePasswordUseCase validatePasswordUseCase)
        {
            _passwordController = new PasswordController(validatePasswordUseCase, passwordValidationService);
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
            var actual = _passwordController.GetValidation(password);

            var result = actual.Result.Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            Assert.False((result.Value as Password).IsValid);
        }

        [Fact]
        public void Assert_ValidPassword_ReturnIsValid_True()
        {
            var actual = _passwordController.GetValidation("AbTp9!fok");

            var result = actual.Result.Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as Password).IsValid);
        }
    }
}