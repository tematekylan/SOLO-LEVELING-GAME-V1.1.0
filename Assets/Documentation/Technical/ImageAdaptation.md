# 🎨 Adaptation UI pour les images d'inventaire fournies

Ce fichier explique comment recréer et adapter uniquement les trois écrans d’UI visibles dans les images jointes :
- écran d’`Inventory`
- écran de `Status`
- écran de `Quest Info`

---

## 1. Préparer les images et les textures

1. Place toutes les images de fond dans `Assets/Textures/` ou `Assets/Images/`.
2. Sélectionne chaque image dans Unity et règle `Texture Type` sur `Sprite (2D and UI)`.
3. Si tu as des éléments de bordure ou des cadres séparés, importe-les aussi en tant que `Sprite`.
4. Si tu veux un fond animé, prépare un matériel `UI/Default` avec un shader de couleur animée.

## 2. Créer la structure principale du Canvas

1. Dans la hiérarchie, sélectionne `Canvas`.
2. Ajoute un `Panel` et renomme-le `InventoryRoot`.
3. Ajoute trois sous-panels :
   - `InventoryPanel`
   - `StatusPanel`
   - `QuestPanel`
4. Désactive `StatusPanel` et `QuestPanel` si tu veux les afficher séparément. Sinon, laisse-les visibles pour un menu de sélection.

## 3. Recréer l’image `Inventory`

### 3.1 Fond et cadre
- Ajoute un `Image` enfant dans `InventoryPanel`, renomme-le `InventoryBackground`.
- Assigne ton sprite principal de fond.
- Régle `Image Type` sur `Simple` ou `Sliced` selon le sprite.
- Ajoute un `Outline` ou `Shadow` si tu veux le halo lumineux.

### 3.2 Titre et boutons
- Ajoute un `TextMeshPro - Text` pour `INVENTORY`.
- Centre-le en haut.
- Utilise une police blanche ou gris clair avec une légère lueur extérieure.
- Ajoute un bouton `X` en haut à droite avec un sprite rouge et un `TextMeshPro` `X` blanc.

### 3.3 Grille des objets
- Ajoute un `GridLayoutGroup` dans un `Panel` enfant nommé `InventoryGrid`.
- Configure :
  - `Cell Size` pour des cases carrées
  - `Spacing` léger
  - `Constraint` en `Fixed Column Count` avec 5 colonnes si besoin
- Crée un prefab `InventorySlot` pour les cases vides.
  - un `Image` de cadre carré transparent avec bordure blanche
  - un `TextMeshPro` petit en bas à gauche pour la quantité

### 3.4 Icônes d’objets
- Pour chaque item visible, utilise un `Image` enfant de `InventorySlot`.
- Assigne les sprites des objets (armure, bottes, amulette, casque).
- Ajoute un label de nom sous chaque ligne d’icônes si nécessaire.

## 4. Recréer l’écran `Status`

### 4.1 Fond et structure
- Place un `Image` de fond dans `StatusPanel` avec le même style sombre.
- Ajoute un titre `STATUS` centré en haut.
- Ajoute un petit label `STATISTICS` en haut à droite.

### 4.2 Informations de personnage
- Utilise des `TextMeshPro` pour :
  - `NAME: SUNG JIN-WOO`
  - `JOB: ONE ABOVE ALL`
  - `TITLE: FALSE RANKER`
- Le niveau doit être grand, blanc et bien visible à droite.

### 4.3 Barres et statistiques
- Ajoute deux barres : `HP` et `IP`.
- Ajoute un texte `XP required to go to next Level: 851.0`.
- Crée des lignes de statistiques :
  - `STR`, `VIT`, `INT`, `PER`, `AGI`, `CMD`
- Ajoute un petit carré `+` à droite de chaque ligne pour l’amélioration.

### 4.4 Monnaie et points disponibles
- Ajoute une section `COINS` en bas gauche.
- Ajoute un encadré pour `Available Points` en bas droite.
- Utilise une police digitale claire.

## 5. Recréer l’écran `Quest Info`

### 5.1 Titre et objectif
- Ajoute un titre `QUEST INFO` centré en haut.
- Ajoute un sous-titre `Daily Quest: Player Training has arrived`.
- Ajoute un bouton `GOAL` sous le titre.

### 5.2 Liste des objectifs
- Crée une liste verticale avec des lignes de quête :
  - `Push-ups [0/15] +`
  - `Sit-ups [0/15] +`
  - `Squats [0/15] +`
  - `Running [0/1.5km] +`
  - `Chapter Reading [0/1.5] +`
  - `Proper Last Night Sleep [0/1] +`
- Chaque ligne est un `Horizontal Layout Group` avec le texte, l’état et un bouton `+`.

### 5.3 Bouton et avertissement
- Ajoute un bouton `COMPLETE QUEST` en bas au centre.
- Ajoute un texte d’avertissement sous la liste :
  - `WARNING: Failure to complete the daily quest will result in an appropriate penalty.`

### 5.4 Timer
- Ajoute un grand texte en bas pour `07:09:07`.
- Le style doit être épuré et lisible.

## 6. Utiliser les mêmes styles pour tous les écrans

- Couleurs principales : bleu nuit, blanc, gris métallique, touches de rouge/bleu clair.
- Bordures fines blanches ou bleues.
- Fond sombre avec effet de texture et reflets.
- Texte clair et espacé.
- Ajoute du `Canvas Group` si tu souhaites faire apparaître les panneaux avec fade.

## 7. Conseils d’intégration Unity

1. Crée un prefab pour chaque écran (`InventoryScreen`, `StatusScreen`, `QuestScreen`).
2. Utilise un seul `Canvas` et active/désactive les écrans selon le menu.
3. Ajoute `InventoryManager` ou un `MenuManager` pour contrôler l’ouverture/fermeture.
4. Place les images de fond en `UI/Image` et superpose des éléments transparents.

## 8. Nom des fichiers recommandés
- `Assets/Textures/inventory_background.png`
- `Assets/Textures/status_background.png`
- `Assets/Textures/quest_background.png`
- `Assets/Prefabs/UI/InventorySlot.prefab`
- `Assets/Prefabs/UI/InventoryScreen.prefab`

---

### Résultat attendu
Ton UI doit ressembler aux images jointes : un inventaire sombre et moderne, un écran de statut clair, et un écran de quête structuré avec un grand timer.

Utilise ce guide comme base de création pour adapter exactement ces trois écrans sans ajouter d’éléments extérieurs. 