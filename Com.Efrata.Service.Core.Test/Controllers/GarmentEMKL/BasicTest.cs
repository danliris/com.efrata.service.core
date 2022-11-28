using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentEMKL;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentEMKL
{
    public class BasicTest : BaseControllerTest<GarmentEMKLController, GarmentEMKLModel, GarmentEMKLViewModel, IGarmentEMKLService>
    {
        public BasicTest()
        {
        }
    }
}
