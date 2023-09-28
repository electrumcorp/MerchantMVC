using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC.ViewModels
{
    public class MainViewModel
    {
        public int MerchantID { get; set; }
        public List<FeedBackViewModel> Feedback { get; set; }
    }
}
