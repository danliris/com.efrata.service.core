using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/product-types")]
    public class ProductTypeController : BasicController<ProductTypeService, ProductType, ProductTypeViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        public ProductTypeController(ProductTypeService service) : base(service, ApiVersion)
        {
        }
    }
}
