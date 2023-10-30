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
    public class BatchRepository : Repository<Tapbatch>,IBatchRepository
    {
        private readonly EbaseDBContext ebaseDBContext = null;

        public BatchRepository(EbaseDBContext context) : base(context)
        { 
            ebaseDBContext = context;
        }

        public   IEnumerable<BatchViewModel> GetBatchByLocationId(int locationID)
        {
            var terminal = ebaseDBContext.Terminals.Where(t => t.LocationId == locationID).ToList();
            var batchViews =  ebaseDBContext.Tapbatches
                .Join(ebaseDBContext.Terminals, c => c.TerminalId, e => e.Terminal30Id, (c, e) => new BatchViewModel
                {
                    TerminalDescription = e.TermDescrip,
                    CutoffDate = c.CutoffDate,
                    BatchAmount = c.BatchAmount,
                    TransactionCount = c.TransactionCount,
                    LocationId=(int)e.LocationId,
                    FormattedCuttOffDate = DateTime.Parse(c.CutoffDate.ToString()).ToString("MM/dd/yyyy")
                })
                .Where(rs => rs.LocationId == locationID && rs.CutoffDate > DateTime.Now.AddDays(-91))
                .AsNoTracking()
                .OrderByDescending(r=>r.CutoffDate)
                .ToList();
            int co = batchViews.Count;

            return batchViews;
        }
    }
}
