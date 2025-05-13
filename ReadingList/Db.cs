public class Db
{
    public static List<Book> Books { get; set; } =
    [
        new()
        {
            author = "Astrid L",
            id = "C8B504C5-F1A0-43A6-B0C5-E01411F67655",
            title = "Pippi Långstrump"
        },
        new()
        {
            author = "Selma L",
            id = "E2F64680-AD0B-44C7-BFC1-2019BCF46FE9",
            title = "Nils H"
        },
        new()
        {
            author = "Olov S",
            id = "21EAB1EA-7439-4E58-9AE0-EDA2EC472255",
            title = "Slottet brinner"
        }
    ];
}
