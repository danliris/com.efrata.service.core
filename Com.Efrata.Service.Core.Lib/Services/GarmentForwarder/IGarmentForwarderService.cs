﻿using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentForwarder
{
    public interface IGarmentForwarderService : IBaseService<GarmentForwarderModel>
    {
        bool CheckExisting(Expression<Func<GarmentForwarderModel, bool>> filter);
    }
}
