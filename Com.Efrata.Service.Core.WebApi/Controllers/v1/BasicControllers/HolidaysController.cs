using Microsoft.AspNetCore.Mvc;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Lib;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/holidays")]
    public class HolidaysController : BasicController<HolidayService, Holiday, HolidayViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";

        public HolidaysController(HolidayService service) : base(service, ApiVersion)
        {
        }
    }
}
