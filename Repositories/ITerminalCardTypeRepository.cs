using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;

namespace MerchantMVC.Repositories
{
    public interface ITerminalCardTypeRepository : IRepository<TerminalCardType>
    {
        //public IEnumerable<Category> GetCategoryByTypeId(int typeid);
        //public IEnumerable<Category> GetCategoryForPriorityByCategoryId();

    }
}
