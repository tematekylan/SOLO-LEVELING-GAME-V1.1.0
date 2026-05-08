using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (animator != null && playerController != null)
        {
            // Animer la vitesse
            Vector3 flatVel = new Vector3(playerController.Velocity.x, 0, playerController.Velocity.z);
            animator.SetFloat("Speed", flatVel.magnitude);
            
            // Animer les sauts
            animator.SetBool("IsGrounded", playerController.IsGrounded);
            animator.SetBool("IsWallRunning", playerController.IsWallRunning);
            animator.SetInteger("JumpCount", playerController.JumpCount);
        }
    }
}
