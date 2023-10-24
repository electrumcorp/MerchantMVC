using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using CsvHelper;
using System.Text;
using CsvHelper.Configuration;

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
        public IActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewData["AccountNumberSortParam"] = string.IsNullOrEmpty(sortOrder) ? "AccountNumber" : "";

            IEnumerable<CardViewModel> cards = _cardRepository.GetCardsByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));

            switch (sortOrder)
            {
                case "AccountNumber":
                    cards = cards.OrderByDescending(l => l.AccountNumber);
                    break;
                default:
                    cards = cards.OrderBy(l => l.AccountNumber);
                    break;
            }

            var pageNumber = page ?? 1;
            var onePageOfCards = cards.ToPagedList(pageNumber, 25);

            ViewBag.OnePageOfCards = onePageOfCards;
            return View();
        }

        [HttpGet]
        public ActionResult ExportCardsToCsv()
        {
            var response = _cardRepository.GetCardExportsByMerchantId((int)HttpContext.Session.GetInt32("MerchantId"));
            List<CardExportViewModel> cards = response.ToList();

            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            var memoryStream = new MemoryStream();
      
            using (var streamWriter = new StreamWriter(memoryStream, encoding: new UTF8Encoding(true)))
            {                    
                using (var csvWriter = new CsvWriter(streamWriter, cc))
                {
                    csvWriter.WriteRecords(cards);
                    streamWriter.Flush();
                    return File(memoryStream.ToArray(), "text/csv", String.Format("MerchantCardHolders_{0}.csv", DateTime.Now.ToString()));
                }
            }
        }
    }
}
