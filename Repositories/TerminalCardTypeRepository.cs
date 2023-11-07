using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;

namespace MerchantMVC.Repositories
{
    public class TerminalCardTypeRepository : Repository<TerminalCardType>,ITerminalCardTypeRepository
    {
        private readonly EbaseDBContext ebaseContext;

        public TerminalCardTypeRepository(EbaseDBContext context) : base(context)
        {
            ebaseContext = context;
        }

        public IEnumerable<TerminalCardType> GetTerminalCardTypes(int terminalID)
        {
            return ebaseContext.TerminalCardTypes.Where(n => n.Terminal30Id == terminalID).ToList();
        }
    }
}
