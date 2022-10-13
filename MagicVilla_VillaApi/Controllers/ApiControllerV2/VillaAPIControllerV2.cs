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
    [Route("api/v{version:apiVersion}/VillaApi")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaAPIControllerV2 : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaRepository _dbContext;
        private readonly IMapper _mapper;
        public VillaAPIControllerV2(IVillaRepository dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hashsasa", "sdfaas" };
        }

    }
}
