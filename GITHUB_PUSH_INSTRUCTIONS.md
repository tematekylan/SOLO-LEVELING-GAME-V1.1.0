# 🚀 INSTRUCTIONS POUR POUSSER SUR GITHUB

## ✅ ÉTAPE 1: Vérification Préalable

Les fichiers suivants ont été créés:
```
✓ .gitignore - Exclut les fichiers Unity temporaires
✓ .gitattributes - Configure les types de fichiers
✓ LICENSE - MIT License
✓ CONTRIBUTING.md - Guide de contribution
✓ CHANGELOG.md - Historique des versions
✓ .github/ISSUE_TEMPLATE/ - Templates issues
```

---

## 🔧 ÉTAPE 2: Configuration Git Local

### 2.1 Initialiser le repository Git (première fois seulement)
```powershell
cd "c:\Users\PC TRHEE T K\Unity Doc\SOLO LEVELING"
git init
git config user.name "Votre Nom"
git config user.email "votre.email@example.com"
```

### 2.2 Configurer Git (optionnel - global)
```powershell
git config --global user.name "Votre Nom"
git config --global user.email "votre.email@example.com"
```

---

## 📝 ÉTAPE 3: Ajouter et Commiter

### 3.1 Ajouter tous les fichiers
```powershell
git add .
```

### 3.2 Vérifier les fichiers à commiter
```powershell
git status
```

**Vous devriez voir:**
- ✓ Les scripts C# dans Assets/Scripts/
- ✓ Les documents Markdown
- ✓ Les fichiers de configuration (.gitignore, .gitattributes, etc.)
- ✗ Pas de Library/, Temp/, Build/, obj/ (ignorés par .gitignore)

### 3.3 Faire le premier commit
```powershell
git commit -m "Initial commit: PROTOTYPE 2 game system complete

- Ajout de 11 scripts C# fonctionnels
- Système de mouvement avec double saut
- Système de combat et IA ennemie
- Documentation complète
- Configuration pour GitHub"
```

---

## 🌐 ÉTAPE 4: Créer le Repository sur GitHub

### 4.1 Aller sur GitHub.com
1. Se connecter à votre compte GitHub
2. Cliquer sur "+" > "New repository"

### 4.2 Configurer le repository
```
Repository name: SOLO-LEVELING
(ou un autre nom de votre choix)

Description: 
"A complete PROTOTYPE 2 style game system in Unity 
with double jump, wall running, melee combat, and enemy AI"

Visibility: Public (ou Private selon vos préférences)

❌ Ne cochez PAS "Initialize this repository with..."
   (nous avons déjà nos fichiers)
```

### 4.3 Cliquer sur "Create repository"

---

## 🔗 ÉTAPE 5: Lier le Repository Local à GitHub

GitHub affichera les commandes. Voici pour vous:

```powershell
# Remplacer VOTRE_USERNAME par votre pseudo GitHub
git remote add origin https://github.com/VOTRE_USERNAME/SOLO-LEVELING.git

# Renommer la branche si nécessaire
git branch -M main

# Pousser vers GitHub
git push -u origin main
```

**Exemple concret:**
```powershell
git remote add origin https://github.com/jean-dupont/SOLO-LEVELING.git
git branch -M main
git push -u origin main
```

---

## ✅ ÉTAPE 6: Vérification sur GitHub

1. Aller sur `https://github.com/VOTRE_USERNAME/SOLO-LEVELING`
2. Vous devriez voir:
   - ✓ Tous les fichiers visibles
   - ✓ README.md affiché automatiquement
   - ✓ Structure Assets/ complète
   - ✓ 11 commits ou 1 commit initial

---

## 🔄 ÉTAPE 7: Mises à Jour Futures

Après des modifications locales:

```powershell
# Ajouter les changements
git add .

# Commiter avec un message clair
git commit -m "feat: description du changement"

# Pousser vers GitHub
git push origin main
```

Format du commit:
- `feat:` Nouvelle fonctionnalité
- `fix:` Correction de bug
- `docs:` Documentation
- `refactor:` Restructuration code
- `perf:` Amélioration performance

---

## 🎯 COMMANDES ESSENTIELLES

```powershell
# Voir le statut
git status

# Voir l'historique des commits
git log --oneline

# Voir les changements avant commit
git diff

# Annuler un changement
git checkout -- nomFichier

# Voir les branches
git branch -a

# Créer une nouvelle branche
git checkout -b feature/ma-feature

# Changer de branche
git checkout main

# Fusionner une branche
git merge feature/ma-feature
```

