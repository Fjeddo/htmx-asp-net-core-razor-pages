namespace With.ASP.NET.RazorPages.Pages.Examples.DeleteRow.Data;

public class Db
{
    public static List<Person> People { get; } =
    [
        new()
        {
            Id = 0,
            Name = "Joe Smith",
            Email = "joe@smith.org",
            Status = "Active"
        },
        new()
        {
            Id = 1,
            Name = "Angie MacDowell",
            Email = "angie@macdowell.org",
            Status = "Active"
        },
        new()
        {
            Id = 2,
            Name = "Fuqua Tarkenton",
            Email = "fuqua@tarkenton.org",
            Status = "Active"
        },
        new()
        {
            Id = 3,
            Name = "Kim Yee",
            Email = "kim@yee.org",
            Status = "Inactive"
        }
    ];

}