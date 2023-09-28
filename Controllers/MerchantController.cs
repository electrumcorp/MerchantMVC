using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantMVC.Controllers
{
    public class MerchantController : Controller
    {
        private IMerchantRepository _merchantRepository;
        private IMapper _mapper;

        public MerchantController(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        // GET: MerchantController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            Merchant merchantResult = await _merchantRepository.Get((int)HttpContext.Session.GetInt32("MerchantId"));

            MerchantViewModel merchantViewModel = _mapper.Map<MerchantViewModel>(merchantResult); //new EditLocationViewModel();//

            HttpContext.Session.SetInt32("MerchantId", merchantViewModel.MerchantId);
            HttpContext.Session.SetString("MerchantName", string.Concat(merchantViewModel.MName));
            TempData["MerchantId"] = merchantViewModel.MerchantId;
            TempData["MerchantName"] = merchantViewModel.MName;

            return View(merchantViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MerchantViewModel editMerchantVM)
        {
            if (ModelState.IsValid)
            {
                Merchant merchantResult = null;
                merchantResult = await _merchantRepository.Get((int)HttpContext.Session.GetInt32("MerchantId"));
                if (merchantResult == null)
                {
                    return BadRequest("Please verify the Merchant Details.");
                }

                merchantResult.MName = editMerchantVM.MName;
                merchantResult.MAddr1 = editMerchantVM.MAddr1;
                merchantResult.MAddr2 = editMerchantVM.MAddr2;
                merchantResult.MCity = editMerchantVM.MCity;
                merchantResult.MState = editMerchantVM.MState;
                merchantResult.MZip = editMerchantVM.MZip;
                merchantResult.MFname = editMerchantVM.MFname;
                merchantResult.MLname = editMerchantVM.MLname;
                merchantResult.MPhone = editMerchantVM.MPhone;
                merchantResult.EmailAddress = editMerchantVM.EmailAddress; 
                merchantResult.MExten = editMerchantVM.MExten; 
                merchantResult.Urladdress = editMerchantVM.Urladdress; 
                _merchantRepository.Update(merchantResult);


                MerchantViewModel merchantVM = _mapper.Map<MerchantViewModel>(merchantResult);
                ViewBag.Message = "Merchant updated successfully.";
                return View("Edit", merchantVM);
            }
            else
            {
                return BadRequest("Please verify the Merchant Details.");
            }

        }
    }
}
