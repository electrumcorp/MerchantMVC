using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;

namespace MerchantMVC.Repositories
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private readonly EbaseDBContext ebaseContext;
        public EmployeeRepository(EbaseDBContext context) : base(context)
        {
            ebaseContext = context;
        }
    }
}
