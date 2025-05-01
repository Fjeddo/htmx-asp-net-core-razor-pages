namespace With.ASP.NET.RazorPages.Pages.Examples.BulkUpdate.Data;

public class Db : DbBase<Contact>
{
    public static List<Contact> Contacts =>
        TheList ??=
        [
            new()
            {
                Name = "Joe Smith",
                Email = "joe@smith.org",
                Active = true
            },
            new()
            {
                Name = "Angie MacDowell",
                Email = "angie@macdowell.org",
                Active = true
            },
            new()
            {
                Name = "Fuqua Tarkenton",
                Email = "fuqua@tarkenton.org",
                Active = true
            },
            new()
            {
                Name = "Kim Yee",
                Email = "kim@yee.org",
                Active = false
            }
        ];
}