using Infrastructure.Database;
using Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;

namespace Application.Services
{
    // interface
    public interface IRequestService
    {
        Task<RequestEntity> GetWorkItemAsync();
    }

    // implementation
    public class RequestService : IRequestService
    {
        private IDownstreamApi _downstreamWebApi;
        private IAppDbContext _dbContext;
        public RequestService(IDownstreamApi downstreamApi, IAppDbContext dbContext)
        {
            _downstreamWebApi = downstreamApi;
            _dbContext = dbContext;
        }

        public async Task<RequestEntity> GetWorkItemAsync()
        {
            var url = "api/WorkItems/request";

            //var test = await _downstreamWebApi.GetForUserAsync<string>("TemplateApi", options => options.RelativePath = url);
            var test = await _dbContext.Requests.FirstOrDefaultAsync();
            return test ?? new RequestEntity();
        }

    }
}
