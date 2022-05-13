using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseBuyer;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentLeftoverWarehouseBuyer
{
    public class BasicTest : BaseControllerTest<GarmentLeftoverWarehouseBuyerController, GarmentLeftoverWarehouseBuyerModel, GarmentLeftoverWarehouseBuyerViewModel, IGarmentLeftoverWarehouseBuyerService>
    {
        public BasicTest()
        {
        }
    }
}
