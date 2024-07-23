using Application.Services;
using Infrastructure.Database;
using Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Abstractions;
using NSubstitute;
using static System.Reflection.Metadata.BlobBuilder;

namespace Infrastructure.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetRequestById()
        {
            // arrange
            var mockDbContext = Substitute.For<IAppDbContext>();

            

            var request = new RequestEntity
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                UpdatedBy = Guid.NewGuid(),
                UpdatedDateUTC = DateTime.UtcNow
            };

            
            var requests = new List<RequestEntity> { request };


            //var mockDbSet = Substitute.For<DbSet<RequestEntity>, IQueryable<RequestEntity>>();


            mockDbContext.Requests.Returns(requests.AsQueryable<RequestEntity>());

            var mockDownstream = Substitute.For<IDownstreamApi>();
            var service = new RequestService(mockDownstream, mockDbContext);

            // act
            var result = await service.GetWorkItemAsync();

            // assert
            Assert.Equal(request.Id, result.Id);
        }
    }
}