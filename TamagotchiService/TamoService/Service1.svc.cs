using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
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

        public void InitTimer()
        {
            Timer timer1 = new Timer();
            timer1.Elapsed += new ElapsedEventHandler(timer1_Tick);
            timer1.Interval = 10000; // in miliseconds
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTamagotchis();
        }
        public void UpdateTamagotchis()
        {
            using (var context = new TamoContext())
            {
                foreach (Tamagot t in context.Tamagots.ToList().Where(t => t.Gezondheid > 0))
                {
                    Tamagot newtam = UpdateTamagotchi(t);
                    updateDBTamagot(newtam);
                }
                ApplyConditions(); // past de spelregel condities toe
                //context.SaveChanges();


                foreach (Tamagot t in context.Tamagots.ToList().Where(t => t.Gezondheid == 0))
                {
                    if (!t.SterfTijd.HasValue)
                    {
                        Debug.WriteLine("dead");
                        DateTime deathTime = DateTime.Now;
                        context.Tamagots.ToList().Find(tam => tam.Id == t.Id).SterfTijd = deathTime;
                    }
                }

                context.SaveChanges();
            }


        }

        public Tamagot UpdateTamagotchi(Tamagot t)
        {
            int minInc = 15;
            int maxInc = 35;
            Random rnd = new Random();

            t.Honger += rnd.Next(minInc, maxInc);
            t.Slaap += rnd.Next(minInc, maxInc);
            t.Verveling += rnd.Next(minInc, maxInc);

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
                    context.Tamagots.ToList().Find(tam => tam.Id == newtam.Id).Honger = newtam.Honger;

                    context.Tamagots.ToList().Find(tam => tam.Id == newtam.Id).Slaap = newtam.Slaap;

                    context.Tamagots.ToList().Find(tam => tam.Id == newtam.Id).Verveling = newtam.Verveling;

                    context.Tamagots.ToList().Find(tam => tam.Id == newtam.Id).Gezondheid = newtam.Gezondheid;

                }
                context.SaveChanges();
            }

            //return lijst van crazy/munchies service.tamagochis??????
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
            if (t.Gezondheid == 0) { t.SterfTijd = DateTime.Now; }
            using (var context = new TamoContext())
            {
                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Honger = t.Honger;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Slaap = t.Slaap;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Verveling = t.Verveling;

                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).Gezondheid = t.Gezondheid;
                context.Tamagots.ToList().Find(tam => tam.Id == t.Id).SterfTijd = t.SterfTijd;
                //context.SaveChanges();
            }
        }
        public bool[] GetRuleArray()
        {
            return ruleArr;
        }

        public int GetAge(int Id)
        {
            int Leeftijd;
            Tamagot ageTam;
            using (var context = new TamoContext())
            {
                ageTam = context.Tamagots.ToList().Find(t => t.Id == Id);
            }
            if (!ageTam.SterfTijd.HasValue)
            {
                Leeftijd = (int)(DateTime.Now - ageTam.GeboorteTijd).TotalSeconds;
            }

            else
            {
                Leeftijd = (int)(ageTam.SterfTijd.Value - ageTam.GeboorteTijd).TotalSeconds;

            }
            return Leeftijd;
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

                var tamagots = tamagotchis.Select(t => new Tamagotchi(t));


                return tamagots;
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
                if (statusTama.Gezondheid == 0)
                {
                    Status = "DOOD";
                    if (statusTama.Gezondheid == 0 && !statusTama.SterfTijd.HasValue)
                    {
                        context.Tamagots.ToList().Find(tam => tam.Id == statusTama.Id).SterfTijd = DateTime.Now;
                        context.SaveChanges();
                    }
                }

            }

            return Status;
        }



        public void PerformAction(int Id, string Actie)
        {
            

            Tamagotchi ActionTamagotchi = GetTamagotchi(Id);
            ApplyConditions();
            ActionTamagotchi = IsCrazy(ActionTamagotchi);


            if (ActionTamagotchi.Gezondheid != 0)
            {
                switch (Actie)
                {

                    case "Voeren":
                        #region   
                        if ((DateTime.Now - ActionTamagotchi.LastAction.GetValueOrDefault()).TotalSeconds > 5)
                        {
                            ActionTamagotchi.Honger -= 50;
                            if (ActionTamagotchi.Honger < 0) { ActionTamagotchi.Honger = 0; }
                            Random rnd = new Random();
                            if (rnd.Next(1, 10) <= 1)
                            {

                                ActionTamagotchi.Gezondheid -= 20;
                                if (ActionTamagotchi.Gezondheid < 0) { ActionTamagotchi.Gezondheid = 0; } //rip
                            }
                            ActionTamagotchi.LastAction = DateTime.Now;
                        }
                        break;
                    #endregion
                    case "Slapen":
                        if ((DateTime.Now - ActionTamagotchi.LastAction.GetValueOrDefault()).TotalSeconds > 15)
                        {
                            #region  
                            ActionTamagotchi.Slaap -= 25;
                            if (ActionTamagotchi.Slaap < 0) { ActionTamagotchi.Slaap = 0; }

                            

                            ActionTamagotchi.Gezondheid += 10;
                            if (ActionTamagotchi.Gezondheid > 100) { ActionTamagotchi.Gezondheid = 100; }
                            ActionTamagotchi.LastAction = DateTime.Now;
                        }
                        break;
                    #endregion
                    case "Spelen":
                        #region 
                        if ((DateTime.Now - ActionTamagotchi.LastAction.GetValueOrDefault()).TotalSeconds > 8)
                        {
                            ActionTamagotchi.Verveling -= 35;
                            if (ActionTamagotchi.Verveling < 0) { ActionTamagotchi.Verveling = 0; }
                            Random rng = new Random();
                            if (rng.Next(1, 10) <= 2)
                            {

                                ActionTamagotchi.Gezondheid -= 10;
                                if (ActionTamagotchi.Gezondheid < 0) { ActionTamagotchi.Gezondheid = 0; } //rip
                            }
                            ActionTamagotchi.LastAction = DateTime.Now;
                        }
                        break;
                    #endregion
                    case "Knuffelen":
                        #region 
                        if ((DateTime.Now - ActionTamagotchi.LastAction.GetValueOrDefault()).TotalSeconds > 3)
                        {
                            ActionTamagotchi.Honger -= 10;
                            if (ActionTamagotchi.Honger < 0) { ActionTamagotchi.Honger = 0; }

                            ActionTamagotchi.Slaap -= 10;
                            if (ActionTamagotchi.Slaap < 0) { ActionTamagotchi.Slaap = 0; }

                            ActionTamagotchi.Verveling -= 10;
                            if (ActionTamagotchi.Verveling < 0) { ActionTamagotchi.Verveling = 0; }

                            ActionTamagotchi.Gezondheid += 10;
                            if (ActionTamagotchi.Gezondheid > 100) { ActionTamagotchi.Gezondheid = 100; }
                            ActionTamagotchi.LastAction = DateTime.Now;
                        }
                        break;
                    #endregion
                    default:

                        break;
                }
                Random rng2 = new Random();
                if (rng2.Next(100) <= 50 && ActionTamagotchi.Crazy)
                {
                    ActionTamagotchi.Gezondheid = 0;//rip in peace
                }
                using (var context = new TamoContext())
                {


                    context.Tamagots.ToList().Find(tam => tam.Id == ActionTamagotchi.Id).Honger = ActionTamagotchi.Honger;

                    context.Tamagots.ToList().Find(tam => tam.Id == ActionTamagotchi.Id).Slaap = ActionTamagotchi.Slaap;

                    context.Tamagots.ToList().Find(tam => tam.Id == ActionTamagotchi.Id).Verveling = ActionTamagotchi.Verveling;

                    context.Tamagots.ToList().Find(tam => tam.Id == ActionTamagotchi.Id).Gezondheid = ActionTamagotchi.Gezondheid;
                    context.Tamagots.ToList().Find(tam => tam.Id == ActionTamagotchi.Id).LastAction = ActionTamagotchi.LastAction;
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

        public Tamagotchi IsCrazy(Tamagotchi tamagochi)
        {
            if (tamagochi.Crazy)
            {
                Random rand = new Random();
                if (rand.Next(100) < 99)
                {
                    tamagochi.Gezondheid = 0;
                    tamagochi.Status = "DOOD";
                }
            }
            return tamagochi;
        }
    }
}
