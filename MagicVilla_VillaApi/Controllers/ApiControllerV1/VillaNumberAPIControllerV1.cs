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

namespace MagicVilla_VillaApi.Controllers.ApiControllerV1
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("1.0")] 
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbersAsync()
        {
            try
            {
                IEnumerable<VillaNumber> villaList = await _dbContextNumber.GetAllAsync(includeProperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }

        

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200,Type=typeof(VillaDto))]
        public async Task<ActionResult<APIResponse>> GetVillaNumberAsync(int id)
        {
            try
            {
                var VillaNumber = await _dbContextNumber.GetByIdAsync(n => n.VillaNo == id, includeProperties: "Villa");
                if (id == 0)
                {

                    return BadRequest();

                }
                else if (VillaNumber == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaNumberDto>(VillaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumberAsync([FromBody] VillaNumberCreatedDto villaNumberDto)
        {
            try
            {
                if (await _dbContextNumber.GetByIdAsync(n => n.VillaNo == villaNumberDto.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Number already Exists!");
                    return BadRequest(ModelState);
                }

                if (await _dbContext.GetByIdAsync(n => n.Id == villaNumberDto.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (villaNumberDto == null)
                {
                    return BadRequest();
                }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberDto);
                await _dbContextNumber.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumberAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbContextNumber.GetByIdAsync(n => n.VillaNo == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbContextNumber.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumberAsync(int id, [FromBody] VillaNumberUpdatedDto villa)
        {
            try
            {
                if (villa == null || id != villa.VillaNo)
                {
                    return BadRequest();
                }
                if (await _dbContext.GetByIdAsync(n => n.Id == villa.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(villa);
                await _dbContextNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }

    }
}
