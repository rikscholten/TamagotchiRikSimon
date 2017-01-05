using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TamagotchiDomain;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Tamagotchi GetTamagotchi(int id);

        [OperationContract]
        IEnumerable<Tamagotchi> GetTamagotchis();

        [OperationContract]
        void AddTamagotchi(Tamagotchi tdamagotchi);

        //acties
        [OperationContract]
        void FeedTamagotchi(int id);

        [OperationContract]
        void SleepTamagotchi(int id);

        [OperationContract]
        void PlayTamagotchi(int id);

        [OperationContract]
        void HugTamagotchi(int id);

        // TODO: Add your service operations here
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
        public int Id { get; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public int Leeftijd { get; set; }


        [DataMember]
        public int Honger { get; set; }

        [DataMember]
        public int Slaap { get; set; }

        [DataMember]
        public int Verveling { get; set; }

        [DataMember]
        public int Gezondheid { get; set; }

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
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

}
