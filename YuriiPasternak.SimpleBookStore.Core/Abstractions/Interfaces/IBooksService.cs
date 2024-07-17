using YuriiPasternak.SimpleBookStore.Core.Models;

namespace YuriiPasternak.SimpleBookStore.Core.Abstractions.Interfaces
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string tytle, string description, decimal price);
    }
}
