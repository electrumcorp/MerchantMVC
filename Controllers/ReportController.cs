using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
namespace MerchantMVC.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult ShowReport()
        {
            string url = string.Empty;
                if (User.Identity.IsAuthenticated)
                {
                url = "https://electrumcorporation.com/webreportviewer/reportlist.aspx?EntityCategoryID=";// clmData = 3823 & site = Location"
                    var uc = User.Identity as System.Security.Claims.ClaimsIdentity;
                    if (uc != null)
                    {
                        var clmName = uc.FindFirst(ClaimTypes.Name).Value;
                        var clmData = uc.FindFirst(ClaimTypes.UserData).Value;
                    url = url + clmData.ToString().Split("|")[0];
                    url = url + "&EntityId=" + clmData.ToString().Split("|")[2] + "&site=" + clmData.ToString().Split("|")[1];
                    }
                    var uname = User.Claims.Select(p => p.Type == "Name");
                }
            //view-source:https://electrumcorporation.com/webreportviewer/reportlist.aspx?EntityCategoryID=57&EntityID=200023738&site=Merchant
            ViewBag.Url = url;
            
            return View();
        }

        //[HttpGet]
        //public ActionResult GetViewbagUrl(int id)
        //{
        //    ViewBag.Url = "https://electrumcorporation.com/webreportviewer/ViewReport.aspx?ID=" + id;
        //    return "";
        //}
    }
}
    