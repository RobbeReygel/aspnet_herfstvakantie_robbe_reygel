using System;
using System.Collections.Generic;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Genre Genre { get; set; }
        public string ISBN { get; set; }
        public DateTime CreationDate { get; set; }
        //List of (multiple) authors
        public virtual List<AuthorBook> Authors { get; set; }
    }
}