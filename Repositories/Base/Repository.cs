using MerchantMVC.Models;
using MerchantMVC.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly EbaseDBContext EbaseDbContext;
        public Repository(EbaseDBContext ebaseDbContext)
        {
            EbaseDbContext = ebaseDbContext;
        }
        public async Task Add(T entity)
        {
            await EbaseDbContext.Set<T>().AddAsync(entity); await EbaseDbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await EbaseDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EbaseDbContext.Set<T>().ToListAsync<T>();
        }

        public void Remove(T entity)
        {
            EbaseDbContext.Set<T>().Remove(entity); EbaseDbContext.SaveChanges();
        }

        public void Update(T entity)
        {

            EbaseDbContext.Set<T>().Update(entity);
            EbaseDbContext.SaveChanges();
        }
    }
}
