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

        [HttpGet]
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
        public IActionResult Index(MainViewModel inputFeedBack)
        {
            MainViewModel vm = new MainViewModel();
            vm.MerchantID = (int)HttpContext.Session.GetInt32("MerchantId");

            List<FeedBackViewModel> updated = new List<FeedBackViewModel>();

            try
            {
                foreach (var input in inputFeedBack.Feedback)
                {
                    var item = _mapper.Map<FeedBack>(input);
                    var update = _repository.UpdateFeedback(item);
                    var updateVM = _mapper.Map<FeedBackViewModel>(update);
                    updated.Add(updateVM);
                }
                vm.Feedback = updated;

                ViewBag.Message = "Feedback questions updated successfully.";
                return PartialView("_PartialEditFeedback", vm);
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return PartialView("_PartialEditFeedback", vm);
        }
    }
}
