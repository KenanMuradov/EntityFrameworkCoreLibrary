using EntityFrameworkCoreLibrary.Contexts;
using EntityFrameworkCoreLibrary.Enums;
using EntityFrameworkCoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EntityFrameworkCoreLibrary;

public class Program
{
    static void Main()
    {
        var context = new LibraryDbContext();

        context.Themes.AddRange
            (
            new Theme()
            {
                Name = "Programming",
            },
            new Theme()
            {
                Name = "Web Design"
            },
            new Theme()
            {
                Name = "C++"
            }
            );

        context.SaveChanges();

        Console.WriteLine(context.Themes.First().Name);

        var themeIdMax = context.Themes.Max(t => t.Id);

        context.Books.AddRange
            (
            new Book()
            {
                Name = "C# in a Nutshell",
                ThemeId = Random.Shared.Next(1, themeIdMax),
                PageCount = Random.Shared.Next(1000),
            },
            new Book()
            {
                Name = "Programming in C++",
                ThemeId = Random.Shared.Next(1, themeIdMax),
                PageCount = Random.Shared.Next(1000),
                Status = DataStatus.Updated
            },
            new Book()
            {
                Name = "Basics Of Visual Basic",
                ThemeId = Random.Shared.Next(1, themeIdMax),
                PageCount = Random.Shared.Next(1000),
                Status = DataStatus.Deleted
            }
            );


        context.SaveChanges();

        var list = context.Books.Select(b => new
        {
            b.Id,
            b.Name,
            b.PageCount,
            b.ThemeId,
            b.Status
        });


        foreach (var book in list)
        {
            Console.WriteLine(@$"{book.Id}
{book.Name}
{book.PageCount}
{book.ThemeId}
{book.Status}
");
        }
    }
}