using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TamagotchiDomain;

namespace TamagotchiService.Data
{
    public class TamagotchiContext : DbContext
    {

            public TamagotchiContext() : base("name=TamagotchiSimonRik")
            {

            }

            public DbSet<Tamagot> Tamagotchi { get; set; }

        
    }
}