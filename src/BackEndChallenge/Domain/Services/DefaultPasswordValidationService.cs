using System.Text.RegularExpressions;

namespace BackEndChallenge.Domain.Services
{
    public class DefaultPasswordValidation : IPasswordValidationService
    {
        public bool IsValid(string password) 
        {
            var rx = new Regex(@"^(?=.+[a-z])(?=.+[A-Z])(?=.+\d)(?=.+[!@#$%^&*()\-+])(?!.*(.+).*\1{1})[a-zA-Z0-9!@#$%^&*()\-+]{9,}$");
            return rx.IsMatch(password);
        }
    }
}