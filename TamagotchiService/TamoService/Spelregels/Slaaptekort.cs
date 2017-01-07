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
                System.Diagnostics.Debug.WriteLine("slaap test     gezondheid pre:"+ tamagochi.Gezondheid);
                tamagochi.Gezondheid -= 20;
                System.Diagnostics.Debug.WriteLine(" gezondheid after:" + tamagochi.Gezondheid);
            }
            return tamagochi;

        }
    }
}