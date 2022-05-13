using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentInsurance
{
    public interface IGarmentInsuranceService : IBaseService<GarmentInsuranceModel>
    {
        bool CheckExisting(Expression<Func<GarmentInsuranceModel, bool>> filter);
    }
}
