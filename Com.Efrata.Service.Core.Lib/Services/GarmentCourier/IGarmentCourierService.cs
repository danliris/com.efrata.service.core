using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentCourier
{
    public interface IGarmentCourierService : IBaseService<GarmentCourierModel>
    {
        bool CheckExisting(Expression<Func<GarmentCourierModel, bool>> filter);
    }
}
