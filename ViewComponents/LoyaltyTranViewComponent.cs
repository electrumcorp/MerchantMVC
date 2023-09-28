using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;
using AutoMapper;
namespace MerchantMVC.ViewComponents
{
    public class LoyaltyTranViewComponent : ViewComponent
    {
        private ILoyaltyTranRepository _loyaltyTranRepository;
        private IMapper _mapper;

        public LoyaltyTranViewComponent(ILoyaltyTranRepository loyaltyTranRepository , IMapper mapper)
        {
            _loyaltyTranRepository = loyaltyTranRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            //IEnumerable<LoyaltyTransactionTEc> listLoyaltyTran = _loyaltyTranRepository.GetLoyaltyTransactionByLocationID(3823);
            //List<LoyaltyTranViewModel> lst = _mapper.Map<IEnumerable<LoyaltyTranViewModel>>(listLoyaltyTran).ToList();
            //lst = lst.Take<LoyaltyTranViewModel>(20).ToList();
            //List<LoyaltyTranViewModel> lst = _loyaltyTranRepository.GetLoyaltyTransactionByLocationID(3823).ToList();
            return View();
        }
    }
}
