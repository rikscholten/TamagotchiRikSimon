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

namespace TamoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public ExcuteSpelregels rules;
        public bool[] ruleArr;

        public Service1()
        {

        }
        public void UpdateTamagotchis()
        {
            using (var context = new TamoContext())
            {
                foreach (Tamagot t in context.Tamagots)
                {
                    Tamagot newtam = UpdateTamagotchi(t);
                    updateDBTamagot(newtam);
                }
                context.SaveChanges();
                ApplyConditions(); // past de spelregel condities toe
            }

        }

        public Tamagot UpdateTamagotchi(Tamagot t)
        {
            t.Honger += new Random().Next(15, 35);
            t.Slaap += new Random().Next(15, 35);
            t.Verveling += new Random().Next(15, 35);
            return t;
        }

        public void ApplyConditions()
        {
            rules = new ExcuteSpelregels(CreateGameRules(new bool[] { true, true, true, true }));

            using (var context = new TamoContext())
            {

                foreach (Tamagot t in context.Tamagots)
                {

                    Tamagot newtam = rules.Execute(GetTamagotchi(t.Id)).toPoco();

                    updateDBTamagot(newtam);
                }
                context.SaveChanges();
            }

        }


        public void updateDBTamagot(Tamagot t)
        {
            if (t.Honger < 0) { t.Honger = 0; }
            if (t.Honger > 100) { t.Honger = 100; }
            if (t.Slaap < 0) { t.Slaap = 0; }
            if (t.Slaap > 100) { t.Slaap = 100; }
            if (t.Verveling < 0) { t.Verveling = 0; }
            if (t.Verveling > 100) { t.Verveling = 100; }
            if (t.Gezondheid < 0) { t.Gezondheid = 0; }
            if (t.Gezondheid > 100) { t.Gezondheid = 100; }
            using (var context = new TamoContext())
            {
                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Honger = t.Honger;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Slaap = t.Slaap;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Verveling = t.Verveling;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Gezondheid = t.Gezondheid;
            }
        }
        public bool[] GetRuleArray()
        {
            return ruleArr;
        }

        public bool[] CreateTempArray()
        {
            bool[] temp = new bool[3];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = true;
            }

            return temp;
        }

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
                if (maxStat == 0 && statusTama.Gezondheid > 99)
                {
                    return "Gezond";
                }
                if (maxStat == 0 && statusTama.Gezondheid < 99)
                {
                    return "healing";
                }
                if (maxStat == statusTama.Honger) { Status = "Hongerig"; }
                else if (maxStat == statusTama.Slaap) { Status = "Slaperig"; }
                else if (maxStat == statusTama.Verveling) { Status = "Verveeld"; }
                if (statusTama.Gezondheid==0) { Status = "DOOD"; }


            }
            return Status;
        }



        public void PerformAction(int Id, string Actie)
        {
            
            Tamagotchi ActionTamagotchi = GetTamagotchi(Id);
            if(ActionTamagotchi.Gezondheid!=0)
            {

            
            switch (Actie)
            {



                case "Voeren":
                    #region   

                    ActionTamagotchi.Honger -= 50;
                    if (ActionTamagotchi.Honger < 0) { ActionTamagotchi.Honger = 0; }

                    if (new Random().Next(1, 10) <= 1)
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

                    if (new Random().Next(1, 10) <= 2)
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
            if (new Random().Next(100) <= 50 && ActionTamagotchi.Crazy)
            {
                ActionTamagotchi.Gezondheid = 0;//rip in peace
            }
            using (var context = new TamoContext())
            {


                updateDBTamagot(ActionTamagotchi.toPoco());
                context.SaveChanges();
            }

                //
            }

        }

        public SortedDictionary<int, ISpelregel> CreateGameRules(bool[] rulesArray)
        {

            SortedDictionary<int, ISpelregel> ruleCollection = new SortedDictionary<int, ISpelregel>();
            for (int i = 0; i < rulesArray.Length; i++)
            {
                if (rulesArray[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            ruleCollection.Add(0, new Munchies());
                            break;
                        case 1:
                            ruleCollection.Add(1, new Crazy());
                            break;
                        case 2:
                            ruleCollection.Add(2, new Slaaptekort());
                            break;
                        case 3:
                            ruleCollection.Add(3, new Voedseltekort());
                            break;
                    }
                }
            }
            return ruleCollection;

        }
    }
}
