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
    }
}
