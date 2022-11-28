using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentFabricType
{
    public interface IGarmentFabricTypeService : IBaseService<GarmentFabricTypeModel>
    {
        bool CheckExisting(Expression<Func<GarmentFabricTypeModel, bool>> filter);
    }
}
