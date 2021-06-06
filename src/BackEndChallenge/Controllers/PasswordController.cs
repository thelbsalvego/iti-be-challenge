using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndChallenge.Domain.Models;
using BackEndChallenge.Domain.Services;
using BackEndChallenge.UseCases;

namespace BackEndChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordValidationService _passwordValidationService;
        private readonly IValidatePasswordUseCase _validatePasswordUseCase;

        public PasswordController(IValidatePasswordUseCase validatePasswordUseCase,
            IPasswordValidationService passwordValidationService)
        {
            _validatePasswordUseCase = validatePasswordUseCase;
            _passwordValidationService = passwordValidationService;
        }

        [HttpGet("{password}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<Password>> GetValidation(string password)
        {
            
            var pwd = _validatePasswordUseCase.Validate(password);
            return Ok(pwd);
        }
    }
}