using System;
using System.ComponentModel.DataAnnotations;

namespace Kostuumotheek.Models
{
    public class Costume
    {
        public int ID { get; set; }

        [Display(Name = "Naam")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Omschrijving")]
        [StringLength(60, MinimumLength = 0)]
        public string Description { get; set; }
    }
}
