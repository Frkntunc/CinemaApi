using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Film : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string FilmName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Required]
        public int PosterID { get; set; }
        public Poster Poster { get; set; }
    }
}
