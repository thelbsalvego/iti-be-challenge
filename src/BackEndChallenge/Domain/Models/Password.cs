using BackEndChallenge.Domain.Services;

namespace BackEndChallenge.Domain.Models
{
    public class Password
    {        
        private readonly string _password;
        private readonly IPasswordValidationService _passwordValidationService;

        public Password(string password, IPasswordValidationService passwordValidationService)
        {
            _password = password;
            _passwordValidationService = passwordValidationService;
        }
        public bool IsValid 
        { 
            get 
            { 
                return IsValid();
            }
        }

        private bool IsValid()
        {
            return _passwordValidationService.IsValid(_password);
        }     
    }
}