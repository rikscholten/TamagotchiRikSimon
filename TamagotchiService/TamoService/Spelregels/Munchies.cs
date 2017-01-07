using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TamoService.Spelregels
{
    public class Munchies : ISpelregel
    {
        public Tamagotchi ExecSpelregel(Tamagotchi tamagochi)
        {
            if (tamagochi.Verveling > 80 )
            {
                tamagochi.Munchies = true;

            }
            else
            {
                tamagochi.Munchies = false;

            }
            return tamagochi;
        }
    }
}