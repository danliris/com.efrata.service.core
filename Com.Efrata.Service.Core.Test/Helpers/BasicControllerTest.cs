﻿using Com.Efrata.Service.Core.Lib.Helpers;
using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Test.Interface;
using Com.Moonlay.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Efrata.Service.Core.Test.Helpers
{
    public abstract class BasicControllerTest<TDbContext, TService, TModel, TViewModel, TDataUtil>
         where TDbContext : DbContext
         where TService : BasicService<TDbContext, TModel>, IMap<TModel, TViewModel>
         where TModel : StandardEntity, IValidatableObject, new()
         where TDataUtil : BasicDataUtil<TDbContext, TService, TModel>, IEmptyData<TViewModel>
         where TViewModel : BasicViewModel
    {
        private const string MediaType = "application/json";
        private readonly string URI;
        private readonly List<string> CreateValidationAttributes;
        private readonly List<string> UpdateValidationAttributes;

        protected TestServerFixture TestFixture { get; set; }

        public BasicControllerTest(TestServerFixture fixture, string URI, List<string> CreateValidationAttributes, List<string> UpdateValidationAttributes)
        {
            TestFixture = fixture;
            this.URI = URI;
            this.CreateValidationAttributes = CreateValidationAttributes;
            this.UpdateValidationAttributes = UpdateValidationAttributes;
        }

        protected HttpClient Client
        {
            get { return this.TestFixture.Client; }
        }

        protected TService Service
        {
            get { return (TService)this.TestFixture.Service.GetService(typeof(TService)); }

        }

        protected TDataUtil DataUtil
        {
            get { return (TDataUtil)this.TestFixture.Service.GetService(typeof(TDataUtil)); }
        }

        [Fact]
        public async Task Should_Success_Get_All_Data()
        {
            var response = await this.Client.GetAsync(URI);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

            Assert.True(result.ContainsKey("apiVersion"));
            Assert.True(result.ContainsKey("message"));
            Assert.True(result.ContainsKey("data"));
            Assert.True(result["data"].GetType().Name.Equals("JArray"));
        }

        [Fact]
        public async Task Should_Success_Get_Data_By_Id()
        {
            TModel Model = await DataUtil.GetTestDataAsync();
            TViewModel ViewModel = Service.MapToViewModel(Model);

            var response = await this.Client.GetAsync(string.Concat(URI, "/", ViewModel.Id));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

            Assert.True(result.ContainsKey("apiVersion"));
            Assert.True(result.ContainsKey("message"));
            Assert.True(result.ContainsKey("data"));
            Assert.True(result["data"].GetType().Name.Equals("JObject"));
        }

        [Fact]
        public async Task Should_Success_Create_Data()
        {
            TViewModel ViewModel = Service.MapToViewModel(DataUtil.GetNewData());
            var response = await this.Client.PostAsync(URI, new StringContent(JsonConvert.SerializeObject(ViewModel).ToString(), Encoding.UTF8, MediaType));
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseLocationHeader = await this.Client.GetAsync(response.Headers.Location.OriginalString);
            Assert.Equal(HttpStatusCode.OK, responseLocationHeader.StatusCode);

            var json = responseLocationHeader.Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

            Assert.True(result.ContainsKey("apiVersion"));
            Assert.True(result.ContainsKey("message"));
            Assert.True(result.ContainsKey("data"));
            Assert.True(result["data"].GetType().Name.Equals("JObject"));
        }

        [Fact]
        public async Task Should_Success_Update_Data()
        {
            TModel Model = await DataUtil.GetTestDataAsync();
            TViewModel ViewModel = Service.MapToViewModel(Model);

            var response = await this.Client.PutAsync(string.Concat(URI, "/", ViewModel.Id), new StringContent(JsonConvert.SerializeObject(ViewModel).ToString(), Encoding.UTF8, MediaType));
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Should_Success_Delete_Data()
        {
            TModel Model = await DataUtil.GetTestDataAsync();
            TViewModel ViewModel = Service.MapToViewModel(Model);

            var response = await this.Client.DeleteAsync(string.Concat(URI, "/", ViewModel.Id));
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Should_Error_Create_With_Empty_Data()
        {
            TViewModel ViewModel = DataUtil.GetEmptyData();

            var response = await this.Client.PostAsync(URI, new StringContent(JsonConvert.SerializeObject(ViewModel).ToString(), Encoding.UTF8, MediaType));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

            Assert.True(result.ContainsKey("apiVersion"));
            Assert.True(result.ContainsKey("message"));
            Assert.True(result.ContainsKey("error"));
            Assert.True(result["error"].GetType().Name.Equals("JObject"));

            JObject error = (JObject)result["error"];
            foreach (string arg in CreateValidationAttributes)
            {
                var prop = error.Properties().FirstOrDefault(c => c.Name.Equals(arg, StringComparison.CurrentCultureIgnoreCase));
                Assert.NotNull(prop);
            }
        }

        [Fact]
        public async Task Should_Error_Update_With_Empty_Data()
        {
            TViewModel EmptyData = DataUtil.GetEmptyData();
            TModel Model = await DataUtil.GetTestDataAsync();
            TViewModel ViewModel = Service.MapToViewModel(Model);
            EmptyData.Id = ViewModel.Id;

            var response = await this.Client.PutAsync(string.Concat(URI, "/", EmptyData.Id), new StringContent(JsonConvert.SerializeObject(EmptyData).ToString(), Encoding.UTF8, MediaType));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());

            Assert.True(result.ContainsKey("apiVersion"));
            Assert.True(result.ContainsKey("message"));
            Assert.True(result.ContainsKey("error"));
            Assert.True(result["error"].GetType().Name.Equals("JObject"));

            JObject error = (JObject)result["error"];
            foreach (string arg in UpdateValidationAttributes)
            {
                var prop = error.Properties().FirstOrDefault(c => c.Name.Equals(arg, StringComparison.CurrentCultureIgnoreCase));
                Assert.NotNull(prop);
            }
        }

        [Fact]
        public async Task Should_Return_404_Get_Data_With_Unknown_Id()
        {
            var response = await this.Client.GetAsync(string.Concat(URI, "/", 0));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Should_Return_400_Update_Data_With_Invalid_Id()
        {
            TModel Model = await DataUtil.GetTestDataAsync();
            TViewModel ViewModel = Service.MapToViewModel(Model);

            var response = await this.Client.PutAsync(string.Concat(URI, "/", 0), new StringContent(JsonConvert.SerializeObject(ViewModel).ToString(), Encoding.UTF8, MediaType));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_Return_404_Delete_Data_With_Unknown_Id()
        {
            var response = await this.Client.DeleteAsync(string.Concat(URI, "/", 0));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
