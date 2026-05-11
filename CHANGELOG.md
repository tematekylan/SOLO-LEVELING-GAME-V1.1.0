# Changelog

Tous les changements importants de ce projet sont documentés dans ce fichier.

Le format est basé sur [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
et ce projet adhère au [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-05-07

### Added
- ✨ Système de mouvement complet avec accélération progressive
- ✨ Double saut implémenté et configurable
- ✨ Course sur murs avec détection raycast
- ✨ Système de combat mêlée avec zone d'attaque sphérique
- ✨ Système de santé générique (joueur + ennemis)
- ✨ Interface utilisateur avec barre de santé dynamique
- ✨ Caméra à la première personne fluide
- ✨ IA ennemie avec patrouille et poursuite (NavMesh)
- ✨ Gestionnaire de jeu avec recharge de scène
- ✨ Système de contrôle d'entrée centralisé
- ✨ Support pour animations avec AnimationController
- ✨ Configuration globale avec GameConfig

### Documentation
- 📚 Guide de configuration complet (8 étapes)
- 📚 Démarrage rapide (2-3 heures)
- 📚 Dépannage avancé avec 10 solutions
- 📚 Guide d'optimisation et paramètres
- 📚 Ressources d'apprentissage (tutoriels + livres)
- 📚 Checklist de vérification complète

### Project Structure
- 📂 Organisation modulaire des scripts
- 📂 Configuration projectile des paramètres
- 📂 Structure prête pour Git
- 📂 Support pour versions futures

## [1.0.1] - 2026-05-07

### Added
- ✨ Animation de roulade (shoulder roll) déclenchée par W + Espace
- ✨ Système de cooldown pour la roulade
- ✨ Paramètres configurables pour vitesse et durée de roulade

### Documentation
- 📚 Mise à jour du guide d'animations avec section roulade
- 📚 Ajout des transitions Animator pour l'état Roll

---

## Management de Versions

### Versions à Venir

#### [1.1.0] - Planned
- Animations complètes (joueur + ennemis)
- Système de sons avec AudioSource
- Plus de variété d'ennemis
- Système de pouvoirs spéciaux
- Support pour manette Xbox/PlayStation

#### [1.2.0] - Planned
- Niveaux supplémentaires
- Bosses avec IA avancée
- Système de progression
- Achievements/Stats
- Interface de menu principal

#### [2.0.0] - Long Term
- Multijoueur réseau
- Contenu utilisateur
- Éditeur de niveaux
- Support mobile
- Optimisations massives

---

## Politique de Versioning

Ce projet suit le **Semantic Versioning**:

- **MAJOR** (X.0.0): Changements incompatibles, features majeures
- **MINOR** (0.X.0): Nouvelles fonctionnalités compatibles
- **PATCH** (0.0.X): Corrections de bugs et petits ajustements

---

## Historique des Modifications

Pour chaque version, ce fichier docummente:

1. **Added**: Nouvelles fonctionnalités
2. **Changed**: Changements à des fonctionnalités existantes
3. **Deprecated**: Fonctionnalités bientôt supprimées
4. **Removed**: Fonctionnalités supprimées
5. **Fixed**: Corrections de bugs
6. **Security**: Correctifs de sécurité

---

## Comment Rapporter les Changements

Lors de créer une Pull Request, incluez:

1. Un titre clair
2. Description des changements
3. Raison de la modification
4. Tests effectués
5. Impact potentiel

Le titre doit suivre le format:
```
type(scope): description

type: feat, fix, docs, refactor, perf, test, ci
scope: PlayerController, CombatSystem, etc.
description: Description claire
```

Exemple:
```
feat(PlayerController): increase jump force to 5.5

- Augmente la force de saut pour meilleur gameplay
- Tested avec différents obstacles
- Paramètre configurable dans l'inspecteur
```

---

## Release Notes

Pour chaque release, créer une issue avec le tag "release" et:

1. Résumé des changements
2. Liste des features ajoutées
3. Liste des bugs corrigés
4. Instructions de mise à jour
5. Remerciements aux contributeurs

---

## Maintenance Schedule

- **Active Development**: Version courante (1.x.x)
- **Bug Fixes**: Version précédente pendant 6 mois
- **End of Life**: Plus ancienne version (moins de support)

---

## Support par Version

| Version | Support | Status |
|---------|---------|--------|
| 1.0.x   | Active  | Stable |
| 0.9.x   | Limited | Ended  |

---

**Dernière mise à jour**: 2026-05-07
**Version active**: 1.0.0
**Prochaine version**: 1.1.0 (Q3 2026)

Pour toute question sur un changement, créer une issue! 🎮
