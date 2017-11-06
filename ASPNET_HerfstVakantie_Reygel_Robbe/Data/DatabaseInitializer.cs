using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(EntityContext entityContext)
        {
            entityContext.Database.EnsureCreated();

            //Create genres
            var genres = new List<Genre>
            {
                new Genre() {Name = "Drama"},
                new Genre() {Name = "Horror"},
                new Genre() {Name = "Actie"},

            };

            //Create 8 Authors
            var authors = new List<Author>();
            for (var i = 0; i < 8; i++)
            {
                authors.Add(new Author {FirstName = $"Author First Name {i}", LastName = $"Author Last Name {i}"});
            }

            //Create 4 books connected to their author(s) & genre
            var books = new List<Book>();
            for (var i = 0; i < 4; i++)
            {
                var authorBook = new AuthorBook()
                {
                    Author = authors[i]
                };
                Genre genre = null;
                if (i % 4 == 0)
                {
                    genre = genres[0];
                }
                else if (i % 3 == 0)
                {
                    genre = genres[1];
                }
                else if (i % 2 == 0)
                {
                    genre = genres[2];
                }
                books.Add(new Book {Title = $"Book {i}", Authors = new List<AuthorBook> {authorBook}, Genre = genre, CreationDate = DateTime.Now.AddYears(-1).AddDays(i)});
            }

            //Set book with ID 0 to custom author "me"
            //var me = new Author {FirstName = "Robbe", LastName = "Reygel"};
            //books[0].Authors.Add(new AuthorBook() { Author = me});
            
            entityContext.Genre.AddRange(genres);
            entityContext.Authors.AddRange(authors);
            entityContext.Books.AddRange(books);
            entityContext.SaveChanges();
        }
    }
}