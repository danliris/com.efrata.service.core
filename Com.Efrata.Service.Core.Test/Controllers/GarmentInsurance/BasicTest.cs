using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentInsurance;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentInsurance
{
    public class BasicTest : BaseControllerTest<GarmentInsuranceController, GarmentInsuranceModel, GarmentInsuranceViewModel, IGarmentInsuranceService>
    {
        public BasicTest()
        {
        }
    }
}
