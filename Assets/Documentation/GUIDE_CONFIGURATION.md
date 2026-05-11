# GUIDE DE CONFIGURATION - PROTOTYPE 2 STYLE GAME

## 📋 ÉTAPE 1: PRÉPARATION DE LA SCÈNE

### 1.1 Créer les couches (Layers)
1. Aller dans Edit > Project Settings > Tags and Layers
2. Ajouter les couches suivantes dans "Layers":
   - Player
   - Enemy
   - Ground
   - Wall

### 1.2 Créer les tags
1. Aller dans Edit > Project Settings > Tags and Layers
2. Ajouter les tags:
   - Player
   - Enemy
   - Ground

### 1.3 Configuration des entrées
1. Aller dans Edit > Project Settings > Input Manager
2. Vérifier que les axes suivants existent:
   - Horizontal (touche A/D ou gauche/droite)
   - Vertical (touche Z/S ou haut/bas)
   - Mouse X et Mouse Y existent déjà par défaut

---

## 🎮 ÉTAPE 2: CONFIGURATION DU JOUEUR

### 2.1 Créer le GameObject Joueur
1. Créer un nouveau Cube (GameObject > 3D Object > Cube)
2. Renommer en "Player"
3. Positionner à (0, 1, 0)
4. Modifier l'échelle à (0.8, 1.8, 0.8)
5. Ajouter le Tag "Player" et la couche "Player"

### 2.2 Ajouter le Rigidbody
1. Dans l'Inspecteur du Player, cliquer Add Component > Physics > Rigidbody
2. Paramètres:
   - Mass: 1
   - Drag: 5
   - Angular Drag: 0.05
   - Use Gravity: ✓ (coché)
   - Is Kinematic: ✗ (décoché)
   - Freeze Rotation: ✓ (X, Y, Z coché)

### 2.3 Ajouter les scripts du joueur
1. Cliquer Add Component > Script > PlayerController
2. Configurer les paramètres dans l'Inspecteur:
   - Move Speed: 7
   - Ground Drag: 5
   - Air Drag: 2
   - Jump Force: 5
   - Wall Run Speed: 6
   - Wall Run Gravity: 1
   - Wall Jump Up Force: 5
   - Wall Jump Side Force: 3
   - Ground Layer: Ground
   - Wall Detection Distance: 0.5

3. Cliquer Add Component > Script > Health
4. Configurer:
   - Max Health: 100

5. Cliquer Add Component > Script > CombatSystem
6. Configurer:
   - Attack Range: 2
   - Attack Damage: 10
   - Attack Cooldown: 0.5
   - Enemy Layer: Enemy

### 2.4 Créer la caméra enfant
1. Dans la hiérarchie, créer un nouveau Cube enfant du Player
2. Renommer en "CameraHolder"
3. Réinitialiser sa Transform (position 0, 0, 0 et rotation 0, 0, 0)
4. Supprimer le Collider

5. Créer un Cube enfant du CameraHolder
6. Renommer en "MainCamera"
7. Positionner à (0, 0.6, 0)
8. Supprimer le Collider et le Rigidbody

9. Sélectionner MainCamera:
   - Supprimer la Camera par défaut si présente
   - Ajouter Add Component > Rendering > Camera
   - Ajouter Add Component > Rendering > AudioListener

10. Sélectionner CameraHolder:
    - Ajouter Add Component > Script > CameraController
    - Configurer:
      - Mouse Sensitivity: 2
      - Max Look Angle: 90
      - Player Body: sélectionner le Player

---

## 🌍 ÉTAPE 3: CONFIGURATION DE L'ENVIRONNEMENT

### 3.1 Créer le sol
1. Créer un Cube (GameObject > 3D Object > Cube)
2. Renommer en "Ground"
3. Réinitialiser la position
4. Modifier l'échelle à (50, 1, 50)
5. Ajouter le Tag "Ground" et la couche "Ground"
6. Dans le Rigidbody, cocher "Is Kinematic"
7. Le Collider existe déjà par défaut

### 3.2 Créer des murs pour tester la course
1. Créer un Cube (GameObject > 3D Object > Cube)
2. Renommer en "Wall"
3. Positionner à (-5, 2, 0)
4. Modifier l'échelle à (1, 4, 50)
5. Ajouter la couche "Ground" et la couche "Wall"
6. Dans le Rigidbody, cocher "Is Kinematic"

### 3.3 Créer des obstacles supplémentaires
1. Dupliquer le mur et le positionner à (5, 2, 0)
2. Créer des cubes obstacles à différentes positions pour tester les sauts

---

## 🎯 ÉTAPE 4: CONFIGURATION DE L'IA ENNEMIE (OPTIONNEL)

### 4.1 Créer un ennemi
1. Créer un Cube (GameObject > 3D Object > Cube)
2. Renommer en "Enemy"
3. Positionner à (5, 1, 10)
4. Modifier l'échelle à (0.8, 1.8, 0.8)
5. Ajouter le Tag "Enemy" et la couche "Enemy"

### 4.2 Ajouter les composants
1. Ajouter un Rigidbody:
   - Mass: 1
   - Is Kinematic: ✓
   
2. Ajouter Add Component > Navigation > Nav Mesh Agent

3. Cliquer Add Component > Script > Health
   - Max Health: 50

4. Cliquer Add Component > Script > EnemyAI
   - Detection Range: 20
   - Attack Range: 2
   - Patrol Speed: 3.5
   - Chase Speed: 5
   - Patrol Points: ajouter des points

