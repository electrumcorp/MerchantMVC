using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MerchantMVC.Repositories;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace MerchantMVC.Controllers
{
    public class AccountController : Controller
    {
        private IPermissionRepository _permissionRepository = null;
        public AccountController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            UserLoginModel userM = new UserLoginModel();
            return View(userM);
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginModel userModel)
        {
            ViewBag.Message = null;
            if (ModelState.IsValid)
            {
                var userVal = _permissionRepository.AuthenticateUser(userModel.username, userModel.password);
                if(userVal!=null && userVal.IsValidUser)
                {
                    //HttpContext.Session.SetInt32("LocationId", userVal.LocationID);
                    HttpContext.Session.SetInt32("MerchantId", userVal.Id);
                    HttpContext.Session.SetString("EmployeeName", userVal.FullName != null ? userVal.FullName : "");
                    HttpContext.Session.SetInt32("EmployeeId", userVal.EmployeeId);
                    HttpContext.Session.SetInt32("CategoryId", userVal.CategoryId);


                    var identity = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,userVal.FullName!=null?userVal.FullName:"[No Name]"),
                        new Claim(ClaimTypes.Locality,userVal.Id.ToString()),
                        new Claim(ClaimTypes.UserData,string.Concat(userVal.CategoryId.ToString(),"|",userVal.CategoryName.Trim(),"|",userVal.Id)),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                        //  var identity =new  ClaimsIdentity();
                        //
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        //return RedirectToAction("ShowReport", "Report");
                         return RedirectToAction("Edit", "Merchant");
                        //return RedirectToAction("AddSupportCall", "CallTracking");
                    
                }

                else
                {
                    ViewBag.Message = "Invalid Credentials.";
                   // ModelState.Clear();
                    userModel = null;
                    return View("Login", userModel);
                }
            }
            else
            {
                ViewBag.Message = "Please provide username and password.";
               // ModelState.Clear();
            }
           
            return View("Login", userModel);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
