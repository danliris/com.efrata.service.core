using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/design-motives")]
    public class DesignMotivesControllers : BasicController<DesignMotiveService, DesignMotive, DesignMotiveViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";

        public DesignMotivesControllers(DesignMotiveService service) : base(service, ApiVersion)
        {
        }
    }
}
