﻿using Com.Moonlay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Com.Efrata.Service.Core.Lib.Helpers;
using Com.Efrata.Service.Core.Lib.Interfaces;

namespace Com.Efrata.Service.Core.Test.Helpers
{
    public class BasicUploadCsvServiceTest<TDbContext, TService, TModel, TViewModel> : IDisposable
        where TDbContext : DbContext
        where TService : BasicService<TDbContext, TModel>, IBasicUploadCsvService<TViewModel>
        where TModel : StandardEntity, IValidatableObject, new()
    {
        protected IServiceProvider ServiceProvider { get; set; }

        protected TService Service
        {
            get { return this.ServiceProvider.GetService<TService>(); }
        }

        protected TDbContext DbContext
        {
            get { return this.ServiceProvider.GetService<TDbContext>(); }
        }

        public void Dispose()
        {
            this.ServiceProvider = null;
        }
    }
}
