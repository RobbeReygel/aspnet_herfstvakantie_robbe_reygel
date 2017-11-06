using System.Collections.Generic;
using System.Linq;
using ASPNET_HerfstVakantie_Reygel_Robbe.Data;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;
using ASPNET_HerfstVakantie_Reygel_Robbe.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Controllers
{
    //List of functions that query the data in the memory
    public class BookService : IBookService
    {
        private readonly EntityContext _entityContext;

        public BookService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        private IIncludableQueryable<Book, Author> GetFullGraph()
        {
            return _entityContext.Books.Include(x => x.Genre).Include(x => x.Authors).ThenInclude(x => x.Author);
        }

        public List<Book> GetAllBooks()
        {
            return GetFullGraph().OrderBy(x => x.Id).ToList();
        }

        public Book GetBookById(int id)
        {
            return GetFullGraph()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Genre> GetAllGenres()
        {
            return _entityContext.Genre.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _entityContext.Genre.Find(id);
        }

        public void Persist(Book book)
        {
            if (book.Id == 0)
                _entityContext.Books.Add(book);
            else
                _entityContext.Books.Update(book);
            _entityContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toDelete = GetBookById(id);
            if (toDelete != null)
            {
                _entityContext.Books.Remove(toDelete);
                _entityContext.SaveChanges();
            }
        }
    }
}