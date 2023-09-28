using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Repositories.Base
{
   public interface IRepository<T> where T :class
    {
     public  Task <T >Get(int id);
       Task< IEnumerable<T>>GetAll();
       Task  Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
