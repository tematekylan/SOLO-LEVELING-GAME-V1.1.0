# 🚀 GUIDE ÉTAPE PAR ÉTAPE - AJOUT D'ANIMATIONS AU JOUEUR

## ⚡ RAPPEL RAPIDE AVANT DE COMMENCER

**Votre projet SOLO LEVELING a déjà :**
- ✅ PlayerController avec mouvement, sprint, wall-run
- ✅ AnimationController étendu avec tous les paramètres
- ✅ Scripts de combat et pouvoirs James Heller
- ✅ Dossier Models/Player/ prêt pour les assets

---

## 📋 ÉTAPE 1: TÉLÉCHARGER LES ANIMATIONS (5 min)

### 1.1 Aller sur Mixamo
1. Ouvrir votre navigateur web
2. Aller sur : **https://www.mixamo.com/**
3. Créer un compte gratuit (si pas déjà fait)

### 1.2 Sélectionner un personnage
1. Dans "Characters", chercher : **"Male Soldier"** ou **"Hero Character"**
2. Sélectionner un modèle réaliste (pas trop stylisé)
3. Cliquer "Use" pour l'ajouter à votre projet

### 1.3 Sélectionner les animations essentielles
**Animations de BASE (obligatoires) :**
```
✓ Idle (repos) - chercher "idle"
✓ Walking (marche) - chercher "walk"
✓ Running (course) - chercher "run"
✓ Jumping (saut) - chercher "jump"
✓ Falling (chute) - chercher "fall"
✓ Landing (atterrissage) - chercher "land"
```

**Animations AVANCÉES (recommandées) :**
```
✓ Sprinting (sprint) - chercher "sprint" ou "run fast"
✓ Wall Run (mur) - chercher "climb" ou "wall run"
✓ Roll (roulade) - chercher "roll" ou "dodge roll"
✓ Punching (attaque) - chercher "punch" ou "fight"
✓ Death (mort) - chercher "death" ou "die"
```

### 1.4 Configuration Export
Pour CHAQUE animation :
1. Cliquer sur l'animation
2. Dans "Settings" :
   ```
   Format: FBX for Unity (.fbx)
   Pose: T-Pose
   Skin: With Skin
   Frames per Second: 30
   Keyframe Reduction: Auto
   ```
3. Cliquer "Download"

### 1.5 Téléchargement en lot
1. Aller dans "Downloads" (en haut à droite)
2. Sélectionner TOUTES les animations
3. Cliquer "Download" → "Batch"
4. Attendre le téléchargement du fichier ZIP

---

## 📥 ÉTAPE 2: IMPORTER DANS UNITY (10 min)

### 2.1 Extraire les fichiers
1. Ouvrir le fichier ZIP téléchargé
2. Créer un dossier temporaire sur votre bureau
3. Extraire tous les fichiers FBX

### 2.2 Organiser dans Unity
1. Ouvrir Unity avec votre projet SOLO LEVELING
2. Dans la fenêtre Project, aller dans `Assets/Models/Player/`
3. **Glisser-déposer** tous les fichiers FBX depuis votre dossier temporaire
4. Vous devriez voir :
   ```
   Assets/Models/Player/
   ├── Character.fbx (le modèle 3D)
   ├── Idle.fbx
   ├── Walking.fbx
   ├── Running.fbx
   ├── Jumping.fbx
   ├── Falling.fbx
   ├── Landing.fbx
   ├── Sprinting.fbx (si téléchargé)
   ├── WallRun.fbx (si téléchargé)
   ├── Punch.fbx (si téléchargé)
   └── Death.fbx (si téléchargé)
   ```

### 2.3 Configurer l'import FBX
**Pour le MODÈLE PRINCIPAL (Character.fbx) :**
1. Sélectionner `Character.fbx` dans Unity
2. Dans l'Inspector → Onglet "Rig" :
   ```
   Animation Type: Humanoid
   Avatar Definition: Create From This Model
   ```
3. Cliquer "Apply"

**Pour CHAQUE ANIMATION (.fbx) :**
1. Sélectionner l'animation
2. Dans l'Inspector → Onglet "Animation" :
   ```
   Loop Time: ✓ (coché pour animations répétitives)
   Root Transform Rotation: Bake Into Pose
   Root Transform Position (Y): Bake Into Pose
   Root Transform Position (XZ): Bake Into Pose
   ```
3. Cliquer "Apply"

---

## 🎭 ÉTAPE 3: CRÉER L'ANIMATOR CONTROLLER (15 min)

### 3.1 Créer le Controller
1. Dans la fenêtre Project, clic droit → **Create → Animator Controller**
2. Nommer : `PlayerAnimator`
3. Double-cliquer pour ouvrir la fenêtre Animator

