# 🎮 DÉMARRAGE RAPIDE - VOTRE JEU EN 2H

## ⏱️ PLAN D'ACTION COMPLET

### **Étape 0: Vérification Préalable (5 min)**
```
☐ Unity 2022 LTS installé?
☐ Le projet s'ouvre sans erreur?
☐ Console vide (pas d'erreurs rouge)?
```

---

### **Étape 1: Créer l'Environnement de Base (20 min)**

#### 1.1 Créer les couches
```
Edit > Project Settings > Tags and Layers

"Layers" - Ajouter:
+ Player
+ Enemy  
+ Ground
+ Wall
```

#### 1.2 Créer les tags
```
"Tags" - Ajouter:
+ Player
+ Enemy
+ Ground
```

#### 1.3 Créer le Ground
```
GameObject > 3D Object > Cube
Renommer: "Ground"
Position: (0, 0, 0)
Scale: (50, 1, 50)
Tag: Ground
Layer: Ground
Rigidbody > Is Kinematic: ✓
```

#### 1.4 Créer les Murs
```
Dupliquer Ground deux fois

Mur 1:
  Nom: Wall_Left
  Position: (-5, 2, 0)
  Scale: (1, 4, 50)
  Layer: Ground

Mur 2:
  Nom: Wall_Right
  Position: (5, 2, 0)
  Scale: (1, 4, 50)
  Layer: Ground
```

---

### **Étape 2: Créer le Joueur (25 min)**

#### 2.1 GameObject Principal
```
GameObject > Create Empty
Renommer: "Player"
Position: (0, 1, 0)
Scale: (1, 1, 1)
Tag: Player
Layer: Player

Ajouter Cube enfant:
  Renommer: "Body"
  Scale: (0.8, 1.8, 0.8)
```

#### 2.2 Ajouter les Composants Physiques
```
Sélectionner "Player":

Add Component > Physics > Rigidbody
├─ Mass: 1
├─ Drag: 5
├─ Angular Drag: 0.05
├─ Use Gravity: ✓
├─ Is Kinematic: ✗
└─ Freeze Rotation: X,Y,Z ✓

Add Component > Physics > Capsule Collider
├─ Radius: 0.4
└─ Height: 1.8
```

#### 2.3 Ajouter les Scripts
```
Add Component > Script > PlayerController

Paramètres à mettre:
├─ Move Speed: 7
├─ Jump Force: 5
├─ Ground Layer: Ground
├─ Wall Detection Distance: 0.5
└─ Autres: garder par défaut

Add Component > Script > Health
└─ Max Health: 100

Add Component > Script > CombatSystem
├─ Attack Damage: 10
├─ Attack Range: 2
├─ Enemy Layer: Enemy
└─ Autres: par défaut
```

---

### **Étape 3: Créer la Caméra (15 min)**

#### 3.1 CameraHolder
```
Créer GameObject enfant du Player
Renommer: "CameraHolder"
Position: (0, 0, 0)
Rotation: (0, 0, 0)
Supprimer le Collider

Add Component > Script > CameraController
├─ Mouse Sensitivity: 2
├─ Player Body: Player
└─ Max Look Angle: 90
```

#### 3.2 MainCamera
```
Créer GameObject enfant du CameraHolder
Renommer: "MainCamera"
Position: (0, 0.6, 0)
Supprimer le Collider et Rigidbody

Add Component > Camera
Add Component > Audio Listener
```

---

### **Étape 4: Créer l'Interface (15 min)**

#### 4.1 Canvas
```
GameObject > UI > Canvas
Renommer: "UICanvas"

Canvas Scaler:
├─ UI Scale Mode: Scale With Screen Size
├─ Reference Resolution: 1920x1080
└─ Match: 0.5

Layout Group > Layout > Canvas
- Render Mode: Screen Space - Overlay
```

#### 4.2 Éléments UI
```
Créer enfant du Canvas:

1. Text pour Santé
   - Nom: HealthText
   - Position: (-900, 900, 0)
   - Text: "Health: 100/100"
   - Font Size: 30

2. Image pour Barre de Santé
   - Nom: HealthBarBg
   - Anchorée: haut-gauche
   - Position: (-850, -50, 0)
   - Size: (400, 50)
   - Color: gris

3. Image enfant (pour remplissage)
   - Nom: HealthBar
   - Image Type: Filled
   - Fill Method: Horizontal
   - Fill Amount: 1

3. Text pour Vitesse
   - Nom: SpeedText
   - Position: (-900, 800, 0)

4. Text pour Sauts
   - Nom: JumpCountText
   - Position: (-900, 700, 0)
```

#### 4.3 UIManager Script
```
Canvas > Add Component > Script > UIManager

Assigner:
├─ Health Bar: HealthBar Image
├─ Health Text: HealthText
├─ Speed Text: SpeedText
├─ Jump Count Text: JumpCountText
├─ Player Controller: Player
└─ Player Health: Player (Health component)
```

