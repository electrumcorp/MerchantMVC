using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MerchantMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantMVC.Controllers
{
    public class EntityDocumentMerchantController : Controller
    {
        private IEntityDocumentMerchantRepository _documentRepository;
        private IMapper _mapper;
        public EntityDocumentMerchantController(IEntityDocumentMerchantRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        // GET: EntityMerchantDocumentController
        public ActionResult Index()
        {
            var docs = _documentRepository.GetDocuments();
            return View(docs);
        }

        //// GET: EntityMerchantDocumentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EntityMerchantDocumentController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: EntityMerchantDocumentController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EntityMerchantDocumentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EntityMerchantDocumentController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EntityMerchantDocumentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EntityMerchantDocumentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
