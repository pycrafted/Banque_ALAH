using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banque_ALAH;

namespace BanqueTests
{
    [TestClass]
    public sealed class CompteBancaireTests
    {
        // ========== TESTS POUR OPÉRATIONS MIXTES ==========

        [TestMethod]
        public void OpérationsMixtesCréditEtDébit()
        {
            // Arrange
            var cb = new CompteBancaire("Pr Mixte", 1000000);

            // Act
            cb.Créditer(500000);
            cb.Débiter(300000);
            cb.Créditer(200000);
            cb.Débiter(100000);

            // Assert
            Assert.AreEqual(1300000, cb.Solde, 0.001, "Le solde après opérations mixtes est incorrect");
        }

        [TestMethod]
        public void VirementSuiviDeCréditEtDébit()
        {
            // Arrange
            var compteSource = new CompteBancaire("Dr Source", 1000000);
            var compteDestination = new CompteBancaire("Dr Dest", 500000);

            // Act
            compteSource.Virement(compteDestination, 200000);
            compteSource.Créditer(100000);
            compteDestination.Débiter(50000);

            // Assert
            Assert.AreEqual(900000, compteSource.Solde, 0.001);
            Assert.AreEqual(650000, compteDestination.Solde, 0.001);
        }
    }
}