### 3.2 Ajouter les paramètres
Dans la fenêtre Animator, onglet "Parameters" :
1. Cliquer "+" → **Float** → nommer `Speed`
2. Cliquer "+" → **Float** → nommer `VerticalVelocity`
3. Cliquer "+" → **Bool** → nommer `IsGrounded`
4. Cliquer "+" → **Bool** → nommer `IsWallRunning`
5. Cliquer "+" → **Bool** → nommer `IsSprinting`
6. Cliquer "+" → **Trigger** → nommer `Jump`
7. Cliquer "+" → **Trigger** → nommer `Land`
8. Cliquer "+" → **Trigger** → nommer `Roll`
9. Cliquer "+" → **Trigger** → nommer `Attack`
10. Cliquer "+" → **Trigger** → nommer `Absorb`
11. Cliquer "+" → **Trigger** → nommer `Sonar`
12. Cliquer "+" → **Trigger** → nommer `TakeDamage`
13. Cliquer "+" → **Trigger** → nommer `Die`

### 3.3 Créer les états d'animation
**Clic droit dans l'espace vide → Create State → Empty**

**États de BASE :**
1. **Idle** : Glisser l'animation `Idle` dessus
2. **Walking** : Glisser `Walking`
3. **Running** : Glisser `Running`
4. **Sprinting** : Glisser `Sprinting` (ou `Running` si pas de sprint)
5. **Jumping** : Glisser `Jumping`
6. **Falling** : Glisser `Falling`
7. **Landing** : Glisser `Landing`

**États AVANCÉS (optionnels) :**
8. **WallRunning** : Glisser `WallRun` (ou `Running` si pas disponible)
9. **Roll** : Glisser `Roll` (ou `Idle` si pas disponible)
10. **MeleeAttack** : Glisser `Punch` (ou `Idle` si pas disponible)
11. **Absorbing** : Glisser `Idle` (temporaire)
12. **SonarPulse** : Glisser `Idle` (temporaire)
13. **HitReaction** : Glisser `Idle` (temporaire)
14. **Death** : Glisser `Death` (ou `Idle` si pas disponible)

### 3.4 Configurer l'état par défaut
1. **Idle** devrait avoir une flèche orange (état par défaut)
2. Si ce n'est pas le cas : Clic droit sur **Idle** → **Set as Layer Default State**

---

## 🔗 ÉTAPE 4: CRÉER LES TRANSITIONS (20 min)

### 4.1 Transitions de MOUVEMENT
**Idle → Walking :**
1. Clic droit sur **Idle** → **Make Transition** → cliquer sur **Walking**
2. Sélectionner la flèche → Conditions :
   ```
   Speed > 0.1
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.15
   ```

**Walking → Running :**
1. Clic droit sur **Walking** → **Make Transition** → **Running**
2. Conditions :
   ```
   Speed > 3
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.2
   ```

**Running → Sprinting :**
1. Clic droit sur **Running** → **Make Transition** → **Sprinting**
2. Conditions :
   ```
   IsSprinting == true
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.1
   ```

### 4.2 Transitions de SAUT
**Any State → Jumping :**
1. Clic droit sur **Any State** → **Make Transition** → **Jumping**
2. Conditions :
   ```
   Jump (trigger)
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.1
   ```

**Jumping → Falling :**
1. Clic droit sur **Jumping** → **Make Transition** → **Falling**
2. Conditions :
   ```
   VerticalVelocity < -0.1
   ```
3. Settings :
   ```
   Has Exit Time: ✓
   Exit Time: 0.8
   Transition Duration: 0.2
   ```

**Falling → Landing :**
1. Clic droit sur **Falling** → **Make Transition** → **Landing**
2. Conditions :
   ```
   IsGrounded == true
   Land (trigger)
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.1
   ```

**Landing → Idle :**
1. Clic droit sur **Landing** → **Make Transition** → **Idle**
2. Conditions :
   ```
   Speed < 0.1
   ```
3. Settings :
   ```
   Has Exit Time: ✓
   Exit Time: 0.9
   Transition Duration: 0.2
   ```

### 4.3 Transitions de WALL-RUN (optionnel)
**Any State → WallRunning :**
1. Conditions :
   ```
   IsWallRunning == true
   ```
2. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.2
   ```

**WallRunning → Falling :**
1. Conditions :
   ```
   IsWallRunning == false
   VerticalVelocity < 0
   ```
2. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.3
   ```

### 4.4 Transitions de ROULADE (optionnel)
**Any State → Roll :**
1. Clic droit sur **Any State** → **Make Transition** → **Roll**
2. Conditions :
   ```
   Roll (trigger)
   ```
3. Settings :
   ```
   Has Exit Time: ✗
   Transition Duration: 0.1
   ```

**Roll → Idle :**
1. Clic droit sur **Roll** → **Make Transition** → **Idle**
2. Conditions :
   ```
   Speed < 0.1
   ```
3. Settings :
   ```
   Has Exit Time: ✓
   Exit Time: 0.9
   Transition Duration: 0.2
   ```

---

## 🎮 ÉTAPE 5: ATTACHER AU JOUEUR (5 min)

### 5.1 Ajouter les composants
1. Dans la Hierarchy, sélectionner votre **Player**
2. **Add Component** → **Animator**
3. Dans Animator :
   ```
   Controller: PlayerAnimator (que vous venez de créer)
   Avatar: Character (l'avatar du modèle FBX)
   Apply Root Motion: ✗ (décoché)
   Update Mode: Normal
   Culling Mode: Always Animate
   ```

