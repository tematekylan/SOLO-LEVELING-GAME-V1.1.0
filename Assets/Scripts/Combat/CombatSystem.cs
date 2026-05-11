using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float attackDamage = 200f; // 200 PV/soldat
    [SerializeField] private float attackCooldown = 0.5f; // Rate 2/sec
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private int maxCombo = 5;
    [SerializeField] private float comboResetTime = 1f;

    private float lastAttackTime = 0f;
    private int currentCombo = 0;
    private float lastComboTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
        }

        // Reset combo if too much time passed
        if (Time.time - lastComboTime > comboResetTime && currentCombo > 0)
        {
            currentCombo = 0;
        }
    }

    private void Attack()
    {
        lastAttackTime = Time.time;
        lastComboTime = Time.time;
        currentCombo = (currentCombo % maxCombo) + 1;

        // Increase damage with combo
        float damageMultiplier = 1f + (currentCombo - 1) * 0.2f; // 20% more per combo hit
        float actualDamage = attackDamage * damageMultiplier;

        // Détecter les ennemis dans la zone d'attaque
        Collider[] hitEnemies = Physics.OverlapSphere(
            attackPoint != null ? attackPoint.position : transform.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider enemy in hitEnemies)
        {
            Health healthComponent = enemy.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(actualDamage);
            }
        }

        // TODO: Ajouter effets visuels et sonores pour les combos
        Debug.Log($"Combo attack {currentCombo} with {actualDamage} damage");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            attackPoint != null ? attackPoint.position : transform.position,
            attackRange
        );
    }
}
