using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleBookStore.Core.Abstractions.Interfaces;
using YuriiPasternak.SimpleBookStore.Core.Models;
using YuriiPasternak.SimpleBookStore.DataAccess.Entities;

namespace YuriiPasternak.SimpleBookStore.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();

            var books = bookEntities
            .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
            .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, title)
                    .SetProperty(b => b.Description, description)
                    .SetProperty(b => b.Price, price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books.
                Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
