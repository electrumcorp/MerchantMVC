using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;

namespace MerchantMVC.Repositories
{
    public class LocationProfileRepository : Repository<LocationProfile>, ILocationProfileRepository
    {
        private readonly EbaseDBContext ebaseDbContext;
        public LocationProfileRepository(EbaseDBContext _ebaseDbContext) : base(_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }
    }
}
