using UnityEngine;

public class AbsorptionAbility : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float absorbTime = 1f;
    [SerializeField] private float healAmount = 100f;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private LayerMask enemyLayer;

    private float lastUseTime = 0f;
    private Camera mainCamera;
    private Health playerHealth;

    private void Start()
    {
        mainCamera = Camera.main;
        playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time - lastUseTime >= cooldown)
        {
            UseAbsorption();
        }
    }

    private void UseAbsorption()
    {
        lastUseTime = Time.time;

        // Raycast to find target
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer))
        {
            StartCoroutine(Absorb(hit.collider));
        }
    }

    private System.Collections.IEnumerator Absorb(Collider target)
    {
        // TODO: Add absorption animation and effects

        // Vulnerable period
        yield return new WaitForSeconds(absorbTime);

        // Consume enemy
        Health enemyHealth = target.GetComponent<Health>();
        if (enemyHealth != null)
        {
            // Full heal
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // TODO: Gain XP, unlock disguise, etc.

            // Destroy enemy
            Destroy(target.gameObject);
        }

        Debug.Log("Absorbed enemy");
    }

    // Upgrade: Absorb multiple enemies
    public void MultiAbsorb(int count = 3)
    {
        // TODO: Implement multi-absorb logic
        Debug.Log("Multi-absorb activated");
    }
}