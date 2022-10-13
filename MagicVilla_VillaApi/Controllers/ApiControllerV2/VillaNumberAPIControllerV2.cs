using System.Data;
using System.Net;
using AutoMapper;
using MagicVilla_VillaApi.Data;

using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Controllers.ApiControllerV2
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    
    [ApiVersion("2.0")]
    public class VillaNumberAPIControllerV2 : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbContextNumber;
        private readonly IVillaRepository _dbContext;
        private readonly IMapper _mapper;
        public VillaNumberAPIControllerV2(IVillaNumberRepository dbContextNumber, IMapper mapper, IVillaRepository dbContext)
        {
            _dbContextNumber = dbContextNumber;
            _mapper = mapper;
            _response = new();
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hashsasa", "sdfaas" };
        }


    }
}
