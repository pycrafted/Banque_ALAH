# Projet Tests Unitaires - Système Bancaire

## 📋 Informations du projet

**Université:** Université Cheikh Anta Diop  
**École:** École Supérieure Polytechnique (ESP)  
**Département:** Génie Informatique  
**Enseignement:** .NET  
**Chargé de Cours:** E. H. Ousmane Diallo  
**Année Universitaire:** 2025/2026  
**Date:** 8 janvier 2025

---

## 📝 Description

Ce projet implémente un système de gestion de comptes bancaires en C# avec une suite complète de tests unitaires utilisant MSTest. Il s'agit d'un travail pratique sur les méthodes, exceptions et pratique des tests en C#.

### Fonctionnalités implémentées

- ✅ Gestion de compte bancaire (Débiter, Créditer)
- ✅ Virement entre comptes
- ✅ Gestion des exceptions et validations
- ✅ Suite de tests unitaires complète (27 tests)
- ✅ Tests du constructeur
- ✅ Tests d'opérations mixtes

---

## 🏗️ Structure du projet

```
ProjetBanque/
├── Banque.slnx                         # Solution principale
├── Banque_ALAH/                        # Bibliothèque de classes
│   ├── Banque_ALAH.csproj
│   └── CompteBancaire.cs               # Classe métier
├── BanqueTests/                        # Projet de tests unitaires
│   ├── BanqueTests.csproj
│   ├── CompteBancaireConstructeurTests.cs    # Tests du constructeur
│   ├── CompteBancaireCrediterTests.cs        # Tests de crédit
│   ├── CompteBancaireDebiterTests.cs         # Tests de débit
│   ├── CompteBancaireVirementTests.cs        # Tests de virement
│   └── CompteBancaireTests.cs                # Tests d'opérations mixtes
└── README.md                           # Ce fichier
```

---

## 🚀 Installation et exécution

### Prérequis

- .NET SDK 10.0 ou supérieur
- Visual Studio Code (ou Visual Studio)
- Extension C# Dev Kit pour VS Code

### Vérifier l'installation de .NET

```bash
dotnet --version
```

### Cloner le dépôt

```bash
git clone https://github.com/VOTRE_USERNAME/ProjetBanque.git
cd ProjetBanque
```

### Restaurer les dépendances

```bash
dotnet restore
```

### Compiler le projet

```bash
dotnet build
```

### Exécuter les tests

```bash
dotnet test
```

Pour plus de détails sur les tests :

```bash
dotnet test --logger "console;verbosity=detailed"
```

---

## 🧪 Tests unitaires

### Couverture des tests

Le projet contient **27 tests unitaires** organisés en plusieurs classes de tests :

#### Tests du constructeur (4 tests)

1. ✅ `ConstructeurAvecSoldePositif` - Vérifie la création avec un solde positif
2. ✅ `ConstructeurAvecSoldeZéro` - Vérifie la création avec un solde à zéro
3. ✅ `ConstructeurAvecSoldeNégatif` - Vérifie la création avec un solde négatif
4. ✅ `ConstructeurAvecNomClientVide` - Vérifie la création avec un nom vide

#### Tests de la méthode `Débiter` (7 tests)

5. ✅ `VérifierDébitCompteCorrect` - Vérifie qu'un montant valide est correctement débité
6. ✅ `DébiterMontantNégatifSoulèveApplicationException` - Vérifie qu'un montant négatif lève une exception
7. ✅ `DébiterMontantSupérieurAuSoldeSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant supérieur au solde lève une exception
8. ✅ `DébiterMontantZéroSoulèveApplicationException` - Vérifie qu'un montant zéro lève une exception
9. ✅ `DébiterMontantÉgalAuSoldeRéussit` - Vérifie qu'un débit égal au solde fonctionne
10. ✅ `DébiterSoldeInitialZéroSoulèveArgumentOutOfRangeException` - Vérifie qu'un débit sur un compte à zéro lève une exception
11. ✅ `DébiterPlusieursFoisConsécutives` - Vérifie plusieurs débits consécutifs

#### Tests de la méthode `Créditer` (6 tests)

12. ✅ `VérifierCréditCompteCorrect` - Vérifie qu'un montant valide est correctement crédité
13. ✅ `CréditerMontantNégatifSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant négatif lève une exception
14. ✅ `CréditerMontantZéroSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant zéro lève une exception
15. ✅ `CréditerPlusieursFoisConsécutives` - Vérifie plusieurs crédits consécutifs
16. ✅ `CréditerSoldeInitialZéro` - Vérifie le crédit sur un compte à zéro
17. ✅ `CréditerMontantTrèsPetit` - Vérifie le crédit d'un montant très petit

#### Tests de la méthode `Virement` (8 tests)

18. ✅ `VirementCorrect` - Vérifie qu'un virement valide s'exécute correctement
19. ✅ `VirementMontantNégatifSoulèveException` - Vérifie qu'un montant négatif lève une exception
20. ✅ `VirementSoldeInsuffisantSoulèveException` - Vérifie qu'un solde insuffisant lève une exception
21. ✅ `VirementCompteNullSoulèveException` - Vérifie qu'un compte null lève une exception
22. ✅ `VirementMontantZéroSoulèveException` - Vérifie qu'un montant zéro lève une exception
23. ✅ `VirementMontantÉgalAuSoldeRéussit` - Vérifie qu'un virement égal au solde fonctionne
24. ✅ `VirementMultipleEntreComptes` - Vérifie plusieurs virements entre différents comptes
25. ✅ `VirementMontantTrèsPetit` - Vérifie le virement d'un montant très petit

#### Tests d'opérations mixtes (2 tests)

26. ✅ `OpérationsMixtesCréditEtDébit` - Vérifie une séquence d'opérations crédit/débit
27. ✅ `VirementSuiviDeCréditEtDébit` - Vérifie un virement suivi d'opérations

### Résultats attendus

Tous les tests doivent passer avec succès :

```
Total tests: 27
     Passed: 27
     Failed: 0
    Skipped: 0
