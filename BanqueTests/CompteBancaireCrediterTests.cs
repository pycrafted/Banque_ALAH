using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banque_ALAH;
using System;

namespace BanqueTests
{
    [TestClass]
    public sealed class CompteBancaireCrediterTests
    {
        [TestMethod]
        public void VérifierCréditCompteCorrect()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantCrédit = 300000;
            const double soldeAttendu = 800000;
            var cb = new CompteBancaire("Pr Fatou Sall", soldeInitial);

            // Act
            cb.Créditer(montantCrédit);

            // Assert
            Assert.AreEqual(soldeAttendu, cb.Solde, 0.001, "Compte crédité incorrectement");
        }

        [TestMethod]
        public void CréditerMontantNégatifSoulèveArgumentOutOfRangeException()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantCrédit = -100000;
            var cb = new CompteBancaire("Pr Amadou Ba", soldeInitial);

            // Act & Assert
            try
            {
                cb.Créditer(montantCrédit);
                Assert.Fail("Une ArgumentOutOfRangeException aurait dû être levée");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void CréditerMontantZéroSoulèveArgumentOutOfRangeException()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantCrédit = 0;
            var cb = new CompteBancaire("Pr Awa Diallo", soldeInitial);

            // Act & Assert
            try
            {
                cb.Créditer(montantCrédit);
                Assert.Fail("Une ArgumentOutOfRangeException aurait dû être levée");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void CréditerPlusieursFoisConsécutives()
        {
            // Arrange
            const double soldeInitial = 100000;
            var cb = new CompteBancaire("Pr Oumar Diallo", soldeInitial);

            // Act
            cb.Créditer(200000);
            cb.Créditer(300000);
            cb.Créditer(100000);

            // Assert
            Assert.AreEqual(700000, cb.Solde, 0.001, "Le solde après plusieurs crédits est incorrect");
        }

        [TestMethod]
        public void CréditerSoldeInitialZéro()
        {
            // Arrange
            const double soldeInitial = 0;
            const double montantCrédit = 500000;
            var cb = new CompteBancaire("Pr Fatou Dieng", soldeInitial);

            // Act
            cb.Créditer(montantCrédit);

            // Assert
            Assert.AreEqual(500000, cb.Solde, 0.001, "Le crédit sur un compte à zéro devrait fonctionner");
        }

        [TestMethod]
        public void CréditerMontantTrèsPetit()
        {
            // Arrange
            const double soldeInitial = 100000;
            const double montantCrédit = 0.01;
            var cb = new CompteBancaire("Pr Mamadou Sow", soldeInitial);

            // Act
            cb.Créditer(montantCrédit);

            // Assert
            Assert.AreEqual(100000.01, cb.Solde, 0.001, "Le crédit d'un montant très petit devrait fonctionner");
        }
    }
}

