//using MerchantMVC.Models;
//using MerchantMVC.Repositories.Base;
//using MerchantMVC.ViewModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MerchantMVC.Repositories
//{
//    public class EDataConfigurationRepository : Repository<EdataConfiguration>, IEdataConfigurationRepository
//    {
//        private readonly EdataDbContext edataDbContext;

//        public EDataConfigurationRepository(EdataDbContext _edataDbContext) : base(_edataDbContext)
//        {
//            edataDbContext = _edataDbContext;
//        }

//        //public IEnumerable<EditLocationViewModel> GetLocationsByMerchantId(int merchantId)
//        //{
//        //    IEnumerable<EditLocationViewModel> locations = null;
//        //    locations = ebaseDbContext.Locations.Where(c => c.MerchantId == merchantId).Where(c => c.CategoryId == 385)
//        //       .Join(ebaseDbContext.LocationProfiles, c => c.LocationId, e => e.LocationId, (c, e) => new EditLocationViewModel
//        //       {
//        //           LocationId = c.LocationId,
//        //           LName = c.LName,
//        //           LAddr1 = c.LAddr1,
//        //           LAddr2 = c.LAddr2,
//        //           LCity = c.LCity,
//        //           LState = c.LState,
//        //           LZip = c.LZip,
//        //           LPhone = c.LPhone,
//        //           EmailAddr = c.EmailAddr,
//        //           LFname = c.LFname,
//        //           LLname = c.LLname,
//        //           LocationStatus = c.LocationStatus,
//        //           Fax = c.Fax,
//        //           Url = c.Url,
//        //           TimeZone = c.TimeZone,
//        //           Comments = c.Comments,
//        //           EntityCategoryId = c.EntityCategoryId,
//        //           MerchantNumber = c.MerchantNumber

//        //       });

//        //       //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
//        //       //{
//        //       //    CategoryName=ce.CategoryName
//        //       //})
//        //       //.OrderByDescending(o => o.MerchantNumber).ToList();

//        //    return locations;
//        //}


//        //public Task Add(Location entity)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public async Task<Location> Get(int id)
//        //{
//        //    return await ebaseDbContext.Locations.FindAsync(12);
//        //}

//        //public Task<IEnumerable<Location>> GetAll()
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public void Remove(Location entity)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public void Update(Location entity)
//        //{
//        //    throw new NotImplementedException();
//        //}



//        //Task IRepository<Location>.Add(Location entity)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //Task<Location> IRepository<Location>.Get(int id)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //Task<IEnumerable<Location>> IRepository<Location>.GetAll()
//        //{
//        //    throw new NotImplementedException();
//        //}
//    }
//}
