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
    public class GarmentSampleUnitDataUtil : BasicDataUtil<CoreDbContext, GarmentSampleUnitService, Unit>, IEmptyData<UnitViewModel>
    {
        public GarmentSampleUnitDataUtil(CoreDbContext dbContext, GarmentSampleUnitService service) : base(dbContext, service)
        {
        }

        public UnitViewModel GetEmptyData()
        {
            return new UnitViewModel
            {
                Division = new DivisionViewModel()
            };
        }

        public override Unit GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            return new Unit
            {
                Code = string.Format("UnitCode {0}", guid),
                Name = string.Format("UnitName {0}", guid),
            };
        }

        public override async Task<Unit> GetTestDataAsync()
        {
            var data = GetNewData();
            await Service.CreateModel(data);
            return data;
        }
    }
}
