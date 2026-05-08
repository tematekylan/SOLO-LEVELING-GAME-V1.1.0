# FICHIER DE DÉPANNAGE AVANCÉ

## 🔴 ERREURS COURANTES ET SOLUTIONS

### **Erreur 1: "CS0246: The type or namespace name 'X' could not be found"**

**Symptôme**: Ligne rouge en rouge sous un nom de classe

**Cause**: Namespace mal configuré ou script dans le mauvais endroit

**Solution**:
```
1. Vérifier que le script est dans le bon dossier
   Assets/Scripts/[Category]/ScriptName.cs

2. Vérifier le namespace du script (début du fichier)
3. Recompiler en appuyant sur Ctrl + S
4. Si toujours erreur, supprimer et recréer le script
```

---

### **Erreur 2: "NullReferenceException: Object reference not set"**

**Symptôme**: Crash boîte rouge "Null reference"

**Cause**: Vous essayez d'accéder à quelque chose qui n'existe pas

**Solutions selon le contexte**:

**Pour PlayerController:**
- Vérifier que le Rigidbody est assigné
- Vérifier que groundLayer est assigné
- C'est normal si Ground Layer n'est pas assigné au démarrage (script le crée)

**Pour CameraController:**
- Vérifier que playerBody est assigné correctement
- playerBody doit être le parent (the actual player object)

