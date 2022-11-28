﻿using Com.Ambassador.Service.Core.Test.Helpers;
using Com.Ambassador.Service.Core.Lib;
using Com.Ambassador.Service.Core.Lib.Models;
using Com.Ambassador.Service.Core.Lib.Services;
using Com.Ambassador.Service.Core.Lib.ViewModels;
using Com.Ambassador.Service.Core.Test.DataUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Ambassador.Service.Core.Test.Services.GarmentSupplierTest
{
    [Collection("ServiceProviderFixture Collection")]
    public class BasicTests : BasicServiceTest<CoreDbContext, GarmentSupplierService, GarmentSupplier>
    {
        private static readonly string[] createAttrAssertions = { "Name" };
        private static readonly string[] updateAttrAssertions = { "Name" };
        private static readonly string[] existAttrCriteria = { "Code" };
        public BasicTests(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }
        public override void EmptyCreateModel(GarmentSupplier model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.UseTax = true;
            model.IncomeTaxesId = 0;
        }

        public override void EmptyUpdateModel(GarmentSupplier model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.UseTax = true;
            model.IncomeTaxesId = 0;
        }
        public override GarmentSupplier GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new GarmentSupplier()
            {
                Code = guid,
                Name = guid,
                UseTax = true,
                UseVat = true,
                Import = true,
                IncomeTaxesId = 1,
                IncomeTaxesName = guid,
                IncomeTaxesRate = 1
            };
        }

        private GarmentSupplierDataUtil DataUtil
        {
            get { return (GarmentSupplierDataUtil)ServiceProvider.GetService(typeof(GarmentSupplierDataUtil)); }
        }

        private GarmentSupplierService Services
        {
            get { return (GarmentSupplierService)ServiceProvider.GetService(typeof(GarmentSupplierService)); }
        }
        [Fact]
        public void Should_Error_Upload_CSV_Data_with_false_IncomeTax()
        {
            GarmentSupplierViewModel Vmodel1 = DataUtil.GetNewData1();
            GarmentSupplierViewModel Vmodel2 = DataUtil.GetNewData2();
            GarmentSupplierViewModel Vmodel3 = DataUtil.GetNewData3();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel1, Vmodel2, Vmodel3 }, null);
            Assert.Equal(Response.Item1, false);
        }
        [Fact]
        public void Should_Success_Upload_CSV_Data_when_UseTax_False()
        {
            GarmentSupplierViewModel Vmodel4 = DataUtil.GetNewData4();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel4 }, null);
            Assert.Equal(Response.Item1, true);
        }
        [Fact]
        public void Should_Error_Upload_CSV_Data_when_UseTax_False()
        {
            GarmentSupplierViewModel Vmodel5 = DataUtil.GetNewData5();
            GarmentSupplierViewModel Vmodel6 = DataUtil.GetNewData6();
            GarmentSupplierViewModel Vmodel7 = DataUtil.GetNewData7();
            var Response = Services.UploadValidate(new List<GarmentSupplierViewModel> { Vmodel5, Vmodel6, Vmodel7 }, null);
            Assert.Equal(Response.Item1, false);
        }


        //[Fact]
        //public async Task Should_Success_Get_Data_By_Id()
        //{
        //    GarmentSupplier model1 = await DataUtil.GetTestDataAsync();
        //    GarmentSupplier model2 = await DataUtil.GetTestDataAsync();
        //    var Response = Services.GetByIds(new List<int> { model1.Id, model2.Id });
        //    Assert.NotNull(Response);
        //}

        [Fact]
        public async Task Should_Success_Get_Data_By_Code()
        {
            GarmentSupplier model1 = await DataUtil.GetTestDataAsync();
            GarmentSupplier model2 = await DataUtil.GetTestDataAsync();

            var codes = string.Format("{0},{1}", model1.Code, model2.Code);
            var Response = Services.GetByCodes(codes);
            Assert.NotNull(Response);
        }
    }
}
