using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banque_ALAH;
using System;

namespace BanqueTests
{
    [TestClass]
    public sealed class CompteBancaireVirementTests
    {
        [TestMethod]
        public void VirementCorrect()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Ousmane", 500000);
            var compteDestination = new CompteBancaire("Dr Aminata", 200000);
            const double montantVirement = 150000;

            // Act
            compteSource.Virement(compteDestination, montantVirement);

            // Assert
            Assert.AreEqual(350000, compteSource.Solde, 0.001);
            Assert.AreEqual(350000, compteDestination.Solde, 0.001);
        }

        [TestMethod]
        public void VirementMontantNégatifSoulèveException()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Seydou", 500000);
            var compteDestination = new CompteBancaire("Dr Mariama", 200000);

            // Act & Assert
            try
            {
                compteSource.Virement(compteDestination, -50000);
                Assert.Fail("Une ApplicationException aurait dû être levée");
            }
            catch (ApplicationException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void VirementSoldeInsuffisantSoulèveException()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Ibou", 100000);
            var compteDestination = new CompteBancaire("Dr Khady", 200000);

            // Act & Assert
            try
            {
                compteSource.Virement(compteDestination, 150000);
                Assert.Fail("Une ArgumentOutOfRangeException aurait dû être levée");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void VirementCompteNullSoulèveException()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Binta", 500000);

            // Act & Assert
            try
            {
                compteSource.Virement(null!, 50000);
                Assert.Fail("Une ArgumentNullException aurait dû être levée");
            }
            catch (ArgumentNullException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void VirementMontantZéroSoulèveException()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Modou", 500000);
            var compteDestination = new CompteBancaire("Dr Awa", 200000);

            // Act & Assert
            try
            {
                compteSource.Virement(compteDestination, 0);
                Assert.Fail("Une ApplicationException aurait dû être levée");
            }
            catch (ApplicationException)
            {
                // Exception attendue, le test réussit
            }
        }

        [TestMethod]
        public void VirementMontantÉgalAuSoldeRéussit()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Ibrahima", 500000);
            var compteDestination = new CompteBancaire("Dr Khady", 200000);
            const double montantVirement = 500000;

            // Act
            compteSource.Virement(compteDestination, montantVirement);

            // Assert
            Assert.AreEqual(0, compteSource.Solde, 0.001, "Le compte source devrait être à zéro");
            Assert.AreEqual(700000, compteDestination.Solde, 0.001, "Le compte destination devrait avoir le montant transféré");
        }

        [TestMethod]
        public void VirementMultipleEntreComptes()
        {
            // Arrange
            var compte1 = new CompteBancaire("Dr Alpha", 1000000);
            var compte2 = new CompteBancaire("Dr Beta", 500000);
            var compte3 = new CompteBancaire("Dr Gamma", 300000);

            // Act
            compte1.Virement(compte2, 200000);
            compte2.Virement(compte3, 100000);
            compte3.Virement(compte1, 50000);

            // Assert
            Assert.AreEqual(850000, compte1.Solde, 0.001);
            Assert.AreEqual(600000, compte2.Solde, 0.001);
            Assert.AreEqual(350000, compte3.Solde, 0.001);
        }

        [TestMethod]
        public void VirementMontantTrèsPetit()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Youssou", 100000);
            var compteDestination = new CompteBancaire("Dr Aissatou", 50000);
            const double montantVirement = 0.01;

            // Act
            compteSource.Virement(compteDestination, montantVirement);

            // Assert
            Assert.AreEqual(99999.99, compteSource.Solde, 0.001);
            Assert.AreEqual(50000.01, compteDestination.Solde, 0.001);
        }
    }
}

