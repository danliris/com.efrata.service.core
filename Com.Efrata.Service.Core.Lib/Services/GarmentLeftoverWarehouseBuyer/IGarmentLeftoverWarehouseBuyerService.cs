using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseBuyer
{
    public interface IGarmentLeftoverWarehouseBuyerService : IBaseService<GarmentLeftoverWarehouseBuyerModel>
    {
        bool CheckExisting(Expression<Func<GarmentLeftoverWarehouseBuyerModel, bool>> filter);
    }
}
