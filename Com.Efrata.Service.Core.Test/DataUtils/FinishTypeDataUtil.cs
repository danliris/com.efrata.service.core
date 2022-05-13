using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Test.Interface;
using System;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.Test.DataUtils
{
    public class FinishTypeDataUtil : BasicDataUtil<CoreDbContext, FinishTypeService, FinishType>, IEmptyData<FinishTypeViewModel>
    {
        public FinishTypeDataUtil(CoreDbContext dbContext, FinishTypeService service) : base(dbContext, service)
        {
        }

        public FinishTypeViewModel GetEmptyData()
        {
            FinishTypeViewModel ViewModel = new FinishTypeViewModel();
            return ViewModel;
        }

        public override FinishType GetNewData()
        {
            Guid guid = Guid.NewGuid();
            FinishType model = new FinishType()
            {
                Name = "FinishTypesName" + guid,
                Code = "FinishTypesCode" + guid,
                Remark = "FinishTypesRemark" + guid,
            };
            return model;
        }

        public override async Task<FinishType> GetTestDataAsync()
        {
            FinishType model = GetNewData();
            await Service.CreateModel(model);
            return model;
        }
    }
}
