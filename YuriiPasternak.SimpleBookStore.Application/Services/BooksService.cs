using YuriiPasternak.SimpleBookStore.Core.Abstractions.Interfaces;
using YuriiPasternak.SimpleBookStore.Core.Models;

namespace YuriiPasternak.SimpleBookStore.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string tytle, string description, decimal price)
        {
            return await _booksRepository.Update(id, tytle, description, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepository.Delete(id);
        }

    }
}