### 5.2 Vérifier AnimationController
1. Votre **Player** devrait déjà avoir le script **AnimationController**
2. Vérifier que les références sont assignées :
   ```
   Animator: (assigné automatiquement)
   Player Controller: (votre PlayerController)
   Combat System: (votre CombatSystem)
   ```

---

## 🧪 ÉTAPE 6: TESTER LES ANIMATIONS (10 min)

### 6.1 Lancer le jeu
1. Sauvegarder la scène (Ctrl+S)
2. Appuyer sur **Play**

### 6.2 Tester les mouvements de base
**Dans le jeu :**
- **Marcher** : Appuyer Z → devrait passer Idle→Walking
- **Courir** : Maintenir Z + bouger → Walking→Running
- **Sprinter** : Maintenir Z + Shift → Running→Sprinting
- **Sauter** : Espace → Jumping→Falling→Landing

### 6.3 Tester avec l'interface debug
**Pendant le jeu :**
- Vous devriez voir des boutons en haut à gauche
- Tester "Jump", "Attack" pour voir les triggers

### 6.4 Vérifier les problèmes courants
**Si les animations ne marchent pas :**
1. Vérifier que l'Avatar est assigné dans l'Animator
2. Vérifier que les noms de paramètres correspondent
3. Vérifier que les transitions ont les bonnes conditions
4. Ouvrir Animator Window (Ctrl+6) pour voir l'état actif

---

## 🎨 ÉTAPE 7: AJOUTER LES POUVOIRS (optionnel - 15 min)

### 7.1 Animations de combat
**MeleeAttack → Idle :**
1. Créer transition depuis MeleeAttack
2. Conditions : aucune (retour auto)
3. Settings :
   ```
   Has Exit Time: ✓
   Exit Time: 0.9
   Transition Duration: 0.2
   ```

### 7.2 Animations de pouvoirs
**Any State → Absorbing :**
1. Conditions : `Absorb (trigger)`
2. Settings : Transition Duration: 0.1

**Any State → SonarPulse :**
1. Conditions : `Sonar (trigger)`
2. Settings : Transition Duration: 0.1

---

## ✅ ÉTAPE 8: VÉRIFICATION FINALE

### 8.1 Checklist
```
☐ Modèle FBX importé avec rig Humanoid
☐ Animations FBX configurées (Loop Time, Bake)
☐ Animator Controller créé avec tous les paramètres
☐ États d'animation créés et animations assignées
☐ Transitions configurées avec bonnes conditions
☐ Animator attaché au Player avec Controller et Avatar
☐ AnimationController script présent et configuré
☐ Test réussi : mouvements fluides
☐ Test réussi : sauts avec bonnes transitions
☐ Interface debug visible et fonctionnelle
```

### 8.2 Commandes de debug
**Dans la console Unity (pendant le jeu) :**
```csharp
// Pour voir les paramètres actifs
Debug.Log("Speed: " + animator.GetFloat("Speed"));
Debug.Log("IsGrounded: " + animator.GetBool("IsGrounded"));
```

### 8.3 Optimisations finales
1. **Compression** : Sélectionner chaque animation → Inspector → Animation → Compression
2. **LOD** : Pour les gros modèles, ajouter Level of Detail
3. **Pooling** : Si beaucoup d'ennemis, utiliser object pooling

---

## 🎯 PROBLÈMES COURANTS & SOLUTIONS

### **Problème 1: Animations ne se jouent pas**
**Solution :**
- Vérifier Avatar dans Animator
- Vérifier que les noms correspondent exactement
- Vérifier Apply Root Motion = false

### **Problème 2: Transitions saccadées**
**Solution :**
- Augmenter Transition Duration
- Utiliser des curves dans les transitions
- Vérifier les conditions de transition

### **Problème 3: Modèle T-pose au lieu d'animation**
**Solution :**
- Vérifier rig Humanoid
- Recréer l'Avatar
- Reimporter le FBX

### **Problème 4: Animations trop lentes/rapides**
**Solution :**
- Ajuster Speed dans les paramètres Animator
- Modifier Sample Rate dans l'animation

---

## 🚀 PROCHAINES ÉTAPES APRÈS ANIMATION

Une fois les animations de base fonctionnelles :

1. **Ajouter des effets visuels** (particules pour sauts, traces)
2. **Intégrer les sons** (pas, impacts, voix)
3. **Créer des ennemis animés**
4. **Ajouter des cinématiques**
5. **Optimiser les performances**

---

## 📞 SUPPORT

Si vous bloquez à une étape :
1. **Vérifier la console Unity** pour les erreurs
2. **Utiliser l'Animator Window** (Ctrl+6) pour debug
3. **Tester une animation seule** d'abord
4. **Comparer avec le guide** étape par étape

**Le jeu devrait maintenant se lancer avec des animations fluides !** 🎮

---

**Temps total estimé : 1h30 - 2h**
**Résultat : Personnage James Heller avec animations complètes**</content>
<parameter name="filePath">c:\Users\PC TRHEE T K\Unity Doc\SOLO LEVELING\Assets\Documentation\TUTORIEL_ANIMATIONS_COMPLET.md