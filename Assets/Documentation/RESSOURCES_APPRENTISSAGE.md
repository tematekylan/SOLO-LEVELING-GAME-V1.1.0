# RESSOURCES D'APPRENTISSAGE ET TUTORIELS

## 📚 DOCUMENTATION OFFICIELLE UNITY

### Physique et Mouvement
- **Rigidbody & Forces**: https://docs.unity3d.com/Manual/RigidbodiesGetStarted.html
- **Physics Raycasting**: https://docs.unity3d.com/Manual/CastingRays.html
- **Collision Detection**: https://docs.unity3d.com/Manual/CollidersOverview.html

### IA et Navigation
- **NavMesh Overview**: https://docs.unity3d.com/Manual/nav-NavigationSystem.html
- **NavMesh Agent**: https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html
- **AI Pathfinding**: https://docs.unity3d.com/Manual/nav-PathFinding.html

### UI
- **Canvas & UI System**: https://docs.unity3d.com/Manual/UICanvas.html
- **UI Scaling**: https://docs.unity3d.com/Manual/UGUI-Canvas.html

### Input
- **Input Management**: https://docs.unity3d.com/Manual/Input.html
- **Input System (Nouveau)**: https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/

---

## 🎓 CONCEPTS CLÉ

### 1. Système de Physique
**Ce qu'il faut savoir:**
- Un Rigidbody contrôle les forces et collisions
- `rb.velocity` change la vitesse directement
- `rb.AddForce()` applique une force progressive
- `Physics.gravity` contrôle la gravité globale

**Ressource**: https://www.youtube.com/watch?v=7xABUTdKwxw (Physique dans Unity)

### 2. Raycasting et Détection
**Ce qu'il faut savoir:**
- `Physics.Raycast()` détecte les objets
- Les raycasts partent d'une position dans une direction
- Utilisé pour: sauts muraux, armes, vision IA

**Ressource**: https://www.youtube.com/watch?v=nFWwvQaBW1c (Raycasting Tutoriel)

### 3. Entrées (Input)
**Ce qu'il faut savoir:**
- `Input.GetKey` = touche maintenue
- `Input.GetKeyDown` = touche appuyée une fois
- `Input.GetAxis` = valeur continue (-1 à 1)

**Ressource**: https://www.youtube.com/watch?v=SkEyhPMfQzU (Gestion Input)

### 4. Caméra à la Première Personne
**Ce qu'il faut savoir:**
- La souris contrôle la rotation X (tilt)
- Le corps contrôle la rotation Y (rotation)
- Utiliser Quaternion.Euler pour les rotations

**Ressource**: https://www.youtube.com/watch?v=AgzwMCQN8AvU (FPS Camera)

### 5. Navigation IA (NavMesh)
**Ce qu'il faut savoir:**
- Une NavMesh est une surface "walkable"
- `NavMeshAgent.SetDestination()` pour pathfinding
- Bake la NavMesh après placer des obstacles

**Ressource**: https://www.youtube.com/watch?v=dv-gAWLfEqg (NavMesh AI)

---

## 💻 TUTORIELS VIDÉO RECOMMANDÉS

### Chaînes YouTube à Suivre:

#### 1. **Brackeys** (Meilleur pour débutants)
- FPS Controller from Scratch
- Jump System Tutorial
- AI Patrol and Chase
- Health System
**Lien**: https://www.youtube.com/@Brackeys

#### 2. **Sebastian Lague** (Avancé)
- Procedural Cave Generation
- Pathfinding Series
- Game Dev Concepts
**Lien**: https://www.youtube.com/@SebastianLague

#### 3. **Code Monkey** (Pratique)
- Movement Controller
- Combat Systems
- UI Management
**Lien**: https://www.youtube.com/@CodeMonkey

#### 4. **Traversy Media** (Complet)
- Unity Game Development Course
- 3D Game Concepts
- Project-Based Learning
**Lien**: https://www.youtube.com/@TraversyMedia

---

## 🎯 TUTORIELS SPÉCIFIQUES

### Double Saut
**Réalisé dans**: PlayerController.cs (lignes 45-130)
**Vidéo tutoriel**: https://www.youtube.com/watch?v=V7S6W9yl9is

**Concepts:**
```
1. Compteur de sauts: jumpCount
2. Limite: maxJumps = 2
3. Réinitialiser au sol
4. Cooldown entre sauts
```

### Course sur Murs
**Réalisé dans**: PlayerController.cs (lignes 71-92)
**Vidéo tutoriel**: https://www.youtube.com/watch?v=eYlHN1vghII

**Concepts:**
```
1. Raycasting pour détecter murs
2. Modifier la gravité en montée
3. Saut directionnel depuis mur
4. Désactiver grâce temps sur mur
```

### Système de Santé
**Réalisé dans**: Health.cs
**Vidéo tutoriel**: https://www.youtube.com/watch?v=Bjo8RhJUAR

**Concepts:**
```
1. Événement OnHealthChanged
2. Événement OnDeath
3. Destruction d'objet
4. Respawn optionnel
```

### Combat
**Réalisé dans**: CombatSystem.cs
**Vidéo tutoriel**: https://www.youtube.com/watch?v=cXw8407pBAs

**Concepts:**
```
1. Physics.OverlapSphere pour zone
2. Détection d'ennemis
3. Application de dégâts
4. Animation de feedback
```

---

## 📖 LIVRES RECOMMANDÉS

1. **"Unity in Action"** par Joseph Hocking
   - Fondamentaux pratiques
   - Exemples complets
   - Code explorable

