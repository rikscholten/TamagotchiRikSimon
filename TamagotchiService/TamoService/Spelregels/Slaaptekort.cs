using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamoService.Spelregels
{
    public class Slaaptekort : ISpelregel
    {
        public Tamagotchi ExecSpelregel(Tamagotchi tamagochi)
        {
            if (tamagochi.Slaap >= 80 )
            {
                //TODO COMMENT WEGHALEN
                //tamagochi.Gezondheid -= 20;
                if (tamagochi.Gezondheid < 0) { tamagochi.Gezondheid = 0; }
            }
            return tamagochi;

        }
    }
}