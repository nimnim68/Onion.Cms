using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Onion.Cms.API.Common;
using Onion.Cms.Domain.DTOs.Auth;
using Onion.Cms.Domain.User.Dtos;
using Onion.Cms.Domain.User.Entities;

namespace Onion.Cms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptionsMonitor<JwtConfig> _jwtConfig;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtConfig = jwtConfig;
        }

        [HttpGet("login")]
        [ProducesResponseType(typeof(RegistrationResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginUserDto login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    var tryCount = user.AccessFailedCount;
                    var lockUser = tryCount >= 5;
                    var res = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, lockUser);
                    if (res.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var jwtGenerate = new JwtGenerate(_jwtConfig);
                        var token = jwtGenerate.GenerateJwtToken(user, roles);

                        return Ok(new RegistrationResponse()
                        {
                            Result = true,
                            Token = token
                        });
                    }
                    return Unauthorized();
                }
            }
            return BadRequest();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(RegistrationResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    EmailConfirmed = false,
                    RegisteredDate = DateTime.Now
                };
                var isCreated = await _userManager.CreateAsync(user, register.Password);
                if (isCreated.Succeeded)
                {
                    var jwtGenerate = new JwtGenerate(_jwtConfig);
                    var token = jwtGenerate.GenerateJwtToken(user);
                    return Ok(new RegistrationResponse
                    {
                        Result = true,
                        Token = token
                    });
                }
                var errorList = isCreated.Errors.Select(x => x.Description.ToString()).ToList();
                return BadRequest(new RegistrationResponse
                {
                    Result = false,
                    Errors = errorList
                });
            }
            return BadRequest();
        }


        [HttpPost("getOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<bool> GetOrderAsync([FromBody] LoginUserDto login)
        {
            return true;
        }
    }
}
