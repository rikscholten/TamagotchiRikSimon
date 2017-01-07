using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TamagotchiWeb.ServiceReference1;

namespace TamagotchiWeb.ViewModels
{
    public class Tamagotchi
    {
        private TamagotchiDomain.Tamagot t;

        public Tamagotchi(ServiceReference1.Tamagotchi t)
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
        
        
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public DateTime Leeftijd { get; set; }


        [Required]
        public int Honger { get; set; }

        [Required]
        public int Slaap { get; set; }

        [Required]
        public int Verveling { get; set; }

        [Required]
        public int Gezondheid { get; set; }
        
        public string Status { get; set; }
    }
}