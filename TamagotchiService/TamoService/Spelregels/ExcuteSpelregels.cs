using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiDomain;
using TamoService.Data;
using TamoService.Spelregels;

namespace TamoService.Spelregels
{
    public class ExcuteSpelregels
    {
        public SortedDictionary<int, ISpelregel> regels;

        public ExcuteSpelregels(SortedDictionary<int, ISpelregel> regels)
        {
            this.regels = regels;
        }

        public Tamagotchi Execute(Tamagotchi tama)
        {
            if (tama.Gezondheid > 0)
            {
                foreach (var spelregel in regels)
                {
                    tama = spelregel.Value.ExecSpelregel(tama);
                }
            }
            return tama;

        }
    }
}