```

---

## 📚 Classes principales

### `CompteBancaire`

Classe représentant un compte bancaire avec les méthodes suivantes :

#### Propriétés
- `Solde` (double) - Le solde du compte

#### Méthodes publiques
- `Débiter(double montant)` - Retire un montant du compte
- `Créditer(double montant)` - Ajoute un montant au compte
- `Virement(CompteBancaire compteDestination, double montant)` - Effectue un virement vers un autre compte

#### Exceptions gérées
- `ArgumentOutOfRangeException` - Montant invalide ou solde insuffisant
- `ApplicationException` - Montant négatif ou zéro
- `ArgumentNullException` - Compte destination null
- `Exception` - Compte bloqué

---

## 🔧 Corrections effectuées

### Bug intentionnel corrigé

Dans la méthode `Débiter`, le code initial contenait une erreur intentionnelle :

```csharp
// ❌ AVANT (bug)
Solde += montant; // code intentionnellement faux
```

Correction appliquée :

```csharp
// ✅ APRÈS (correct)
Solde -= montant; // soustraire le montant
```

Cette correction a été validée par les tests unitaires.

---

## 📊 Méthodologie de test

Le projet utilise la méthodologie **AAA (Arrange-Act-Assert)** :

```csharp
[TestMethod]
public void VérifierDébitCompteCorrect()
{
    // Arrange - Préparation des données de test
    const double soldeInitial = 500000;
    const double montantDébit = 400000;
    const double soldeAttendu = 100000;
    var cb = new CompteBancaire("Pr Ibrahima Fall", soldeInitial);

    // Act - Exécution de la méthode à tester
    cb.Débiter(montantDébit);

    // Assert - Vérification du résultat
    Assert.AreEqual(soldeAttendu, cb.Solde, 0.001, "Compte débité incorrectement");
}
```

---

## 🛠️ Technologies utilisées

- **Langage:** C# (version latest)
- **Framework:** .NET 10.0
- **Framework de tests:** MSTest 4.0.1
- **IDE recommandé:** Visual Studio Code / Visual Studio 2022

---

## 📖 Ressources

- [Documentation .NET](https://docs.microsoft.com/dotnet/)
- [Guide MSTest](https://docs.microsoft.com/visualstudio/test/unit-test-basics)
- [Tests unitaires en C#](https://learn.microsoft.com/fr-fr/dotnet/core/testing/)

---

## 👨‍🎓 Auteur

**Nom:** [VOTRE NOM]  
**Matricule:** [VOTRE MATRICULE]  
**Section:** Génie Informatique - ESP  
**Email:** [VOTRE EMAIL]

---

## 📄 Licence

Ce projet est réalisé dans le cadre d'un travail pratique académique à l'ESP - UCAD.

---

## 🤝 Contribution

Ce projet est un travail individuel dans le cadre d'un TP noté. Les contributions externes ne sont pas acceptées.

---

## ✅ Checklist de vérification

Avant de soumettre le projet, assurez-vous que :

- [x] Le code compile sans erreur (`dotnet build`)
- [x] Tous les tests passent (`dotnet test`)
- [x] Le bug intentionnel a été corrigé
- [x] Les 27 tests unitaires sont implémentés
- [x] Le README.md est complet et à jour
- [x] Le projet est poussé sur GitHub
- [x] Le lien GitHub a été partagé avec le professeur

---

## 📌 Notes importantes

- Le projet utilise .NET 10.0 comme framework cible
- La classe `CompteBancaire` gère les comptes bloqués via un champ privé `_bloqué`
- Les méthodes `BloquerCompte()` et `DéBloquerCompte()` sont privées
- Le bug intentionnel dans la méthode `Débiter` a été corrigé (utilisation de `-=` au lieu de `+=`)

---

*Dernière mise à jour : 8 janvier 2025*
