using AutoMapper;
using Com.Efrata.Service.Core.Lib.Helpers.IdentityService;
using Com.Efrata.Service.Core.Lib.Helpers.ValidateService;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentShippingStaff;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/garment-shipping-staffs")]
    [Authorize]
    public class GarmentShippingStaffController : BaseController<GarmentShippingStaffModel, GarmentShippingStaffViewModel, IGarmentShippingStaffService>
    {
        public GarmentShippingStaffController(IIdentityService identityService, IValidateService validateService, IGarmentShippingStaffService service, IMapper mapper) : base(identityService, validateService, service, mapper, "1.0.0")
        {
        }
    }
}
