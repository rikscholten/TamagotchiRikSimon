using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TamagotchiWeb.TamagotchiService;

namespace TamagotchiWeb.ViewModels
{
    public class Tamagotchi
    {
        private TamagotchiService.Tamagotchi t;

        public Tamagotchi(TamagotchiService.Tamagotchi t)
        {
            Id = t.Id;
            Naam = t.Naam;
            Leeftijd = t.Leeftijd;
            Honger = t.Honger;
            Slaap = t.Slaap;
            Verveling = t.Verveling;
            Gezondheid = t.Gezondheid;
        }

        public Tamagotchi()
            {
            }

        [Required]
        public int Id { get; }

        [Required]
        [MinLength(0)]
        [MaxLength(50)]
        public string Naam { get; set; }

        [Required]
        public int Leeftijd { get; set; }


        [Required]
        [Range(0, 100)]
        public int Honger { get; set; }

        [Required]
        [Range(0, 100)]
        public int Slaap { get; set; }

        [Required]
        [Range(0, 100)]
        public int Verveling { get; set; }

        [Required]
        [Range(0, 100)]
        public int Gezondheid { get; set; }
    }
}