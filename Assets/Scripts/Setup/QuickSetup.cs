using UnityEngine;

/// <summary>
/// Script de configuration rapide pour PROTOTYPE 2 Game
/// Attacher ce script à un GameObject vide pour initialiser les paramètres
/// </summary>
public class QuickSetup : MonoBehaviour
{
    [SerializeField] private bool setupOnStart = true;
    
    private void Start()
    {
        if (setupOnStart)
        {
            SetupGame();
            Debug.Log("✓ Configuration rapide complétée!");
        }
    }
    
    public void SetupGame()
    {
        SetupGameSettings();
        SetupPhysics();
        Debug.Log("Tous les paramètres ont été initialisés!");
    }
    
    private void SetupGameSettings()
    {
        // Paramètres Unity
        Time.timeScale = 1f;
        QualitySettings.globalTextureMipmapLimit = 0;
        
        // Target framerate
        Application.targetFrameRate = 60;
        
        Debug.Log("✓ Paramètres du jeu configurés");
    }
    
    private void SetupPhysics()
    {
        // Paramètres physiques
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Physics.defaultSolverIterations = 6;
        Physics.defaultSolverVelocityIterations = 1;
        
        Debug.Log("✓ Physique configurée");
    }
    
    /// <summary>
    /// Crée rapidement un environnement de test standard
    /// À appeler une seule fois lors de la création de la scène
    /// </summary>
    public void CreateTestEnvironment()
    {
        // Ground
        GameObject ground = CreatePrimitive(PrimitiveType.Cube, "Ground");
        ground.transform.localScale = new Vector3(50, 1, 50);
        ground.transform.position = Vector3.zero;
        
        // Walls
        CreateWall("Wall Left", new Vector3(-5, 2, 0), new Vector3(1, 4, 50));
        CreateWall("Wall Right", new Vector3(5, 2, 0), new Vector3(1, 4, 50));
        
        Debug.Log("✓ Environnement de test créé!");
    }
    
    private GameObject CreatePrimitive(PrimitiveType type, string name)
    {
        GameObject obj = GameObject.CreatePrimitive(type);
        obj.name = name;
        
        // Supprimer le Collider default si nécessaire
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        
        return obj;
    }
    
    private void CreateWall(string name, Vector3 position, Vector3 scale)
    {
        GameObject wall = CreatePrimitive(PrimitiveType.Cube, name);
        wall.transform.position = position;
        wall.transform.localScale = scale;
        
        Rigidbody rb = wall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
