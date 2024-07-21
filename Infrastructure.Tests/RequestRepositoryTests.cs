using Infrastructure.Database.Entities;
using Infrastructure.Database.Repositories;
using NSubstitute;

namespace Infrastructure.Tests
{

    public class RequestRepositoryTests
    {
        public RequestRepositoryTests()
        {
            // set up?
        }

        [Fact]
        public async Task GetByValidId_ReturnsRquest()
        {
            // arrange
            // set up mock data
            var data = new List<RequestEntity>
            {
                new RequestEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedById = Guid.NewGuid(),
                    DateCreatedUtcDte = DateTime.UtcNow,
                    UpdatedById = Guid.NewGuid(),
                    DateUpdatedUtcDte = DateTime.UtcNow
                },
                //new RequestEntity
                //{
                //    Id = Guid.NewGuid(),
                //    CreatedById = Guid.NewGuid(),
                //    DateCreatedUtcDte = DateTime.UtcNow,
                //    UpdatedById = Guid.NewGuid(),
                //    DateUpdatedUtcDte = DateTime.UtcNow
                //}
            }.AsQueryable();

            var request = new RequestEntity
            {
                Id = Guid.NewGuid(),
                CreatedById = Guid.NewGuid(),
                DateCreatedUtcDte = DateTime.UtcNow,
                UpdatedById = Guid.NewGuid(),
                DateUpdatedUtcDte = DateTime.UtcNow
            };

            //var mockSet = Substitute.For<DbSet<RequestEntity>, IQueryable<RequestEntity>>();

            // mock dbcontext and repo to return the mock data
            var mockDb = Substitute.For<NPoco.IDatabase>();
            var mockRepo = new RequestRepository(mockDb);
        
            mockDb.SingleByIdAsync<RequestEntity>(request.Id).Returns(request);

            // act
            var result = await mockRepo.GetById(request.Id);

            // assert
            Assert.NotNull(result);
            Assert.Equal(request.Id, result.Id);
        }
    }
}