### 4.3 Créer une NavMesh
1. Sélectionner le sol et tous les obstacles
2. Dans l'Inspecteur, cocher "Walkable" dans les propriétés de navigation
3. Aller dans Window > AI > Navigation
4. Cliquer "Bake" pour générer la NavMesh

---

## 🖼️ ÉTAPE 5: CONFIGURATION DE L'INTERFACE (UI)

### 5.1 Créer le Canvas
1. Créer un Canvas (GameObject > UI > Canvas)
2. Renommer en "UICanvas"
3. Configurer:
   - Render Mode: Screen Space - Overlay
   - Canvas Scaler: Scale Mode à "Scale With Screen Size"

### 5.2 Créer la barre de santé
1. Créer une Image enfant du Canvas
2. Renommer en "HealthBarBackground"
3. Positionner haut-gauche de l'écran
4. Ajouter une Image avec couleur de fond (gris)

5. Créer une Image enfant de HealthBarBackground
6. Renommer en "HealthBar"
7. Configurer:
   - Image Type: Filled
   - Fill Method: Horizontal
   - Fill Amount: 1

### 5.3 Ajouter les textes
1. Créer un Text enfant du Canvas pour afficher la santé
2. Créer un Text pour afficher la vitesse
3. Créer un Text pour afficher les sauts

4. Sélectionner le Canvas:
   - Ajouter Add Component > Script > UIManager
   - Configurer:
     - Health Bar: HealthBar Image
     - Health Text: le Text de santé
     - Speed Text: le Text de vitesse
     - Jump Count Text: le Text de sauts
     - Player Controller: sélectionner le Player
     - Player Health: sélectionner le Health du Player

---

## ⚙️ ÉTAPE 6: CONFIGURATION DU GESTIONNAIRE DE JEU

### 6.1 Créer le GameManager
1. Créer un GameObject vide
2. Renommer en "GameManager"
3. Ajouter Add Component > Script > GameManager
4. Ce script gère les rechargements de scène

---

## 🎮 ÉTAPE 7: ÉCLAIRAGE

### 7.1 Configurer la lumière directionnelle
1. Sélectionner "Directional Light" dans la scène
2. Paramètres recommandés:
   - Intensity: 1
   - Color: blanc (#FFFFFF)
   - Rotation: (50, -30, 0)

### 7.2 Ajouter l'éclairage ambiant
1. Aller dans Window > Rendering > Lighting
2. Ambient Light: blanc avec intensité 0.3

---

## 🚀 ÉTAPE 8: COMPILATION ET TEST

### 8.1 Avant de compiler
1. Vérifier que toutes les couches sont assignées correctement
2. Vérifier que le Player a tous les scripts nécessaires
3. Vérifier que la NavMesh est baked si vous utilisez les ennemis
4. Sauvegarder la scène (Ctrl + S)

### 8.2 Tester le jeu
1. Appuyer sur Play dans l'Éditeur
2. Tester les contrôles:
   - Z/S et A/D: se déplacer
   - Espace: sauter (2 fois pour double saut)
   - Souris: regarder autour
   - Clic gauche: attaquer
   - Échap: déverrouiller la souris
   - R: recharger la scène

---

## 🐛 DÉPANNAGE

### Le joueur tombe sans cesse
- Vérifier que le Rigidbody a "Use Gravity" coché
- Vérifier que la couche Ground est bien définie dans PlayerController

### Le joueur ne peut pas courir sur les murs
- Vérifier que les murs ont la couche Ground
- Vérifier que Wall Detection Distance n'est pas trop petit
- Vérifier que le mur est suffisamment proche

### La caméra ne suit pas
- Vérifier que CameraController est sur le CameraHolder
- Vérifier que Player Body pointe vers le Player

### Les ennemis ne bougent pas
- Vérifier que la NavMesh est baked
- Vérifier que le terrain est assigné à "Walkable"
- Vérifier que le NavMesh Agent a un target valide

---

## 📝 NOTES IMPORTANTES

✓ Double saut: Configuré pour 2 sauts maximum
✓ Course sur murs: Activée automatiquement près des murs
✓ Combat: Clic gauche avec zone d'effet
✓ Santé: Système de barre de santé fonctionnelle
✓ UI: Affichage de la vitesse, des sauts et de la santé

---

## 🎯 FONCTIONNALITÉS PROTOTYPE 2

Voici ce qui est implémenté:

1. **Mouvement Fluide** - COMPLÈTE
   - Accélération/Décélération progressive
   - Friction du sol

2. **Double Saut** - COMPLÈTE ✓
   - Premier saut au sol
   - Deuxième saut en l'air
   - Cooldown entre les sauts

3. **Course sur Murs** - COMPLÈTE ✓
   - Détection des murs avec raycasts
   - Mouvement vertical sur murs
   - Saut depuis les murs avec angle de sortie

4. **Combat Proche** - COMPLÈTE ✓
   - Zone d'attaque avec OverlapSphere
   - Système de dégâts
   - Cooldown d'attaque

5. **Caméra à la Première Personne** - COMPLÈTE ✓
   - Sensibilité de souris configurable
   - Angle de regard limité

6. **Système de Santé** - COMPLÈTE ✓
   - Barre de santé affichée
   - Événements de dégâts

7. **IA Ennemie (Navmesh)** - COMPLÈTE ✓
   - Patrouille automatique
   - Poursuite du joueur
   - Détection de la distance

---

Bon jeu! Si vous avez besoin d'aide, vérifier d'abord le dépannage ci-dessus.
