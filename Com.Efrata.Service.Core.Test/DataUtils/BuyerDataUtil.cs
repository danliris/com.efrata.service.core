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
    public class BuyerDataUtil : BasicDataUtil<CoreDbContext, BuyerService, Buyer>, IEmptyData<BuyerViewModel>
    {
        public BuyerDataUtil(CoreDbContext dbContext, BuyerService Service) : base(dbContext, Service)
        {
        }

        public BuyerViewModel GetEmptyData()
        {

            return new BuyerViewModel();
        }

        public override Buyer GetNewData()
        {
            string guid = Guid.NewGuid().ToString();

            return new Buyer()
            {
                Name = string.Format("TEST {0}", guid),
                Id = 0,
                UId = "UId",
                Active = true,
                Address = "Address",
                Code = string.Format("TEST {0}", guid),
                City = "City",
                Contact = "Contact",
                Country = "Country",
                Tempo = 1,
                Type = "Type",
                NPWP = "NPWP",
                NIK= "NIK"
            };
        }

        public override async Task<Buyer> GetTestDataAsync()
        {
            var data = GetNewData();
            await Service.CreateModel(data);
            return data;
        }
    }
}
