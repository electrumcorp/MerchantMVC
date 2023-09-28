using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Repositories
{
    public class CallTrackingRepository :Repository<CallTracking>, ICallTrackingRepository
    {
        private readonly EbaseDBContext ebaseDBContext;
        public CallTrackingRepository(EbaseDBContext _ebaseContext):base(_ebaseContext)
        {
            ebaseDBContext = _ebaseContext;
        }

        public IEnumerable<CallTrackingViewModel> GetCallTrackingByLocationId(int locationId)
        {
            IEnumerable<CallTrackingViewModel> cv = null;
             var callTracking = ebaseDBContext.CallTrackings
                .Join(ebaseDBContext.Employees, c => c.EmployeeId, e => e.EmployeeId, (c, e) => new CallTrackingViewModel
            {
                CallTrackingId = c.CallTrackingId,
                Id = c.Id,
                EntityCategoryId = c.EntityCategoryId,
        EmployeeId =c.EmployeeId,
        TrackingDateTime =c.DateTime,
        TrackingType=c.Type,
     PriorityID=c.Priority,
     EmployeeName=string.Concat(e.FirstName," ",e.LastName),
         Comment =c.Comment
        
    })
                //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
                //{
                //    CategoryName=ce.CategoryName
                //})
                .OrderByDescending(o=>o.TrackingDateTime).Where(l => l.Id == locationId).ToList();
            if (callTracking != null)
            {
                if (callTracking.Count > 0)
                {
                    var entitycategory = callTracking.Take(1).Select(c => c.EntityCategoryId).SingleOrDefault();

                    var categoryName = ebaseDBContext.Categories.Where(ct => ct.CategoryId == entitycategory.Value).FirstOrDefault();
                    var callT2 = (from cc in callTracking
                                  join c in ebaseDBContext.Categories on cc.PriorityID equals c.CategoryId
                                  //join ct in ebaseDbContext.Categories on lt.CategoryId equals ct.CategoryId
                                  select new CallTrackingViewModel
                                  // .Join(ebaseDBContext.Categories, c => c.EntityCategoryId, ctg => ctg.CategoryId, (c, ctg) => new CallTrackingViewModel
                                  {
                                      CallTrackingId = cc.CallTrackingId,
                                      Id = cc.Id,
                                      EntityCategoryId = cc.EntityCategoryId,
                                      EmployeeId = cc.EmployeeId,
                                      TrackingDateTime = cc.TrackingDateTime,
                                      TrackingType = cc.TrackingType,
                                      PriorityName = c.CategoryName,
                                      EmployeeName = cc.EmployeeName,
                                      Comment = cc.Comment,
                                      StatusName = c.CategoryName,
                                      CategoryName = categoryName.CategoryName
                                  }
                        //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
                        //{
                        //    CategoryName=ce.CategoryName
                        //})
                        ).OrderByDescending(p => p.TrackingDateTime).ToList();
                    var callT3 = (from cc in callT2
                                  join c in ebaseDBContext.Categories on cc.TrackingType equals c.CategoryId
                                  //join ct in ebaseDbContext.Categories on lt.CategoryId equals ct.CategoryId
                                  select new CallTrackingViewModel
                                  // .Join(ebaseDBContext.Categories, c => c.EntityCategoryId, ctg => ctg.CategoryId, (c, ctg) => new CallTrackingViewModel
                                  {
                                      CallTrackingId = cc.CallTrackingId,
                                      Id = cc.Id,
                                      EntityCategoryId = cc.EntityCategoryId,
                                      EmployeeId = cc.EmployeeId,
                                      TrackingDateTime = cc.TrackingDateTime,
                                      TrackingTypeName = c.CategoryName,
                                      PriorityName = cc.PriorityName,
                                      EmployeeName = cc.EmployeeName,
                                      Comment = cc.Comment,
                                      StatusName = cc.StatusName,
                                      CategoryName = categoryName.CategoryName,
                                      TrackingDTFormatted=DateTime.Parse(cc.TrackingDateTime.ToString()).ToString("MM/dd/yyyy")
                                  }
                       //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
                       //{
                       //    CategoryName=ce.CategoryName
                       //})
                       ).OrderByDescending(p => p.TrackingDateTime.Value.Date).ThenByDescending(p=>p.TrackingDateTime.Value.TimeOfDay).ToList();
                    cv = callT3;
                }
            }

            return cv;
        }
    }
}
