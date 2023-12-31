﻿using MerchantMVC.Models;
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
                        Priority=c.Priority,
                        EmployeeName=string.Concat(e.FirstName," ",e.LastName),
                        Comment =c.Comment
        
                })
                .OrderByDescending(o=>o.TrackingDateTime).Where(l => l.Id == locationId).ToList();

            if (callTracking != null)
            {
                if (callTracking.Count > 0)
                {
                    var entitycategory = callTracking.Take(1).Select(c => c.EntityCategoryId).SingleOrDefault();

                    var categoryName = ebaseDBContext.Categories.Where(ct => ct.CategoryId == entitycategory.Value).FirstOrDefault();
                    var callT2 = (from cc in callTracking
                                  join c in ebaseDBContext.Categories on cc.Priority equals c.CategoryId
                                  select new CallTrackingViewModel
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
                        ).OrderByDescending(p => p.TrackingDateTime).ToList();
                    var callT3 = (from cc in callT2
                                  join c in ebaseDBContext.Categories on cc.TrackingType equals c.CategoryId
                                  select new CallTrackingViewModel
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
                   Priority = c.Priority,
                   Status = c.Status,
               })
               .OrderByDescending(o => o.TrackingDateTime).Where(l => l.Id == merchantId).ToList();

            if (callTracking != null)
            {
                if (callTracking.Count > 0)
                {
                    var callT2 = (from cc in callTracking
                                  join c in ebaseDBContext.Categories on cc.Priority equals c.CategoryId
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
                                      Priority = cc.Priority,
                                      PriorityName = c.CategoryName,
                                      EmployeeName = cc.EmployeeName,
                                      Comment = cc.Comment,
                                      Status = cc.Status
                                  }
                        ).ToList();

                    var callT3 = (from cc in callT2
                                  join c in ebaseDBContext.Categories on cc.Status equals c.CategoryId
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
                                      Status = cc.Status,
                                      StatusName = c.CategoryName,
                                      Comment = cc.Comment,
                                      Priority = cc.Priority,
                                      PriorityName = cc.PriorityName
                                  }
                        ).ToList();


                    cv = callT3.OrderByDescending(p => p.TrackingDateTime).ToList();
                }
            }

            return cv;
        }
    }
}
