using System;
using System.Collections.Generic;
using System.Linq;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerchantMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MerchantMVC.Repositories
{
    public class VirtualTerminalRepository : Repository<VirtualTerminal>, IVirtualTerminalRepository
    {
        private readonly EbaseDBContext ebaseContext;
        public VirtualTerminalRepository(EbaseDBContext context) : base(context)
        {
            ebaseContext = context;
        }

        public VirtualTerminalViewModel CreateVirtualTerminal(int merchantId)
        {
            var virtualTerminal = new VirtualTerminalViewModel()
            {
                VirtualTerminalID = Guid.NewGuid(),
                LocationsList = GetLocations(merchantId),
                TerminalsList = GetTerminals(),
                CardTypeList = GetCardTypes(),
                ReferenceTypeList = GetReferenceTypes(),
                TransCodeList = GetTransCodes()
            };

            return virtualTerminal;
        }

 #region "Drop Down Lists"
        public IEnumerable<SelectListItem> GetLocations(int merchantID)
        {
            List<SelectListItem> locations = ebaseContext.Locations.AsNoTracking()
                .Where(n => n.MerchantId == merchantID && n.CategoryId == 385 && n.LocationStatus == "P")
                .OrderBy(n => n.LName)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.LocationId.ToString(),
                        Text = n.LName
                    }).ToList();

            return new SelectList(locations, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetTerminals()
        {
            IEnumerable<SelectListItem> terminals = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "-- Select Location first --"
                }
            };

            return terminals;
        }

        public IEnumerable<Terminal> GetTerminals(int locationID)
        {
            var terminals = ebaseContext.Terminals.AsNoTracking()
                .Where(n => n.LocationId == locationID && n.CategoryId == 589 && n.Status == "P")
                .OrderBy(n => n.TermDescrip).ToList();

            return terminals;
        }

        public IEnumerable<SelectListItem> GetTerminalSelectItems(int locationID)
        {
            List<SelectListItem> locations = ebaseContext.Terminals.AsNoTracking()
                .Where(n => n.LocationId == locationID && n.CategoryId == 589 && n.Status == "P")
                .OrderBy(n => n.TermDescrip)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Terminal30Id.ToString(),
                        Text = n.TermDescrip
                    }).ToList();

            return new SelectList(locations, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetReferenceTypes()
        {
            List<SelectListItem> referenceTypes = ebaseContext.Categories.AsNoTracking()
                .Where(n => n.TypeId == 161)
                .OrderBy(n => n.CategoryId)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.CategoryId.ToString(),
                            Text = n.CategoryName
                        }).ToList();

            var referenceTip = new SelectListItem()
            {
                Value = null,
                Text = "-- Select Reference Type --"
            };
            referenceTypes.Insert(0, referenceTip);
            return new SelectList(referenceTypes, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetTransactionTypes()
        {
            List<SelectListItem> referenceTypes = ebaseContext.Categories.AsNoTracking()
                .Where(n => n.CategoryId == 860)
                .OrderBy(n => n.CategoryId)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.CategoryId.ToString(),
                            Text = n.CategoryName
                        }).ToList();

            var referenceTip = new SelectListItem()
            {
                Value = null,
                Text = "-- Select Transaction Type --"
            };
            referenceTypes.Insert(0, referenceTip);
            return new SelectList(referenceTypes, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetTransCodes()
        {
            IEnumerable<SelectListItem> terminals = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "-- Select Terminal first --"
                }
            };

            return terminals;
        }

        public IEnumerable<TerminalTranCode> GetTransCodes(int terminalID)
        {

            var param = new SqlParameter("@TerminalID", terminalID);
            var transCodes = ebaseContext.TerminalTranCodes.FromSqlRaw("TerminalTranCode_S_EC @TerminalID", param).ToList();

            return transCodes;
        }

        public IEnumerable<SelectListItem> GetTransCodeSelectItems(int terminalID)
        {
            var list = GetTransCodes(terminalID);
            List<SelectListItem> transCodes = list
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.TranCodeId.ToString(),
                        Text = n.TranCodeName
                    }).ToList();

            return new SelectList(transCodes, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetCardTypes()
        {
            IEnumerable<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "-- Select Terminal first --"
                }
            };

            return list;
        }

        public IEnumerable<TerminalCardType> GetCardTypes(int terminalID)
        {
            var param = new SqlParameter("@TerminalID", terminalID);
            var cardTypes = ebaseContext.TerminalCardTypes.FromSqlRaw("TerminalCardType_S_EC @TerminalID", param).ToList();

            return cardTypes;
        }

        public IEnumerable<SelectListItem> GetCardTypeSelectItems(int terminalID)
        {
            var list = GetCardTypes(terminalID);
            List<SelectListItem> transCodes = list
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.CardTypeId.ToString(),
                        Text = n.CardTypeName
                    }).ToList();

            return new SelectList(transCodes, "Value", "Text");
        }
        #endregion
    }
}
