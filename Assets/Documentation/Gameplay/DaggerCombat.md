# ⚔️ Système de Combat aux Dagues

## 🕹️ Touches de contrôle

| Action | Touche | Description |
|---|---|---|
| **Équiper dague slot 1** | `U` | Équipe la 1ère dague de l'inventaire |
| **Équiper dague slot 2** | `O` | Équipe la 2ème dague de l'inventaire |
| **Équiper dague slot 3** | `P` | Équipe la 3ème dague de l'inventaire |
| **Équiper dague slot 4** | `L` | Équipe la 4ème dague de l'inventaire |
| **Ranger la dague** | `X` | Range la dague dans l'inventaire |
| **Attaquer** | `Mouse 0` (Click gauche) | Effectue une attaque avec la dague équipée |

---

## 📦 Inventaire de dagues

- **Max 4 dagues** dans l'inventaire
- Les dagues peuvent être équipées/rangées rapidement
- Chaque slot correspond à une touche

---

## ⚔️ Système de combat

### Stats par dague
- **Dégâts de base** — Dégâts min/max par attaque
- **Vitesse d'attaque** — Cooldown entre attaques
- **Portée** — Rayon de détection des ennemis
- **Poison** — Certaines dagues infligent du poison

### Système de combo
- Attaques rapides en succession = bonus de dégâts
- Chaque coup ajoute **+10% de dégâts**
- Fenêtre de combo : **1 seconde**
- Le combo se réinitialise après 1 seconde d'inactivité

### Exemple de dégâts
```
Dague simple : 25 dégâts
Attaque 1 : 25 dégâts (combo x1)
Attaque 2 : 27.5 dégâts (combo x2 = +10%)
Attaque 3 : 30 dégâts (combo x3 = +20%)
```

---

## 💀 Types de dagues

| Dague | Dégâts | Vitesse | Poison |
|---|---|---|---|
| **Croc empoisonné de Casaka** | 25 | Lent | ✓ -1% HP/sec |
| **Knight Killer** | 75 | Moyen | ✗ |
| **Dague de Baruka** | 110 | Rapide | ✗ |
| **Épées du Roi Démon** | 220 | Ultra-rapide | ✗ |

---

## 🔧 Integration dans Unity

### 1. Ajouter les scripts au joueur
- Attache `DaggerInventory.cs` au joueur
- Attache `DaggerCombat.cs` au joueur
- Assigne les références dans l'inspecteur

### 2. Créer les prefabs de dagues
- Crée un objet 3D pour chaque dague (cube, model, etc.)
- Ajoute un `Collider` trigger
- Ajoute le script `Dagger.cs`
- Configure les stats dans l'inspecteur

### 3. Initialiser l'inventaire (optional)
- Ajoute des dagues au joueur via code ou l'éditeur
- Les dagues peuvent être trouvées en jeu

---

## 💡 Améliorations futures

- [ ] Animations d'attaque
- [ ] Effets visuels (traînées, particules)
- [ ] Système de poison complet avec durée
- [ ] Échange d'armes dual-wield
- [ ] Attaques spéciales avec les épées du Roi Démon
- [ ] Barre de cooldown visuelle
- [ ] Affichage du combo en temps réel
