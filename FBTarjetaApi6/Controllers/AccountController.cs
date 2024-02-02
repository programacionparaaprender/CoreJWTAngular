using FBTarjetaApi6.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FBTarjetaApi6.Controllers
{


    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        // Same key configured in startup to validte the JWT tokens
        private readonly UsuarioService _tarjetaCreditoService;

        private IConfiguration _config;

        public AccountController(IConfiguration config, UsuarioService noticiaService)
        {
            _config = config;
            this._tarjetaCreditoService = noticiaService;
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return StatusCode(200);
        }

        [HttpGet("context")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public JsonResult Context()
        {
            return Json(new
            {
                name = this.User?.Identity?.Name,
                email = this.User?.FindFirstValue(ClaimTypes.Email),
                role = this.User?.FindFirstValue(ClaimTypes.Role),
            });
        }

        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Token([FromBody] Usuario creds)
        {
            var secret = _config.GetSection("JwtConfig").GetSection("secret").Value;
            var key = Encoding.Default.GetBytes(secret);
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(key);
            const string JWTAuthScheme = "JWTAuthScheme";


            SigningCredentials SigningCreds = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

            List<Usuario> listaUsuarios = ValidateLogin(creds);
            if (listaUsuarios.Count == 0)
            {
                return Json(new
                {
                    error = "Login failed"
                });
            }
            Usuario usuario = listaUsuarios.First();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, creds.email)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                //Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return Json(new
            {
                //token = token, 
                token = _tokenHandler.WriteToken(token),
                id = usuario.id,
                nombre = usuario.nombre,
                email = usuario.email,
                role = "User",
                status = 200
            });
        }

        private List<Usuario> ValidateLogin(Usuario creds)
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                lista = _tarjetaCreditoService.findEmailAndPassword(creds);
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
