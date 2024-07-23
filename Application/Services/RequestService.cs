using Infrastructure.Database;
using Infrastructure.Database.Entities;
using Infrastructure.Database.Models;
using Infrastructure.Database.Repositories;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;

namespace Application.Services
{
    // interface
    public interface IRequestService
    {
        Task<string> GetWorkItemAsync();
        public Task GenerateNewRequest();
        public Task<RequestEntity> GetRequestById(Guid requestId);
    }

    // implementation
    public class RequestService : IRequestService
    {
        private IDownstreamApi _downstreamWebApi;
        private IRequestDbContext _requestDbContext;
        private ISubRequestDbContext _subRequestDbContext;
        public RequestService(IDownstreamApi downstreamApi, IRequestDbContext dbContext, ISubRequestDbContext subRequestDbContext)
        {
            _downstreamWebApi = downstreamApi;
            _requestDbContext = dbContext;
            _subRequestDbContext = subRequestDbContext;
        }

        public async Task<string> GetWorkItemAsync()
        {
            var url = "api/WorkItems/request";

            //var test = await _downstreamWebApi.GetForUserAsync<string>("TemplateApi", options => options.RelativePath = url);

            return string.Empty;
        }

        public async Task GenerateNewRequest()
        {
            var newRequest = new RequestEntity()
            {
                Id = Guid.NewGuid(),
                CreatedById = Guid.NewGuid(),
                DateCreatedUtcDte = DateTime.UtcNow,
                UpdatedById = Guid.NewGuid(),
                DateUpdatedUtcDte = DateTime.UtcNow,
                
            };
            await _requestDbContext.Add<RequestEntity>(newRequest);

            var sub = new SubRequestEntity()
            {
                Id = Guid.NewGuid(),
                CreatedById = Guid.NewGuid(),
                DateCreatedUtcDte = DateTime.UtcNow,
                UpdatedById = Guid.NewGuid(),
                DateUpdatedUtcDte = DateTime.UtcNow,
                RequestId = newRequest.Id,
                //Request = newRequest
            };
            await _subRequestDbContext.Add<SubRequestEntity>(sub);
        }

        public async Task<RequestEntity> GetRequestById(Guid requestId)
        {
            var result = await _requestDbContext.GetRequestById(requestId);
            return result;
        }
    }
}
