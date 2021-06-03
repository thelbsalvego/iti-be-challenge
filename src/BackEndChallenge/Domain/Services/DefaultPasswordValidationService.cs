namespace BackEndChallenge.Domain.Services
{
    public class DefaultPasswordValidation : IPasswordValidationService
    {
        public bool IsValid(string password)
        {
            return false;
        }
    }
}