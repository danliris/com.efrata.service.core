using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentFabricType;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentFabricType
{
    public class BasicTest : BaseControllerTest<GarmentFabricTypeController, GarmentFabricTypeModel, GarmentFabricTypeViewModel, IGarmentFabricTypeService>
    {
        public BasicTest()
        {
        }
    }
}
