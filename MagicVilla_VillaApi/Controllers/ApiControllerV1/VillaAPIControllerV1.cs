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
    [Route("api/v{version:apiVersion}/VillaApi")]
    [ApiController]
    [ApiVersion("1.0")]
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillasAsync()
        {
            try
            {
                IEnumerable<Villa> villaList = await _dbContext.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDto>>(villaList);
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

        [HttpGet("{id:int}", Name = "GetVilla")]

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200,Type=typeof(VillaDto))]
        public async Task<ActionResult<APIResponse>> GetVillaAsync(int id)
        {
            try
            {
                var Villa = await _dbContext.GetByIdAsync(n => n.Id == id);
                if (id == 0)
                {

                    return BadRequest();

                }
                else if (Villa == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaDto>(Villa);
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateVillaAsync([FromBody] VillaCreateDto villaDto)
        {
            try
            {
                if (await _dbContext.GetByIdAsync(n => n.Name.ToLower() == villaDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa already Exists!");
                    return BadRequest(ModelState);
                }
                if (villaDto == null)
                {
                    return BadRequest();
                }

                Villa model = _mapper.Map<Villa>(villaDto);
                await _dbContext.CreateAsync(model);
                _response.Result = _mapper.Map<VillaDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }

            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteVillaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbContext.GetByIdAsync(n => n.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbContext.RemoveAsync(villa);
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
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaAsync(int id, [FromBody] VillaUpdateDto villa)
        {
            try
            {
                if (villa == null || id != villa.Id)
                {
                    return BadRequest();
                }
                Villa model = _mapper.Map<Villa>(villa);
                await _dbContext.UpdateAsync(model);
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

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVillaAsync(int id, JsonPatchDocument<VillaUpdateDto> PatchDTO)
        {
            if (PatchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbContext.GetByIdAsync(n => n.Id == id, tracked: false);
            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

            if (villa == null)
            {
                return NotFound();
            }
            PatchDTO.ApplyTo(villaDto, ModelState);
            Villa modelVilla = _mapper.Map<Villa>(villaDto);

            await _dbContext.UpdateAsync(modelVilla);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
