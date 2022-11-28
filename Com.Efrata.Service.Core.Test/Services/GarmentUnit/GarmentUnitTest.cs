﻿using Com.Efrata.Service.Core.Test.Helpers;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Efrata.Service.Core.Test.Services.GarmentUnit
{
	[Collection("ServiceProviderFixture Collection")]
	public class GarmentUnitTest : BasicServiceTest<CoreDbContext, GarmentUnitService, Unit>
	{
		private static readonly string[] createAttrAssertions = { "Name" };
		private static readonly string[] updateAttrAssertions = { "Name" };
		private static readonly string[] existAttrCriteria = { "Code" };
		public GarmentUnitTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
		{
		}
		public override void EmptyCreateModel(Unit model)
		{
			model.Code = string.Empty;
			model.Name = string.Empty;

		}

		public override void EmptyUpdateModel(Unit model)
		{
			model.Code = string.Empty;
			model.Name = string.Empty;

		}
		public override Unit GenerateTestModel()
		{
			string guid = Guid.NewGuid().ToString();

			return new Unit()
			{
				Code = guid,
				Name = string.Format("TEST {0}", guid),
			};
		}
	}
}
