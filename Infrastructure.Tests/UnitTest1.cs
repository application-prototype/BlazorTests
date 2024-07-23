using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Database;
using Infrastructure.Database.Models;
using System.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Abstractions;
using Application.Services;

namespace Infrastructure.Tests
{
    public class InfrastructureTests
    {
        private TestHelper _helper;
        public InfrastructureTests()
        {
            _helper = new TestHelper();

        }

        [Fact]
        public async Task GetRequestById()
        {
            // arrange
            var mockDbContext = _helper._dbContext;

            var request = new RequestEntity
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = Guid.NewGuid(),
                UpdatedDateUTC = DateTime.UtcNow
            };

           
            await mockDbContext.Requests.AddAsync(request);
            await mockDbContext.SaveChangesAsync();

            var mockDownstream = Substitute.For<IDownstreamApi>();
            var service = new RequestService(mockDownstream, mockDbContext);

            // act
            var result = await service.GetWorkItemAsync();

            // assert
            Assert.Equal(request.Id, result.Id);
        }
    }
}