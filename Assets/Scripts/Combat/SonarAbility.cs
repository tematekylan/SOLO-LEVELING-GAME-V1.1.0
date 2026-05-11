using UnityEngine;

public class SonarAbility : MonoBehaviour
{
    [SerializeField] private float range = 200f;
    [SerializeField] private float highlightDuration = 10f;
    [SerializeField] private float cooldown = 20f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask objectiveLayer;

    private float lastUseTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastUseTime >= cooldown)
        {
            UseSonar();
        }
    }

    private void UseSonar()
    {
        lastUseTime = Time.time;

        // Pulse radial
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, enemyLayer | objectiveLayer);

        foreach (Collider hit in hitColliders)
        {
            // Highlight enemies
            if (enemyLayer == (enemyLayer | (1 << hit.gameObject.layer)))
            {
                StartCoroutine(HighlightEnemy(hit.gameObject, highlightDuration));
            }

            // Reveal objectives
            if (objectiveLayer == (objectiveLayer | (1 << hit.gameObject.layer)))
            {
                // TODO: Reveal hidden objectives
                Debug.Log("Revealed objective: " + hit.gameObject.name);
            }
        }

        // TODO: Add sonar visual and sound effects
        Debug.Log("Sonar pulse activated");
    }

    private System.Collections.IEnumerator HighlightEnemy(GameObject enemy, float duration)
    {
        // TODO: Add highlight effect (glow, outline, etc.)
        Renderer renderer = enemy.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Temporary highlight
            Color originalColor = renderer.material.color;
            renderer.material.color = Color.red;

            yield return new WaitForSeconds(duration);

            renderer.material.color = originalColor;
        }
    }

    // Upgrade: Pierce obstacles
    public void PiercingSonar()
    {
        // TODO: Implement piercing through walls
        Debug.Log("Piercing sonar activated");
    }
}