using UnityEngine;

public class TendrilsAbility : MonoBehaviour
{
    [SerializeField] private float range = 15f;
    [SerializeField] private float grabDamage = 50f;
    [SerializeField] private float whipDamage = 100f;
    [SerializeField] private float whipRadius = 10f;
    [SerializeField] private float cooldown = 2f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask destructibleLayer;

    private float lastUseTime = 0f;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastUseTime >= cooldown)
        {
            UseTendrils();
        }
    }

    private void UseTendrils()
    {
        lastUseTime = Time.time;

        // Raycast from camera to find target
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer | destructibleLayer))
        {
            if (Input.GetKey(KeyCode.LeftControl)) // Hold for whip
            {
                Whip(hit.point);
            }
            else
            {
                Grab(hit.collider);
            }
        }
    }

    private void Grab(Collider target)
    {
        // Pull target towards player
        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        if (targetRb != null)
        {
            Vector3 pullDirection = (transform.position - target.transform.position).normalized;
            targetRb.AddForce(pullDirection * 1000f, ForceMode.Impulse);
        }

        // Damage if enemy
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(grabDamage);
        }

        // TODO: Add visual tendrils effect
        Debug.Log("Grabbed target");
    }

    private void Whip(Vector3 center)
    {
        // Damage all enemies in radius
        Collider[] hitEnemies = Physics.OverlapSphere(center, whipRadius, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Health health = enemy.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(whipDamage);
            }

            // Knockback
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 knockbackDir = (enemy.transform.position - center).normalized;
                rb.AddForce(knockbackDir * 500f, ForceMode.Impulse);
            }
        }

        // TODO: Add whip visual and sound
        Debug.Log("Whipped area");
    }

    // Upgrade: Black Hole
    public void BlackHole(Vector3 center)
    {
        // Aspire tous les ennemis dans le rayon
        Collider[] hitEnemies = Physics.OverlapSphere(center, 20f, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pullDirection = (center - enemy.transform.position).normalized;
                rb.AddForce(pullDirection * 2000f, ForceMode.Force);
            }
        }

        // Après un délai, explosion
        Invoke(nameof(ExplodeBlackHole), 2f);
    }

    private void ExplodeBlackHole()
    {
        // TODO: Implement explosion at center
        Debug.Log("Black Hole explosion");
    }
}