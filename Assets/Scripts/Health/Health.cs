using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    
    public delegate void HealthChangeDelegate(float health, float maxHealth);
    public event HealthChangeDelegate OnHealthChanged;
    
    public delegate void DeathDelegate();
    public event DeathDelegate OnDeath;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
    
    private void Die()
    {
        OnDeath?.Invoke();
        
        if (gameObject.CompareTag("Player"))
        {
            // Rechargement ou écran de fin
            Destroy(gameObject);
        }
        else
        {
            // Destruction de l'ennemi
            Destroy(gameObject);
        }
    }
    
    public float GetHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
}
