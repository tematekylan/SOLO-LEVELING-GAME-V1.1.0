# 🎮 GUIDE D'INTÉGRATION DE PERSONNAGES ET ANIMATIONS

## 📋 SOURCES DE RESSOURCES GRATUITES

### 🎯 Sites Recommandés pour Modèles 3D

#### 1. **Mixamo** (Adobe) - ⭐ RECOMMANDÉ
- **URL**: https://www.mixamo.com/
- **Avantages**:
  - Animations de haute qualité
  - Personnages variés (humains, créatures)
  - Export direct vers Unity
  - Animations de combat, course, saut
- **Pour James Heller**:
  - Chercher "male character" ou "soldier"
  - Sélectionner animations: "running", "jumping", "fighting", "wall running"

#### 2. **Unity Asset Store** (Gratuit)
- **URL**: https://assetstore.unity.com/
- **Rechercher**: "free character model" ou "free animations"
- **Assets recommandés**:
  - "Unity-chan!" (personnage féminin avec animations)
  - "Ethan" (modèle de base Unity)
  - "Free Low Poly Character Pack"

#### 3. **OpenGameArt.org**
- **URL**: https://opengameart.org/
- **Avantages**: 100% gratuit, Creative Commons
- **Pour animations**: Chercher "character animations" ou "sprite sheets"

#### 4. **Kenney Assets** (Gratuit)
- **URL**: https://kenney.nl/assets?q=3d
- **Avantages**: Assets de qualité, optimisés pour jeux
- **Collections**: "Character Pack", "Animation Pack"

#### 5. **Blender Models** (Sites communautaires)
- **URL**: https://www.blendswap.com/ ou https://www.turbosquid.com/
- **Note**: Certains modèles nécessitent crédits

---

## 🎬 ANIMATIONS SPÉCIFIQUES POUR JAMES HELLER

### Animations Essentielles
```
✓ Idle (repos)
✓ Walking (marche)
✓ Running (course)
✓ Sprinting (sprint)
✓ Jumping (saut)
✓ Falling (chute)
✓ Landing (atterrissage)
✓ Wall Running (course murale)
✓ Air Dash (dash aérien)
✓ Melee Attacks (attaques griffes)
✓ Absorbing (absorption)
✓ Sonar Pulse (pulse sonar)
✓ Death (mort)
✓ Hit Reactions (réactions aux dégâts)
```

### Transitions d'Animation
- **Idle → Running**: Fluide en 0.2s
- **Running → Jumping**: Anticipation
- **Jumping → Falling**: Transition naturelle
- **Landing → Idle/Running**: Impact

---

## 🔧 GUIDE D'INTÉGRATION DANS UNITY

### Étape 1: Préparation du Modèle

#### 1.1 Télécharger depuis Mixamo
1. Aller sur https://www.mixamo.com/
2. Créer un compte gratuit
3. Chercher un modèle adapté (ex: "Male Soldier" ou "Hero Character")
4. Sélectionner les animations souhaitées

#### 1.2 Configuration Export
```
Format: FBX for Unity (.fbx)
Pose: T-Pose
Skin: With Skin
Frames per Second: 30
Keyframe Reduction: Auto
```

#### 1.3 Télécharger le pack complet
- Sélectionner toutes les animations
- Cliquer "Download" → "Batch"

### Étape 2: Import dans Unity

#### 2.1 Placer les fichiers
```
Assets/Models/Player/
├── Character.fbx (modèle 3D)
├── Idle.fbx (animation repos)
├── Running.fbx (animation course)
├── Jumping.fbx (animation saut)
├── ... (autres animations)
├── Materials/ (matériaux auto-générés)
└── Textures/ (textures du modèle)
```

#### 2.2 Configuration Import FBX
1. Sélectionner le fichier FBX dans Unity
2. Dans l'Inspector → Rig:
   ```
   Animation Type: Humanoid
   Avatar Definition: Create From This Model
   ```
3. Cliquer "Apply"

#### 2.3 Configuration Animations
1. Sélectionner chaque animation FBX
2. Dans l'Inspector → Animation:
   ```
   Loop Time: ✓ (pour animations répétitives)
   Root Transform Rotation: Bake Into Pose
   Root Transform Position (Y): Bake Into Pose
   Root Transform Position (XZ): Bake Into Pose
   ```

### Étape 3: Configuration Animator

#### 3.1 Créer Animator Controller
1. Clic droit dans Assets → Create → Animator Controller
2. Nommer "PlayerAnimator"
3. Double-clic pour ouvrir Animator Window

#### 3.2 États d'Animation
Créer ces états dans l'Animator:

**États de Base:**
- **Idle**: Animation de repos
- **Walking**: Marche lente
- **Running**: Course normale
- **Sprinting**: Course rapide
- **Jumping**: Saut ascendant
- **Falling**: Chute
- **Landing**: Atterrissage

**États de Combat:**
- **MeleeAttack1-5**: Combos griffes
- **Absorbing**: Animation absorption
- **SonarPulse**: Animation sonar

**États Spéciaux:**
- **WallRunning**: Course murale
- **AirDashing**: Dash aérien
- **HitReaction**: Réaction aux dégâts
- **Death**: Animation de mort

