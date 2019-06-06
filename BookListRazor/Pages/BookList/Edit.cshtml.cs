using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly BookListRazorDBContext _db;


        public EditModel(BookListRazorDBContext db)
        {
            _db = db;
        }


        public async Task OnGet(int id)
        {
            Book =  await _db.Book.FindAsync(id);
        }


        public async Task<IActionResult> OnPost(int Id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.Update(book);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
           
        }

   
    }
}
