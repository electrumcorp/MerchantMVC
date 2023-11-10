using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;

namespace MerchantMVC.Repositories
{
    public interface IFeedBackRepository : IRepository<FeedBack>
    {        
        public IEnumerable<FeedBack> GetFeedBackByMerchantId(int merchantId);
        public FeedBack UpdateFeedback(FeedBack feedBack);
    }
}
