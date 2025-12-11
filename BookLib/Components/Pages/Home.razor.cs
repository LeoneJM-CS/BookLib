using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using Microsoft.AspNetCore.Components;
namespace BookLib.Components.Pages
{
    public partial class ViewCurrentUsers
    {
        private List<UserCurrent>? currUser;

        // Add a property or field for Repository.
        // You must provide an instance of a repository that implements GetAllAsync().
        // Example: inject via property or constructor, or instantiate if available.

        // Option 1: If using dependency injection (recommended for Blazor)
        [Inject]
        public IUserCurrentRepos Repository { get; set; } = default!;

        protected async Task OnInitializedAsync()
        {
            currUser = await Repository.GetAllCurrentAsync();
        }
    }
}