using AutoMapper;
using MerchantMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;

namespace MerchantMVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPriority(string searchTerm)
        {           
            List<Category> lstCs = new List<Category>();
            var lstC = _categoryRepository.GetCategoryForPriorityByCategoryId().ToList();
            lstC = lstC.Where(c => c.CategoryId != 171).ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
               // lstC= from c in lstCs
            }

            var jsonData = lstC.Select(x => new { id = x.CategoryId, text = x.CategoryName });
            return Json(jsonData);
        }

        [HttpGet]
        public JsonResult GetStatus()
        {
            var lstStatus = _categoryRepository.GetCategoryByTypeId(26).ToList();

            var json = lstStatus.Select(x => new { id = x.CategoryId, text = x.CategoryName });

            return Json(json);
        }

        [HttpGet]
        public JsonResult GetCategoryType(string searchTerm)
        {
            List<Category> lstCs = new List<Category>();
            List<Category> lstCSearch = new List<Category>();

            lstCs = _categoryRepository.GetCategoryByTypeId(28).ToList();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                lstCSearch = (from c in lstCs
                              where c.CategoryName.ToLower().Contains(searchTerm)
                              select c).ToList();
                       //.Select(x=>  x.CategoryId,  x=>x.CategoryName }).ToList();
            }
            else
            {
                lstCSearch = lstCs;
            }

            var jsonData = lstCSearch.Select(x => new { id = x.CategoryId, text = x.CategoryName });

            return Json(jsonData);
        }
    }
}
