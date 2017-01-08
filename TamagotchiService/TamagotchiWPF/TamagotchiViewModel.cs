using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TamagotchiWPF
{
    class TamagotchiViewModel : INotifyPropertyChanged
    {
        ServiceReference1.IService1 service;

        public TamagotchiViewModel()
        {
            service = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            status = "Rik";

        }

        public String _status;

        public String status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public CollectionView Tamagotchis
        {

            get {
                return new CollectionView(service.GetTamagotchis().ToList());
            }
            
        }

       

    }
}
