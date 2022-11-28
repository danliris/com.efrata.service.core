using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseComodity;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentLeftoverWarehouseComodity
{
    public class BasicTest : BaseControllerTest<GarmentLeftoverWarehouseComodityController, GarmentLeftoverWarehouseComodityModel, GarmentLeftoverWarehouseComodityViewModel, IGarmentLeftoverWarehouseComodityService>
    {
        public BasicTest()
        {
        }
    }
}
