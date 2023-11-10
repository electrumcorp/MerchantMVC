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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchantMVC.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository _locationRepository;
        private ILocationActivateRepository _locationActivateRepository;
        private IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, ILocationActivateRepository locationActivateRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _locationActivateRepository = locationActivateRepository;
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
        public async Task<IActionResult> Create(EditLocationViewModel newLocationViewModel)
        {
            try
            {
                LocationActivate locationActivate = new LocationActivate();
                if (ModelState.IsValid)
                {
                    newLocationViewModel.MerchantId = HttpContext.Session.GetInt32("MerchantId");
                    newLocationViewModel.LocationStatus = "P";
                    newLocationViewModel.CategoryId = 385;
                    newLocationViewModel.EntityCategoryId = 58;
                    newLocationViewModel.CountryId = 1;
                    _mapper.Map(newLocationViewModel, locationActivate);

                    await _locationActivateRepository.Add(locationActivate);

                    ViewBag.Message = "New Location added successfully. Once reviewed, your location will be activated.";

                    EditLocationViewModel viewModel = new EditLocationViewModel();
                    return PartialView("_PartialCreateLocation", viewModel);
                }
                else
                {
                    var msg = "";
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in allErrors)
                    {
                        msg += error.ErrorMessage + "; ";
                    }
                    TempData["Message"] = msg;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(newLocationViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpContext.Session.SetString("LocationId", id.ToString());
            EditLocationViewModel locationViewModel = _locationRepository.GetLocationViewModel(id);


            //set Session vars
            HttpContext.Session.SetString("LocationName", locationViewModel.LName.ToString());
            HttpContext.Session.SetString("LocationId", locationViewModel.LocationId.ToString());
            TempData["LocationId"] = locationViewModel.LocationId;
            TempData["LocationName"] = string.Concat(locationViewModel.LFname, " ", locationViewModel.LLname);
            ViewBag.LocationId = locationViewModel.LocationId;

            return View(locationViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditLocationViewModel editLocationModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("LocationId", editLocationModel.LocationId.ToString());
                    var viewModel = _locationRepository.UpdateLocation(editLocationModel);
                    ViewBag.Message = "Location updated successfully.";

                    return PartialView("_PartialEditLocation", viewModel);
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
