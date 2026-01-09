# Projet Tests Unitaires - Système Bancaire

## 📋 Informations du projet

**Université:** Université Cheikh Anta Diop  
**École:** École Supérieure Polytechnique (ESP)  
**Département:** Génie Informatique  
**Enseignement:** .NET  
**Chargé de Cours:** E. H. Ousmane Diallo  
**Année Universitaire:** 2025/2026  
**Date:** 8 décembre 2026

---

## 📝 Description

Ce projet implémente un système de gestion de comptes bancaires en C# avec une suite complète de tests unitaires utilisant MSTest. Il s'agit d'un travail pratique sur les méthodes, exceptions et pratique des tests en C#.

### Fonctionnalités implémentées

- ✅ Gestion de compte bancaire (Débiter, Créditer)
- ✅ Virement entre comptes
- ✅ Gestion des exceptions et validations
- ✅ Suite de tests unitaires complète (10 tests)

---

## 🏗️ Structure du projet

```
ProjetBanque/
├── Banque.sln                          # Solution principale
├── BanqueXXXX/                         # Bibliothèque de classes
│   ├── BanqueXXXX.csproj
│   └── CompteBancaire.cs               # Classe métier
├── BanqueTests/                        # Projet de tests unitaires
│   ├── BanqueTests.csproj
│   └── CompteBancaireTests.cs          # Tests unitaires
└── README.md                           # Ce fichier
```

---

## 🚀 Installation et exécution

### Prérequis

- .NET SDK 8.0 ou supérieur
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

Le projet contient **10 tests unitaires** couvrant les scénarios suivants :

#### Tests de la méthode `Débiter` (3 tests)

1. ✅ `VérifierDébitCompteCorrect` - Vérifie qu'un montant valide est correctement débité
2. ✅ `DébiterMontantNégatifSoulèveApplicationException` - Vérifie qu'un montant négatif lève une exception
3. ✅ `DébiterMontantSupérieurAuSoldeSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant supérieur au solde lève une exception

#### Tests de la méthode `Créditer` (3 tests)

4. ✅ `VérifierCréditCompteCorrect` - Vérifie qu'un montant valide est correctement crédité
5. ✅ `CréditerMontantNégatifSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant négatif lève une exception
6. ✅ `CréditerMontantZéroSoulèveArgumentOutOfRangeException` - Vérifie qu'un montant zéro lève une exception

#### Tests de la méthode `Virement` (4 tests)

7. ✅ `VirementCorrect` - Vérifie qu'un virement valide s'exécute correctement
8. ✅ `VirementMontantNégatifSoulèveException` - Vérifie qu'un montant négatif lève une exception
9. ✅ `VirementSoldeInsuffisantSoulèveException` - Vérifie qu'un solde insuffisant lève une exception
10. ✅ `VirementCompteNullSoulèveException` - Vérifie qu'un compte null lève une exception

### Résultats attendus

Tous les tests doivent passer avec succès :

```
Total tests: 10
     Passed: 10
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

- **Langage:** C# 12
- **Framework:** .NET 8.0
- **Framework de tests:** MSTest
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
- [x] Les 10 tests unitaires sont implémentés
- [x] Le README.md est complet
- [x] Le projet est poussé sur GitHub
- [x] Le lien GitHub a été partagé avec le professeur

---

*Dernière mise à jour : 8 décembre 2026*