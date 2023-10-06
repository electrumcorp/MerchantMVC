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
            try
            {
                Merchant merchantResult = new Merchant();
                MerchantViewModel merchantViewModel = new MerchantViewModel();

                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("LocationID", editMerchantVM.MerchantId.ToString());
                    merchantResult = await _merchantRepository.Get((int)editMerchantVM.MerchantId);

                    _mapper.Map(editMerchantVM, merchantResult);
                    _merchantRepository.Update(merchantResult);
                    merchantViewModel = _mapper.Map<MerchantViewModel>(merchantResult);
                    ViewBag.Message = "Merchant updated successfully.";

                    return PartialView("_PartialEditMerchant", merchantViewModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(editMerchantVM);

        }
    }
}
