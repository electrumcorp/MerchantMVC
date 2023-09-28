using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;

namespace MerchantMVC.Repositories
{
    public class FeedbackRepository : Repository<FeedBack>, IFeedBackRepository
    {
        private readonly EbaseDBContext ebaseDbContext;
        public FeedbackRepository(EbaseDBContext _ebaseDbContext) : base(_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }

        public IEnumerable<FeedBack> GetFeedBackByMerchantId(int merchantId)
        {
            IEnumerable<FeedBack> feedBacks = null;
            feedBacks = ebaseDbContext.FeedBacks.Where(c => c.RespondentId == merchantId && c.StatusCategoryId == 185).ToList();


            //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
            //{
            //    CategoryName=ce.CategoryName
            //})
            //.OrderByDescending(o => o.MerchantNumber).ToList();

            return feedBacks;
        }
    }
}
