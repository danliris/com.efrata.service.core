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
    [Route("v{version:apiVersion}/master/upload-uoms")]
    public class UomsUploadController : BasicUploadController<UomService, Uom, UomViewModel, UomService.UomMap, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";

        public UomsUploadController(UomService service) : base(service, ApiVersion)
        {
        }
    }
}