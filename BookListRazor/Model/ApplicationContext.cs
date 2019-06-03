using System;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
