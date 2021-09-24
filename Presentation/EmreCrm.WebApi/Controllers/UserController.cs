using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmreCrm.Core.Models;
using EmreCrm.Model.Model;
using EmreCrm.Service.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EmreCrm.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        #endregion

        #region Ctor
        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Methods
        [HttpGet]
        public List<UserModel> Get(int? page, int? rows)
        {
            return _userService.GetPagedList(page, rows);
        }

        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(UserModel userModel)
        {
            ReturnModel<UserModel> returnModel = _userService.Add(userModel);

            return CreatedAtAction("Get", new { id = returnModel.Data.Id }, returnModel.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserModel userModel)
        {
            var user = _userService.GetById(id);

            if (user is null)
            {
                ReturnModel<UserModel> returnModel = _userService.Add(userModel);

                return CreatedAtRoute("Get", new { id = returnModel.Data.Id }, returnModel.Data);
            }

            userModel.Id = id;

            _userService.Update(userModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user is null)
                return NotFound();

            _userService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("/api/token")]
        [AllowAnonymous]
        public IActionResult Token()
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtConfiguration.SigningKey);
            var singingKey = new SymmetricSecurityKey(key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _appSettings.JwtConfiguration.Audience,
                Issuer = _appSettings.JwtConfiguration.Issuer,
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, _appSettings.JwtConfiguration.Issuer)
                }),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

        #endregion
    }
}
