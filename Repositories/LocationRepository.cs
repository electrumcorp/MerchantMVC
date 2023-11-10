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

        public Location GetLocation(int locationId)
        {
            return ebaseDbContext.Locations.Where(x => x.LocationId == locationId).FirstOrDefault();
        }

        public EditLocationViewModel GetLocationViewModel(int locationId)
        {
            EditLocationViewModel location = null;
            location = ebaseDbContext.Locations.Where(c => c.LocationId == locationId & c.CategoryId == 385)
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
                   Brand = c.Brand,
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
                   PosmaintSupportPhone = e.PosmaintSupportPhone,
                   FuelBrand = e.FuelBrand
               }).FirstOrDefault();


            return location;
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
                   Brand = c.Brand,
                   DefaultOriginationDeviceId = e.DefaultOriginationDeviceId,
                   PosmaintSupport = e.PosmaintSupport,
                   PosmaintSupportPhone = e.PosmaintSupportPhone,
                   FuelBrand = e.FuelBrand
               })
               .OrderBy(c => c.MerchantNumber);
               

            return locations;
        }

        public EditLocationViewModel UpdateLocation(EditLocationViewModel viewModel)
        {
            var location = ebaseDbContext.Locations.Where(x => x.LocationId == viewModel.LocationId).FirstOrDefault();
            location.LLname = viewModel.LLname;
            location.LFname = viewModel.LFname;
            location.Brand = viewModel.Brand;
            location.Comments = viewModel.Comments;
            location.DefaultOriginationDeviceId = viewModel.DefaultOriginationDeviceId;
            location.EmailAddr = viewModel.EmailAddr;
            location.LAddr1 = viewModel.LAddr1;
            location.LAddr2 = viewModel.LAddr2;
            location.LCity = viewModel.LCity;
            location.LState = viewModel.LState;
            location.LZip = viewModel.LZip;
            location.MerchantNumber = viewModel.MerchantNumber;
            location.TimeZone = viewModel.TimeZone;
            location.Url = viewModel.Url;
            location.Latitude = viewModel.Latitude;
            location.Longitude = viewModel.Longitude;

            ebaseDbContext.Locations.Update(location);
            ebaseDbContext.SaveChanges();

            var activate = ebaseDbContext.LocationActivates.Where(x => x.LocationId == viewModel.LocationId).FirstOrDefault();
            activate.FuelBrand = viewModel.FuelBrand;
            activate.PosmaintSupport = viewModel.PosmaintSupport;
            activate.PosmaintSupportPhone = viewModel.PosmaintSupportPhone;

            ebaseDbContext.LocationActivates.Update(activate);
            ebaseDbContext.SaveChanges();

            return viewModel;
        }
    }
}
