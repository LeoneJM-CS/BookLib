using BookLib.App.Interfaces;
using BookLib.Domain.Entities;
using Microsoft.AspNetCore.Components;
namespace BookLib.Components.Pages
{
    public partial class ViewBooks
    {   
        private List<Book>? books;
        protected override async Task OnInitializedAsync()
        {
            books = await Repository.GetAllAsync();
        }
    }
}
