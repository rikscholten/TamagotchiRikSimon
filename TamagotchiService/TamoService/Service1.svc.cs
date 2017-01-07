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

namespace TamoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void AddTamagotchi(Tamagot t)
        {
            Debug.WriteLine("test1");
            using (var context = new TamoContext())
            {
                Debug.WriteLine("test2");
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



        public Tamagotchi GetTamagotchi(int Id)
        {
            using (var context = new TamoContext())
            {
                var returnTamagot = context.Tamagots.ToList().Find(t => t.Id.Equals(Id));
                return new Tamagotchi(returnTamagot);
            }
        }

        public void EditTamagotchi(int Id, string Name)
        {
            using (var context = new TamoContext())
            {
                context.Tamagots.ToList().Find(t => t.Id == Id).Naam = Name;
                context.SaveChanges();

            }
        }

        public string GetStatus(int Id)
        {
            string Status = "";
            using (var context = new TamoContext())
            {
                var statusTama = GetTamagotchi(Id);
                List<int> stats = new List<int>() { statusTama.Honger, statusTama.Slaap, statusTama.Verveling };

                int maxStat = stats.Max();
                if(maxStat==0 && statusTama.Gezondheid>99)
                {
                    return "Gezond";
                }
                if (maxStat == 0 && statusTama.Gezondheid <99)
                {
                    return "healing";
                }
                if (maxStat == statusTama.Honger) { Status = "Hongerig"; }
                else if (maxStat == statusTama.Slaap) { Status = "Slaperig"; }
                else if (maxStat == statusTama.Verveling) { Status = "Verveeld"; }


            }
            return Status;
        }



        public void PerformAction(int Id, string Actie)
        {

            Tamagotchi ActionTamagotchi = GetTamagotchi(Id);
            switch (Actie)
            {
                

                   
                case "Voeren":
                    #region   
                    
                        ActionTamagotchi.Honger -= 50;
                    if (ActionTamagotchi.Honger < 0) { ActionTamagotchi.Honger = 0; }
                    Random rnd = new Random();
                    if (rnd.Next(1, 10) <= 1)
                    {
                       
                        ActionTamagotchi.Gezondheid -= 20;
                        if (ActionTamagotchi.Gezondheid < 0) { ActionTamagotchi.Gezondheid = 0; } //rip
                    }
                    break;
                #endregion
                case "Slapen":
                    #region  
                    ActionTamagotchi.Slaap -= 25;
                    if (ActionTamagotchi.Slaap < 0) { ActionTamagotchi.Slaap = 0; }


                    ActionTamagotchi.Gezondheid += 10;
                    if (ActionTamagotchi.Gezondheid > 100) { ActionTamagotchi.Gezondheid = 100; }

                    break;
                #endregion
                case "Spelen":
                    #region 

                    ActionTamagotchi.Verveling -= 35;
                    if (ActionTamagotchi.Verveling < 0) { ActionTamagotchi.Verveling = 0; }
                    rnd = new Random();
                    if (rnd.Next(1, 10) <= 2)
                    {
                       
                        ActionTamagotchi.Gezondheid -= 10;
                        if (ActionTamagotchi.Gezondheid < 0) { ActionTamagotchi.Gezondheid = 0; } //rip
                    }
                    break;
                #endregion
                case "Knuffelen":
                    #region 

                    ActionTamagotchi.Honger -= 10;
                    if (ActionTamagotchi.Honger < 0) { ActionTamagotchi.Honger = 0; }

                    ActionTamagotchi.Slaap -= 10;
                    if (ActionTamagotchi.Slaap < 0) { ActionTamagotchi.Slaap = 0; }

                    ActionTamagotchi.Verveling -= 10;
                    if (ActionTamagotchi.Verveling < 0) { ActionTamagotchi.Verveling = 0; }

                    ActionTamagotchi.Gezondheid += 10;
                    if (ActionTamagotchi.Gezondheid > 100) { ActionTamagotchi.Gezondheid = 100; }
                    break;
                #endregion
                default:

                    break;
            }
            using (var context = new TamoContext())
            {



                context.Tamagots.ToList().Find(t => t.Id == Id).Honger = ActionTamagotchi.Honger;
                context.Tamagots.ToList().Find(t => t.Id == Id).Slaap = ActionTamagotchi.Slaap;
                context.Tamagots.ToList().Find(t => t.Id == Id).Verveling = ActionTamagotchi.Verveling;
                context.Tamagots.ToList().Find(t => t.Id == Id).Gezondheid = ActionTamagotchi.Gezondheid;
                context.SaveChanges();
            }

        }
    }
}
