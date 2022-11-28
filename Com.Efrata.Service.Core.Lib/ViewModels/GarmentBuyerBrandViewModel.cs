using Com.Efrata.Service.Core.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Efrata.Service.Core.Lib.ViewModels
{
    public class GarmentBuyerBrandViewModel :BasicViewModel
    {
        public string Code { get; set; }

        public string Name { get; set; }
        
        public GarmentBuyerViewModel Buyers { get; set; }

        public string BuyerName { get; set; }
    }
}
