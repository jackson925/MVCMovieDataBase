using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMovieDB.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Movie Genre")]
        public string Genre { get; set; }
        [Required]
        [Display(Name = "Date Released")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }


    }

    //  /movies/random
}