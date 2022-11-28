﻿using Com.Efrata.Service.Core.Lib;
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
    public class GarmentComodityDataUtil : BasicDataUtil<CoreDbContext, GarmentComodityService, GarmentComodity>, IEmptyData<GarmentComodityViewModel>
    {

        public GarmentComodityDataUtil(CoreDbContext dbContext, GarmentComodityService service) : base(dbContext, service)
        {
        }

        public GarmentComodityViewModel GetEmptyData()
        {
            GarmentComodityViewModel viewModel = new GarmentComodityViewModel()
            {
                Code="",
                Name="",
                
            };

            return viewModel;
        }

        public override GarmentComodity GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            GarmentComodity TestData = new GarmentComodity
            {
                Name = "TEST",
                Code = guid
            };

            return TestData;
        }

        public async override Task<GarmentComodity> GetTestDataAsync()
        {
            GarmentComodity Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
