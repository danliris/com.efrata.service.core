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
    public class CategoryDataUtil : BasicDataUtil<CoreDbContext, CategoryService, Category>, IEmptyData<CategoryViewModel>
    {
        public CategoryDataUtil(CoreDbContext dbContext, CategoryService service) : base(dbContext, service)
        {
        }

        public CategoryViewModel GetEmptyData()
        {
            return new CategoryViewModel();
        }

        public override Category GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            return new Category
            {
                Code = string.Format("CategoryCode {0}", guid),
                Name = string.Format("CategoryName {0}", guid),
                DivisionId = 0,
                CodeRequirement = string.Format("CodeRequirement {0}" , guid)
            };
        }

        public override async Task<Category> GetTestDataAsync()
        {
            var data = GetNewData();
            await Service.CreateModel(data);
            return data;
        }
    }
}
