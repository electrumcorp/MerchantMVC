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
    public class FeedBackController : Controller
    {
        private IFeedBackRepository _repository;
        private IMapper _mapper;

        public FeedBackController(IFeedBackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            MainViewModel vm = new MainViewModel();
            vm.MerchantID = (int)HttpContext.Session.GetInt32("MerchantId");

            List<FeedBackViewModel> feedbacks = new List<FeedBackViewModel>();

            IEnumerable<FeedBack> feedBacksResult = _repository.GetFeedBackByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));

            foreach (var t in feedBacksResult)
            {
                FeedBackViewModel viewModel = _mapper.Map<FeedBackViewModel>(t);
                feedbacks.Add(viewModel);
            }

            vm.Feedback = feedbacks.OrderBy(t => t.Ordinal).ToList();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MainViewModel inputMainViewModel)
        {
            //if (ModelState.IsValid)
            //{
            List<FeedBackViewModel> updated = new List<FeedBackViewModel>();

            foreach (var feedback in inputMainViewModel.Feedback)
            {
                FeedBack inputFeedBack = _mapper.Map<FeedBack>(feedback);
                FeedBack feedBackResult = await _repository.Get((int)feedback.FeedBackId);
                _mapper.Map(inputFeedBack, feedBackResult);
                _repository.Update(feedBackResult);
                FeedBackViewModel feedbackVM = _mapper.Map<FeedBackViewModel>(feedBackResult);
                updated.Add(feedbackVM);
            }

            inputMainViewModel.Feedback = updated;
            ViewBag.Message = "Feedback questions updated successfully.";
            return View("Index", inputMainViewModel);

            //[HttpGet]
            //public IActionResult Index()
            //{
            //    IEnumerable<TerminalViewModel> terminals = _terminalRepository.GetTerminalsByMerchantId((int)HttpContext.Session.GetInt32("MerchantId")).OrderBy(t => t.Terminal30Id);

            //    return View(terminals);
            //}

            //[HttpGet]
            //public IActionResult Create()
            //{
            //    return View();
            //}

            //[HttpGet]
            //public async Task<IActionResult> Edit1()
            //{
            //    Terminal terminalResult = await _terminalRepository.Get((int)HttpContext.Session.GetInt32("LocationId"));

            //    EditLocationViewModel locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult);

            //    return View(locationViewModel);

            //}


            //[HttpGet]
            //public  async Task< IActionResult> Edit(int id)
            //{
            //     //Location locationResult = await _locationRepository.Get((int)HttpContext.Session.GetInt32("LocationId"));
            //     Location locationResult = await _locationRepository.Get(id);

            //    EditLocationViewModel locationViewModel = new EditLocationViewModel();
            //    locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult); //new EditLocationViewModel();//

            //    //HttpContext.Session.SetInt32("LocationId", locationViewModel.LocationId);\
            //    HttpContext.Session.SetString("LocationName", locationViewModel.LName.ToString());
            //    HttpContext.Session.SetString("LocationID", locationViewModel.LocationId.ToString());
            //    TempData["LocationId"] = locationViewModel.LocationId;
            //    TempData["LocationName"] =string.Concat( locationViewModel.LFname," ",locationViewModel.LLname);
            //    return View(locationViewModel);
            //}

            //[HttpPost]
            //public async Task<IActionResult> Edit(EditLocationViewModel editLocationModel)
            //{
            //    if(ModelState.IsValid)
            //    {
            //        Location locationResult = _mapper.Map<Location>(editLocationModel);
            //        //
            //        locationResult = null;
            //        locationResult = await _locationRepository.Get((int)HttpContext.Session.GetInt32("LocationId"));

            //        _mapper.Map(editLocationModel, locationResult);
            //        _locationRepository.Update(locationResult);
            //        EditLocationViewModel locationViewModel = _mapper.Map<EditLocationViewModel>(locationResult);
            //        ViewBag.Message = "Location updated successfully.";
            //        return PartialView("_PartialEditLocation", locationViewModel);
            //    }
            //    else
            //    {
            //        return BadRequest("Please verify the Location Details.");
            //    }

            //}
            //public string SwitchTabs(string tabname)
            //{
            //    var lm = new EditLocationViewModel();
            //    switch (tabname)
            //    {
            //        case "LoyaltyTransaction":
            //            lm.ActiveTab = EditLocationViewModel.Tab.LoyaltyTransaction; break;
            //        case "Batches":
            //            lm.ActiveTab = EditLocationViewModel.Tab.Batches; break;
            //        case "Terminal":
            //            lm.ActiveTab = EditLocationViewModel.Tab.Terminal; break;
            //        case "CurrentTransaction":
            //            lm.ActiveTab = EditLocationViewModel.Tab.CurrentTransaction; break;
            //        case "SupportCalls":
            //            lm.ActiveTab = EditLocationViewModel.Tab.SupportCalls; break;
            //        default:
            //            lm.ActiveTab = EditLocationViewModel.Tab.LoyaltyTransaction; break;


            //    }
            //    TempData["ActiveTab"] = lm.ActiveTab;
            //    return lm.ActiveTab.ToString();
            //}
        }
    }
}
