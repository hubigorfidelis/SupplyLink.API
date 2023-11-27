using SupplyLink.Application.InputModels;
using SupplyLink.Application.Services.Interfaces;
using SupplyLink.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SupplyLink.API.Models;
using SupplyLink.Core.Account;
using SupplyLink.Application.ViewModels;

namespace SupplyLink.API.Controllers
{
    [Route("api/users")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUserService _userService;

        public UsersController(IAuthenticate authenticate, IUserService userService)
        {
            _authenticate = authenticate;
            _userService = userService;
        }

        // api/users/1
        [HttpPost("register")]
        public ActionResult<UserToken> Create( NewUserInputModel newUserInputModel)
        {
            if (newUserInputModel == null) 
            {
                return BadRequest("User Exists");
            }
            //var validateEmail = _authenticate.UserExists(newUserInputModel.Email);
            
            //if (validateEmail)
            //{
            //    return BadRequest("Email Exists");
            //}
            var user = _userService.Create(newUserInputModel);
            if(user == null) 
            {
                return BadRequest();
            }

            var token = _authenticate.GenerateToken(newUserInputModel.Id, newUserInputModel.Email);
            return new UserToken
            {
                Token = token,
            };

        }
        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> SelectUser(LoginUserViewModel loginUserViewModel) 
        {
            var exists = _authenticate.UserExists(loginUserViewModel.Email);
            if (!exists) 
            {
                return Unauthorized();
            }
            var result = _authenticate.Authenticate(loginUserViewModel.Email, loginUserViewModel.Password);
            if (!result) 
            {
                return Unauthorized("User or Password invalid");
            }
            var user = await _authenticate.GetUserByEmail(loginUserViewModel.Email);
            var token = _authenticate.GenerateToken(user.Id, user.Email);
            return new UserToken
            {
                Token = token,
            };
        }

    }
}
