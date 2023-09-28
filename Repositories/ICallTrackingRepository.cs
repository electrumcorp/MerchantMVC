using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Repositories
{
  public  interface ICallTrackingRepository : IRepository<CallTracking>
    {
        public IEnumerable<CallTrackingViewModel> GetCallTrackingByLocationId(int locationID);
    }
}
