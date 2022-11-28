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
    public class DesignMotiveDataUtil : BasicDataUtil<CoreDbContext, DesignMotiveService, DesignMotive>, IEmptyData<DesignMotiveViewModel>
    {
        public DesignMotiveDataUtil(CoreDbContext dbContext, DesignMotiveService service) : base(dbContext, service)
        {
        }

        public DesignMotiveViewModel GetEmptyData()
        {
            return new DesignMotiveViewModel();
        }

        public override DesignMotive GetNewData()
        {
            string guid = Guid.NewGuid().ToString();

            return new DesignMotive()
            {
                Code = string.Format("TEST {0}", guid),
                Name = string.Format("TEST {0}", guid),
            };
        }

        public override async Task<DesignMotive> GetTestDataAsync()
        {
            var data = GetNewData();
            await this.Service.CreateModel(data);
            return data;
        }
    }
}
