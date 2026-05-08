using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CombatSystem combatSystem;
    
    private void Update()
    {
        HandleInput();
    }
    
    private void HandleInput()
    {
        // Les entrées sont gérées directement dans PlayerController et CombatSystem
        // Ce script peut être utilisé pour centraliser toute la gestion des entrées si nécessaire
    }
}
