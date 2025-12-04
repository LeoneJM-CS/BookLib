using BookLib.Domain.Entities;
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
