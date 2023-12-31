﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerchantMVC.Repositories
{
    public interface IVirtualTerminalRepository: IRepository<VirtualTerminal>
    {
        public VirtualTerminalViewModel CreateVirtualTerminal(int merchantID);
        public IEnumerable<SelectListItem> GetLocations(int merchantID);
        public IEnumerable<Terminal> GetTerminals(int locationID);
        public IEnumerable<SelectListItem> GetTerminalSelectItems(int locationID);
        public IEnumerable<TerminalCardType> GetCardTypes(int terminalID);
        public IEnumerable<SelectListItem> GetCardTypeSelectItems(int terminalID);
        public IEnumerable<TerminalTranCode> GetTransCodes(int terminalID);
        public IEnumerable<SelectListItem> GetTransCodeSelectItems(int terminalID);
        public IEnumerable<SelectListItem> GetReferenceTypes();
    }
}
