using System;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Models
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        //Why no { get; set; } in this case ?
        public string ISBN;
        public DateTime CreationDate { get; set; }
    }
}