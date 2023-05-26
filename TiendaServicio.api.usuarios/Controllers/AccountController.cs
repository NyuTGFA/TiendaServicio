using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiendaServicio.api.usuarios.Data;
using TiendaServicio.api.usuarios.Dto;
using TiendaServicio.api.usuarios.Interfaces;
using TiendaServicio.api.usuarios.Modelo;

namespace TiendaServicio.api.usuarios.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.users.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);
            if (user == null)
                return Unauthorized("Usuario o Password inválidos.");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Usuario o Password inválidos.");
                }
            }

            return new UserDto
            {
                UserName = loginDto.UserName,
                Id = user.Id,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegistrerDto registerDto)
        {
            if (await UserExists(registerDto.UserName))
            {
                return BadRequest("El nombre de usuario ya se encuentra asignado.");
            }

            using var haac = new HMACSHA512();
            var user = new Usuario
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = haac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = haac.Key
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string userName)
        {
            return await _context.users.AnyAsync(x => x.UserName == userName.ToLower());
        }

    }
}