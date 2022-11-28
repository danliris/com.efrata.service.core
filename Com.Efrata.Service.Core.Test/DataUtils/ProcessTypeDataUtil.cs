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
    public class ProcessTypeDataUtil : BasicDataUtil<CoreDbContext, ProcessTypeService, ProcessType>, IEmptyData<ProcessTypeViewModel>
    {
        public ProcessTypeDataUtil(CoreDbContext dbContext, ProcessTypeService service) : base(dbContext, service)
        {
        }

        public ProcessTypeViewModel GetEmptyData()
        {
            return new ProcessTypeViewModel();
        }

        public override ProcessType GetNewData()
        {
            string guid = Guid.NewGuid().ToString();

            return new ProcessType()
            {
                Name = string.Format("TEST {0}", guid),
                Code = string.Format("TEST {0}", guid),
                Unit = string.Format("TEST {0}", guid),
                SPPCode = string.Format("TEST {0}", guid)
                //  Unit= "Unit"
            };
        }

        public override async Task<ProcessType> GetTestDataAsync()
        {
            var data = GetNewData();
            await this.Service.CreateModel(data);
            return data;
        }
    }
}
