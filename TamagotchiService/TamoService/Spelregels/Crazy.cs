using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TamoService.Spelregels
{
    public class Crazy : ISpelregel
    {
        public Tamagotchi ExecSpelregel(Tamagotchi tamagochi)
        {
            if (tamagochi.Honger > 70 && tamagochi.Slaap > 70)
            {
                
                    tamagochi.Crazy = true;
                    
                

            }
            else
            {
                tamagochi.Crazy = false;
            }
            return tamagochi;
        }
    }
}