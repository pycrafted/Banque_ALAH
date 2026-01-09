using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banque_ALAH;
using System;

namespace BanqueTests
{
    [TestClass]
    public sealed class CompteBancaireDebiterTests
    {
        [TestMethod]
        public void VérifierDébitCompteCorrect()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantDébit = 400000;
            const double soldeAttendu = 100000;
            var cb = new CompteBancaire("Pr Ibrahima Fall", soldeInitial);

            // Act
            cb.Débiter(montantDébit);

            // Assert
            Assert.AreEqual(soldeAttendu, cb.Solde, 0.001, "Compte débité incorrectement");
        }

        [TestMethod]
        public void DébiterMontantNégatifSoulèveApplicationException()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantDébit = -400000;
            var cb = new CompteBancaire("Pr Ibrahima NGom", soldeInitial);

            // Act & Assert
            try
            {
                cb.Débiter(montantDébit);
                Assert.Fail("Une ApplicationException aurait dû être levée");
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Le montant retiré doit être Positif", ex.Message);
            }
        }

        [TestMethod]
        public void DébiterMontantSupérieurAuSoldeSoulèveArgumentOutOfRangeException()
        {
            // Arrange
            const double soldeInitial = 100000;
            const double montantDébit = 200000;
            var cb = new CompteBancaire("Pr Moussa Diop", soldeInitial);

            // Act & Assert
            try
            {
                cb.Débiter(montantDébit);
                Assert.Fail("Une ArgumentOutOfRangeException aurait dû être levée");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void DébiterMontantZéroSoulèveApplicationException()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantDébit = 0;
            var cb = new CompteBancaire("Pr Modou Diop", soldeInitial);

            // Act & Assert
            try
            {
                cb.Débiter(montantDébit);
                Assert.Fail("Une ApplicationException aurait dû être levée");
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Le montant retiré doit être Positif", ex.Message);
            }
        }

        [TestMethod]
        public void DébiterMontantÉgalAuSoldeRéussit()
        {
            // Arrange
            const double soldeInitial = 500000;
            const double montantDébit = 500000;
            const double soldeAttendu = 0;
            var cb = new CompteBancaire("Pr Aissatou Ba", soldeInitial);

            // Act
            cb.Débiter(montantDébit);

            // Assert
            Assert.AreEqual(soldeAttendu, cb.Solde, 0.001, "Le solde devrait être à zéro");
        }

        [TestMethod]
        public void DébiterSoldeInitialZéroSoulèveArgumentOutOfRangeException()
        {
            // Arrange
            const double soldeInitial = 0;
            const double montantDébit = 100000;
            var cb = new CompteBancaire("Pr Malick Ndiaye", soldeInitial);

            // Act & Assert
            try
            {
                cb.Débiter(montantDébit);
                Assert.Fail("Une ArgumentOutOfRangeException aurait dû être levée");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void DébiterPlusieursFoisConsécutives()
        {
            // Arrange
            const double soldeInitial = 1000000;
            var cb = new CompteBancaire("Pr Khady Fall", soldeInitial);

            // Act
            cb.Débiter(200000);
            cb.Débiter(300000);
            cb.Débiter(100000);

            // Assert
            Assert.AreEqual(400000, cb.Solde, 0.001, "Le solde après plusieurs débits est incorrect");
        }
    }
}

