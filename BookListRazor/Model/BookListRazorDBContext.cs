using System;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
    public class BookListRazorDBContext : DbContext
    {
        public BookListRazorDBContext(DbContextOptions<BookListRazorDBContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
