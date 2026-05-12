le PlayerController.cs# Pause Menu - Interface Prototype 2

Ce guide explique comment créer un menu pause ressemblant à l'interface que vous avez montrée :
- `PROTOTYPE2` en haut à gauche
- date/heure au centre de la barre supérieure
- boutons `PAUSE` / `...` en haut à droite
- menu de navigation vertical à gauche
- colonnes de statistiques et contenus centraux

## Structure recommandée

PauseMenuPanel
├─ TopBar
│  ├─ LogoText (`[PROTOTYPE2]`)
│  ├─ DateTimeText
│  └─ TopRightPanel (`Pause`, `...`)
├─ LeftMenuPanel
│  ├─ MenuTitle (`NAVIGATION`)
│  ├─ ButtonReprendre
│  ├─ ButtonCarte
│  ├─ ButtonMutations
│  ├─ ButtonMissions
│  ├─ ButtonDefis
│  ├─ ButtonOptions
│  └─ ButtonQuitter
└─ ContentPanel
   ├─ StatsPanel
   │  ├─ BiomassCard
   │  └─ MutationsCard
   ├─ InfectionPanel
   │  ├─ ZoneRougeButton
   │  ├─ ZoneJauneButton
   │  └─ ZoneVerteButton
   ├─ AlertPanel
   │  ├─ BlackwatchLabel
   │  ├─ AlertBarMilitaire
   │  ├─ ContaminationLabel
   │  └─ ContaminationBar
   └─ MissionPanel
      ├─ MissionTitle
      └─ MissionDescription

## 1. Créer le Canvas

1. Dans Unity, clic droit dans `Hierarchy` → `UI` → `Canvas`.
2. Assurez-vous que `Render Mode` est `Screen Space - Overlay`.
3. Ajoutez un `Panel` enfant et nommez-le `PauseMenuPanel`.
4. Dans le `RectTransform` du panel, étirez-le pour recouvrir tout l'écran.

## 2. Ajouter la barre du haut

1. Dans Unity, clic droit dans `Hierarchy` → `UI` → `Canvas`.
2. Assurez-vous que `Render Mode` est `Screen Space - Overlay`.
3. Ajoutez un `Panel` enfant et nommez-le `PauseMenuPanel`.
4. Dans le `RectTransform` du panel, étirez-le pour recouvrir tout l'écran.

## 2. Ajouter la barre du haut

1. Dans `PauseMenuPanel`, ajoutez un enfant `UI` → `Panel`.
2. Renommez-le `TopBar`.
3. Ajustez sa hauteur à environ 120 px et placez-le en haut.
4. Ajoutez un `TextMeshPro - Text` enfant à `TopBar` et nommez-le `LogoText`.
   - Texte : `[PROTOTYPE2]`
   - Couleur : vert néon pour `PROTO`, rouge pour `TYPE2`
5. Ajoutez un `TextMeshPro - Text` enfant à `TopBar` et nommez-le `DateTimeText`.
6. Ajoutez un `Panel` enfant à `TopBar` nommé `TopRightPanel`.
   - Ajoutez deux `TextMeshPro` : `PauseText` et `MoreText`.
   - `PauseText` : `- PAUSE` (rouge clair)
   - `MoreText` : `...` (gris clair)

