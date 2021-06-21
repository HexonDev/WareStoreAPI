using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using WareStoreAPI.DTO;
using WareStoreAPI.Models;
using WareStoreAPI.Services;

namespace WareStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IFileProvider _fileProvider;

        public UsersController(UsersService usersService, IMapper mapper, IConfiguration configuration, IFileProvider fileProvider)
        {
            _usersService = usersService;
            _mapper = mapper;
            _configuration = configuration;
            _fileProvider = fileProvider;
        }

        #region GET METHODS

        [HttpGet]
        public IActionResult GetUsers()
        {
            var userDTOs = _mapper.Map<ICollection<User>, ICollection<UserDTO>>(_usersService.GetUsers());
            return Ok(userDTOs);
        }

        [HttpGet("{uid:long}")]
        public IActionResult GetUser(long uid)
        {
            var user = _usersService.GetUser(uid);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDTO>(user));
        }

        #endregion

        #region POST METHODS

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateDTO authenticateDto)
        {
            User user = _usersService.Authenticate(authenticateDto.Username, authenticateDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password incorrect" });

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"));
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString,
                PermissionLevel = user.PermissionLevel,
                TokenExpired = token.ValidTo
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDto)
        {
            User user = _mapper.Map<User>(registerDto);

            try
            {
                _usersService.AddUser(user, registerDto.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        #endregion

        #region PUT METHODS

        [HttpPut("{uid:long}")]
        public IActionResult PutUser(long uid, UpdateDTO updateDto)
        {
            User putUser = _mapper.Map<User>(updateDto);

            if (putUser == null)
                return BadRequest("Model is null");

            putUser.Id = uid;

            try
            {
                _usersService.UpdateUser(putUser, updateDto.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete("{uid:long}")]
        public IActionResult DeleteUser(long uid)
        {
            var user = _usersService.GetUser(uid);

            if (user == null)
                return NotFound();

            _usersService.DeleteUser(user);

            return Ok();
        }

        #endregion
    }
}
