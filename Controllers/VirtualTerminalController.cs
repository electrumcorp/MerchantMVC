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
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MerchantMVC.Controllers
{
    public class VirtualTerminalController : Controller
    {
        private IVirtualTerminalRepository _virtualTerminalRepository;
        
        public VirtualTerminalController(IVirtualTerminalRepository virtualTerminalRepository)
        {
            _virtualTerminalRepository = virtualTerminalRepository;
        }
        public ActionResult Index()
        {
            //using (EbaseDBContext dBContext = new EbaseDBContext())
            //{
            //    var tranCodeRepo = new TerminalTranCodeRepository(dBContext);
            //    var tranCodeList = tranCodeRepo.GetTerminalTranCodes();
            //    var cardTypeRepo = new TerminalCardTypeRepository(dBContext);
            //}

            var vm = _virtualTerminalRepository.CreateVirtualTerminal((int)HttpContext.Session.GetInt32("MerchantId"));

            return View(vm);
        }

        [HttpPost]
        public ActionResult Submit(VirtualTerminalViewModel viewModel)
        {
            
            return View();
        }

        [HttpGet]
        public JsonResult GetTerminals(int locationID)
        {
                var terminals = _virtualTerminalRepository.GetTerminals(locationID).ToList();
                var json = terminals.Select(x => new { id = x.Terminal30Id, text = x.TermDescrip });

                return Json(json);
        }

        [HttpGet]
        public JsonResult GetCardTypes(int terminalID)
        {
            var cardtypes = _virtualTerminalRepository.GetCardTypes(terminalID).ToList();
            var json = cardtypes.Select(x => new { id = x.CardTypeId, text = x.CardTypeName });

            return Json(json);
        }
    }
}
