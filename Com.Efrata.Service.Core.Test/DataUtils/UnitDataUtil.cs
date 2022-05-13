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
    public class UnitDataUtil : BasicDataUtil<CoreDbContext, UnitService, Unit>, IEmptyData<UnitViewModel>
    {
        public UnitDataUtil(CoreDbContext dbContext, UnitService service) : base(dbContext, service)
        {
        }

        public UnitViewModel GetEmptyData()
        {
            return new UnitViewModel();
        }

        public override Unit GetNewData()
        {
            string guid = Guid.NewGuid().ToString();

            return new Unit()
            {
                Name = string.Format("Unit {0}", guid),
                Code = string.Format("Unit {0}", guid),
            };
        }

        public override async Task<Unit> GetTestDataAsync()
        {
            var data = GetNewData();
            await this.Service.CreateModel(data);
            return data;
        }
    }
}
