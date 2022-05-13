using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Test.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.Test.DataUtils
{
	public class GarmentCurrencyDataUtil : BasicDataUtil<CoreDbContext, GarmentCurrencyService, GarmentCurrency>, IEmptyData<GarmentCurrencyViewModel>
	{
		public GarmentCurrencyDataUtil(CoreDbContext dbContext, GarmentCurrencyService service) : base(dbContext, service)
		{
		}

		public GarmentCurrencyViewModel GetEmptyData()
		{
			GarmentCurrencyViewModel Data = new GarmentCurrencyViewModel();
			
			return Data;
		}

		public override GarmentCurrency GetNewData()
		{
			GarmentCurrency model = new GarmentCurrency();

			string guid = Guid.NewGuid().ToString();

			model.Code = guid;
			model.Date = DateTime.Now;
			model.Rate = 1;

			return model;
		}

		public override async Task<GarmentCurrency> GetTestDataAsync()
		{
			GarmentCurrency model = GetNewData();
			await this.Service.CreateModel(model);
			return model;
		}

		

		
	}
}
