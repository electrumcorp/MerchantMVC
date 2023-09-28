﻿using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public CallTrackingController(ICallTrackingRepository callTrackingRepository,ICategoryRepository categoryRepository, IMapper mapper)
        {
            _callTrackingRepository = callTrackingRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCallTracking()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCallTracking()
        {
           // TempData["CategoryId"] = 58;
            List<CallTrackingViewModel> lst = new List<CallTrackingViewModel> ();
            if (HttpContext.Session.GetInt32("LocationId") != null)
            {
               var callT = _callTrackingRepository.GetCallTrackingByLocationId((int)HttpContext.Session.GetInt32("LocationId"));
                if(callT!=null)
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
            callTrackingViewModel.Status = _categoryRepository.GetCategoryByTypeId(26).Select(s =>
               new SelectListItem
               {
                   Value = s.CategoryId.ToString(),
                   Text = s.CategoryName
               }
                ).ToList();
            callTrackingViewModel.Priority = _categoryRepository.GetCategoryByTypeId(27).Select(p =>
              //GetCategoryForPriorityByCategoryId().Select(p =>
              new SelectListItem
              {
                  Value = p.CategoryId.ToString(),
                  Text=p.CategoryName

              }).ToList();

            
            return View(callTrackingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddSupportCall(CallTrackingViewModel callTrackingViewModel)
        {
            CallTracking callTracking = new CallTracking();
            if(ModelState.IsValid)
            {
                callTrackingViewModel.Id = HttpContext.Session.GetInt32("LocationId");
                callTrackingViewModel.EmployeeId = HttpContext.Session.GetInt32("EmployeeId") ;
                callTrackingViewModel.EntityCategoryId=HttpContext.Session.GetInt32("CategoryId");
                _mapper.Map(callTrackingViewModel, callTracking);
              
                await _callTrackingRepository.Add(callTracking);
                TempData["Message"] = "Support call added successfully.";
            }
            
           // _mapper.Map(callTrackingViewModel, callTracking);
            //callTracking.Id = callTrackingViewModel.Id;
            //callTracking.Priority = callTrackingViewModel.PriorityID;
            //callTracking.Status = callTrackingViewModel.StatusID;
            //callTracking.Type = callTrackingViewModel.TrackingType;
            //callTracking.EntityCategoryId = 58; //callTrackingViewModel.EntityCategoryId;
         // await   _callTrackingRepository.Add(callTracking);
         //   ModelState.Clear();
            return RedirectToAction("AddSupportCall");
        }
    }
}