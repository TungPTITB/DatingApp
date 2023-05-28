using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Thing;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using API.Entities;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Interfaces;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService){
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){

            if(await UserExists(registerDto.User)) return BadRequest("User is taken");
            using var hmac = new HMACSHA512();

            var auser = new AppUser{
                User = registerDto.User,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(auser);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                User = auser.User,
                Token = _tokenService.CreateToken(auser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto){
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.User == logindto.User);

            if(user == null) return Unauthorized("Invalid user");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            for(int i=0 ; i< computeHash.Length ; i++){
                if(computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");

            }

            return new UserDto
            {
                User = user.User,
                Token = _tokenService.CreateToken(user)
            };

        }
        private async Task<bool> UserExists(string user){
            return await _context.Users.AnyAsync(x => x.User == user.ToLower());
        }
    }
}