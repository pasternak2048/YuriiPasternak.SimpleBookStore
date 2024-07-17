using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleBookStore.DataAccess.Entities;

namespace YuriiPasternak.SimpleBookStore.DataAccess
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }

        public DbSet<BookEntity> Books { get; set; }
    }
}
