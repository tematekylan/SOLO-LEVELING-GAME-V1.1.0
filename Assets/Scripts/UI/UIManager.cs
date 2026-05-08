using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour 
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI jumpCountText;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Health playerHealth;
    
    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthUI;
        }
    }
    
    private void Update()
    {
        if (playerController != null)
        {
            UpdateSpeedUI();
            UpdateJumpUI();
        }
    }
    
    private void UpdateHealthUI(float health, float maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = health / maxHealth;
        }
        
        if (healthText != null)
        {
            healthText.text = $"Health: {health:F0}/{maxHealth:F0}";
        }
    }
    
    private void UpdateSpeedUI()
    {
        if (speedText != null)
        {
            float speed = new Vector3(playerController.Velocity.x, 0, playerController.Velocity.z).magnitude;
            speedText.text = $"Speed: {speed:F1}";
        }
    }
    
    private void UpdateJumpUI()
    {
        if (jumpCountText != null)
        {
            jumpCountText.text = $"Sauts: {playerController.JumpCount}/2";
            
            if (playerController.IsWallRunning)
            {
                jumpCountText.text += " (Wall Run)";
            }
        }
    }
    
    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI;
        }
    }
}
