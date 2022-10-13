using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;

namespace MagicVilla_VillaApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDBContext _dbContext;
        private string SecretKey;
        public UserRepository(AplicationDBContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var USER = _dbContext.LocalUsers.FirstOrDefault(N => N.UserName == username);
            if (USER == null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            var user = _dbContext.LocalUsers.FirstOrDefault(n =>
                n.UserName.ToLower() == loginRequestDto.UserName.ToLower()
                && n.Password == loginRequestDto.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            //if user was found generate JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponse;
        }

        public async Task<LocalUser> Registre(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Password = registrationRequestDTO.Password,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role

            };
             _dbContext.LocalUsers.Add(user);
            await _dbContext.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
