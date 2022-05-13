using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentForwarder;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentForwarder
{
    public class BasicTest : BaseControllerTest<GarmentForwarderController, GarmentForwarderModel, GarmentForwarderViewModel, IGarmentForwarderService>
    {
        public BasicTest()
        {
        }
    }
}
