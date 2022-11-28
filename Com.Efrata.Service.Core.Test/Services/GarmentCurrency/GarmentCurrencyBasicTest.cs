﻿using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.DataUtils;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;
using Models = Com.Efrata.Service.Core.Lib.Models;

namespace Com.Efrata.Service.Core.Test.Services.GarmentCurrency
{
	[Collection("ServiceProviderFixture Collection")]
	public class GarmentCurrencyBasicTest : BasicServiceTest<CoreDbContext, GarmentCurrencyService, Models.GarmentCurrency>
	{
		private static readonly string[] createAttrAssertions = { "Code","Date","Rate" };
		private static readonly string[] updateAttrAssertions = { "Code","Date","Rate" };
		private static readonly string[] existAttrCriteria = { "Code","Date" };

		private GarmentCurrencyDataUtil DataUtil
		{
			get { return (GarmentCurrencyDataUtil)ServiceProvider.GetService(typeof(GarmentCurrencyDataUtil)); }
		}

		private GarmentCurrencyService Services
		{
			get { return (GarmentCurrencyService)ServiceProvider.GetService(typeof(GarmentCurrencyService)); }
		}

		public GarmentCurrencyBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
		{
		}

		public override void EmptyCreateModel(Models.GarmentCurrency model)
		{
			model.Code = string.Empty;
			model.Date = DateTime.MaxValue;
			model.Rate = -1;
		}

		public override void EmptyUpdateModel(Models.GarmentCurrency model)
		{
			model.Code = string.Empty;
			model.Date = DateTime.MaxValue;
			model.Rate = -1;
		}

		public override Models.GarmentCurrency GenerateTestModel()
		{
			string guid = Guid.NewGuid().ToString();

			return new Models.GarmentCurrency()
			{
				Code = guid,
				Date = DateTime.Today,
				Rate = 0,
			};
		}

		[Fact]
		public async void Should_Success_Get_Data_By_Id()
		{
			Models.GarmentCurrency model1 = await DataUtil.GetTestDataAsync();
			Models.GarmentCurrency model2 = await DataUtil.GetTestDataAsync();
			var Response = Services.GetByIds(new List<int> { model1.Id, model2.Id });
			Assert.NotNull(Response);
		}

        [Fact]
        public async void Should_Success_Get_Data_By_Code()
        {
            Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
            var Response = Services.GetByCode(model.Code);
            Assert.NotNull(Response);
        }

        [Fact]
        public async void Should_Success_Get_Single_Data_By_Code()
        {
            Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
            var Response = Services.GetSingleByCode(model.Code);
            Assert.NotNull(Response);
        }

		[Fact]
		public async void Should_Success_Get_Single_Data_By_Code_Date()
		{
			Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
			var Response = Services.GetSingleByCodeDate(model.Code, model.Date);
			Assert.NotNull(Response);
		}

		[Fact]
		public async void Should_Success_GetByCodeBeforeDate()
		{
			Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
            List<GarmentCurrencyViewModel> garmentCurrencies = new List<GarmentCurrencyViewModel>
            {
                new GarmentCurrencyViewModel
                {
                    code = model.Code,
                    date = model.Date.AddDays(1)
                }
            };
            var Response = Services.GetByCodeBeforeDate(garmentCurrencies);
			Assert.NotNull(Response);
		}

		[Fact]
		public async void Should_Success_ReadModel()
		{
			Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
			
			var orderData = new
			{
				Code="asc"
			};
			string order = JsonConvert.SerializeObject(orderData);

			var Response = Services.ReadModel(1, 25, order, new List<string>(), "", "{}");
			Assert.NotNull(Response);
		}

		[Fact]
		public async void Should_Success_UploadValidate()
		{
			Models.GarmentCurrency model = await DataUtil.GetTestDataAsync();
			List<GarmentCurrencyViewModel> garmentCurrencies = new List<GarmentCurrencyViewModel>
			{
				new GarmentCurrencyViewModel
				{
					code = "",
					date = model.Date.AddDays(1),
					rate="",
				}
			};

			List<KeyValuePair<string, StringValues>> body = new List<KeyValuePair<string, StringValues>>();
			KeyValuePair<string, StringValues> keyValue =new   KeyValuePair<string, StringValues>("date", "2020-01-10");
			body.Add(keyValue);

			var Response = Services.UploadValidate(garmentCurrencies,body);
			Assert.NotNull(Response);
		}


		
	}
}
