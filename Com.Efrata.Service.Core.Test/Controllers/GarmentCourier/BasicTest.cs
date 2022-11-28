using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentCourier;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentCourier
{
    public class BasicTest : BaseControllerTest<GarmentCourierController, GarmentCourierModel, GarmentCourierViewModel, IGarmentCourierService>
    {
        public BasicTest()
        {
        }
    }
}
