using AutoMapper;
using MagicVilla_Web.Models.DTO;


namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
           
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
       

           
            CreateMap<VillaNumberDto, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdatedDto>().ReverseMap();
           

        }
    }
}
