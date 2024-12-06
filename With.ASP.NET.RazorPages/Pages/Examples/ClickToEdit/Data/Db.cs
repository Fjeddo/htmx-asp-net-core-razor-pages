namespace With.ASP.NET.RazorPages.Pages.Examples.ClickToEdit.Data;

public class Db
{
    public static List<ContactInfo> Contacts =
    [
        new()
        {
            ID = 1,
            FirstName = "Joe",
            LastName = "Blow",
            Email = "joe@blow.com"
        },
        new()
        {
            ID = 1,
            FirstName = "Charles",
            LastName = "Eagles",
            Email = "charles@eagles.com"
        },
        new()
        {
            ID = 1,
            FirstName = "John",
            LastName = "Bond",
            Email = "john@bond.com"
        },
    ];

    public static ContactInfo Upsert(ContactInfo contactInfo)
    {
        var existing = Contacts.FirstOrDefault(x => x.ID == contactInfo.ID);
        if (existing != null)
        {
            existing.Email = contactInfo.Email;
            existing.FirstName = contactInfo.FirstName;
            existing.LastName = contactInfo.LastName;
        }
        else
        {
            Contacts.Add(contactInfo);
        }

        return contactInfo;
    }
}
