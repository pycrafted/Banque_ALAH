using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banque_ALAH;

namespace BanqueTests
{
    [TestClass]
    public sealed class CompteBancaireConstructeurTests
    {
        [TestMethod]
        public void ConstructeurAvecSoldePositif()
        {
            // Arrange & Act
            var cb = new CompteBancaire("Pr Test", 1000000);

            // Assert
            Assert.AreEqual(1000000, cb.Solde, 0.001, "Le solde initial devrait être correct");
        }

        [TestMethod]
        public void ConstructeurAvecSoldeZéro()
        {
            // Arrange & Act
            var cb = new CompteBancaire("Pr Test", 0);

            // Assert
            Assert.AreEqual(0, cb.Solde, 0.001, "Le solde initial à zéro devrait être accepté");
        }

        [TestMethod]
        public void ConstructeurAvecSoldeNégatif()
        {
            // Arrange & Act
            var cb = new CompteBancaire("Pr Test", -100000);

            // Assert
            Assert.AreEqual(-100000, cb.Solde, 0.001, "Le constructeur accepte un solde négatif");
        }

        [TestMethod]
        public void ConstructeurAvecNomClientVide()
        {
            // Arrange & Act
            var cb = new CompteBancaire("", 500000);

            // Assert
            Assert.AreEqual(500000, cb.Solde, 0.001, "Le constructeur accepte un nom vide");
        }
    }
}

