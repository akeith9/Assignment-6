using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SeedData
    {
        //creating method to ensure that databse is populated
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BooksContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BooksContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if not populated, then insert this data
            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    {
                        Title = "Les Miserables",
                        FirstName = "Victor",
                        MiddleName = "",
                        LastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },

                    new Books
                    {
                        Title = "Team of Rivals",
                        FirstName = "Doris",
                        MiddleName = "Kearns",
                        LastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.48,
                        Pages = 944
                    },

                    new Books
                    {
                        Title = "The Snowball",
                        FirstName = "Alice",
                        MiddleName = "",
                        LastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },

                    new Books
                    {
                        Title = "American Ulysses",
                        FirstName = "Ronald",
                        MiddleName = "C.",
                        LastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },

                    new Books
                    {
                        Title = "Unbroken",
                        FirstName = "Laura",
                        MiddleName = "",
                        LastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528
                    },

                    new Books
                    {
                        Title = "The Great Train Robbery",
                        FirstName = "Michael",
                        MiddleName = "",
                        LastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },

                    new Books
                    {
                        Title = "Deep Work",
                        FirstName = "Cal",
                        MiddleName = "",
                        LastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },

                    new Books
                    {
                        Title = "It's Your Ship",
                        FirstName = "Michael",
                        MiddleName = "",
                        LastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },

                    new Books
                    {
                        Title = "The Virgin Way",
                        FirstName = "Richard",
                        MiddleName = "",
                        LastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Pages = 400
                    },

                    new Books
                    {
                        Title = "Sycamore Row",
                        FirstName = "John",
                        MiddleName = "",
                        LastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },

                    new Books
                    {
                        Title = "The Hobbit",
                        FirstName = "J.R.R.",
                        MiddleName = "",
                        LastName = "Tolkien",
                        Publisher = "HMH Books",
                        ISBN = "978-0547928227",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 14.99,
                        Pages = 310
                    },

                    new Books
                    {
                        Title = "Harry Potter and the Deathly Hallows",
                        FirstName = "J.K.",
                        MiddleName = "",
                        LastName = "Rowling",
                        Publisher = "Arthur A. Levine Books",
                        ISBN = "978-0545139700",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 10.49,
                        Pages = 784
                    },

                    new Books
                    {
                        Title = "How to Win Friends and Influence People",
                        FirstName = "Dale",
                        MiddleName = "",
                        LastName = "Carnegie",
                        Publisher = "Pocket Books",
                        ISBN = "978-0671027032",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 11.85,
                        Pages = 288
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
