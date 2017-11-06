using System.Collections.Generic;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Services
{
    //Data stored in memory
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void Persist(Book book);
        void Delete(int id);
    }
}