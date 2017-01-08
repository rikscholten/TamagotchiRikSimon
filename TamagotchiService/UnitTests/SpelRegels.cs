using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamoService;
using TamoService.Spelregels;

namespace UnitTests
{
    [TestClass]
    public class SpelRegels
    {
        [TestMethod]
        public void MunchiesTrueSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 85, Slaap = 15, Verveling = 85, Gezondheid = 50 };
            Tamagotchi result;
            ISpelregel spelregel = new Munchies();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.IsTrue(result.Munchies);
        }

        [TestMethod]
        public void MunchiesFalseSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 85, Slaap = 15, Verveling = 10, Gezondheid = 50 };
            Tamagotchi result;
            ISpelregel spelregel = new Munchies();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.IsFalse(result.Munchies);
        }

        [TestMethod]
        public void CrazyTrueSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 85, Slaap = 85, Verveling = 30, Gezondheid = 50 };
            Tamagotchi result;
            ISpelregel spelregel = new Crazy();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.IsTrue(result.Crazy);
        }

        [TestMethod]
        public void CrazyFalseSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 15, Verveling = 60, Gezondheid = 50 };
            Tamagotchi result;
            ISpelregel spelregel = new Crazy();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.IsFalse(result.Crazy);
        }

        [TestMethod]
        public void SlaaptekortTrueSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 100, Verveling = 60, Gezondheid = 20 };
            Tamagotchi result;
            ISpelregel spelregel = new Slaaptekort();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.AreEqual(result.Gezondheid, 0);
        }

        [TestMethod]
        public void SlaaptekortFalseSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 60, Slaap = 50, Verveling = 60, Gezondheid = 20 };
            Tamagotchi result;
            ISpelregel spelregel = new Slaaptekort();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.AreEqual(result.Gezondheid, 20);
        }

        [TestMethod]
        public void VoedseltekortTrueSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 100, Slaap = 50, Verveling = 60, Gezondheid = 20 };
            Tamagotchi result;
            ISpelregel spelregel = new Voedseltekort();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.AreEqual(result.Gezondheid, 0);
        }

        [TestMethod]
        public void VoedseltekortFalseSucces()
        {
            // 1. Arrange
            Tamagotchi tama = new Tamagotchi { Naam = "Simon", Honger = 50, Slaap = 50, Verveling = 60, Gezondheid = 20 };
            Tamagotchi result;
            ISpelregel spelregel = new Voedseltekort();

            // 2. Act
            result = spelregel.ExecSpelregel(tama);

            // 3. Assert
            Assert.AreEqual(result.Gezondheid, 20);
        }
    }
}
