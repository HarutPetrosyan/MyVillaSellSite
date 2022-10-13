using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using MagicVilla_Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using MagicVilla_Utility;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDto> list = new();
            var response = await _villaNumberService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVmnew = new();
            var response = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberVmnew.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result)).Select(i=>new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return View(villaNumberVmnew);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM modelCreateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(modelCreateDto.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else if (response.ErrorMessages.Count > 0)
                {
                    ModelState.AddModelError("Error Messages",response.ErrorMessages.FirstOrDefault());
                }
                
            }

            
            var resp = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                modelCreateDto.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(resp.Result)).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
          
            return View(modelCreateDto);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            VillaNumberUpdateVM villaNumberUpdate = new();
            var response = await _villaNumberService.GetByIdAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (ModelState.IsValid)
            {
               
                if (response != null && response.IsSuccess)
                {
                    VillaNumberDto model = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result));
                    villaNumberUpdate.VillaNumber= _mapper.Map<VillaNumberUpdatedDto>(model);
                }
            }

            response = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberUpdate.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result)).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(villaNumberUpdate);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM modelCreateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(modelCreateDto.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else if (response.ErrorMessages.Count > 0)
                {
                    ModelState.AddModelError("Error Messages", response.ErrorMessages.FirstOrDefault());
                }

            }


            var resp = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                modelCreateDto.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(resp.Result)).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return View(modelCreateDto);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM villaNumberUpdate = new();
            var response = await _villaNumberService.GetByIdAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (ModelState.IsValid)
            {

                if (response != null && response.IsSuccess)
                {
                    VillaNumberDto model = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result));
                    villaNumberUpdate.VillaNumber = model;
                }
            }

            response = await _villaService.GatAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberUpdate.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result)).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(villaNumberUpdate);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM modelCreateDto)
        {

            var response = await _villaNumberService.DeleteAsync<APIResponse>(modelCreateDto.VillaNumber.VillaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

            return View(modelCreateDto);
        }
    }
}
