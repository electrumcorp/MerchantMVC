using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchantMVC.Repositories
{
    public class TimezoneRepository
    {
        public IEnumerable<SelectListItem> GetTimezones()
        {
            List<SelectListItem> timezones = new List<SelectListItem>();
            timezones.Add(new SelectListItem()
            {
                Value = "-5",
                Text = "EST - Eastern"
            }); 
            timezones.Add(new SelectListItem()
            {
                Value = "-6",
                Text = "CST - Central"
            }); 
            timezones.Add(new SelectListItem()
            {
                Value = "-7",
                Text = "MST - Mountain"
            });
            timezones.Add(new SelectListItem()
            {
                Value = "-8",
                Text = "PST - Pacific"
            });

            return timezones;
        }

        //public IEnumerable<Category> GetCategoryForPriorityByCategoryId()
        //{
        //    var categoryPriority = ebaseContext.Categories.Where(ct => ct.CategoryId == 115 || ct.CategoryId == 117);
        //    return (IEnumerable<Category>)categoryPriority;
        //}

        //public IEnumerable<Category> GetCategoryForStatus(int typeid)
        //{
        //    var categoryStatus = ebaseContext.Categories.Where(ct => ct.CategoryId == 115 || ct.CategoryId == 117);
        //    return (IEnumerable<Category>)categoryStatus;
        //}
    }
}
