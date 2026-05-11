# README des mises à jour

Ce fichier récapitule les derniers ajouts et améliorations apportés au projet **SOLO LEVELING**.

## Dernières mises à jour

### 2026-05-11
- Ajout d'une mécanique de mouvement inspirée de James Heller :
  - Course rapide à 60 km/h.
  - Course murale à 40 km/h avec adhésion verticale.
  - Saut renforcé avec onde de choc à l'atterrissage (rayon 10m).
  - Double saut et air dash à 80 km/h avec 3 charges.
- Mise à jour du système de combat :
  - Combo de griffes sur 5 frappes.
  - Dégâts augmentés à 200 par coup de base.
- Création de nouveaux pouvoirs :
  - **Tendacules** : grab et whip sur zone.
  - **Bio-Bombe** : injection virale puis explosion à retardement.
  - **Absorption** : consommation d'ennemis pour se soigner.
  - **Sonar** : pulse de détection et révélation d'ennemis/points d'intérêt.
- Ajout d'un gestionnaire d'aptitudes pour regrouper ces pouvoirs.

## Fichiers ajoutés
- `Assets/Scripts/Player/PlayerController.cs` : mouvement, saut, course murale, air dash.
- `Assets/Scripts/Combat/CombatSystem.cs` : système de combos griffes.
- `Assets/Scripts/Combat/TendrilsAbility.cs` : capacité tendacules.
- `Assets/Scripts/Combat/BioBombAbility.cs` : capacité bio-bombe.
- `Assets/Scripts/Combat/AbsorptionAbility.cs` : capacité absorption.
- `Assets/Scripts/Combat/SonarAbility.cs` : capacité sonar.
- `Assets/Scripts/Combat/AbilityManager.cs` : gestion unifiée des pouvoirs.

## Objectifs pour la prochaine itération
- Implémenter les effets visuels et sonores pour chaque pouvoir.
- Ajouter un système de progression / upgrades pour chaque capacité.
- Intégrer des UI de cooldown et d'état des pouvoirs.
- Tester l'ensemble des mécaniques dans l'éditeur Unity.

## Notes de développement
- Tous les scripts sont basés sur un prototype modulaire, prêts pour être étendus.
- Les interactions mentionnées (infections, véhicules, objets destructibles) sont prévues mais restent à réaliser.
- Priorité : fluidité du gameplay à 60 FPS et retour haptique.

---

Ce fichier est destiné à être mis à jour à chaque ajout majeur de mécanique ou bugfix important.