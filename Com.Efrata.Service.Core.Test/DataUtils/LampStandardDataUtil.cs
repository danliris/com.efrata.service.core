﻿using Com.Ambassador.Service.Core.Lib;
using Com.Ambassador.Service.Core.Lib.Models;
using Com.Ambassador.Service.Core.Lib.Services;
using Com.Ambassador.Service.Core.Lib.ViewModels;
using Com.Ambassador.Service.Core.Test.Helpers;
using Com.Ambassador.Service.Core.Test.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ambassador.Service.Core.Test.DataUtils
{
    public class LampStandardDataUtil : BasicDataUtil<CoreDbContext, LampStandardService, LampStandard>, IEmptyData<LampStandardViewModel>
    {
        public LampStandardDataUtil(CoreDbContext dbContext, LampStandardService service) : base(dbContext, service)
        {
        }
        public LampStandardViewModel GetEmptyData()
        {
            LampStandardViewModel Data = new LampStandardViewModel();

            Data.Name = "";
            Data.Code = "";
            Data.Remark = "";
            return Data;
        }

        public override LampStandard GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            LampStandard TestData = new LampStandard
            {
                Name = "TEST",
                Remark = "test",
            };

            return TestData;
        }

        public override async Task<LampStandard> GetTestDataAsync()
        {
            LampStandard Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
