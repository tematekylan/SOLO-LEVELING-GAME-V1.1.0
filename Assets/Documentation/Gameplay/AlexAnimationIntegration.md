# 🎬 Intégration des animations Alex

## 📋 Animations disponibles

Voici les animations que tu as téléchargées pour le personnage Alex :

| Nom | Type | Utilisation |
|---|---|---|
| **Alex@Idle** | Mouvement | Inactivité du personnage |
| **Alex@Walking** | Mouvement | Marche normale |
| **Alex@Running** | Mouvement | Course sprinte |
| **Alex@Flying** | Mouvement | Vol/Déplacement aérien |
| **Alex@Big Jump** | Saut | Saut simple |
| **Alex@Mutant Jumping** | Saut | Double saut/Saut puissant |
| **Alex@Wall Run** | Saut | Course sur mur |
| **Alex@Fall A Land To Run Forward** | Saut | Atterrissage et transition |
| **Alex@Punching** | Combat | Attaque poing rapide |
| **Alex@Boxing** | Combat | Attaque poing puissant |
| **Alex@Throwing** | Combat | Lancer/Throw (dague) |
| **Alex@Inward Block** | Combat | Blocage défensif |
| **Alex@Victory** | État | Victoire/Célébration |
| **Alex@Death From The Front** | État | Mort par l'avant |

---

## 🔧 Configuration dans Unity

### Étape 1 : Importer les animations

1. Les animations doivent être dans `Assets/Animation/` ou un dossier similaire
2. Assure-toi que chaque animation est importée correctement :
   - Format : `.fbx` ou répertoire des animations
   - Rig : Humanoid
   - Animation : Enabled

### Étape 2 : Créer l'Animator Controller

1. **Crée un nouveau Animator Controller** :
   - Clic droit dans `Assets/Animators/`
   - `Create` → `Animator Controller`
   - Nomme-le `PlayerAnimator`

2. **Ajoute les animations au Controller** :
   - Double-clique sur `PlayerAnimator`
   - Organise les états en layers :
     - **Movement** : Idle, Walk, Run, Flying
     - **Jump** : Jump, MutantJump, WallRun, Land
     - **Combat** : Punch, Boxing, Throw, Block
     - **Special** : Victory, Death

### Étape 3 : Créer les transitions

#### Transitions de mouvement
```
Idle → Walking (Speed > 0.1)
Walking → Running (Speed > 5)
Running → Idle (Speed < 0.1)
Idle → Flying (IsAirborne = true)
Flying → Falling (Vertical Velocity < -1)
```

#### Transitions de saut
```
Any → Jump (Jump trigger)
Jump → Falling (Jump duration ended)
Any → WallRun (IsWallRunning = true)
WallRun → Jump (Jump trigger)
Any → Land (IsGrounded = true)
```

#### Transitions de combat
```
Any → Punch (Attack trigger)
Punch → Idle (Animation finished)
Any → Boxing (Power Attack trigger)
Any → Block (Block trigger)
```

### Étape 4 : Assigner à Unity

1. **Sélectionne le joueur** dans la hiérarchie
2. **Dans l'Animator component** :
   - Assigne `PlayerAnimator` au champ `Controller`
3. **Ajoute les scripts** :
   - Attache `AnimationMapper.cs` au joueur
   - Attache `AnimationController.cs` au joueur
4. **Configure les références** dans l'inspecteur

### Étape 5 : Configuration dans AnimationMapper

Dans l'inspecteur du composant `AnimationMapper` :
- Assigne chaque animation au champ correspondant
- Tous les noms doivent correspondre exactement aux noms dans l'Animator

---

## 🕹️ Utilisation dans le code

### Exemple : Déclencher une animation

```csharp
AnimationMapper mapper = GetComponent<AnimationMapper>();

// Déclencher une animation de mouvement
mapper.PlayRun();
mapper.PlayJump();
mapper.PlayWallRun();

// Déclencher une animation de combat
mapper.PlayPunch();
mapper.PlayThrow();

// Animations spéciales
mapper.PlayVictory();
mapper.PlayDeath();
```

### Intégration avec PlayerController

Le `PlayerController` peut appeler directement les animations via `AnimationMapper` :

```csharp
[SerializeField] private AnimationMapper animationMapper;

private void Jump()
{
    // ... code de saut
    if (jumpCount == 2)
        animationMapper.PlayMutantJump();
    else
        animationMapper.PlayJump();
}

private void CheckWallRun()
{
    if (isWallRunning)
        animationMapper.PlayWallRun();
}
```

---

## 📊 Exemple de structure Animator complète

```
PlayerAnimator
├── Movement Layer
│   ├── Idle
│   ├── Walking
│   ├── Running
│   └── Flying
├── Jump Layer
│   ├── Jump
│   ├── MutantJump
│   ├── WallRun
│   └── Land
├── Combat Layer
│   ├── Punch
│   ├── Boxing
│   ├── Throw
│   └── Block
└── Special Layer
    ├── Victory
    └── Death
```

---

## 💡 Astuce

- **Humanoid Rig** : Assure-toi que chaque animation utilise un rig humanoid compatible
- **Import Settings** : Vérifie que les animations sont bien extraites (Extract All)
- **Animation Clips** : Renomme les clips pour correspondre aux noms attendus
- **Transitions** : Ajoute des temps de transition légers (0.1s) entre les états

---

## 🚀 Prochaines étapes

1. [ ] Importer les animations dans Unity
2. [ ] Créer l'Animator Controller
3. [ ] Ajouter les états et transitions
4. [ ] Assigner à AnimationMapper
5. [ ] Tester avec les touches du jeu
6. [ ] Ajuster les transitions si nécessaire
