using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiDomain;
using TamoService.Spelregels;

namespace TamoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void InitTimer();

        [OperationContract]
        void AddTamagotchi(Tamagot tam);

        [OperationContract]
        Tamagotchi GetTamagotchi(int Id);

        [OperationContract]
        void EditTamagotchi(int Id,string Name);

        [OperationContract]
        IEnumerable<Tamagotchi> GetTamagotchis();

        [OperationContract]
        String GetStatus(int Id);

        [OperationContract]
        void PerformAction(int Id, string Action);

        [OperationContract]
        bool[] GetRuleArray();

        [OperationContract]
        SortedDictionary<int, ISpelregel> CreateGameRules(bool[] rulesArray);
    }


 

    [DataContract]
    public class Tamagotchi
    {
        public Tamagotchi()
        {

        }

        public Tamagotchi(TamagotchiDomain.Tamagot t)
        {
            Id = t.Id;
            Naam = t.Naam;
            Leeftijd = t.Leeftijd;
            Honger = t.Honger;
            Slaap = t.Slaap;
            Verveling = t.Verveling;
            Gezondheid = t.Gezondheid;
        }


        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public DateTime Leeftijd { get; set; }

        [DataMember]
        public int Honger { get; set; }

        [DataMember]
        public int Slaap { get; set; }

        [DataMember]
        public int Verveling { get; set; }

        [DataMember]
        public int Gezondheid { get; set; }


        [DataMember]
        public bool Crazy { get; set; }

        [DataMember]
        public bool Munchies { get; set; }


        internal TamagotchiDomain.Tamagot toPoco()
        {
            return new TamagotchiDomain.Tamagot()
            {
                Id = this.Id,
                Naam = this.Naam,
                Leeftijd = this.Leeftijd,
                Honger = this.Honger,
                Slaap = this.Slaap,
                Verveling = this.Verveling,
                Gezondheid = this.Gezondheid,
            };
        }
    }
}
