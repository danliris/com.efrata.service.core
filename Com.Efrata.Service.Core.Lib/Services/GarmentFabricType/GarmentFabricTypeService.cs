﻿using Com.Efrata.Service.Core.Lib.Helpers;
using Com.Efrata.Service.Core.Lib.Helpers.IdentityService;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentFabricType
{
    public class GarmentFabricTypeService : IGarmentFabricTypeService
    {
        private const string _UserAgent = "core-service";
        protected DbSet<GarmentFabricTypeModel> _DbSet;
        protected IIdentityService _IdentityService;
        public CoreDbContext _DbContext;

        public GarmentFabricTypeService(IServiceProvider serviceProvider, CoreDbContext dbContext)
        {
            _DbContext = dbContext;
            _DbSet = dbContext.Set<GarmentFabricTypeModel>();
            _IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public async Task<int> CreateAsync(GarmentFabricTypeModel model)
        {
            model.FlagForCreate(_IdentityService.Username, _UserAgent);
            model._LastModifiedAgent = model._CreatedAgent;
            model._LastModifiedBy = model._CreatedBy;
            model._LastModifiedUtc = model._CreatedUtc;

            _DbSet.Add(model);
            return await _DbContext.SaveChangesAsync();
        }

        public ReadResponse<GarmentFabricTypeModel> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            IQueryable<GarmentFabricTypeModel> Query = _DbSet;

            List<string> SearchAttributes = new List<string>()
            {
                "Name"
            };
            Query = QueryHelper<GarmentFabricTypeModel>.Search(Query, SearchAttributes, keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            Query = QueryHelper<GarmentFabricTypeModel>.Filter(Query, FilterDictionary);

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(order);
            Query = QueryHelper<GarmentFabricTypeModel>.Order(Query, OrderDictionary);

            Query = Query.Select(s => new GarmentFabricTypeModel
            {
                Id = s.Id,
                Name = s.Name,
            });

            Pageable<GarmentFabricTypeModel> pageable = new Pageable<GarmentFabricTypeModel>(Query, page - 1, size);
            List<GarmentFabricTypeModel> Data = pageable.Data.ToList();

            int TotalData = pageable.TotalCount;
            return new ReadResponse<GarmentFabricTypeModel>(Data, TotalData, OrderDictionary, new List<string>());
        }

        public async Task<GarmentFabricTypeModel> ReadByIdAsync(int id)
        {
            return await _DbSet.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(int id, GarmentFabricTypeModel model)
        {
            model.FlagForUpdate(_IdentityService.Username, _UserAgent);
            _DbSet.Update(model);
            return await _DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var model = _DbSet.Where(w => w.Id == id).FirstOrDefault();
            model.FlagForDelete(_IdentityService.Username, _UserAgent);
            _DbSet.Update(model);
            return await _DbContext.SaveChangesAsync();
        }

        public bool CheckExisting(Expression<Func<GarmentFabricTypeModel, bool>> filter)
        {
            var count = _DbSet.Where(filter).Count();

            return count > 0;
        }
    }
}
