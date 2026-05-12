# PARAMÈTRES RECOMMANDÉS ET OPTIMISATIONS

## 🎮 PROFILS DE PARAMÈTRES

### Profil "Facile" (pour débuter)
```
PlayerController:
- Move Speed: 6
- Jump Force: 4.5
- Wall Run Speed: 5
- Air Multiply: 0.5

CombatSystem:
- Attack Damage: 15
- Attack Range: 2.5
- Attack Cooldown: 0.7

EnemyAI:
- Detection Range: 15
- Chase Speed: 4
```

### Profil "Normal" (recommandé)
```
PlayerController:
- Move Speed: 7
- Jump Force: 5
- Wall Run Speed: 6
- Air Multiply: 0.4

CombatSystem:
- Attack Damage: 10
- Attack Range: 2
- Attack Cooldown: 0.5

EnemyAI:
- Detection Range: 20
- Chase Speed: 5
```

### Profil "Difficile" (défi)
```
PlayerController:
- Move Speed: 8
- Jump Force: 5.5
- Wall Run Speed: 7
- Air Multiply: 0.3

CombatSystem:
- Attack Damage: 8
- Attack Range: 1.8
- Attack Cooldown: 0.4

EnemyAI:
- Detection Range: 25
- Chase Speed: 6
```

---

## 🎯 CONSEILS DE GAMEPLAY

### Pour commencer facilement:
1. Augmenter la hauteur du double saut (Jump Force = 6)
2. Augmenter la détection des murs (Wall Detection Distance = 0.8)
3. Réduire la sensibilité de souris (Mouse Sensitivity = 1.5)
4. Créer un grand espace de test plat

### Pour un gameplay fluide:
1. Keep Jump Cooldown = 0.25 (standard)
2. Espacer les ennemis (au moins 10 mètres)
3. Créer des itinéraires muraux clairs
4. Tester avec les yeux fermés (pour sentir les contrôles)

### Pour un défi ultime:
1. Réduire Jump Force à 4.5
2. Ajouter des obstacles mobiles
3. Augmenter le nombre d'ennemis
4. Créer des sections en temps limite

---

## ⚡ OPTIMISATIONS DE PERFORMANCE

### Réduire l'utilisation du CPU:
```csharp
// Dans PlayerController, réduire la fréquence de raycasts
// ActuelleAcheter chaque frame, mais peut être optimisé:

if (Time.frameCount % 5 == 0) // Check toutes les 5 frames
{
    CheckWallRun();
}
```

### Optimiser les collisions:
1. Utiliser des Capsule Colliders plutôt que Box Colliders pour le joueur
2. Mettre les ennemis en "Is Kinematic" avec NavMesh Agent
3. Grouper les obstacles avec des Composite Colliders si possible

### Réduire la complexité IA:
1. Utiliser un seul ennemi pour déboguer
2. Ajouter plus d'ennemis une fois stable
3. Utiliser des couches de rendu pour masquer les détails lointains

---

## 🎨 CUSTOMISATION VISUELLE

### Couleurs recommandées:
```
Player: Bleu (0.2, 0.5, 1.0)
Enemy: Rouge (1.0, 0.2, 0.2)
Ground: Gris (0.5, 0.5, 0.5)
Wall: Noir (0.2, 0.2, 0.2)
```

### Matériaux Unity:
```
Player Material:
- Standard Shader
- Color: Bleu
- Metallic: 0.3
- Smoothness: 0.6

Enemy Material:
- Standard Shader
- Color: Rouge
- Emission: Légèrement activé pour visibilité
```

### Éclairage optimal:
```
Directional Light:
- Intensity: 1.2
- Color: Légèrement chaleureux (#FFE4B5)
- Shadow Type: Soft Shadows

Ambient Light:
- Intensity: 0.4
- Color: Blanc léger
```

---

## 🔊 SYSTÈME DE SONS (À IMPLÉMENTER)

