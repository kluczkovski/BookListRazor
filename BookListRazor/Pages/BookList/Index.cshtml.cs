using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly BookListRazorDBContext _db;


        public IndexModel(BookListRazorDBContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
           Books = await _db.Book.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            Book book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();
            Message = "Book deleted successfully";
            return RedirectToPage("Index");

        }
 
    }
}
