using Microsoft.AspNetCore.Mvc;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.UploadControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/upload-units")]
    public class UnitsUploadController : BasicUploadController<UnitService, Unit, UnitViewModel, UnitService.UnitMap, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public UnitsUploadController(UnitService service) : base(service, ApiVersion)
        {
        }
    }
}