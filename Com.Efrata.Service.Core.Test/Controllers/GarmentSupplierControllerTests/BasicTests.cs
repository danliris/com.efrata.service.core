﻿using Com.Ambassador.Service.Core.Lib;
using Com.Ambassador.Service.Core.Lib.Services;
using Com.Ambassador.Service.Core.Lib.ViewModels;
using Com.Ambassador.Service.Core.Test.Helpers;
using Models = Com.Ambassador.Service.Core.Lib.Models;
using Xunit;
using Com.Ambassador.Service.Core.Test.DataUtils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace Com.Ambassador.Service.Core.Test.Controllers.GarmentSupplierControllerTests
{
    [Collection("TestFixture Collection")]
    public class BasicTests : BasicControllerTest<CoreDbContext, GarmentSupplierService, Models.GarmentSupplier, GarmentSupplierViewModel, GarmentSupplierDataUtil>
	{
		private const string URI = "v1/master/garment-suppliers";
		
		private static List<string> CreateValidationAttributes = new List<string> { };
		private static List<string> UpdateValidationAttributes = new List<string> { };

		public BasicTests(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
		{
		}

        [Fact]
        public async Task GetByCode()
        {
            var response = await this.Client.GetAsync(string.Concat(URI, "/byCodes"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}

