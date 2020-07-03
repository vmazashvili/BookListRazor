using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        /*We use IActionResult because we will be redirecting to the new page
         Also, we could use OnPost(Book Bookobj), but, as we can see that we have book object already on line 22, we can bind and 
        dont write it instead. Meaning we can write code presented in line 21 and thats all*/


        public async Task<IActionResult> OnPost()
        {
            /*Checks if the book name field is valid. It is checked on serverside, 
             however, in Create.cshtml, there is a reference to _ValidationScriptsPartial.cshtml
            which checks modelstate on client side*/
            if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}