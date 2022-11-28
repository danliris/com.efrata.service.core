﻿using AutoMapper;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Helpers.IdentityService;
using Com.Efrata.Service.Core.Lib.Helpers.ValidateService;
using Com.Efrata.Service.Core.Lib.Services; 
using Com.Efrata.Service.Core.Lib.Services.GarmentEMKL;
using Com.Efrata.Service.Core.Lib.Services.GarmentFabricType;
using Com.Efrata.Service.Core.Lib.Services.GarmentForwarder;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseBuyer;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseProduct;
using Com.Efrata.Service.Core.Lib.Services.GarmentShippingStaff;
using Com.Efrata.Service.Core.Lib.Services.MachineSpinning;
using Com.Efrata.Service.Core.Lib.Services.GarmentTransactionType;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Efrata.Service.Core.Lib.Services.GarmentCourier;
using Com.Efrata.Service.Core.Lib.Services.GarmentInsurance;
using Com.Efrata.Service.Core.Lib.Services.BICurrency;
using Com.Efrata.Service.Core.Lib.Services.AccountingCategory;
using Com.Efrata.Service.Core.Lib.Services.AccountingUnit;
using Com.Efrata.Service.Core.Lib.Services.GarmentAdditionalCharges;
using Com.Efrata.Service.Core.Lib.Services.BudgetingCategory;
using Com.Efrata.Service.Core.Lib.Services.IBCurrency;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseComodity;
using Com.Efrata.Service.Core.Lib.Services.BankCashReceiptType;

namespace Com.Efrata.Service.Core.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void RegisterServices(IServiceCollection services)
        {
            services
                .AddScoped<IIdentityService, IdentityService>()
                .AddScoped<IValidateService, ValidateService>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection") ?? Configuration["DefaultConnection"];
            string authority = Configuration["Authority"];
            string clientId = Configuration["ClientId"];
            string secret = Configuration["Secret"];

            services
                .AddDbContext<CoreDbContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<AccountBankService>()
                //.AddScoped<AccountService>()
                .AddScoped<DesignMotiveService>()
                .AddScoped<BudgetService>()
                .AddScoped<BuyerService>()
                .AddScoped<CategoryService>()
                .AddScoped<CurrencyService>()
                .AddScoped<DivisionService>()
                .AddScoped<DesignMotiveService>()
                .AddScoped<GarmentCurrencyService>()
                .AddScoped<GarmentDetailCurrencyService>()
                .AddScoped<BudgetCurrencyService>()
                .AddScoped<GarmentBuyerService>()
                .AddScoped<GarmentComodityService>()
                .AddScoped<HolidayService>()
                .AddScoped<ProductService>()
                .AddScoped<StorageService>()
                .AddScoped<SupplierService>()
                .AddScoped<TermOfPaymentService>()
                .AddScoped<UnitService>()
                .AddScoped<UomService>()
                .AddScoped<IncomeTaxService>()
                .AddScoped<QualityService>()
                .AddScoped<ComodityService>()
                .AddScoped<OrderTypeService>()
                .AddScoped<YarnMaterialService>()
                .AddScoped<MaterialConstructionService>()
                .AddScoped<ProcessTypeService>()
                .AddScoped<FinishTypeService>()
                .AddScoped<StandardTestsService>()
                .AddScoped<LampStandardService>()
                 
                .AddScoped<ColorTypeService>()
                
                .AddScoped<GarmentProductService>()
                .AddScoped<GarmentCategoryService>()
                .AddScoped<GarmentSupplierService>()
                .AddScoped<GarmentUnitService>()
                .AddScoped<GarmentSampleUnitService>()
                .AddScoped<GarmentBuyerBrandService>()
                .AddScoped<GarmentSectionService>()
                .AddScoped<StandardMinuteValueService>()
                .AddTransient<IMachineSpinningService, MachineSpinningService>()
                .AddTransient<IGarmentLeftoverWarehouseBuyerService, GarmentLeftoverWarehouseBuyerService>()
                .AddTransient<IGarmentShippingStaffService, GarmentShipingStaffService>()
                .AddTransient<IGarmentFabricTypeService, GarmentFabricTypeService>()
                .AddTransient<IGarmentEMKLService, GarmentEMKLService>()
                .AddTransient<IGarmentForwarderService, GarmentForwarderService>()
                .AddTransient<IGarmentTransactionTypeService, GarmentTransactionTypeService>()
                .AddTransient<IGarmentLeftoverWarehouseProductService, GarmentLeftoverWarehouseProductService>()
                .AddTransient<IGarmentLeftoverWarehouseComodityService, GarmentLeftoverWarehouseComodityService>()
                .AddTransient<IGarmentCourierService, GarmentCourierService>()
                .AddTransient<IGarmentInsuranceService, GarmentInsuranceService>()
                .AddTransient<IBICurrencyService, BICurrencyService>()
                .AddTransient<IAccountingCategoryService, AccountingCategoryService>()
                .AddTransient<IAccountingUnitService, AccountingUnitService>()
                .AddTransient<IBudgetingCategoryService, BudgetingCategoryService>()
                .AddTransient<IGarmentAdditionalChargesService, GarmentAdditionalChargesService>()
                .AddTransient<IIBCurrencyService, IBCurrencyService>()
                .AddTransient<IBankCashReceiptTypeService, BankCashReceiptTypeService>()
                
                .AddScoped<SizeService>()
                .AddScoped<VatService>()
                .AddScoped<ProductTypeService>();


            RegisterServices(services);

            services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 1);
                });

            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration.GetConnectionString("MongoConnection") ?? Configuration["MongoConnection"]));


            services.AddAutoMapper();

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.ApiName = "com.Efrata.service";
            //        options.ApiSecret = secret;
            //        options.Authority = authority;
            //        options.RequireHttpsMetadata = false;
            //        options.NameClaimType = JwtClaimTypes.Name;
            //    });

            string Secret = Configuration.GetValue<string>("Secret") ?? Configuration["Secret"];
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = Key
                    };
                });

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("RedisConnection") ?? Configuration["RedisConnection"];
                options.InstanceName = Configuration.GetValue<string>("RedisConnectionName") ?? Configuration["RedisConnectionName"];
            });

            services.AddCors(o => o.AddPolicy("CorePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Content-Disposition", "api-version", "content-length", "content-md5", "content-type", "date", "request-id", "response-time");
            }));

            services
                .AddMvcCore()
                .AddApiExplorer()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    In = "header",
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = "apiKey",
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                    {
                        "Bearer",
                        Enumerable.Empty<string>()
                    }
                });
                c.CustomSchemaIds(i => i.FullName);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CoreDbContext>();
                context.Database.SetCommandTimeout(1000 * 60 * 10);
               // context.Database.Migrate();
            }
            app.UseAuthentication();
            app.UseCors("CorePolicy");

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
