using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TamoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void AddTamagotchi(TamagotchiDomain.Tamagot t);

        [OperationContract]
        IEnumerable<Tamagotchi> GetTamagotchis();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

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
}
