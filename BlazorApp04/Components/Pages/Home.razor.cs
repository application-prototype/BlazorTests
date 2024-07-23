using Application.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp04.Components.Pages
{
    public partial class Home
    {
        [Inject] 
        protected IRequestService _service { get; set; }
        private string _testString { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var test = await _service.GetWorkItemAsync();
        }

    }
}