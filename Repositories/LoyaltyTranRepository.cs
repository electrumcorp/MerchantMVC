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

            LoyaltyTranViewModel loyaltrans = ebaseDbContext.LoyaltyTransactionTEcs.Where(lt=>lt.LoyaltyTransactionId==id).Include(f => f.Card).Where(l => l.LocationId ==locationid)
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
                          CardName = string.Concat(lt.Card.ChFname, " ", lt.Card.ChLname),
                          LocationId = lt.LocationId,
                          UpdatedDateFormatted = DateTime.Parse(lt.UpdatedDate.ToString()).ToString("MM/dd/yyyy")
                      })
                 .SingleOrDefault();
            //.Join()ToList();
            //join c in ebaseDbContext.Cards on lt.CardId equals c.CardId
            //join ct in ebaseDbContext.Categories on lt.CategoryId equals ct.CategoryId
            //select new LoyaltyTranViewModel
            //{
            //    Amount = lt.Amount,
            //    LoyaltyTransactionId = lt.LoyaltyTransactionId,
            //    UpdatedDate = lt.UpdatedDate,
            //    Item = lt.Item,
            //    Discount = lt.Discount,
            //    Quantity = lt.Quantity,
            //    //CategoryName = ct.CategoryName,
            //    // CardName = c.ChFname,
            //    LocationId = lt.LocationId

            //}).


            //var    loyaltrans= ebaseDbContext.LoyaltyTransactionTEcs.Join(ebaseDbContext.Cards,lt=>lt.CardId,c=>c.CardId, (lt,c)=> new LoyaltyTranViewModel
            //    {
            //        Amount = lt.Amount,
            //        LoyaltyTransactionId = lt.LoyaltyTransactionId,
            //        UpdatedDate = lt.UpdatedDate,
            //        Item = lt.Item,
            //        Discount = lt.Discount,
            //        Quantity = lt.Quantity,
            //        //CategoryName = ct.CategoryName,
            //         CardName = c.ChFname,
            //        LocationId = lt.LocationId
            //    }).Where(l => l.LocationId == locationID).OrderByDescending(l => l.UpdatedDate)
            //                    .ToList();
            // ebaseDbContext.inc
            //  var loyaltrans= ebaseDbContext.LoyaltyTransactionTEcs.Where(l => l.LocationId == locationID).ToList();//.Join(l=>l.cat)inToList();


            return loyaltrans;

        }

        public  IEnumerable<LoyaltyTranViewModel> GetAllLoyaltyTransactionByLocationID(int locationID)
        {

            var loyaltrans = ebaseDbContext.LoyaltyTransactionTEcs.Include(f => f.Card).Where(l => l.LocationId == locationID)
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
                          CardName = string.Concat(lt.Card.ChFname, " ", lt.Card.ChLname),
                          LocationId = lt.LocationId,
                          UpdatedDateFormatted =  DateTime.Parse(lt.UpdatedDate.ToString()).ToString("MM/dd/yyyy")
                      }).OrderByDescending(r=>r.UpdatedDate)
                 .ToList();
                              //.Join()ToList();
            //join c in ebaseDbContext.Cards on lt.CardId equals c.CardId
            //join ct in ebaseDbContext.Categories on lt.CategoryId equals ct.CategoryId
            //select new LoyaltyTranViewModel
            //{
            //    Amount = lt.Amount,
            //    LoyaltyTransactionId = lt.LoyaltyTransactionId,
            //    UpdatedDate = lt.UpdatedDate,
            //    Item = lt.Item,
            //    Discount = lt.Discount,
            //    Quantity = lt.Quantity,
            //    //CategoryName = ct.CategoryName,
            //    // CardName = c.ChFname,
            //    LocationId = lt.LocationId

            //}).
            

            //var    loyaltrans= ebaseDbContext.LoyaltyTransactionTEcs.Join(ebaseDbContext.Cards,lt=>lt.CardId,c=>c.CardId, (lt,c)=> new LoyaltyTranViewModel
            //    {
            //        Amount = lt.Amount,
            //        LoyaltyTransactionId = lt.LoyaltyTransactionId,
            //        UpdatedDate = lt.UpdatedDate,
            //        Item = lt.Item,
            //        Discount = lt.Discount,
            //        Quantity = lt.Quantity,
            //        //CategoryName = ct.CategoryName,
            //         CardName = c.ChFname,
            //        LocationId = lt.LocationId
            //    }).Where(l => l.LocationId == locationID).OrderByDescending(l => l.UpdatedDate)
            //                    .ToList();
            // ebaseDbContext.inc
            //  var loyaltrans= ebaseDbContext.LoyaltyTransactionTEcs.Where(l => l.LocationId == locationID).ToList();//.Join(l=>l.cat)inToList();


            return (IEnumerable<LoyaltyTranViewModel>) loyaltrans;
           
        }

    }
}
