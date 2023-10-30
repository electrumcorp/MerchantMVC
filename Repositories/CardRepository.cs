using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<CardViewModel> GetCardsByMerchantId(int merchantId)
        {
            IEnumerable<CardViewModel> cards = null;
            cards = ebaseDbContext.Cards.Where(c => c.ChStatus == "P")
            .Where(c => !string.IsNullOrEmpty(c.Email)).Where(c => c.PrivacyLevel == 330).Where(c => c.CommunicationsDeliveryCategoryId == 902)
            .Where(c => c.LastTransDate > DateTime.Now.AddYears(-1))
            .Join(ebaseDbContext.Locations, c => c.LocationId, e => e.LocationId, (c, e) => new CardViewModel
            {
                CardId = c.CardId,
                ChFname = c.ChFname,
                ChLname = c.ChLname,
                ChHaddr1 = c.ChHaddr1,
                ChHcity = c.ChHcity,
                ChHstate = c.ChHstate,
                ChHzip = c.ChHzip,
                ChMphone = c.ChMphone,
                AccountNumber = c.AccountNumber,
                DateOfBirth = c.DateOfBirth,
                Email = c.Email,
                Gender = c.Gender,
                LocationId = c.LocationId,
                MerchantId = c.MerchantId
            })
            .Where(e => e.MerchantId == merchantId)
            .AsNoTracking()
            .OrderByDescending(c => c.AccountNumber).ToList();

            return cards;
        }

        public IEnumerable<CardExportViewModel> GetCardExportsByMerchantId(int merchantId)
        {
            IEnumerable<CardExportViewModel> cards = null;
            cards = ebaseDbContext.Cards.Where(c => c.MerchantId == merchantId).Where(c => c.ChStatus == "P")
            .Where(c => !string.IsNullOrEmpty(c.Email)).Where(c => c.PrivacyLevel == 330).Where(c => c.CommunicationsDeliveryCategoryId == 902)
            .Where(c => c.LastTransDate > DateTime.Now.AddYears(-1))
            .Join(ebaseDbContext.Locations, c => c.EnrollmentLocationId, e => e.LocationId, (c, e) => new CardExportViewModel
            {
                CardId = c.CardId,
                ChFname = c.ChFname,
                ChLname = c.ChLname,
                ChHaddr1 = c.ChHaddr1,
                ChHcity = c.ChHcity,
                ChHstate = c.ChHstate,
                ChHzip = c.ChHzip,
                ChMphone = c.ChMphone,
                AccountNumber = c.AccountNumber,
                DateOfBirth = c.DateOfBirth,
                Email = c.Email,
                Gender = c.Gender
            })
            .AsNoTracking()
            .OrderByDescending(c => c.AccountNumber).ToList();

            return cards;
        }
    }
}
