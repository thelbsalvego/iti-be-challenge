namespace BackEndChallenge.Domain.Services
{
    public interface IPasswordValidationService
    {
        bool IsValid(string password);
    }
}