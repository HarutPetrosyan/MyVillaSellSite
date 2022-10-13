using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;

namespace MagicVilla_VillaApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        Task<LocalUser> Registre(RegistrationRequestDTO registrationRequestDTO);
    }
}
