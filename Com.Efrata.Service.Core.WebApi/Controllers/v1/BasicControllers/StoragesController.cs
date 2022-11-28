using Microsoft.AspNetCore.Mvc;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Lib;
using System.Threading.Tasks;
using System;
using System.Net;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/storages")]
    public class StoragesController : BasicController<StorageService, Storage, StorageViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";

        public StoragesController(StorageService service) : base(service, ApiVersion)
        {
        }

        [HttpGet("by-storage-name")]
        public async Task<IActionResult> GetByStorageName(string keyword, int page = 1, int size = 25)
        {
            var result = await Service.GetStorageByName(keyword, page, size);

            return Ok(result);
        }
    }
}