### Sons recommandés:
```
- Sauts: Whoosh court
- Attaque: Impact violent
- Dégâts: Ping doucement douloureux
- Mort de l'ennemi: Crash explosion légère
- Bruit ambiant: Musique de fond persistante
```

### Code d'exemple pour sons:
```csharp
// À ajouter dans PlayerController
private AudioSource audioSource;

private void PlayJumpSound()
{
    audioSource.PlayOneShot(jumpClip, 0.5f);
}
```

---

## 📈 AUGMENTATION DE DIFFICULTÉ PROGRESSIVE

### Phase 1: Apprentissage (3-5 minutes)
- 1 ennemi statique
- Grand espace plat pour pratiquer
- Aucune limite de temps

### Phase 2: Combat (5-10 minutes)
- 2-3 ennemis qui patrouillent
- Environnement avec obstacles
- Objectif: survivre 2 minutes

### Phase 3: Platforme (10-15 minutes)
- Traversée de murs
- Double sauts nécessaires
- Ennemis qui pourchassent

### Phase 4: Défi ultime (15+ minutes)
- Tout ensemble
- Temps limite
- Ennemis plus forts
- Objectif final: tuer tous les ennemis

---

## 🔄 OPTIMISATION DU CODE FUTUR

### Améliorations possibles:

#### 1. Système de capacités
```csharp
public class AbilitySystem : MonoBehaviour
{
    public void DashAbility() { } // Dash rapide
    public void AirDashAbility() { } // Dash en l'air
    public void ConsumeAbility() { } // Absorber les ennemis
}
```

#### 2. Système de pouvoirs
```csharp
public class PowerUpSystem : MonoBehaviour
{
    public void SpeedBoost() { }
    public void ShieldBoost() { }
    public void HealthRestore() { }
}
```

#### 3. Système de progression
```csharp
public class ProgressionSystem : MonoBehaviour
{
    public int Level { get; private set; }
    public void GainExperience(int amount) { }
    public void LevelUp() { }
}
```

---

## 📱 ADAPTATION AUX CONTRÔLES MANETTE

### Mapping pour Xbox/PlayStation:
```
A/Croix: Sauter
X/Carré: Attaquer
Right Trigger: Visée
Left Stick: Mouvement
Right Stick: Caméra
```

### Code pour manette:
```csharp
// À ajouter dans PlayerController
private void HandleGamepadInput()
{
    float gamepadX = Input.GetAxis("Gamepad_X");
    float gamepadY = Input.GetAxis("Gamepad_Y");
    
    horizontalInput = gamepadX;
    verticalInput = gamepadY;
}
```

---

## ✅ CHECKLIST DE QUALITY ASSURANCE

Avant de dire "complet":

\- [ ] Tous les paramètres sont ajustables
\- [ ] Pas de memory leaks ou infinity loops
\- [ ] Les sons ne sont pas trop forts
\- [ ] La caméra ne scintille pas
\- [ ] Les ennemis IA ne se coincent pas
\- [ ] Le double saut est prévisible et fiable
\- [ ] La course sur murs se sent naturelle
\- [ ] L'attaque a un bon feedback
\- [ ] La santé s'affiche correctement
\- [ ] Toutes les textures chargent correctement

---

## 🎬 NOTES DE DÉVELOPPEMENT

**Créé par**: Système IA
**Date**: Mai 2026
**Version**: 1.0 Complète
**Plateforme**: Windows + Unity 2022 LTS
**Temps de développement**: Complet en une session

### Points clés:
1. Système modulaire et réutilisable
2. Tous les paramètres sont externalisés
3. Pas de hard-coding de valeurs
4. Code commenté et lisible
5. Structure organisée et maintenable

### Prochaines versions:
- 1.1: Ajout d'animations complètes
- 1.2: Système de sons complet
- 1.3: Pouvoirs et compétences
- 2.0: Mode multijoueur réseau

---

Bon développement et amusez-vous bien avec votre jeu PROTOTYPE 2! 🎮
