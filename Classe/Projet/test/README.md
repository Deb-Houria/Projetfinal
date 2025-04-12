# Projetfinal – Application de gestion de garage mécanique 

Bienvenue dans **Projetfinal**, une application console C# développée sous **Visual Studio 2022 Community** dans le but de gérer 
efficacement les opérations d’un garage automobile. Ce projet couvre la gestion des utilisateurs, des véhicules, des réparations,
des devis, des factures et des paiements.

---- 

##  1. Récupération des données
Les données sont initialement fournies sous forme de fichiers CSV :
- `voitures_db.csv` : contient les voitures disponibles à la vente
- `reparations_db.csv` : contient les types de réparations et pièces associées

La bibliothèque **CsvHelper** est utilisée pour importer ces données et les convertir en objets exploitables dans l’application.

---

## 2. Fonctionnalités à implémenter

### 2.1.  Gestion des utilisateurs
L’application gère plusieurs rôles :
- **Propriétaire** : a tous les droits (ajout/modif/suppression des utilisateurs, pièces, véhicules, etc.)
- **Vendeur** : gère la vente de véhicules et pièces
- **Client** : peut consulter, acheter, gérer ses voitures, demander des réparations, consulter devis/factures, effectuer des paiements
- **Fournisseur** : gère l’approvisionnement en pièces et véhicules

Chaque utilisateur est défini par un `id`, un `mot de passe` et un `rôle`, tous stockés dans un fichier `utilisateurs.json`.

### 2.2. 🚘 Gestion des voitures des clients
Chaque client a un fichier personnel `voitures_client_<id>.json` qui contient ses voitures personnelles. Le client peut :
- Ajouter une voiture (marque, modèle, année, catégorie, kilométrage, prix estimé)
- Modifier/supprimer ses véhicules
- Voir ou importer ses voitures depuis un fichier JSON

Les voitures proposées à la vente sont stockées dans le fichier `voitures_db.csv`.

### 2.3. Gestion des réparations
Chaque réparation inclut :
- Type d’intervention (mécanique, carrosserie, électronique...)
- Description des travaux
- Coût estimé
- Liste des pièces utilisées

Les réparations sont historisées dans `reparations.json`. Le client peut également planifier des **entretiens** futurs via `entretiens.json`.

### 2.4.Gestion des devis
Chaque client peut créer un **devis** à partir de ses réparations. Il contient :
- Liste des travaux prévus
- Main-d’œuvre
- Coût estimé des pièces

Une fois validé, le devis peut être converti en **facture**.

### 2.5.Gestion des factures et paiements
Une facture inclut :
- Détail complet des interventions
- Coût total (pièces + main-d’œuvre)
- Paiement via : carte, espèces ou virement (via interface `IPaiement')

Les factures sont sauvegardées dans `factures.json', avec un champ pour le statut de paiement (payée/en attente).

---

## 2.6. Stockage des données de l'application
Toutes les entités sont stockées dans des fichiers **JSON** :
- `utilisateurs.json'
- `pieces.json'
- `reparations.json'
- `factures.json'
- `voitures_client_<id>.json'

La bibliothèque **Json.NET** est utilisée pour la sérialisation et la désérialisation.



## Lancer le projet
1. Ouvrir la solution dans Visual Studio
2. S’assurer que le dossier `test/` contient les fichiers `voitures_db.csv`, `reparations_db.csv`.


## Auteur
Debbioui Houria 
Étudiante en Maîtrise informatique – UQAR  
houriadebbioui@gmail.com  

/*Ce projet m’a permis de consolider mes compétences en C#, en conception orientée objet et en structuration d’applications 
multi-utilisateurs avec gestion de fichiers.*/
