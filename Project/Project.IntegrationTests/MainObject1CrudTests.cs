using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Project.App;
using Project.App.Common;
using Project.App.MainObject1Module.Contracts;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Project.IntegrationTests
{
    public class MainObject1CrudTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public MainObject1CrudTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
        }

        [Fact]
        public async Task SanityCheck()
        {
            true.Should().BeTrue();
        }

        [Fact]
        public async Task Get_ShouldReturn200()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(ApiRoutes.MainObject1.Get);

            response.StatusCode.Should().Be(200);
            var responseObjects = await response.Content.ReadAsAsync<List<MainObject1Response>>();
            responseObjects.Should().AllBeOfType<MainObject1Response>();
            _output.WriteLine(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Post_ShouldReturn201AndResponseObject()
        {
            var client = _factory.CreateClient();
            var createRequest = new MainObject1CreateModel
            {
                Id = Guid.NewGuid(),
                Message = "post-test"
            };
            
            var response = await client.PostAsJsonAsync(ApiRoutes.MainObject1.Post, createRequest);
            var createdObject = await response.Content.ReadAsAsync<MainObject1Response>();

            response.StatusCode.Should().Be(201);
            createdObject.Should().BeEquivalentTo(createRequest);
            
            _output.WriteLine(await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData("AF25DB44-DE7B-4DFE-A573-DC3AA22AAE1D", "message", 201)]
        [InlineData("AF25DB44-DE7B-4DFE-A573-DC3AA22AAE1D", "hello world", 201)]
        [InlineData("AF25DB44-DE7B-4DFE-A573-DC3AA22AAE1D", "", 400)]
        [InlineData(null, "hello world", 201)]
        [InlineData(null, null, 400)]
        public async Task Post_StatusCodeShouldBeExpectedValue(string id, string message, int expected)
        {
            var client = _factory.CreateClient();
            var createRequest = new MainObject1CreateModel
            {
                Message = message
            };

            if (id != null) createRequest.Id = Guid.Parse(id);

            var response = await client.PostAsJsonAsync(ApiRoutes.MainObject1.Post, createRequest);

            response.StatusCode.Should().Be(expected);
            if (response.IsSuccessStatusCode)
            {
                var createdObject = await response.Content.ReadAsAsync<MainObject1Response>();
                createdObject.Id.Should().NotBe(default).And.NotBeEmpty();
                createdObject.Message.Should().NotBe(default).And.NotBeNullOrEmpty();
            }

            _output.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}