# Guide de Contribution

## 📋 Avant de Contribuer

1. **Lire le README.md** pour comprendre la structure du projet
2. **Consulter le GUIDE_CONFIGURATION.md** pour comprendre l'architecture
3. **Vérifier les issues ouvertes** pour voir si quelque chose est en cours

## 🎯 Comment Contribuer

### 1. Fork le Repository
```bash
# Sur GitHub, cliquer sur "Fork"
```

### 2. Cloner votre Fork
```bash
git clone https://github.com/VOTRE_USERNAME/SOLO-LEVELING.git
cd SOLO-LEVELING
```

### 3. Créer une Branche Feature
```bash
git checkout -b feature/ma-feature
# ou pour un bugfix:
git checkout -b bugfix/ma-correction
```

### 4. Faire vos Modifications
- Respecter le style de code existant
- Commenter votre code en français ou anglais
- Mettre à jour la documentation si nécessaire

### 5. Tester Complètement
```bash
# Dans Unity:
1. Ouvrir la scène de test
2. Appuyer Play et tester tous les contrôles
3. Vérifier la console pour les erreurs
4. Vérifier les performances
```

### 6. Commit et Push
```bash
git add .
git commit -m "feat: Description claire de la modification"
git push origin feature/ma-feature
```

Le message de commit doit suivre le format:
- `feat:` Pour une nouvelle fonctionnalité
- `fix:` Pour une correction de bug
- `docs:` Pour la documentation
- `refactor:` Pour du refactoring de code
- `perf:` Pour des améliorations de performance

### 7. Faire une Pull Request
1. Aller sur GitHub
2. Cliquer sur "New Pull Request"
3. Sélectionner votre branche
4. Décrire vos modifications
5. Soumettre

## 📝 Conventions de Code

### C#
```csharp
// Noms de classe: PascalCase
public class PlayerController : MonoBehaviour

// Noms de variables: camelCase
private float moveSpeed = 7f;

// Noms de méthodes: PascalCase
private void MovePlayer()

// Constantes: UPPER_CASE
private const float FRICTION_MULTIPLIER = 1.2f;

// Propriétés avec triple-slash
/// <summary>
/// Description claire de ce que fait cette méthode
/// </summary>
/// <param name="paramName">Description du paramètre</param>
/// <returns>Description de ce qui est retourné</returns>
public float GetHealth()
{
    return currentHealth;
}
```

### Organisation du Code
```csharp
public class Example : MonoBehaviour
{
    // 1. Variables avec [SerializeField]
    [SerializeField] private float speed = 5f;
    
    // 2. Variables privées
    private Rigidbody rb;
    
    // 3. Propriétés
    public float Speed { get; private set; }
    
    // 4. Unity Lifecycle (Awake, Start, Update, etc.)
    private void Start() { }
    private void Update() { }
    
    // 5. Méthodes publiques
    public void DoSomething() { }
    
    // 6. Méthodes privées
    private void PrivateMethod() { }
}
```

## 🐛 Signaler un Bug

Créer une issue avec:
1. **Titre clair**: "Bug: [Description courte]"
2. **Description**: Pas à pas pour reproduire
3. **Console output**: Copier les erreurs
4. **Environnement**: Version Unity, OS, specs

## 💡 Suggérer une Feature

Créer une issue avec:
1. **Titre**: "Feature: [Description]"
2. **Motivation**: Pourquoi c'est utile
3. **Implémentation proposée**: Comment le faire
4. **Alternatives**: D'autres approches?

## 📚 Standards de Documentation

- Tout code public doit avoir des commentaires triple-slash
- Les fichiers markdown doivent suivre la structure existante
- Les images dans la doc doivent être en PNG optimisé
- Les liens doivent être relatifs au dossier du projet

## ✅ Checklist avant de Soumettre

- [ ] Code compile sans erreurs
- [ ] Pas d'avertissements Console
- [ ] Code respecte les conventions
- [ ] Documentation mise à jour si nécessaire
- [ ] Tests passent dans Unity
- [ ] Commit message clair et descriptif
- [ ] Pas de fichiers de build inclus
- [ ] .gitignore respecté

## 🎓 Questions?

1. Vérifiez les issues existantes
2. Consultez le GUIDE_CONFIGURATION.md
3. Regardez le code existant pour les exemples
4. Créez une discussion si besoin

## 📜 Code of Conduct

- Respectez tous les contributeurs
- Soyez constructif dans les code reviews
- Pas de spam ou contenu offensant
- Les violations peuvent entraîner un bannissement

---

**Merci de contribuer!** Votre aide rend ce projet meilleur! 🎮
