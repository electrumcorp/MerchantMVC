﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;

namespace MerchantMVC.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private readonly EbaseDBContext ebaseContext;
        public CategoryRepository(EbaseDBContext context) : base(context)
        {
            ebaseContext = context;
        }
        public IEnumerable<Category> GetCategoryByTypeId(int typeid)
        {
            var category = ebaseContext.Categories.Where(ct => ct.TypeId == typeid );
            return (IEnumerable<Category>)category;
        }

        public IEnumerable<Category> GetCategoryForPriorityByCategoryId()
        {
            var categoryPriority = ebaseContext.Categories.Where(ct => ct.TypeId == 27);
            return (IEnumerable<Category>)categoryPriority;
        }

        public IEnumerable<Category> GetCategoryForStatus(int typeid)
        {
            var categoryStatus = ebaseContext.Categories.Where(ct => ct.CategoryId == 115 || ct.CategoryId == 117).Where(ct => ct.CategoryId != 171);
            return (IEnumerable<Category>)categoryStatus;
        }
    }
}
