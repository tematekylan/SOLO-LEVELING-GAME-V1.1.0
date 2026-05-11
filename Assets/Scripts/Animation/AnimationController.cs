using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CombatSystem combatSystem;
    // AnimationMapper est optionnel - cherchera le composant s'il existe

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (playerController == null)
            playerController = GetComponent<PlayerController>();
        if (combatSystem == null)
            combatSystem = GetComponent<CombatSystem>();
    }

    private void Update()
    {
        if (animator == null || playerController == null) return;

        // Paramètres de mouvement
        float speed = playerController.Velocity.magnitude;
        animator.SetFloat("Speed", speed);

        float verticalVel = playerController.Velocity.y;
        animator.SetFloat("VerticalVelocity", verticalVel);

        // États booléens
        animator.SetBool("IsGrounded", playerController.IsGrounded);
        animator.SetBool("IsWallRunning", playerController.IsWallRunning);

        // États de combat
        if (combatSystem != null)
        {
            // TODO: Ajouter une propriété IsAttacking dans CombatSystem
            // animator.SetBool("IsAttacking", combatSystem.IsAttacking);
        }

        // Nombre de sauts (pour animations multiples)
        animator.SetInteger("JumpCount", playerController.JumpCount);
    }

    // Méthodes publiques pour triggers
    public void TriggerJump()
    {
        if (animator != null)
            animator.SetTrigger("Jump");
    }

    public void TriggerLand()
    {
        if (animator != null)
            animator.SetTrigger("Land");
    }

    public void TriggerAttack()
    {
        if (animator != null)
            animator.SetTrigger("Attack");
    }

    public void TriggerAbsorb()
    {
        if (animator != null)
            animator.SetTrigger("Absorb");
    }

    public void TriggerSonar()
    {
        if (animator != null)
            animator.SetTrigger("Sonar");
    }

    public void TriggerTakeDamage()
    {
        if (animator != null)
            animator.SetTrigger("TakeDamage");
    }

    public void TriggerDeath()
    {
        if (animator != null)
            animator.SetTrigger("Die");
    }

    // Debug GUI (temporaire - désactiver en production)
    private void OnGUI()
    {
        if (!Application.isEditor) return;

        GUI.Box(new Rect(10, 10, 200, 180), "Animation Debug");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Jump"))
            TriggerJump();
        if (GUI.Button(new Rect(110, 40, 80, 20), "Attack"))
            TriggerAttack();
        if (GUI.Button(new Rect(20, 70, 80, 20), "Absorb"))
            TriggerAbsorb();
        if (GUI.Button(new Rect(110, 70, 80, 20), "Sonar"))
            TriggerSonar();
        if (GUI.Button(new Rect(20, 100, 80, 20), "Damage"))
            TriggerTakeDamage();
        if (GUI.Button(new Rect(110, 100, 80, 20), "Death"))
            TriggerDeath();
        if (GUI.Button(new Rect(20, 130, 80, 20), "Land"))
            TriggerLand();
        if (GUI.Button(new Rect(20, 160, 160, 20), "Reset All Triggers"))
            ResetAllTriggers();
    }

    private void ResetAllTriggers()
    {
        if (animator != null)
        {
            animator.ResetTrigger("Jump");
            animator.ResetTrigger("Land");
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Absorb");
            animator.ResetTrigger("Sonar");
            animator.ResetTrigger("TakeDamage");
            animator.ResetTrigger("Die");
        }
    }
}