2. **"Mastering Unity Networking"** par Vaughan
   - Concepts avancés
   - Optimisations
   - Patterns de code

3. **"Learning C# Programming with Unity"** par Jonathan Linietsky
   - C# spécifique à Unity
   - Bonnes pratiques
   - Performance

---

## 🎮 JEUX D'INSPIRATION

### PROTOTYPE 2 (Notre modèle)
- **Analyse**: Mécanique d'absorbation, combat fluide
- **À étudier**: 
  - Mouvement en l'air
  - Transhumance de murs
  - Combat viscéral
- **Ressource**: Game Analysis Videos sur YouTube

### Autre jeux d'inspiration de plateforme:
- **Mirror's Edge**: Parkour fluide, fluidité
- **Dying Light**: Escalade et mouvement
- **Titanfall**: Mécanique murale avancée
- **Dishonored**: Mouvement créatif

---

## 🛠️ OUTILS UTILES

### Logiciels de Modélisation:
- **Blender** (gratuit): https://www.blender.org/
- **Maya** (payant): https://www.autodesk.com/products/maya
- **3ds Max** (payant): https://www.autodesk.com/products/3dsmax

### Créateurs de Sons:
- **Audacity** (gratuit): https://www.audacityteam.org/
- **FMOD Studio** (gratuit/payant): https://www.fmod.com/
- **Wwise** (gratuit/payant): https://www.audiokinetic.com/

### Créateurs d'Animations:
- **MakeHuman** (gratuit): http://www.makehumancommunity.org/
- **Mixamo** (gratuit): https://www.mixamo.com/
- **Adobe Animate** (payant): https://www.adobe.com/products/animate

### Arts & Graphiques:
- **Aseprite** (pixel art): https://www.aseprite.org/
- **Photoshop** (payant): https://www.adobe.com/
- **GIMP** (gratuit): https://www.gimp.org/

---

## 📚 COMMUNAUTÉS À REJOINDRE

### Forums:
- **Unity Forums**: https://forum.unity.com/
- **GameDev Stack Overflow**: https://gamedev.stackexchange.com/
- **Reddit r/Unity3D**: https://www.reddit.com/r/Unity3D/

### Discords:
- **Official Unity Discord**: Invite via Unity
- **GameDev Community**: https://discord.gg/gamedev
- **Brackeys Discord**: https://discord.gg/brackeys

### Blogs:
- **Game Developers Blog**: https://blogs.unity3d.com/
- **Gamasutra**: https://www.gamasutra.com/
- **Game Jams**: https://itch.io/ (voir pour inspiration)

---

## 🎯 PARCOURS D'APPRENTISSAGE RECOMMANDÉ

### Semaine 1: Fondamentaux
- [ ] Regarder "Unity Basics" sur YouTube (2h)
- [ ] Comprendre le système de physique
- [ ] Créer un simple cube qui se déplace

### Semaine 2: Mouvement
- [ ] Implémenter le mouvement WASD
- [ ] Ajouter un système de saut basique
- [ ] Créer une caméra FPS

### Semaine 3: Combat et Santé
- [ ] Système de santé basique
- [ ] Zone de dégâts
- [ ] Feedback visuel

### Semaine 4: IA
- [ ] Ennemi qui patrouille
- [ ] Détection du joueur
- [ ] Poursuite simple

### Semaine 5: Polissage
- [ ] Animations
- [ ] Sons
- [ ] Effets visuels

### Semaine 6+: Avancé
- [ ] Pouvoirs spéciaux
- [ ] Niveaux plus complexes
- [ ] Optimisation

---

## 💡 CONSEILS PRATIQUES

### Performance:
1. Utiliser `Update()` pour les entrées
2. Utiliser `FixedUpdate()` pour la physique
3. Mettre en cache les références
4. Éviter les allocations dans les loops

### Code Quality:
1. Documenter avec triple slash `///`
2. Utiliser des noms de variables explicites
3. Grouper les propriétés avec [Header]
4. Tester avec une scène vide d'abord

### Debugging:
1. Utiliser `Debug.Log()` généreusement
2. Utiliser les Gizmos pour voir les raycasts
3. Mettre des breakpoints dans le code
4. Profiler avec Window > Analysis > Profiler

---

## 🎓 CERTIFICATION ET APPRENTISSAGE FORMEL

### Plateforme d'Apprentissage:
- **Unity Learn**: https://learn.unity.com/ (Gratuit & Payant)
- **Coursera**: https://www.coursera.org/ (Jeux vidéo)
- **Udemy**: https://www.udemy.com/ (Cours complets)
- **Skillshare**: https://www.skillshare.com/ (Projets)

### Certifications:
- **Unity Certified Associate**: Débutants
- **Unity Certified Expert**: Intermédiaire
- **Unity Certified Profesional**: Avancé

---

## 🎬 PROJETS À FAIRE

### Projet 1: Jeu de Plateforme Simple
**Durée**: 1 semaine
**Objectif**: Maîtriser le mouvement et les sauts
**Éléments**: Plateforme, piques, collectibles

### Projet 2: FPS Simple
**Durée**: 2 semaines
**Objectif**: Combat et IA
**Éléments**: Joueur, ennemis, niveaux

### Projet 3: Jeu Complet
**Durée**: 1 mois
**Objectif**: Intégration complète
**Éléments**: Tout ensemble avec polissage

---

**Dernier conseil**: Pratiquer régulièrement, créer des petits projets, et s'amuser! 
Le mieux est d'apprendre en faisant. 🎮

Bon apprentissage et bon développement! 🚀
