using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiService.Data;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void AddTamagotchi(Tamagotchi tamagotchi)
        {
            using (var context = new TamagotchiContext())
            {
                context.Tamagotchi.Add(tamagotchi.toPoco());
                context.SaveChanges();
            }
        }

        public void FeedTamagotchi(int id)
        {
            throw new NotImplementedException();
        }

        public Tamagotchi GetTamagotchi(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tamagotchi> GetTamagotchis()
        {
            using (var context = new TamagotchiContext())
            {
                var tamagotchis = context.Tamagotchi.ToList();
                return tamagotchis.Select(t => new Tamagotchi(t));
            }
        }

        public void HugTamagotchi(int id)
        {
            throw new NotImplementedException();
        }

        public void PlayTamagotchi(int id)
        {
            throw new NotImplementedException();
        }

        public void SleepTamagotchi(int id)
        {
            throw new NotImplementedException();
        }
    }
}
