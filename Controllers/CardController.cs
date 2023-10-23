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
    public class CardController : Controller
    {
        private ICardRepository _cardRepository;
        private IMapper _mapper;

        public CardController(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["LNameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "LName" : "";
            ViewData["AccountNumberSortParam"] = string.IsNullOrEmpty(sortOrder) ? "AccountNumber" : "";

            IEnumerable<Card> cards = _cardRepository.GetCardsByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));

            if (!String.IsNullOrEmpty(searchString))
            {
                cards = cards.Where(x => x.ChLname.ToUpper().Contains(searchString.ToUpper()) || x.ChFname.ToUpper().Contains(searchString.ToUpper()) || x.AccountNumber.Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "LName":
                    cards = cards.OrderByDescending(l => l.ChLname);
                    break;
                case "AccountNumber":
                    cards = cards.OrderByDescending(l => l.AccountNumber);
                    break;
                default:
                    cards = cards.OrderBy(l => l.ChLname);
                    break;
            }
            return View(cards);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
    }
}
