using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamoService;
using TamoService.Data;
using TamoService.Spelregels;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class Acties
    {

        public ServiceReference1.IService1 service = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");

        [TestMethod]
        public void VoerenSucces()
        {
            

            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon" };

            // 2. Act
            tama.Honger = 80;


            // 3. Assert
            Assert.AreEqual(30, tama.Honger);
        }

        [TestMethod]
        public void SlapenSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 60, Verveling = 60, Gezondheid = 20 };

            // 2. Act
            service.PerformAction(tama.Id, "Slapen");

            // 3. Assert
            Assert.AreEqual(35, tama.Slaap);
        }

        [TestMethod]
        public void SpelenSucces()
        {

            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 60, Verveling = 60, Gezondheid = 20 };

            // 2. Act
            service.PerformAction(tama.Id, "Spelen");

            // 3. Assert
            Assert.AreEqual(25, tama.Verveling);
        }

        [TestMethod]
        public void KnuffelenSucces()
        {
            // 1. Arrange

            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 60, Verveling = 60, Gezondheid = 20 };

            // 2. Act
            service.PerformAction(tama.Id, "Knuffelen");

            // 3. Assert
            Assert.AreEqual(50, tama.Honger);
            Assert.AreEqual(50, tama.Slaap);
            Assert.AreEqual(50, tama.Verveling);

        }
    }
}
