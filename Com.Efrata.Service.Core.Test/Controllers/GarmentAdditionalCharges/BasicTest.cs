using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentAdditionalCharges;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentAdditionalCharges
{
    public class BasicTest : BaseControllerTest<GarmentAdditionalChargesController, GarmentAdditionalChargesModel, GarmentAdditionalChargesViewModel, IGarmentAdditionalChargesService>
    {
        public BasicTest()
        {
        }
    }
}
