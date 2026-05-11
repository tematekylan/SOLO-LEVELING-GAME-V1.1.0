using UnityEngine;

public class AnimationMapper : MonoBehaviour
{
    [Header("Animations de mouvement")]
    [SerializeField] private string idleAnimation = "Alex@Idle";
    [SerializeField] private string walkAnimation = "Alex@Walking";
    [SerializeField] private string runAnimation = "Alex@Running";
    [SerializeField] private string flyingAnimation = "Alex@Flying";

    [Header("Animations de saut")]
    [SerializeField] private string jumpAnimation = "Alex@Big Jump";
    [SerializeField] private string mutantJumpAnimation = "Alex@Mutant Jumping";
    [SerializeField] private string wallRunAnimation = "Alex@Wall Run";
    [SerializeField] private string landAnimation = "Alex@Fall A Land To Run Forward";

    [Header("Animations de combat")]
    [SerializeField] private string punchAnimation = "Alex@Punching";
    [SerializeField] private string boxingAnimation = "Alex@Boxing";
    [SerializeField] private string throwAnimation = "Alex@Throw In";
    [SerializeField] private string blockAnimation = "Alex@Inward Block";

    [Header("Animations de mort/victoire")]
    [SerializeField] private string deathAnimation = "Alex@Death From The Front";
    [SerializeField] private string victoryAnimation = "Alex@Victory";

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("AnimationMapper: Animator component non trouvé!");
        }
    }

    // Méthodes de mouvement
    public void PlayIdle()
    {
        PlayAnimation(idleAnimation);
    }

    public void PlayWalk()
    {
        PlayAnimation(walkAnimation);
    }

    public void PlayRun()
    {
        PlayAnimation(runAnimation);
    }

    public void PlayFlying()
    {
        PlayAnimation(flyingAnimation);
    }

    // Méthodes de saut
    public void PlayJump()
    {
        PlayAnimation(jumpAnimation);
    }

    public void PlayMutantJump()
    {
        PlayAnimation(mutantJumpAnimation);
    }

    public void PlayWallRun()
    {
        PlayAnimation(wallRunAnimation);
    }

    public void PlayLand()
    {
        PlayAnimation(landAnimation);
    }

    // Méthodes de combat
    public void PlayPunch()
    {
        PlayAnimation(punchAnimation);
    }

    public void PlayBoxing()
    {
        PlayAnimation(boxingAnimation);
    }

    public void PlayThrow()
    {
        PlayAnimation(throwAnimation);
    }

    public void PlayBlock()
    {
        PlayAnimation(blockAnimation);
    }

    // Méthodes de mort/victoire
    public void PlayDeath()
    {
        PlayAnimation(deathAnimation);
    }

    public void PlayVictory()
    {
        PlayAnimation(victoryAnimation);
    }

    // Méthode générale pour jouer une animation
    private void PlayAnimation(string animationName)
    {
        if (animator == null || string.IsNullOrEmpty(animationName))
        {
            return;
        }

        if (animator.HasParameter(animationName))
        {
            animator.SetTrigger(animationName);
        }
        else
        {
            Debug.LogWarning($"Animation '{animationName}' non trouvée dans l'Animator!");
        }
    }

    // Getter pour les noms d'animation (pour la configuration UI)
    public string GetIdleAnimation() => idleAnimation;
    public string GetWalkAnimation() => walkAnimation;
    public string GetRunAnimation() => runAnimation;
    public string GetJumpAnimation() => jumpAnimation;
}
