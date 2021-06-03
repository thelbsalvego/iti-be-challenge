using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndChallenge.Domain.Models;
using BackEndChallenge.Domain.Services;

namespace BackEndChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordValidationService _passwordValidationService;

        public PasswordController(IPasswordValidationService passwordValidationService)
        {
            _passwordValidationService = passwordValidationService;
        }

        [HttpGet("{password}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<Password>> GetValidation(string password)
        {
            return Ok();
        }
    }
}