﻿using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Efrata.Service.Core.Test.Services.OrderTypeTest
{
    [Collection("ServiceProviderFixture Collection")]
    public class OrderTypeBasicTest : BasicServiceTest<CoreDbContext, OrderTypeService, OrderType>
    {
        private static readonly string[] createAttrAssertions = { "Name","Unit" };
        private static readonly string[] updateAttrAssertions = { "Name","Unit" };
        private static readonly string[] existAttrCriteria = { "Name" };

        public OrderTypeBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(OrderType model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
           model.Unit = string.Empty;
        }

        public override void EmptyUpdateModel(OrderType model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
           model.Unit = string.Empty;
        }

        public override OrderType GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();

            return new OrderType()
            {
                Name = string.Format("Order {0}", guid),
                Code = string.Format("Code {0}", guid),
                Unit = string.Format("Unit {0}", guid),
                Remark = "REMARK",
            };
        }
    }
}
