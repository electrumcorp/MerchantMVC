using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;

namespace MerchantMVC.Repositories
{
   public interface ILoyaltyTranRepository :IRepository<LoyaltyTransactionTEc>
    {
        LoyaltyTranViewModel GetLoyaltyTransactionByLocationID(int id,int locationid);
        IEnumerable<LoyaltyTranViewModel> GetAllLoyaltyTransactionByLocationID(int locationID);
    }
}
