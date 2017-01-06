using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiDomain;
using TamoService.Data;

namespace TamoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void AddTamagotchi(Tamagot t)
        {
            using (var context = new TamoContext())
            {
                
                context.Tamagots.Add(t);
                context.SaveChanges();
            }
        }

        public IEnumerable<Tamagotchi> GetTamagotchis()
        {
            using (var context = new TamoContext())
            {
                var tamagotchis = context.Tamagots.ToList();
                return tamagotchis.Select(t => new Tamagotchi(t));
            }
        }


        public string GetData(int value)
        {
            using (var context = new TamoContext())
            {

                return context.Tamagots.ToList().First().Naam;
            }
        }

        public Tamagotchi GetTamagotchi(int Id)
        {
            using (var context = new TamoContext())
                {
                var returnTamagot = context.Tamagots.ToList().Find(t => t.Id.Equals(Id));
                return new Tamagotchi(returnTamagot);
            }
        }


        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
