using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Project.App;
using Project.App.Common;
using Project.App.MainObject1Module.Contracts;
using Xunit;

namespace Project.IntegrationTests
{
    public class MainObject1CrudTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MainObject1CrudTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
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
        }

        [Fact]
        public async Task Post_ShouldReturn201AndResponseObject()
        {
            var client = _factory.CreateClient();
            var createRequest = new MainObject1CreateModel
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Message = "post-test"
            };
            var response = await client.PostAsJsonAsync(ApiRoutes.MainObject1.Post, createRequest);
            var createdObject = await response.Content.ReadAsAsync<MainObject1Response>();

            response.StatusCode.Should().Be(201);
            createdObject.Should().BeEquivalentTo(createRequest);
        }
        
        [Theory]
        [InlineData()]
        public async Task StatusCodeShouldCorrespondWithExpected(Guid id,DateTime dateTime,string message,StatusCodes expected)
        {
            var client = _factory.CreateClient();
            var createRequest = new MainObject1CreateModel
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Message = "post-test"
            };
            var response = await client.PostAsJsonAsync(ApiRoutes.MainObject1.Post, createRequest);
            var createdObject = await response.Content.ReadAsAsync<MainObject1Response>();

            response.StatusCode.Should().Be(201);
            createdObject.Should().BeEquivalentTo(createRequest);
        }
    }
}