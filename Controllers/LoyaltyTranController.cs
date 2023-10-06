using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Controllers
{
    public class LoyaltyTranController : Controller
    {
        private ILoyaltyTranRepository _loyaltyTranRepository;
        private IMapper _mapper;
        public LoyaltyTranController(ILoyaltyTranRepository loyaltyTranRepository , IMapper mapper)
        {
            _loyaltyTranRepository = loyaltyTranRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDetail(int id)
        {

            LoyaltyTranViewModel detailTranViewModel = _loyaltyTranRepository.GetLoyaltyTransactionByLocationID(id,(int) HttpContext.Session.GetInt32("LocationId"));
            //_mapper.Map<LoyaltyTransactionTEc, LoyaltyTranViewModel>(lt, detailTranViewModel);


            return PartialView("_PartialLoyaltyTranDetail",detailTranViewModel);
        }
        [HttpGet]
        public IActionResult Detail (int id)
        {
            
            LoyaltyTranViewModel detailTranViewModel = new LoyaltyTranViewModel();
            LoyaltyTransactionTEc lt = _loyaltyTranRepository.Get(id).Result;
                _mapper.Map<LoyaltyTransactionTEc,LoyaltyTranViewModel>(lt, detailTranViewModel);


            return View(detailTranViewModel);
        }
        public IActionResult Edit(int id=0)
        {
            if(id!=0)
            {
                LoyaltyTransactionTEc tec = _loyaltyTranRepository.Get(id).Result;
                return View(tec);
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLoyaltyTran()
        {
            List<LoyaltyTranViewModel> lst = _loyaltyTranRepository.GetAllLoyaltyTransactionByLocationID((int)HttpContext.Session.GetInt32("LocationId")).ToList();
            return new JsonResult(lst);
        }

    }
}
