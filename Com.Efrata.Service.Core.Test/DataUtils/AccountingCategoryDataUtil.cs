﻿using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.AccountingCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.Test.DataUtils
{
  public  class AccountingCategoryDataUtil
    {
        private readonly AccountingCategoryService Service;

        public AccountingCategoryDataUtil(AccountingCategoryService service)
        {
            Service = service;
        }

        public AccountingCategory GetNewData()
        {
            Guid guid = Guid.NewGuid();

            AccountingCategory model = new AccountingCategory()
            {
                Code = "Code",
                Name = "Name",
               AccountingLayoutIndex=1,
               
            };

            return model;
        }

        public async Task<AccountingCategory> GetTestData()
        {
            var data = GetNewData();

            await Service.CreateModel(data);

            return data;
        }
    }
}
