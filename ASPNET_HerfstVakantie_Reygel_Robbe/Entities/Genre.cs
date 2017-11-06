using System.Collections.Generic;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //List of books with this genre
        public virtual IEnumerable<Book> Books { get; set; }
    }
}