﻿namespace With.ASP.NET.RazorPages.Pages.Examples.EditRow.Data;

public class Db : DbBase<Person>
{
    public static List<Person> People =>
        TheList ??=
        [
            new()
            {
                Id = 0,
                Name = "Joe Smith",
                Email = "joe@smith.org",
            },
            new()
            {
                Id = 1,
                Name = "Angie MacDowell",
                Email = "angie@macdowell.org",
            },
            new()
            {
                Id = 2,
                Name = "Fuqua Tarkenton",
                Email = "fuqua@tarkenton.org",
            },
            new()
            {
                Id = 3,
                Name = "Kim Yee",
                Email = "kim@yee.org",
            }
        ];
}