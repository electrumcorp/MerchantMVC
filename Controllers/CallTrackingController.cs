using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Controllers
{
    public class CallTrackingController : Controller
    {
        private ICallTrackingRepository _callTrackingRepository;
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CallTrackingController(ICallTrackingRepository callTrackingRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _callTrackingRepository = callTrackingRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<CallTrackingViewModel> callTrackings = new List<CallTrackingViewModel>();
            callTrackings = _callTrackingRepository.GetCallTrackingByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));
            return View(callTrackings);
        }

        public IActionResult ShowCallTracking()
        {
            IEnumerable<CallTrackingViewModel> locations = _callTrackingRepository.GetCallTrackingByLocationId((int)HttpContext.Session.GetInt32("LocationId"));
            return View();
        }

        [HttpGet]
        public IActionResult GetCallTracking()
        {
            // TempData["CategoryId"] = 58;
            List<CallTrackingViewModel> lst = new List<CallTrackingViewModel>();
            if (HttpContext.Session.GetInt32("LocationId") != null)
            {
                var callT = _callTrackingRepository.GetCallTrackingByLocationId((int)HttpContext.Session.GetInt32("LocationId"));
                if (callT != null)
                {
                    lst = callT.ToList();
                }
            }

            return new JsonResult(lst);
        }

        public IActionResult AddSupportCall()
        {
            CallTrackingViewModel callTrackingViewModel = new CallTrackingViewModel();
            callTrackingViewModel.Id = HttpContext.Session.GetInt32("LocationId");
            callTrackingViewModel.EmployeeName = HttpContext.Session.GetString("EmployeeName");// TempData["LocationName"].ToString();// "Hot Spot 4005 - Greer";//
            //callTrackingViewModel.Status = _categoryRepository.GetCategoryByTypeId(26).Select(s =>
            //   new SelectListItem
            //   {
            //       Value = s.CategoryId.ToString(),
            //       Text = s.CategoryName
            //   }
            //    ).ToList();
            //callTrackingViewModel.Priority = _categoryRepository.GetCategoryByTypeId(27).Select(p =>
            //  //GetCategoryForPriorityByCategoryId().Select(p =>
            //  new SelectListItem
            //  {
            //      Value = p.CategoryId.ToString(),
            //      Text = p.CategoryName

            //  }).ToList();

            return View(callTrackingViewModel);
        }

        public IActionResult Create()
        {
            CallTrackingViewModel callTrackingViewModel = new CallTrackingViewModel();
            callTrackingViewModel.Id = HttpContext.Session.GetInt32("MerchantId");
            callTrackingViewModel.EmployeeName = HttpContext.Session.GetString("EmployeeName");
            callTrackingViewModel.StatusList = new List<SelectListItem>
            { new SelectListItem { Text = "Open Escalate Electrum", Value = "378"},
                new SelectListItem {Text="Open", Value="111"},
                new SelectListItem {Text="Closed", Value="112"},
                new SelectListItem {Text="Open Escalate", Value="375"},
                new SelectListItem {Text="Open Escalate Sponsor", Value="376"},
                new SelectListItem {Text="Resolved Open Escalate Sponsor", Value="377"},
                new SelectListItem {Text="Resolved Open Escalate Electrum", Value="379"}
            };

            callTrackingViewModel.PriorityList = new List<SelectListItem>
            {
                new SelectListItem { Text = "4 - Low Severity", Value = "115"},
                new SelectListItem { Text = "3 - Medium Severity", Value = "117"},
                new SelectListItem { Text = "2 - High Severity", Value = "116"}
            };

            return View(callTrackingViewModel);
        }

        [HttpPost]
        //public async Task<IActionResult> AddSupportCall(CallTrackingViewModel callTrackingViewModel)
        //{
        //    CallTracking callTracking = new CallTracking();
        //    if(ModelState.IsValid)
        //    {
        //        callTrackingViewModel.Id = HttpContext.Session.GetInt32("LocationId");
        //        callTrackingViewModel.EntityCategoryId = 58;
        //        callTrackingViewModel.EmployeeId = HttpContext.Session.GetInt32("EmployeeId") ;
        //        callTrackingViewModel.EntityCategoryId=HttpContext.Session.GetInt32("CategoryId");
        //        _mapper.Map(callTrackingViewModel, callTracking);
              
        //        await _callTrackingRepository.Add(callTracking);
        //        TempData["Message"] = "Support call added successfully.";
        //    }
        //    else
        //    {
        //        var msg = "";
        //        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var error in allErrors)
        //        {
        //            msg += error.ErrorMessage + "; ";
        //        }
        //        TempData["Message"] = msg;

        //    return RedirectToAction("AddSupportCall");
        //}

        [HttpPost]
        public async Task<IActionResult> AddMerchantSupportCall(CallTrackingViewModel callTrackingViewModel)
        {
            CallTracking callTracking = new CallTracking();
            if (ModelState.IsValid)
            {
                callTrackingViewModel.Id = HttpContext.Session.GetInt32("MerchantId");
                callTrackingViewModel.EntityCategoryId = 57;
                callTrackingViewModel.EmployeeId = HttpContext.Session.GetInt32("EmployeeId");
                _mapper.Map(callTrackingViewModel, callTracking);

                await _callTrackingRepository.Add(callTracking);
                TempData["Message"] = "Support call added successfully.";
            }

            return RedirectToAction("AddSupportCall");
        }
    }
}
