using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using MagicVilla_Utility;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDto> list = new();
            var response = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVilla()
        {
           
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDto modelCreateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(modelCreateDto, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(modelCreateDto);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.GetByIdAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                   
                    VillaDto model= JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                    return View(_mapper.Map<VillaUpdateDto>(model));
                }
            }
            
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDto modelCreateDto)
        {
            if (ModelState.IsValid)
            {
                
                var response = await _villaService.UpdateAsync<APIResponse>(modelCreateDto, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa updated successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(modelCreateDto);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.GetByIdAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                    return View(model);
                }
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDto modelCreateDto)
        {
           
                var response = await _villaService.DeleteAsync<APIResponse>(modelCreateDto.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa deleted successfully";
                return RedirectToAction(nameof(IndexVilla));
                }
                TempData["error"] = "Error encountered.";

            return View(modelCreateDto);
        }
    }
}
