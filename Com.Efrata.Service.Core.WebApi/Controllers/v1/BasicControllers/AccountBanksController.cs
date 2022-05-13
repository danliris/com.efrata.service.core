using Microsoft.AspNetCore.Mvc;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Lib;
using System;
using System.Collections.Generic;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/account-banks")]
    public class AccountBanksController : BasicController<AccountBankService, AccountBank, AccountBankViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";

        public AccountBanksController(AccountBankService service) : base(service, ApiVersion)
        {
        }

        [HttpGet("division/{divisionName}")]
        public IActionResult GetByDivisionName(string divisionName)
        {
            Tuple<List<AccountBank>> Data = Service.ReadModelByDivisionName(divisionName);

            return Ok(new
            {
                apiVersion = ApiVersion,
                statusCode = General.OK_STATUS_CODE,
                message = General.OK_MESSAGE,
                data = Data.Item1
            });
        }

    }
}
