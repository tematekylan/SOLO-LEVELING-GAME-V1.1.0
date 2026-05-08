using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float maxLookAngle = 90f;
    [SerializeField] private Transform playerBody;
    
    private float xRotation = 0f;
    
    private void Start()
    {
        // Verrouiller et faire disparaître le curseur
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Rotation horizontale
        playerBody.Rotate(Vector3.up * mouseX);
        
        // Rotation verticale
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Déverrouiller le curseur avec Échap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
