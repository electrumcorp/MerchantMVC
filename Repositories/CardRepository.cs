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
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly EbaseDBContext ebaseDbContext;
        private IMapper mapper;

        public CardRepository(EbaseDBContext _ebaseDbContext) : base(_ebaseDbContext)
        {
            ebaseDbContext = _ebaseDbContext;
        }
        public IEnumerable<Card> GetCardsByMerchantId(int merchantId)
        {
            IEnumerable<Card> cards = null;
            cards = ebaseDbContext.Cards.Where(c => c.MerchantId == merchantId).OrderBy(c => c.CardId).ToList();


            //.Join(ebaseDBContext.Categories,ct=>ct.EntityCategoryId,ce=>ce.CategoryId,(ct,ce)=>new CallTrackingViewModel
            //{
            //    CategoryName=ce.CategoryName
            //})
            //.OrderByDescending(o => o.MerchantNumber).ToList();

            return cards;
        }
    }
}
