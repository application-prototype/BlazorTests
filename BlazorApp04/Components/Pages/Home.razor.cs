using Application.Services;
using Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorApp04.Components.Pages
{
    public partial class Home
    {
        [Inject] 
        protected IRequestService _service { get; set; }

        private string _testString { get; set; }

        protected async override void OnInitialized() 
        {
            await _service.GenerateNewRequest();
            var result = await _service.GetRequestById(new Guid("d7766f7f-3ee9-43f6-a10c-b0d8e95e51d2"));
            _testString = result.Id.ToString();
        }
    }
}