using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TamoService.Data
{
    public class TamoContext :DbContext
    {
        public TamoContext() : base("name=default")
        {

        }

        public DbSet<TamagotchiDomain.Tamagot> Tamagots { get; set; }

    }
}