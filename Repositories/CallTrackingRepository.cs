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

        public List<CallTrackingViewModel> GetCallTrackingByMerchantId(int merchantId)
        {
            List<CallTrackingViewModel> cv = null;

            var callTracking = ebaseDBContext.CallTrackings
               .Join(ebaseDBContext.Categories, c => c.Type, e => e.CategoryId, (c, e) => new CallTrackingViewModel
               {
                   CallTrackingId = c.CallTrackingId,
                   Id = c.Id,
                   EntityCategoryId = c.EntityCategoryId,
                   EmployeeId = c.EmployeeId,
                   Comment = c.Comment,
                   TrackingDateTime = c.DateTime,
                   TrackingType = c.Type,
                   TrackingTypeName = e.CategoryName,
                   PriorityID = c.Priority,
                   StatusID = c.Status,
               })
               .OrderByDescending(o => o.TrackingDateTime).Where(l => l.Id == merchantId).ToList();

            if (callTracking != null)
            {
                if (callTracking.Count > 0)
                {
                    //var entitycategory = callTracking.Take(1).Select(c => c.EntityCategoryId).SingleOrDefault();
                    //var categoryName = ebaseDBContext.Categories.Where(ct => ct.CategoryId == entitycategory.Value).FirstOrDefault();

                    var callT2 = (from cc in callTracking
                                  join c in ebaseDBContext.Categories on cc.PriorityID equals c.CategoryId
                                  select new CallTrackingViewModel
                                  {
                                      CallTrackingId = cc.CallTrackingId,
                                      Id = cc.Id,
                                      EntityCategoryId = cc.EntityCategoryId,
                                      EmployeeId = cc.EmployeeId,
                                      TrackingDateTime = cc.TrackingDateTime,
                                      TrackingDTFormatted = cc.TrackingDTFormatted,
                                      TrackingTypeName = cc.TrackingTypeName,
                                      TrackingType = cc.TrackingType,
                                      PriorityID = cc.PriorityID,
                                      PriorityName = c.CategoryName,
                                      EmployeeName = cc.EmployeeName,
                                      Comment = cc.Comment,
                                      StatusID = cc.StatusID
                                  }
                        ).ToList();

                    var callT3 = (from cc in callT2
                                  join c in ebaseDBContext.Categories on cc.StatusID equals c.CategoryId
                                  select new CallTrackingViewModel
                                  {
                                      CallTrackingId = cc.CallTrackingId,
                                      Id = cc.Id,
                                      EntityCategoryId = cc.EntityCategoryId,
                                      EmployeeId = cc.EmployeeId,
                                      EmployeeName = cc.EmployeeName,
                                      TrackingDateTime = cc.TrackingDateTime,
                                      TrackingTypeName = cc.TrackingTypeName,
                                      TrackingDTFormatted = DateTime.Parse(cc.TrackingDateTime.ToString()).ToShortDateString(),
                                      StatusID = cc.StatusID,
                                      StatusName = c.CategoryName,
                                      Comment = cc.Comment,
                                      PriorityID = cc.PriorityID,
                                      PriorityName = cc.PriorityName
                                  }
                        ).ToList();


                    //var callT4 = (from cc in callT3
                    //              join e in ebaseDBContext.Employees on cc.EmployeeId equals e.EmployeeId 
                    //                into grouping
                    //              from e in grouping.DefaultIfEmpty()
                    //              select new CallTrackingViewModel
                    //              {
                    //                  CallTrackingId = cc.CallTrackingId,
                    //                  Id = cc.Id,
                    //                  EntityCategoryId = cc.EntityCategoryId,
                    //                  EmployeeId = cc.EmployeeId,
                    //                  EmployeeName = String.Format(e.FirstName + ' ' + e.LastName),
                    //                  TrackingDateTime = cc.TrackingDateTime,
                    //                  TrackingType = cc.TrackingType,
                    //                  PriorityID = cc.PriorityID,
                    //                  PriorityName = cc.PriorityName,
                    //                  Comment = cc.Comment,
                    //                  StatusName = cc.StatusName,
                    //                  StatusID = cc.StatusID,
                    //                  TrackingDTFormatted = cc.TrackingDTFormatted
                    //              }
                    //   ).ToList();   

                    cv = callT3.OrderByDescending(p => p.TrackingDateTime).ToList();
                }
            }

            return cv;
        }
    }
}
