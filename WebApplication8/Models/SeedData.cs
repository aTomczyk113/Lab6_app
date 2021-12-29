using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace WebApplication8.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }
                context.TodoItems.AddRange(
                    new Todoitems
                    {
                        Title = "Władca Pierścieni",
                        ReleaseDate = DateTime.Parse("1954-7-29"),
                        Category = "Fantasy",
                        Price = 40M
                    },
                    new Todoitems
                    {
                        Title = "Pani Jeziora",
                        ReleaseDate = DateTime.Parse("1999-1-1"),
                        Category = "Fantasy",
                        Price = 35M
                    },
                    new Todoitems
                    {
                        Title = "Przypadki Robinsona Kruzoe",
                        ReleaseDate = DateTime.Parse("1719-4-25"),
                        Category = "Przygodowe",
                        Price = 23M
                    },
                    new Todoitems
                    {
                        Title = "Harry Potter i Kamień Filozoficzny",
                        ReleaseDate = DateTime.Parse("1997-6-26"),
                        Category = "Epicka fantasy",
                        Price = 33M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}