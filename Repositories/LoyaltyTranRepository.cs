using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MerchantMVC.Repositories
{
    public class LoyaltyTranRepository : Repository<LoyaltyTransactionTEc>, ILoyaltyTranRepository
    {
        private EbaseDBContext ebaseDbContext;
        public LoyaltyTranRepository(EbaseDBContext ebaseDB) : base(ebaseDB)
        {
            ebaseDbContext = ebaseDB;

        }
        public LoyaltyTranViewModel GetLoyaltyTransactionByLocationID(int id,int locationid)
        {

            LoyaltyTranViewModel loyaltrans = ebaseDbContext.LoyaltyTransactionTEcs.Where(lt=>lt.LoyaltyTransactionId==id).Include(f => f.Card).Where(l => l.LocationId ==locationid).Where(lt => lt.UpdatedDate > DateTime.Now.AddDays(-91))
                .Join(ebaseDbContext.Categories, lt => lt.CategoryId, ct => ct.CategoryId, (lt, ct) =>
                      new LoyaltyTranViewModel
                      {
                          Amount = lt.Amount,
                          LoyaltyTransactionId = lt.LoyaltyTransactionId,
                          UpdatedDate = lt.UpdatedDate,
                          ItemId=lt.ItemId,
                          Item = lt.Item,
                          Discount = lt.Discount,
                          Quantity = lt.Quantity,
                          CategoryName = ct.CategoryName,
                          CardName = string.Concat(lt.Card.ChFname, " ", lt.Card.ChLname, " ", lt.Card.ChMphone, " ", lt.Card.AccountNumber),
                          LocationId = lt.LocationId,
                          UpdatedDateFormatted = DateTime.Parse(lt.UpdatedDate.ToString()).ToString("MM/dd/yyyy")
                      })
                 .SingleOrDefault();

            return loyaltrans;

        }

        public  IEnumerable<LoyaltyTranViewModel> GetAllLoyaltyTransactionByLocationID(int locationID)
        {
            var loyaltrans = ebaseDbContext.LoyaltyTransactionTEcs.Include(f => f.Card).Where(l => l.LocationId == locationID)
            .Where(lt => lt.UpdatedDate > DateTime.Now.AddDays(-91))
                .Join(ebaseDbContext.Categories, lt => lt.CategoryId, ct => ct.CategoryId, (lt, ct) =>
                      new LoyaltyTranViewModel
                      {
                          Amount = lt.Amount,
                          LoyaltyTransactionId = lt.LoyaltyTransactionId,
                          UpdatedDate = lt.UpdatedDate,
                          Item = lt.Item,
                          Discount = lt.Discount,
                          Quantity = lt.Quantity,
                          CategoryName = ct.CategoryName,
                          CardName = string.Concat(lt.Card.ChFname, " ", lt.Card.ChLname, " ", lt.Card.ChMphone, " ", lt.Card.AccountNumber),
                          LocationId = lt.LocationId,
                          UpdatedDateFormatted =  DateTime.Parse(lt.UpdatedDate.ToString()).ToString("MM/dd/yyyy")
                      })                    
                .OrderByDescending(r=>r.UpdatedDate)
                .AsNoTracking()
                .ToList();

            return (IEnumerable<LoyaltyTranViewModel>) loyaltrans;
           
        }

    }
}
