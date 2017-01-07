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
            Debug.WriteLine("ExcuteSpelregels 1");
            if (tama.Gezondheid > 0)
            {
                Debug.WriteLine("ExcuteSpelregels 2");
                foreach (var spelregel in regels)
                {
                    Debug.WriteLine("ExcuteSpelregels 3");
                    tama = spelregel.Value.ExecSpelregel(tama);
                    Debug.WriteLine("ExcuteSpelregels 4");
                }
                Debug.WriteLine("ExcuteSpelregels 5");
            }
            Debug.WriteLine("ExcuteSpelregels 6");
            return tama;

        }
    }
}