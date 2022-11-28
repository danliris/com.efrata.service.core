﻿using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.DataUtils;
using Com.Efrata.Service.Core.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Efrata.Service.Core.Test.Controllers.ColorTypeControllerTests
{
    [Collection("TestFixture Collection")]
    public class ColorTypeBasicTest : BasicControllerTest<CoreDbContext, ColorTypeService, ColorTypes, ColorTypeViewModel, ColorTypeDataUtil>
    {
        private static string URI = "v1/master/color-types";
        private static List<string> CreateValidationAttributes = new List<string> { };
        private static List<string> UpdateValidationAttributes = new List<string> { "Name", "Code" };

        public ColorTypeBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
