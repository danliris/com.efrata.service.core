using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentTransactionType;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;

namespace Com.Efrata.Service.Core.Test.Controllers.GarmentTransactionType
{
    public class BasicTest : BaseControllerTest<GarmentTransactionTypeController, GarmentTransactionTypeModel, GarmentTransactionTypeViewModel, IGarmentTransactionTypeService>
    {
        public BasicTest()
        {
        }
    }
}