---

### **Étape 5: Créer un Ennemi (10 min)** [OPTIONNEL]

#### 5.1 GameObject
```
GameObject > 3D Object > Cube
Renommer: "Enemy"
Position: (10, 1, 0)
Scale: (0.8, 1.8, 0.8)
Tag: Enemy
Layer: Enemy
```

#### 5.2 Composants
```
Add Component > Physics > Rigidbody
└─ Is Kinematic: ✓

Add Component > Navigation > Nav Mesh Agent

Add Component > Script > Health
└─ Max Health: 50

Add Component > Script > EnemyAI
├─ Detection Range: 20
├─ Chase Speed: 5
├─ Patrol Speed: 3.5
└─ Patrol Points: ajouter positions
```

#### 5.3 Créer NavMesh
```
Sélectionner Ground + Murs + Obstacles

Window > AI > Navigation

Vérifier "Walkable" est ✓

Cliquer "Bake"
(du bleu doit apparaître)
```

---

### **Étape 6: Configuration Finale (15 min)**

#### 6.1 Ajouter GameManager
```
GameObject > Create Empty
Renommer: "GameManager"

Add Component > Script > GameManager
(Pas de paramètres à configurer)
```

#### 6.2 Configurer la Lumière
```
Sélectionner "Directional Light"

Intensity: 1
Color: blanc (#FFFFFF)
Rotation: (50, -30, 0)
Shadow Type: Soft Shadows
```

#### 6.3 Sauvegarder
```
Ctrl + S > Nommer la scène "MainScene"
```

---

### **Étape 7: Test (15 min)**

#### 7.1 Vérification Rapide
```
Appuyer sur Play

Test:
✓ Le joueur se déplace (ZQSD)
✓ Saute avec Espace
✓ Double saut fonctionne
✓ Caméra suit la souris
✓ Clic gauche attaque
✓ Barre de santé affichée
✓ Pas d'erreurs console
```

#### 7.2 Ajustements
```
Si saut trop faible: augmenter Jump Force
Si trop vite: diminuer Move Speed
Si caméra lente: augmenter Mouse Sensitivity
Si mur ne fonctionne pas: augmenter Wall Detection Distance
```

---

## 🎮 CONTRÔLES FINAUX

| Action | Touche |
|--------|--------|
| Avancer | Z |
| Reculer | S |
| Gauche | A |
| Droite | D |
| Sauter | Espace (x2) |
| Caméra | Souris |
| Attaquer | Clic Gauche |
| Recharger | R |
| Déverrouiller souris | Échap |

---

## ✅ CHECKLIST AVANT DE JOUER

```
☐ Tous les scripts compilent sans erreur
☐ Le joueur se déplace correctement
☐ Le double saut fonctionne
☐ La seule saut sur mur fonctionne
☐ L'attaque peut tuer un ennemi
☐ La caméra suit bien
☐ L'interface affiche les stats
☐ Aucune erreur en console quand tu joues
☐ Le jeu tourne à 60 FPS stable
```

**Si tous les éléments sont ✓ = VOUS ÊTES PRÊT À JOUER!**

---

## 🚀 PROCHAINES ÉTAPES AVANCÉES

Une fois que tout est fonctionnel:

1. **Ajouter des Animations**
   - Créer un Animator Controller
   - Assigner à AnimationController.cs

2. **Ajouter des Sons**
   - Créer des AudioSources
   - Lire sons dans les scripts

3. **Créer des Niveaux**
   - Dupliquer la scène
   - Ajouter plus d'obstacles et ennemis
   - Créer des zones de victoire

4. **Effets Visuels**
   - Particules à l'attaque
   - Particules à la mort d'ennemi
   - Feedback visuel de saut

5. **Optimisation**
   - Build et tester performance
   - Profiler pour trouver les problèmes
   - Optimiser le code si nécessaire

---

## 📱 DOCUMENTS À CONSULTER

Pendant la configuration:
1. **GUIDE_CONFIGURATION.md** - Plus détaillé
2. **PARAMETRES_OPTIMISATIONS.md** - Ajustements
3. **CHECKLIST_VERIFICATION.md** - Vérification complète
4. **DEPANNAGE_AVANCE.md** - Si ça ne marche pas
5. **RESSOURCES_APPRENTISSAGE.md** - Pour apprendre plus

---

## 🎯 TEMPS ESTIMÉ

- Configuration: 1.5-2 heures
- Tests et ajustements: 30 minutes
- Polissage (optionnel): 30 minutes
- **TOTAL: 2-3 heures**

Après 3 heures, vous aurez un jeu PROTOTYPE 2 **absolument fonctionnel!** 🎮

---

**Bon développement et amusez-vous! 🚀**

*Si vous avez des questions, consulter la section "Dépannage" dans DEPANNAGE_AVANCE.md*
