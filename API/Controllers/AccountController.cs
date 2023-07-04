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
using AutoMapper;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public readonly IMapper _mapper;
        public AccountController(DataContext context, ITokenService tokenService, IMapper mapper){
            _mapper = mapper;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){

            if(await UserExists(registerDto.User)) return BadRequest("User is taken");
            
            var auser = _mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512();

                auser.User = registerDto.User;
                auser.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
                auser.PasswordSalt = hmac.Key;

            _context.Users.Add(auser);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                User = auser.User,
                //Token = _tokenService.CreateToken(auser),
                KnownAs = auser.KnownAs,
                Gender = auser.Gender
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto){
            var auser = await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.User == logindto.User);

            if(auser == null) return Unauthorized("Invalid user");

            using var hmac = new HMACSHA512(auser.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            for(int i=0 ; i< computeHash.Length ; i++){
                if(computeHash[i] != auser.PasswordHash[i]) return Unauthorized("Invalid password");

            }

            return new UserDto
            {
                User = auser.User,
                //Token = _tokenService.CreateToken(auser),
                PhotoUrl = auser.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = auser.KnownAs,
                Gender = auser.Gender
            };

        }
        private async Task<bool> UserExists(string user){
            return await _context.Users.AnyAsync(x => x.User == user.ToLower());
        }
    }
}