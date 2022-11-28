﻿using Com.Ambassador.Service.Core.Lib;
using Com.Ambassador.Service.Core.Lib.Models;
using Com.Ambassador.Service.Core.Lib.Services;
using Com.Ambassador.Service.Core.Lib.ViewModels;
using Com.Ambassador.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Ambassador.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/standard-minute-value")]
    public class StandardMinuteValueController : BasicController<StandardMinuteValueService, StandardMinuteValue, StandardMinuteValueViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        public StandardMinuteValueController(StandardMinuteValueService Service) : base(Service, ApiVersion)
        {
        }
    }
}
