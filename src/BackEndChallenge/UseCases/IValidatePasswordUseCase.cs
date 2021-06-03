using BackEndChallenge.Domain.Models;

namespace BackEndChallenge.UseCases
{
    public interface IValidatePasswordUseCase
    {
        Password Validate(string password);
    }
}