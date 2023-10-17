using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MerchantMVC.Repositories
{
    public class EntityDocumentMerchantRepository : Repository<EntityDocumentMerchantViewModel>, IEntityDocumentMerchantRepository
    {
        private readonly EbaseDBContext ebaseDBContext = null;


        public EntityDocumentMerchantRepository(EbaseDBContext context) : base(context)
        { 
            ebaseDBContext = context;
        }

        public List<EntityDocumentMerchantViewModel> GetDocuments()
        {
            var list = new List<EntityDocumentMerchantViewModel>();
            var documents = ebaseDBContext.EntityDocumentMerchants.ToList();

            foreach (var doc in documents)
            {
                var vm = new EntityDocumentMerchantViewModel()
                {
                    DocumentsId = doc.DocumentsId,
                    Title = doc.Title,
                    CategoryName = doc.CategoryName
                };

                if (!String.IsNullOrEmpty(doc.VideoUrl))
                {
                    vm.DocumentUrl = doc.VideoUrl;
                }
                
                if (!string.IsNullOrEmpty(doc.CloudStorageUrl))
                {
                    vm.DocumentUrl = doc.CloudStorageUrl;
                }

                if (!String.IsNullOrEmpty(vm.DocumentUrl))
                {
                    list.Add(vm);
                }
            }

            list = list.OrderBy(p => p.CategoryName).ThenBy(p => p.CategoryName).ToList();
            return list;
        }

        //public   IEnumerable<BatchViewModel> GetBatchByLocationId(int locationID)
        //{
        //    var terminal = ebaseDBContext.Terminals.Where(t => t.LocationId == locationID).ToList();
        //    var batchViews =  ebaseDBContext.Tapbatches
        //    //                  join t in terminal on b.TerminalId equals t.Terminal30Id
        //    //                  select new BatchViewModel
        //    //                  {
        //    //                      TerminalDescription = t.TermDescrip,
        //    //                      CutoffDate = b.CutoffDate,
        //    //                      BatchAmount = b.BatchAmount,
        //    //                      TransactionCount = b.TransactionCount
        //    //                  }).ToList();

        //        .Join(ebaseDBContext.Terminals, c => c.TerminalId, e => e.Terminal30Id, (c, e) => new BatchViewModel
        //        {
        //            TerminalDescription = e.TermDescrip,
        //            CutoffDate = c.CutoffDate,
        //            BatchAmount = c.BatchAmount,
        //            TransactionCount = c.TransactionCount,
        //            LocationId=(int)e.LocationId,
        //            FormattedCuttOffDate = DateTime.Parse(c.CutoffDate.ToString()).ToString("MM/dd/yyyy")
        //        }).Where(rs => rs.LocationId == locationID).OrderByDescending(r=>r.CutoffDate).ToList();
        //    int co = batchViews.Count;

        //    return (IEnumerable < BatchViewModel > )batchViews ;
        //}
    }
}
