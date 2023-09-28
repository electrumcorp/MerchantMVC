using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;

namespace MerchantMVC.Repositories
{
    public interface IFeedBackRepository : IRepository<FeedBack>
    {        public IEnumerable<FeedBack> GetFeedBackByMerchantId(int merchantId);
    }
}
