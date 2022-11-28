﻿using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models = Com.Efrata.Service.Core.Lib.Models;

namespace Com.Efrata.Service.Core.Test.Services.SizeTests
{
    [Collection("ServiceProviderFixture Collection")]
    public class SizeBasicTest : BasicServiceTest<CoreDbContext, SizeService, Models.SizeModel>
    {
        private static readonly string[] createAttrAssertions = { "Size" };
        private static readonly string[] updateAttrAssertions = { "Size" };
        private static readonly string[] existAttrCriteria = { "Size" };

        public SizeBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }
        public override void EmptyCreateModel(Models.SizeModel model)
        {
            model.Size = string.Empty;
            model.SizeIdx = 0;
        }

        public override void EmptyUpdateModel(Models.SizeModel model)
        {
            model.Size = string.Empty;
            model.SizeIdx = 0;
        }

        public override Models.SizeModel GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new Models.SizeModel()
            {
                Size = string.Format("TEST {0}", guid),
                SizeIdx = 0,
            };
        }
    }
}