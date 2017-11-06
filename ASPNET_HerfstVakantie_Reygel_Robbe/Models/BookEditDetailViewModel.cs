using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Models
{
    public class BookEditDetailViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        //Regex to make sure right ISBN format is applied
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$")]
        public string ISBN { get; set; }
        public DateTime CreationDate { get; set; }
        public int Id { get; set; }
        public string Genre { get; set; }
        public int? GenreId { get; set; }
        //Dropdown selection
        public List<SelectListItem> Genres { get; set; }

    }
}