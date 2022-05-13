using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentShippingStaff;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentShippingStaff
{
    public class BasicTest : BaseControllerTest<GarmentShippingStaffController, GarmentShippingStaffModel, GarmentShippingStaffViewModel, IGarmentShippingStaffService>
    {
        public BasicTest()
        {
        }
    }
}
