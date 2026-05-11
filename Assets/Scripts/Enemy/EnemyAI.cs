using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectionRange = 20f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float patrolSpeed = 3.5f;
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float stoppingDistance = 0.5f;

    private NavMeshAgent navMeshAgent;
    private Health health;
    private Transform playerTransform;
    private Health playerHealth;
    private int currentPatrolIndex = 0;
    private bool isChasing = false;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackCooldown = 1.5f;
    private float lastAttackTime = 0f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();

        if (navMeshAgent == null)
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        playerHealth = playerTransform != null ? playerTransform.GetComponent<Health>() : null;

        if (patrolPoints.Length == 0)
        {
            patrolPoints = new Transform[] { transform };
        }

        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        if (health != null && health.GetHealth() <= 0)
            return;

        float distanceToPlayer = playerTransform != null ?
            Vector3.Distance(transform.position, playerTransform.position) : float.MaxValue;

        if (playerTransform != null && distanceToPlayer < attackRange)
        {
            isChasing = true;
            AttackPlayer();
            return;
        }

        if (distanceToPlayer < detectionRange && playerTransform != null)
        {
            isChasing = true;
            ChasePlayer(distanceToPlayer);
        }
        else
        {
            isChasing = false;
            Patrol();
        }
    }

    private void ChasePlayer(float distanceToPlayer)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.SetDestination(playerTransform.position);

        // Face le joueur
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
    }

    private void AttackPlayer()
    {
        navMeshAgent.isStopped = true;
        transform.rotation = Quaternion.LookRotation((playerTransform.position - transform.position).normalized);

        if (Time.time - lastAttackTime >= attackCooldown && playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            lastAttackTime = Time.time;
        }
    }

    private void Patrol()
    {
        navMeshAgent.speed = patrolSpeed;

        if (patrolPoints.Length == 0)
            return;

        if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance < stoppingDistance)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
}
