using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;


namespace MerchantMVC.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        public IEnumerable<CardViewModel> GetCardsByMerchantId(int merchantId);
    }
}
