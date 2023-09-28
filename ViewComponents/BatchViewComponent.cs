using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace MerchantMVC.ViewComponents
{
    public class BatchViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
