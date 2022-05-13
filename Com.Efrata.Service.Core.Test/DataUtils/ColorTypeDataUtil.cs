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
    public class ColorTypeDataUtil : BasicDataUtil<CoreDbContext, ColorTypeService, ColorTypes>, IEmptyData<ColorTypeViewModel>
    {
        public ColorTypeDataUtil(CoreDbContext dbContext, ColorTypeService service) : base(dbContext, service)
        {
        }

        public ColorTypeViewModel GetEmptyData()
        {
            ColorTypeViewModel colorTypeViewModel = new ColorTypeViewModel();
            return colorTypeViewModel;
        }

        public override ColorTypes GetNewData()
        {
            ColorTypes colorTypes = new ColorTypes()
            {
                Name = "ColorTypesName",
                Code = "ColorTypesCode",
                Remark = "ColorTypesRemark",
            };
            return colorTypes;
        }

        public override async Task<ColorTypes> GetTestDataAsync()
        {
            ColorTypes colorTypes = GetNewData();
            await Service.CreateModel(colorTypes);
            return colorTypes;
        }
    }
}
