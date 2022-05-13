﻿using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using System;
using Xunit;
namespace Com.Efrata.Service.Core.Test.Services.BuyerTest
{
    [Collection("ServiceProviderFixture Collection")]
    public class BuyerBasicTest : BasicServiceTest<CoreDbContext, BuyerService, Buyer>
    {
        private static readonly string[] createAttrAssertions = { "Name", "Code", "Country", "Type", "Tempo","NIK" };
        private static readonly string[] updateAttrAssertions = { "Name", "Code", "Country", "Type", "Tempo","NIK" };
        private static readonly string[] existAttrCriteria = { "Code" };
        public BuyerBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }
        public override void EmptyCreateModel(Buyer model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Country = string.Empty;
            model.Type = string.Empty;
            model.NPWP = string.Empty;
            model.Tempo = -1;
            model.NIK = string.Empty;
        }

        public override void EmptyUpdateModel(Buyer model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Country = string.Empty;
            model.Type = string.Empty;
            model.NPWP = string.Empty;
            model.Tempo = -1;
            model.NIK = string.Empty;
        }

        public override Buyer GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Buyer()
            {
                Code = string.Format("BuyerCode {0}", guid),
                Name = string.Format("BuyerName {0}", guid),
                Country = string.Format("BuyerCountry {0}", guid),
                Type = string.Format("BuyerType {0}", guid),
                NPWP = string.Format("BuyerNPWP {0}", guid),
                NIK = string.Format("BuyerNIK {0}",guid )
            };
        }
    }
}
