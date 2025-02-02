using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.EditRow.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.EditRow
{
    public class PeopleModel : PageModel
    {
        public List<Person> People { get; set; } = Db.People;

        public IActionResult OnPut(string id, string name, string email)
        {
            var identity = int.Parse(id);
            var person = People.Single(x => x.Id == identity);

            person.Name = name;
            person.Email = email;

            return Partial("_RowTemplate", person);
        }
    }
}
