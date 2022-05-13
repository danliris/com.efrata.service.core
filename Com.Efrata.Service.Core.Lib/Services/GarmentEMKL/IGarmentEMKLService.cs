using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentEMKL
{
    public interface IGarmentEMKLService : IBaseService<GarmentEMKLModel>
    {
        bool CheckExisting(Expression<Func<GarmentEMKLModel, bool>> filter);
    }
}
