
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;

namespace MerchantMVC.Repositories
{
    public class MerchantProfileRepository : Repository<MerchantProfile>, IMerchantProfileRepository
    {
        private readonly EbaseDBContext ebaseDbContext;
        public MerchantProfileRepository(EbaseDBContext _ebaseDbContext) : base(_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }
    }
}

