using System;
using System.Collections.Generic;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Models
{
    public class BookListViewModel
    {
        //list of all books
        public List<BookDetailViewModel> Books { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}