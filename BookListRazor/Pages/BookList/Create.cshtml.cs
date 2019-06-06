using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Model;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly BookListRazorDBContext _db;

        public CreateModel(BookListRazorDBContext bookListRazorDBContext)
        {
            _db = bookListRazorDBContext;
        }


        //Before the handlers page
        public void OnGet()
        {
        }



        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //TESTE
            if (Book.ISBN =="66")
            {
                Message = "ISBN is wrong!!!";
                return Page();
            }

            _db.Book.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Book was Create with success!!!";
            return RedirectToPage("Index");
        }

    }
}
