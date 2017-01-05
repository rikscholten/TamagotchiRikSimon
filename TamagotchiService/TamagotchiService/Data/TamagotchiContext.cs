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
            public TamagotchiContext() : base("name=default")
            {

            }

            public DbSet<TamagotchiDomain.Tamagot> Tamagotchi { get; set; }

        
    }
}