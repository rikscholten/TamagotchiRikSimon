using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamoService.Spelregels
{
    public interface ISpelregel
    {
        Tamagotchi ExecSpelregel(Tamagotchi tamagochi);
    }
}