**Pour CombatSystem:**
- Vérifier que enemyLayer est assigné
- Vérifier que attackPoint existe (ou null, c'est ok)

**Pour UIManager:**
- Vérifier que healthBar Image est assignée
- Vérifier que playerController est assigné
- Vérifier que playerHealth est assigné

---

### **Erreur 3: Le joueur tombe infiniment**

**Symptôme**: Character tombe sans s'arrêter

**Vérifications**:
```csharp
1. Physics > Gravity = (0, -9.81, 0)  ✓

2. Player Rigidbody:
   - Use Gravity: ✓ COCHÉ
   - Is Kinematic: ✗ DÉCOCHÉ
   - Drag = 5
   
3. Ground GameObject:
   - Doit avoir un Collider
   - Doit avoir la couche "Ground"
   - PlayerController groundLayer = Ground
```

**Testez** avec ce code debug:
```csharp
// Ajouter dans PlayerController Update()
Debug.Log($"IsGrounded: {isGrounded}, Velocity: {rb.velocity}");
```

---

### **Erreur 4: Le joueur ne peut pas sauter**

**Symptôme**: Espace n'a aucun effet

**Vérifications**:
```
1. Input Manager > Horizontal/Vertical
2. Player Rigidbody > Use Gravity ✓
3. Rigidbody Mass = 1 (trop lourd ralentit le saut)
4. Jump Cooldown est peut-être trop court
```

**Debug**:
```csharp
// Ajouter dans PlayerController
void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
        Debug.Log("Space pressed!");
    }
    // ... reste du code
}
```

---

### **Erreur 5: Course sur murs ne fonctionne pas**

**Symptôme**: Joueur colle pas au mur

**Vérifications**:
```
1. Ground Layer doit inclure les murs
2. Wall Detection Distance ≥ 0.5
3. Mur doit être suffisamment épais (au moins 0.5 de largeur)
4. Vérifier que c'est un Raycast qui détecte
```

**Debug** (ajouter dans CheckWallRun):
```csharp
RaycastHit hit;
if (Physics.Raycast(transform.position, transform.right, out hit, wallDetectionDistance)) {
    Debug.Log($"Wall detected: {hit.collider.name}");
}
```

---

### **Erreur 6: Combat ne fonctionne pas / Dégâts ne s'appliquent pas**

**Symptôme**: Clic gauche ne fait rien

**Vérifications**:
```
1. Vérifier Enemy Layer est assigné
2. Ennemi doit avoir un Collider
3. Ennemi doit avoir un Health component
4. Vérifier la portée d'attaque (attackRange)
```

**Debug**:
```csharp
// Dans CombatSystem Attack():
Collider[] hitEnemies = Physics.OverlapSphere(
    transform.position, 
    attackRange, 
    enemyLayer
);

Debug.Log($"Enemies hit: {hitEnemies.Length}");

foreach (Collider enemy in hitEnemies) {
    Debug.Log($"Hit: {enemy.name}");
}
```

---

### **Erreur 7: Caméra saute / scintille**

**Symptôme**: Vue de caméra instable

**Vérifications**:
```
1. Vérifier Input.GetAxis() pas Input.GetKey()
2. CameraController sur CameraHolder, pas sur Player
3. MouseSensitivity < 5 (généralement 1-3)
4. Pas de rotation du body dans CameraController
```

**Solution rapide**:
```csharp
// Dans CameraController
private void Update()
{
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    
    // X rotation LOCAL (caméra)
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
    
    // Y rotation GLOBALE (body)
    playerBody.Rotate(Vector3.up * mouseX);
    
    // PAS toucher à la rotation Y locale!
    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
}
```

---

### **Erreur 8: Ennemis ne bougent pas**

**Symptôme**: Ennemi reste immobile

**Vérifications**:
```
1. NavMesh Agent configuré? 
   - Window > AI > Navigation > Bake
   
2. Ground doit avoir "Walkable" ✓
3. NavMesh Agent > Path Pending debug
4. Destination assignée? (EnemyAI > patrolPoints)
```

**Debug**:
```csharp
// Dans EnemyAI
void Update() {
    if (navMeshAgent != null) {
        Debug.Log($"NavMesh Active: {navMeshAgent.isActiveAndEnabled}");
        Debug.Log($"Has Path: {navMeshAgent.hasPath}");
        Debug.Log($"Remaining Distance: {navMeshAgent.remainingDistance}");
    }
}
```

---

### **Erreur 9: Interface UI ne s'affiche pas**

**Symptôme**: Barre de santé/textes invisibles

**Vérifications**:
```
1. Canvas > Render Mode = Screen Space - Overlay
2. Canvas > Canvas Scaler > UI Scale Mode = Scale With Screen Size
3. Vérifier que les éléments ne sont pas en dehors de l'écran
4. Vérifier l'ordre Z du Canvas
```

**Solution**:
```csharp
// Dans UIManager Start()
if (healthBar == null) Debug.LogError("Health Bar not assigned!");
if (healthText == null) Debug.LogError("Health Text not assigned!");

// Puis tester si UpdateHealthUI est appelé
OnHealthChanged?.Invoke(100, 100); // Forcer mise à jour
```

---

### **Erreur 10: Performance lente / FPS bas**

**Symptôme**: Jeu saccadé ou lent

**Solutions de performance**:

```csharp
1. Trop de raycasts?
   // Dans PlayerController CheckWallRun()
   // Ajouter cooldown:
   if (Time.time - lastWallCheckTime < 0.1f) return;
   lastWallCheckTime = Time.time;

2. Trop d'ennemis?
   // Limiter rayon de vue:
   if (distanceToPlayer > 30f) return;

3. Vérifier console erreurs répétées
   // Les erreurs s'accumulent et ralentissent le jeu

4. Utiliser Profiler
   // Window > Analysis > Profiler
   // Voir où le temps est dépensé
```

---

## 🔧 OUTILS DE DEBUG

### 1. **Debug.Log** (à ajouter dans n'importe quel script)
```csharp
// Affiche un message dans la Console
Debug.Log("Message: " + variable);
Debug.LogWarning("Attention!");
Debug.LogError("Erreur critique!");
```

### 2. **Gizmos** (affiche visuellement dans la scène)
```csharp
// Dans OnDrawGizmosSelected():
Gizmos.color = Color.red;
Gizmos.DrawWireSphere(transform.position, attackRange);

Gizmos.color = Color.green;
Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
```

### 3. **Profiler** (mesure de performance)
```
Window > Analysis > Profiler

Onglets:
- CPU: Où le temps est utilisé
- Memory: Consommation de mémoire
- Physics: Calculs physiques
```

### 4. **Breakpoints** (pause l'exécution)
```
1. Cliquer à gauche d'une ligne (point rouge apparaît)
2. Lancer le jeu
3. L'exécution s'arrêtera à cette ligne
4. Parcourir avec F10 ou Continue avec F5
```

---

## 🚨 PROBLÈMES SPÉCIFIQUES À UNITY

### **Problème: Scripts ne se rechargent pas**
**Solution**: File > Preferences > Script Recompilation > Toggle auto-refresh

### **Problème: Scène corrompue**
**Solution**: Supprimer la scène et en créer une nouvelle

### **Problème: DLL conflicts**
**Solution**: Supprimer la lib problématique ou utiliser version compatible

### **Problème: Assets not imported**
**Solution**: Assets > Reimport All (peut prendre du temps)

---

## 📊 TEMPLATE DE RAPPORT DE BUG

S'il y a un bug critique, créer un rapport avec:

```
BUG REPORT:
───────────

Titre: [Description court du bug]

Reproduction:
1. Faire [action 1]
2. Faire [action 2]
3. Observez [comportement inattendu]

Attendu: [Comportement correct]

Actual: [Comportement actuel]

Console Errors: [Copy-paste des erreurs]

Screenshots: [Si applicable]

Environment:
- Unity Version: 2022.3.x
- OS: Windows/Mac/Linux
- Script: [Nom du script]
```

---

## ✅ PLAN DE DÉPANNAGE SYSTÉMATIQUE

**Si quelque chose ne marche pas:**

1. **Vérifier la console** (Ctrl + Shift + C)
   → Quelle erreur apparaît?

2. **Lire le message d'erreur** entièrement
   → Fichier:Ligne du bug

3. **Ajouter Debug.Log()** au bon endroit
   → Vérifier que le code est atteint

4. **Vérifier les paramètres**
   → Tous les champs assignés?

5. **Consulter la documentation**
   → Chercher la solution connue

6. **Essayer l'approche simple d'abord**
   → Recompile, redémarrage, relance

7. **Isoler le problème**
   → Enlever du code jusqu'à ce que ça marche

---

**En cas de besoin, référencer ce document!** 📖