---

## 🛡️ BONNES PRATIQUES

### ✓ À FAIRE
```
✓ Commiter régulièrement (pas 1x par semaine)
✓ Messages de commit clairs et courts
✓ Respecter le .gitignore
✓ Créer des branches pour les features
✓ Documenter les changements importants
✓ Mettre à jour CHANGELOG.md
```

### ✗ À ÉVITER
```
✗ Ne pas commiter Library/ (300+ MB)
✗ Ne pas commiter Build/
✗ Ne pas commiter .vs/ (fichiers Visual Studio)
✗ Pas de messages "test" ou "fix"
✗ Ne pas pousser sur main en simultané avec d'autres
✗ Fichiers LFS (trop de bande passante)
```

---

## 🚨 PROBLÈMES COURANTS

### Problème 1: "fatal: not a git repository"
**Solution:**
```powershell
cd "c:\Users\PC TRHEE T K\Unity Doc\SOLO LEVELING"
git init
```

### Problème 2: "Authentication required"
**Solution:**
1. Utiliser un Personal Access Token (meilleure pratique)
2. Aller sur GitHub > Settings > Developer settings > Personal access tokens
3. Créer un token avec droits 'repo'
4. Utiliser lors du push

### Problème 3: "remote already exists"
**Solution:**
```powershell
git remote remove origin
git remote add origin https://github.com/VOTRE_USERNAME/SOLO-LEVELING.git
```

### Problème 4: Library/ envoie trop de données
**Solution:**
```powershell
# Arrêter l'upload avec Ctrl+C
# Ensuite:
git reset HEAD~1
rm -r Library/
git add .
git commit -m "Add project files without Library/"
git push -u origin main
```

### Problème 5: Commits depuis la mauvaise branche
**Solution:**
```powershell
git reset --soft HEAD~1
git checkout -b feature/correct-branch
git commit -m "message correct"
git push origin feature/correct-branch
```

---

## 📊 VÉRIFICATION FINALE

Avant de pousser:
```powershell
# Vérifier le statut
git status

# Devrait afficher:
# On branch main
# nothing to commit, working tree clean

# Vérifier les fichiers à pousser
git log --oneline -3

# Vérifier la remote
git remote -v
```

Devrait afficher:
```
origin  https://github.com/VOTRE_USERNAME/SOLO-LEVELING.git (fetch)
origin  https://github.com/VOTRE_USERNAME/SOLO-LEVELING.git (push)
```

---

## 🎯 CHECKLIST AVANT PUSH

```
☐ Tous les scripts C# ont été ajoutés
☐ Les documents Markdown sont présents
☐ .gitignore est configuré
☐ .gitattributes est configuré
☐ LICENSE est présent
☐ Repository créé sur GitHub
☐ Git init et config fait
☐ Premier commit réalisé
☐ Remote origin configuré
☐ Aucun dossier Library/ n'a été commité
☐ Push réussi sur GitHub
☐ Les fichiers sont visibles sur GitHub
```

---

## 📚 RESSOURCES UTILES

- **Git Basics**: https://git-scm.com/doc
- **GitHub Flow**: https://guides.github.com/introduction/flow/
- **Commit Messages**: https://www.conventionalcommits.org/
- **GitHub CLI**: https://cli.github.com/

---

## 🔐 SÉCURITÉ

### Protéger votre code
```
1. Ne jamais commiter de secrets/passwords
2. Utiliser .gitignore pour les fichiers sensibles
3. Activer la vérification à deux facteurs sur GitHub
4. Utiliser des SSH keys plutôt que passwords
```

### Configurer SSH (optionnel mais recommandé)
```powershell
# Générer une clé SSH
ssh-keygen -t ed25519 -C "votre.email@example.com"

# Ajouter à GitHub:
# Settings > SSH and GPG keys > New SSH key
# Coller le contenu de ~/.ssh/id_ed25519.pub

# Puis utiliser:
git remote set-url origin git@github.com:VOTRE_USERNAME/SOLO-LEVELING.git
```

---

## 🎉 C'EST FAIT!

Votre projet est maintenant sur GitHub! 🎊

**Prochaines étapes:**
1. Ajouter des collaborateurs (si voulu)
2. Configurer les branches protégées
3. Activer les Actions GitHub (optionnel)
4. Ajouter des badges au README.md
5. Commencer à développer!

---

**Questions?** Consulter la documentation Git officielle ou GitHub Help.

**Bon développement sur GitHub!** 🚀
