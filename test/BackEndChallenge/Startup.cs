using Microsoft.Extensions.DependencyInjection;
using BackEndChallenge.Domain.Services;
using BackEndChallenge.UseCases;

namespace BackEndChallenge.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidationService, DefaultPasswordValidation>();
            services.AddTransient<IValidatePasswordUseCase, ValidatePasswordUseCase>();
        }
    }
}