﻿using AutoMapper;
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
        }
    }
}
