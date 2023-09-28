using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;

namespace MerchantMVC.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        public IEnumerable<Category> GetCategoryByTypeId(int typeid);
        public IEnumerable<Category> GetCategoryForPriorityByCategoryId();
       // public IEnumerable<Category> GetCategoryForStatus();
    }
}