**Style recommandé :**
- `TopBar` background : très foncé (#050a0f)
- Texes : vert clair (#00ff9f), jaune (#ffd800), rouge (#ff4d4d)
- Police : `TextMeshPro` avec petit espacement et majuscules

**Texte du haut** :
- `LogoText` à gauche
- `DateTimeText` centré
- `PauseText` et `MoreText` à droite

## 3. Créer le menu gauche

1. Dans `PauseMenuPanel`, ajoutez un enfant `UI` → `Panel`.
2. Renommez-le `LeftMenuPanel`.
3. Ajustez sa largeur à environ 280 px et étirez-le verticalement.
4. Ajoutez un `TextMeshPro - Text` en haut du panel pour le titre `NAVIGATION`.
5. Ajoutez des boutons `Button - TextMeshPro` pour chaque section :
   - `Reprendre`
   - `Carte`
   - `Mutations`
   - `Missions`
   - `Defis`
   - `Options`
   - `Quitter`
6. Ajoutez une ligne séparatrice fine entre `Defis` et `Options`

**Style du menu gauche :**
- Fond : très foncé, légèrement transparent
- Texte : gris clair (#99aab5)
- Bouton actif : fond vert néon, bordure verte
- Icone de sélection : petit triangle `>` à droite de `Reprendre`

## 4. Créer les sections de contenu

1. Dans `PauseMenuPanel`, ajoutez plusieurs `UI` → `Panel` enfants pour chaque section de contenu.
2. Par exemple :
   - `SectionResume`
   - `SectionMap`
   - `SectionMutations`
   - `SectionMissions`
   - `SectionChallenges`
   - `SectionOptions`
3. Placez-les à droite du menu gauche, en occupant l'espace central.
4. Ajoutez des textes et indicateurs pour afficher :
   - Biomasse
   - Mutations
   - Zones d'infection
   - Niveau d'alerte Blackwatch
   - Mission en cours

**Organisation du contenu central :**
- Une ligne supérieure avec deux cartes côte à côte : `Biomasse` et `Mutations`
- Une ligne intermédiaire avec trois boutons stylisés : `Zone Rouge`, `Zone Jaune`, `Zone Verte`
- Une zone suivante avec deux barres de progression : `Alerte militaire` et `Contamination Blacklight`
- En bas, une grande carte de mission avec titre et description

**Style des cartes :**
- Bordure verte claire, fond presque noir transparent
- Texte titre en vert néon
- Barres de progression en dégradé vert / jaune / rouge selon le statut
- Boutons `Zone` : fond rouge, jaune ou vert, bordure dans la même couleur

## 5. Ajouter le script `PauseMenuManager`

1. Ajoutez le script `Assets/Scripts/UI/PauseMenuManager.cs` sur un GameObject vide (par exemple `UIManager` ou `PauseMenu`).
2. Assignez :
   - `Pause Menu Panel` → `PauseMenuPanel`
   - `Date Time Text` → `DateTimeText`
   - `Title Text` → votre titre (optionnel)
   - `Menu Buttons` → tous les boutons gauche dans l'ordre
   - `Content Sections` → toutes les sections correspondantes dans le même ordre
   - `Default Section Index` → `0` pour afficher `Reprendre` au démarrage

## 6. Configurer les boutons

Pour chaque bouton du menu gauche :
1. Dans `Button` → `On Click ()`, ajoutez le GameObject qui contient `PauseMenuManager`.
2. Choisissez `PauseMenuManager.ShowSection(int)`.
3. Mettez l'indice correspondant à la section :
   - `Reprendre` → 0
   - `Carte` → 1
   - `Mutations` → 2
   - `Missions` → 3
   - `Defis` → 4
   - `Options` → 5

Pour le bouton `Reprendre`, vous pouvez aussi ajouter `PauseMenuManager.ClosePauseMenu()`.

## 7. Tester le menu pause

1. Appuyez sur `Escape` pour ouvrir/fermer le menu.
2. Si le panneau est ouvert, le jeu doit être en pause (`Time.timeScale = 0`).
3. Si le panneau est fermé, le jeu doit reprendre (`Time.timeScale = 1`).

## 8. Personnalisation visuelle

- Utilisez des couleurs vertes et rouges comme sur votre image.
- Utilisez des `TextMeshPro` pour un rendu propre.
- Ajoutez des bordures et des séparateurs sur la gauche.
- Mettez un `Image` sous les boutons pour simuler un style console HUD.

## 9. Options supplémentaires possibles

- `Quitter` peut appeler `Application.Quit()`.
- `Reprendre` ferme le menu.
- `Carte` peut afficher une image de la zone.
- `Mutations` peut afficher une liste de statistiques et une jauge.
- `Mission en cours` peut être un `TextMeshPro` central.

---

Avec ce script et cette structure, vous pourrez obtenir l’interface pause que vous avez montrée : date/heure en haut, menu de navigation à gauche et contenu central dynamique.
