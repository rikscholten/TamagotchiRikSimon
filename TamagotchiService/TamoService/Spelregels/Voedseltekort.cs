using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TamoService.Spelregels
{
    public class Voedseltekort : ISpelregel
    {
        public Tamagotchi ExecSpelregel(Tamagotchi tamagochi)
        {
            if (tamagochi.Honger >= 80)
            {
                Debug.WriteLine("honger test");
                tamagochi.Gezondheid = tamagochi.Gezondheid - 20;
            }
            return tamagochi;

        }
    }
}