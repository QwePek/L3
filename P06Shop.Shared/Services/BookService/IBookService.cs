using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetBookAsync();
        Task<ServiceResponse<Book>> GetBookByID(int ID);
        Task<ServiceResponse<Book>> AddBook(Book book);
        Task<ServiceResponse<Book>> DeleteBook(int ID);
        Task<ServiceResponse<Book>> UpdateBook(Book book);

    }
}
