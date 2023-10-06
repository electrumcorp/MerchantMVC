using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchantMVC.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository _locationRepository;
        private IMapper _mapper;
        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "LName" : "";

            IEnumerable<EditLocationViewModel> locations = _locationRepository.GetLocationsByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));

            if (!String.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(x => x.LName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "LName":
                    locations = locations.OrderByDescending(l => l.LName);
                    break;
                default:
                    locations = locations.OrderBy(l => l.LName);
                    break;
            }

            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLocation(EditLocationViewModel newLocationViewModel)
        {
            //try
            //{
               Location location = new Location();
                if (ModelState.IsValid)
                {
                    newLocationViewModel.MerchantId = HttpContext.Session.GetInt32("MerchantId");
                    newLocationViewModel.LocationStatus = "P";
                    _mapper.Map(newLocationViewModel, location);

                    await _locationRepository.Add(location);
                    TempData["Message"] = "New Location successfully added.";
                }
                else 
                {
                    TempData["Message"] = "Verify Location details.";
                }
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError("", ex.Message);
            //}

            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit1(int id)
        {
            HttpContext.Session.SetString("LocationID", id.ToString());
            //Location locationResult = await _locationRepository.Get((int)HttpContext.Session.GetInt32("LocationId"));
            Location locationResult = await _locationRepository.Get(id);
            EditLocationViewModel locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult);

            //set Session vars
            HttpContext.Session.SetString("LocationName", locationViewModel.LName.ToString());
            HttpContext.Session.SetString("LocationID", locationViewModel.LocationId.ToString());
            TempData["LocationId"] = locationViewModel.LocationId;
            TempData["LocationName"] = string.Concat(locationViewModel.LFname, " ", locationViewModel.LLname);

            return View(locationViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpContext.Session.SetString("LocationID", id.ToString());
            //Location locationResult = await _locationRepository.Get((int)HttpContext.Session.GetInt32("LocationId"));
            Location locationResult = await _locationRepository.Get(id);

            EditLocationViewModel locationViewModel = new EditLocationViewModel();
            locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult); //new EditLocationViewModel();//

            //set Session vars
            HttpContext.Session.SetString("LocationName", locationViewModel.LName.ToString());
            HttpContext.Session.SetString("LocationID", locationViewModel.LocationId.ToString());
            TempData["LocationId"] = locationViewModel.LocationId;
            TempData["LocationName"] = string.Concat(locationViewModel.LFname, " ", locationViewModel.LLname);

            return View(locationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditLocationViewModel editLocationModel)
        {
            try
            {
                Location locationResult = new Location();
                EditLocationViewModel locationViewModel = new EditLocationViewModel();

                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("LocationID", editLocationModel.LocationId.ToString());
                    locationResult = await _locationRepository.Get((int)editLocationModel.LocationId);

                    _mapper.Map(editLocationModel, locationResult);
                    _locationRepository.Update(locationResult);
                    locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult);
                    ViewBag.Message = "Location updated successfully.";

                    return PartialView("_PartialEditLocation", locationViewModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(editLocationModel);
        }

        public string SwitchTabs(string tabname)
        {
            var lm = new EditLocationViewModel();
            switch (tabname)
            {
                case "LoyaltyTransaction":
                    lm.ActiveTab = EditLocationViewModel.Tab.LoyaltyTransaction; break;
                case "Batches":
                    lm.ActiveTab = EditLocationViewModel.Tab.Batches; break;
                case "Terminal":
                    lm.ActiveTab = EditLocationViewModel.Tab.Terminal; break;
                case "CurrentTransaction":
                    lm.ActiveTab = EditLocationViewModel.Tab.CurrentTransaction; break;
                case "SupportCalls":
                    lm.ActiveTab = EditLocationViewModel.Tab.SupportCalls; break;
                default:
                    lm.ActiveTab = EditLocationViewModel.Tab.LoyaltyTransaction; break;


            }

            TempData["ActiveTab"] = lm.ActiveTab;
            return lm.ActiveTab.ToString();
        }
    }
}
