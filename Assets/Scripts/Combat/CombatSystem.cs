using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;

    private float lastAttackTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        lastAttackTime = Time.time;

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
                healthComponent.TakeDamage(attackDamage);
            }
        }
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
