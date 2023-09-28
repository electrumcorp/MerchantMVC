using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private readonly EbaseDBContext ebaseDbContext;
        private IMapper mapper;

        public TerminalRepository(EbaseDBContext _ebaseDbContext) : base(_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }
        public IEnumerable<Terminal> GetTerminalsByMerchantId(int merchantId)
        {
            IEnumerable<Terminal> terminals = null;
            terminals = ebaseDbContext.Terminals.Where(c => c.MerchantId == merchantId).OrderBy(c => c.Terminal30Id).ToList();


            //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
            //{
            //    CategoryName=ce.CategoryName
            //})
            //.OrderByDescending(o => o.MerchantNumber).ToList();

            return terminals;
        }
    }
}
