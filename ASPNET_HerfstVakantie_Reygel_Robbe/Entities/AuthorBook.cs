namespace ASPNET_HerfstVakantie_Reygel_Robbe.Entities
{
    public class AuthorBook
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}