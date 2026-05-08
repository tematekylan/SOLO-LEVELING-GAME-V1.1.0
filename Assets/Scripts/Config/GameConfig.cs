using UnityEditor;
using UnityEngine;

/// <summary>
/// Classe de configuration centralisée pour le projet PROTOTYPE 2
/// Permet de modifier facilement tous les paramètres en un seul endroit
/// </summary>
[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Configuration")]
public class GameConfig : ScriptableObject
{
    [Header("MOUVEMENT")]
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float groundDrag = 5f;
    [SerializeField] public float airDrag = 2f;
    [SerializeField] public float airMultiplier = 0.4f;
    
    [Header("SAUT")]
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public float jumpCooldown = 0.25f;
    [SerializeField] public int maxJumps = 2;
    [SerializeField] public float groundDragDistance = 0.2f;
    
    [Header("COURSE SUR MURS")]
    [SerializeField] public float wallRunSpeed = 6f;
    [SerializeField] public float wallRunGravity = 1f;
    [SerializeField] public float wallJumpUpForce = 5f;
    [SerializeField] public float wallJumpSideForce = 3f;
    [SerializeField] public float wallDetectionDistance = 0.5f;
    
    [Header("COMBAT")]
    [SerializeField] public float attackRange = 2f;
    [SerializeField] public float attackDamage = 10f;
    [SerializeField] public float attackCooldown = 0.5f;
    
    [Header("SANTÉ")]
    [SerializeField] public float playerMaxHealth = 100f;
    [SerializeField] public float enemyMaxHealth = 50f;
    
    [Header("CAMÉRA")]
    [SerializeField] public float mouseSensitivity = 2f;
    [SerializeField] public float maxLookAngle = 90f;
    
    [Header("IA")]
    [SerializeField] public float enemyDetectionRange = 20f;
    [SerializeField] public float enemyChaseSpeed = 5f;
    [SerializeField] public float enemyPatrolSpeed = 3.5f;
    
    /// <summary>
    /// Obtenir l'instance singleton de la configuration
    /// </summary>
    private static GameConfig instance;
    public static GameConfig Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameConfig>("GameConfig");
                if (instance == null)
                {
                    Debug.LogError("GameConfig not found in Resources folder! Please create one.");
                }
            }
            return instance;
        }
    }
    
    /// <summary>
    /// Appliquer un profil de difficulté prédéfini
    /// </summary>
    public enum DifficultyProfile
    {
        Easy,
        Normal,
        Hard
    }
    
    public void ApplyDifficultyProfile(DifficultyProfile profile)
    {
        switch (profile)
        {
            case DifficultyProfile.Easy:
                moveSpeed = 6f;
                jumpForce = 4.5f;
                wallRunSpeed = 5f;
                attackDamage = 15f;
                enemyChaseSpeed = 4f;
                break;
                
            case DifficultyProfile.Normal:
                moveSpeed = 7f;
                jumpForce = 5f;
                wallRunSpeed = 6f;
                attackDamage = 10f;
                enemyChaseSpeed = 5f;
                break;
                
            case DifficultyProfile.Hard:
                moveSpeed = 8f;
                jumpForce = 5.5f;
                wallRunSpeed = 7f;
                attackDamage = 8f;
                enemyChaseSpeed = 6f;
                break;
        }
        
        EditorUtility.SetDirty(this);
    }
    
    /// <summary>
    /// Sauvegarder la configuration dans un fichier JSON
    /// </summary>
    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }
    
    /// <summary>
    /// Charger la configuration depuis un JSON
    /// </summary>
    public void FromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
        EditorUtility.SetDirty(this);
    }
}
