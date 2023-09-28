using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories;
using Microsoft.AspNetCore.Http;

namespace MerchantMVC.Controllers
{
    public class BatchController : Controller
    {
        private IBatchRepository _batchRepository = null;

        public BatchController(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBatchByLocationId()
        {
            int locationId = (int)HttpContext.Session.GetInt32("LocationId");
            var btchList = _batchRepository.GetBatchByLocationId(locationId);
            return new JsonResult(btchList);

        }
    }
}
