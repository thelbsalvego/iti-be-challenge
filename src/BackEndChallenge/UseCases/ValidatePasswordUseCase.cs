using BackEndChallenge.Domain.Services;
using BackEndChallenge.Domain.Models;

namespace BackEndChallenge.UseCases
{
    public class ValidatePasswordUseCase : IValidatePasswordUseCase
    {
        private readonly IPasswordValidationService _passwordValidationService;

        public ValidatePasswordUseCase(IPasswordValidationService passwordValidationService)
        {
            _passwordValidationService = passwordValidationService;
        }

        public Password Validate(string password) => new Password(password, _passwordValidationService);
    }
}
