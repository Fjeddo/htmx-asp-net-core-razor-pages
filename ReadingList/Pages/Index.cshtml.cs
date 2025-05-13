using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReadingList.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return Page();
        }

        if (id == "-1")
        {
            return Partial("_List", Db.Books.ToArray());
        }

        return Partial("_Book", Db.Books.FirstOrDefault(x => x.id == id));
    }

    public IActionResult OnPostSearch()
    {
        var search = Request.Form["search"];

        return Partial("_List", Db.Books.Where(x => 
            x.title.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
            x.author.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToArray());
    }
        
    public IActionResult OnPost()
    {
        var title = Request.Form["title"];
        var author = Request.Form["author"];

        var book = new Book {author = author, title = title, id = Guid.NewGuid().ToString()};
        Db.Books.Add(book);

        return RedirectToPage("Index", new {id = book.id});
    }

    public IActionResult OnDelete(string id)
    {
        Db.Books.RemoveAll(x => x.id == id);

        return Partial("_Empty");
    }

    public IActionResult OnPut(string id)
    {
        var book = Db.Books.FirstOrDefault(x => x.id == id);
        if (book != null)
        {
            book.author = Request.Form["author"];
            book.title = Request.Form["title"];
        }

        return Partial("_Book", book);
    }

    public IActionResult OnGetEdit(string id) => Partial("_Edit", Db.Books.FirstOrDefault(x => x.id == id));
}