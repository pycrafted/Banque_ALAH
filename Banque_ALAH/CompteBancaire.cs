namespace Banque_ALAH

{
    public class CompteBancaire
    {
        private readonly string? _nomClient;
        private bool _bloqué = false;

        private CompteBancaire() { }

        public CompteBancaire(string nomClient, double solde)
        {
            _nomClient = nomClient;
            Solde = solde;
        }

        public double Solde { get; private set; }

        public void Débiter(double montant)
        {
            if (_bloqué)
            {
                throw new Exception("Compte Bloqué");
            }

            ArgumentOutOfRangeException.ThrowIfGreaterThan(montant, Solde);
            
            if (montant <= 0)
            {
                throw new ApplicationException("Le montant retiré doit être Positif");
            }
            
            // Solde += montant;
            Solde -= montant;//ce code à été intentionnellement fassé pour les tests maintenant il est corrigé
        }

        public void Créditer(double montant)
        {
            if (_bloqué)
            {
                throw new Exception("Compte Bloqué");
            }

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(montant);
            Solde += montant;
        }

        private void BloquerCompte() { _bloqué = true; }
        private void DéBloquerCompte() { _bloqué = false; }

        // Ajout de la méthode Virement
        public void Virement(CompteBancaire compteDestination, double montant)
        {
            if (compteDestination == null)
            {
                throw new ArgumentNullException(nameof(compteDestination));
            }

            if (montant <= 0)
            {
                throw new ApplicationException("Le montant du virement doit être positif");
            }

            // Débiter le compte source
            this.Débiter(montant);
            
            // Créditer le compte destination
            compteDestination.Créditer(montant);
        }

        public static void Main()
        {
            var cb = new CompteBancaire("Pr Mamadou Samba Camara", 500000);
            cb.Créditer(1000000);
            cb.Débiter(500000);
            Console.WriteLine($"Solde disponible : {cb.Solde}");
        }
    }
}