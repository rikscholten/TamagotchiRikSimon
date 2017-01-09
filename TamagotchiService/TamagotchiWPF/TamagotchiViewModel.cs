using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TamagotchiDomain;

namespace TamagotchiWPF
{
    class TamagotchiViewModel : INotifyPropertyChanged
    {
        Timer timer1 = new Timer();
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public void InitTimer()
        {
            timer1.Elapsed += new ElapsedEventHandler(UpdateApp);
            timer1.Interval = 2000; // in miliseconds
            timer1.Enabled = true;
            timer1.Start();
        }

        private void UpdateApp(object sender, EventArgs e)
        {
            OnPropertyChanged("Tamagotchis");
        }

        ServiceReference1.IService1 service;

        public TamagotchiViewModel()
        {
            InitTimer();
            service = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            timer1.Elapsed += (s, e) => OnPropertyChanged("Tamagotchis");

        }



        protected void OnPropertyChanged(string name)
        {
           
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public CollectionView Tamagotchis
        {

            get
            {
                List<Tamagotchi> tamagotchis = service.GetTamagotchis()
                .Select(t => new Tamagotchi(t))
                .ToList();

                //aanzetten als je wild at de doode tamagotchis niet wordne weergegeven in de wpf app
                tamagotchis = tamagotchis.Where(t => t.SterfTijd.HasValue == false).ToList();

                tamagotchis.ForEach(t =>
                {
                    t.Status = service.GetStatus(t.Id);
                    t.Leeftijd = service.GetAge(t.Id);
                });
                return new CollectionView(tamagotchis);
            }

        }



    }


    public class Tamagotchi
    {
        private TamagotchiDomain.Tamagot t;

        public Tamagotchi(ServiceReference1.Tamagotchi t)
        {
            Id = t.Id;
            Naam = t.Naam;
            GeboorteTijd = t.GeboorteTijd;
            SterfTijd = t.SterfTijd;
            LastAction = t.LastAction;
            Honger = t.Honger;
            Slaap = t.Slaap;
            Verveling = t.Verveling;
            Gezondheid = t.Gezondheid;
        }


        public Tamagotchi()
        {
        }


        public int Id { get; set; }

        public string Naam { get; set; }

        public DateTime GeboorteTijd { get; set; }
        public DateTime? SterfTijd { get; set; }
        public DateTime? LastAction { get; set; }


        public int Honger { get; set; }

        public int Slaap { get; set; }

        public int Verveling { get; set; }

        public int Gezondheid { get; set; }

        public string Status { get; set; }
        public int Leeftijd { get; set; }
    }
}