#### 3.3 Paramètres Animator
Créer ces paramètres (float/bool/trigger):

```
Float:
- Speed (0-2): contrôle vitesse déplacement
- VerticalVelocity (-10/+10): contrôle saut/chute

Bool:
- IsGrounded: au sol ou en l'air
- IsWallRunning: course murale active
- IsSprinting: sprint actif
- IsAttacking: en train d'attaquer

Trigger:
- Jump: déclenche saut
- Land: déclenche atterrissage
- Attack: déclenche attaque
- Absorb: déclenche absorption
- Sonar: déclenche pulse sonar
- TakeDamage: réaction aux dégâts
- Die: animation de mort
```

#### 3.4 Transitions
Configurer les transitions entre états:

**Exemple: Idle → Running**
```
Conditions: Speed > 0.1
Transition Duration: 0.15s
Has Exit Time: ✗
```

**Exemple: Running → Jumping**
```
Conditions: Jump trigger
Transition Duration: 0.1s
Has Exit Time: ✗
```

### Étape 4: Script AnimationController

#### 4.1 Créer le script
```csharp
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CombatSystem combatSystem;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (playerController == null)
            playerController = GetComponent<PlayerController>();
        if (combatSystem == null)
            combatSystem = GetComponent<CombatSystem>();
    }

    private void Update()
    {
        // Paramètres de mouvement
        float speed = playerController.Velocity.magnitude;
        animator.SetFloat("Speed", speed);

        float verticalVel = playerController.Velocity.y;
        animator.SetFloat("VerticalVelocity", verticalVel);

        // États booléens
        animator.SetBool("IsGrounded", playerController.IsGrounded);
        animator.SetBool("IsWallRunning", playerController.IsWallRunning);
        animator.SetBool("IsSprinting", playerController.IsSprinting);

        // États de combat
        if (combatSystem != null)
        {
            animator.SetBool("IsAttacking", combatSystem.IsAttacking);
        }
    }

    // Méthodes publiques pour triggers
    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void TriggerLand()
    {
        animator.SetTrigger("Land");
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void TriggerAbsorb()
    {
        animator.SetTrigger("Absorb");
    }

    public void TriggerSonar()
    {
        animator.SetTrigger("Sonar");
    }

    public void TriggerTakeDamage()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void TriggerDeath()
    {
        animator.SetTrigger("Die");
    }
}
```

#### 4.2 Intégration avec PlayerController
Ajouter dans PlayerController.cs:

```csharp
[Header("Animation")]
[SerializeField] private AnimationController animationController;

private void HandleJump()
{
    // ... code existant ...
    if (animationController != null)
        animationController.TriggerJump();
}

private void TriggerShockwave()
{
    // ... code existant ...
    if (animationController != null)
        animationController.TriggerLand();
}
```

---

## 🎨 OPTIMISATION DES ANIMATIONS

### Transitions Fluides
```
- Utiliser des transition curves pour des mouvements naturels
- Ajuster les transition durations (0.1s-0.3s)
- Utiliser des blend trees pour les directions
```

### Performance
```
- Compresser les animations (Keyframe Reduction)
- Utiliser Animation Culling pour les objets hors écran
- Précharger les animations importantes
```

### Debug Animation
```csharp
// Dans AnimationController.cs
private void OnGUI()
{
    if (GUI.Button(new Rect(10, 10, 100, 30), "Test Jump"))
        TriggerJump();
    if (GUI.Button(new Rect(10, 50, 100, 30), "Test Attack"))
        TriggerAttack();
}
```

---

## 🔍 RESSOURCES AVANCÉES

### Pour des Animations Plus Réalistes
- **Motion Capture**: Utiliser des données de capture réelle
- **Procedural Animation**: Générer des animations dynamiques
- **Blend Shapes**: Pour les expressions faciales

### Outils Recommandés
- **Unity Animation Rigging**: Pour des contrôles avancés
- **Timeline**: Pour des séquences cinématiques
- **Playable API**: Pour des systèmes d'animation complexes

---

## 📝 CHECKLIST D'INTÉGRATION

```
☐ Modèle 3D téléchargé depuis Mixamo
☐ Animations essentielles sélectionnées
☐ FBX importé dans Unity avec rig Humanoid
☐ Animator Controller créé avec tous les états
☐ Paramètres configurés (float/bool/trigger)
☐ Transitions définies entre états
☐ Script AnimationController créé et attaché
☐ Intégration avec PlayerController
☐ Test des animations de base (idle/walk/run/jump)
☐ Test des animations spéciales (combat/pouvoirs)
☐ Optimisation performance (compression)
☐ Debug et ajustements finaux
```

---

## 🎯 PROCHAINES ÉTAPES

1. **Tester les animations de base** (mouvement)
2. **Ajouter les animations de combat** (griffes)
3. **Implémenter les pouvoirs visuels** (tendacules, bio-bombe)
4. **Créer des effets de particules** (traces, impacts)
5. **Ajouter des sons** (pas, attaques, pouvoirs)

**Besoin d'aide pour une étape spécifique ?**