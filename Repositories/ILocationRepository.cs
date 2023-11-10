using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;

namespace MerchantMVC.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        public Location GetLocation(int locationId);
        public EditLocationViewModel GetLocationViewModel(int locationId);
        public IEnumerable<EditLocationViewModel> GetLocationsByMerchantId(int merchantId);
        public EditLocationViewModel UpdateLocation(EditLocationViewModel viewModel);
    }
}
