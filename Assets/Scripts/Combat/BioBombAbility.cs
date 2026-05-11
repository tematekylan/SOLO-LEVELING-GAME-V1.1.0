using UnityEngine;

public class BioBombAbility : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float explosionDelay = 3f;
    [SerializeField] private float explosionRadius = 15f;
    [SerializeField] private float explosionDamage = 1000f;
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private LayerMask enemyLayer;

    private float lastUseTime = 0f;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUseTime >= cooldown)
        {
            UseBioBomb();
        }
    }

    private void UseBioBomb()
    {
        lastUseTime = Time.time;

        // Raycast to find target
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer))
        {
            // Inject virus
            StartCoroutine(InjectVirus(hit.collider));
        }
    }

    private System.Collections.IEnumerator InjectVirus(Collider target)
    {
        // TODO: Add injection animation and effect

        // Wait for delay
        yield return new WaitForSeconds(explosionDelay);

        // Explosion
        Explode(target.transform.position);
    }

    private void Explode(Vector3 center)
    {
        // Damage all enemies in radius
        Collider[] hitEnemies = Physics.OverlapSphere(center, explosionRadius, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Health health = enemy.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(explosionDamage);
            }

            // Knockback
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 knockbackDir = (enemy.transform.position - center).normalized;
                rb.AddForce(knockbackDir * 1000f, ForceMode.Impulse);
            }
        }

        // TODO: Add explosion visual and sound
        Debug.Log("Bio-bomb explosion");
    }

    // Upgrade: Chain to multiple targets
    public void ChainBioBomb(Collider initialTarget, int maxChains = 5)
    {
        // TODO: Implement chaining logic
        Debug.Log("Chained bio-bomb");
    }
}