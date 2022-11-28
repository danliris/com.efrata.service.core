﻿using Com.Ambassador.Service.Core.Lib;
using Com.Ambassador.Service.Core.Lib.Models;
using Com.Ambassador.Service.Core.Lib.Services;
using Com.Ambassador.Service.Core.Lib.ViewModels;
using Com.Ambassador.Service.Core.Test.Helpers;
using Com.Ambassador.Service.Core.Test.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Ambassador.Service.Core.Test.DataUtils
{
    public class UomServiceDataUtil : BasicDataUtil<CoreDbContext, UomService, Uom>, IEmptyData<UomViewModel>
    {
        public UomServiceDataUtil(CoreDbContext dbContext, UomService service) : base(dbContext, service)
        {
        }

        public UomViewModel GetEmptyData()
        {
            UomViewModel Data = new UomViewModel();

            Data.Unit = "";
            return Data;
        }

        public override Uom GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            Uom TestData = new Uom
            {
                Active = true,
                Unit = string.Format("TEST {0}", guid),
                UId = guid
            };

            return TestData;
        }

        public override async Task<Uom> GetTestDataAsync()
        {
            Uom Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
