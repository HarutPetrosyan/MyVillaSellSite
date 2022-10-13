using AutoMapper;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;

namespace MagicVilla_VillaApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdatedDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreatedDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdatedDto>().ReverseMap();

        }
    }
}
