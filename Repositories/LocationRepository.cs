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
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly EbaseDBContext ebaseDbContext;

        public LocationRepository(EbaseDBContext _ebaseDbContext):base (_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }
        public IEnumerable<EditLocationViewModel> GetLocationsByMerchantId(int merchantId)
        {
            IEnumerable<EditLocationViewModel> locations = null;
            locations = ebaseDbContext.Locations.Where(c => c.MerchantId == merchantId & c.CategoryId == 385)
               .Join(ebaseDbContext.LocationActivates, c => c.LocationId, e => e.LocationId, (c, e) => new EditLocationViewModel
               {
                   LocationId = c.LocationId,
                   LName = c.LName,
                   LAddr1 = c.LAddr1,
                   LAddr2 = c.LAddr2,
                   LCity = c.LCity,
                   LState = c.LState,
                   LZip = c.LZip,
                   LPhone = c.LPhone,
                   EmailAddr = c.EmailAddr,
                   LFname = c.LFname,
                   LLname = c.LLname,
                   LocationStatus = c.LocationStatus,
                   Fax = c.Fax,
                   Url = c.Url,
                   TimeZone = c.TimeZone,
                   Comments = c.Comments,
                   EntityCategoryId = c.EntityCategoryId,
                   MerchantNumber = c.MerchantNumber,
                   Longitude = c.Longitude,
                   Latitude = c.Latitude,
                   DefaultOriginationDeviceId = e.DefaultOriginationDeviceId,
                   PosmaintSupport = e.PosmaintSupport,
                   PosmaintSupportPhone = e.PosmaintSupportPhone
               })
               .OrderBy(c => c.MerchantNumber);
               
               //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
               //{
               //    CategoryName=ce.CategoryName
               //})
               //.OrderByDescending(o => o.MerchantNumber).ToList();
               

            return locations;
        }
    }
}
