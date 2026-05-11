using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 16.67f; // 60 km/h
    [SerializeField] private float groundDrag = 5f;
    [SerializeField] private float airDrag = 2f;
    
    [Header("Saut")]
    [SerializeField] private float jumpForce = 12f; // Increased for 50m height
    [SerializeField] private float jumpCooldown = 0.25f;
    [SerializeField] private float airMultiplier = 0.4f;
    private bool canJump = true;
    private int jumpCount = 0;
    private const int maxJumps = 2; // Double saut
    [SerializeField] private float shockwaveRadius = 10f;
    [SerializeField] private float shockwaveForce = 500f;
    [SerializeField] private LayerMask enemyLayer;
    
    [Header("Air Dash")]
    [SerializeField] private float dashSpeed = 22.22f; // 80 km/h
    [SerializeField] private int maxDashes = 3;
    private int currentDashes;
    [SerializeField] private float dashCooldown = 0.5f;
    private bool canDash = true;
    
    [Header("Détection du sol")]
    [SerializeField] private float groundDrag_value = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDragDistance = 0.2f;
    private bool isGrounded = false;
    private bool wasGrounded = false;
    
    [Header("Course sur murs")]
    [SerializeField] private float wallRunSpeed = 11.11f; // 40 km/h
    [SerializeField] private float wallRunGravity = 1f;
    [SerializeField] private float wallJumpUpForce = 5f;
    [SerializeField] private float wallJumpSideForce = 3f;
    private bool isWallRunning = false;
    private Vector3 wallNormal = Vector3.zero;
    [SerializeField] private float wallDetectionDistance = 0.5f;
    [SerializeField] private float maxWallRunHeight = 100f;
    private float currentWallRunHeight = 0f;
    
    [Header("Composants")]
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float horizontalInput;
    private float verticalInput;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        rb.mass = 1f;
        rb.freezeRotation = true;
        currentDashes = maxDashes;
    }
    
    private void Update()
    {
        // Entrées
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Détection du sol
        CheckGrounded();
        
        // Shockwave on landing
        if (!wasGrounded && isGrounded)
        {
            TriggerShockwave();
        }
        wasGrounded = isGrounded;
        
        // Détection des murs
        CheckWallRun();
        
        // Saut
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
        
        // Air Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded && currentDashes > 0 && canDash)
        {
            AirDash();
        }
        
        // Recharge dashes au sol
        if (isGrounded && currentDashes < maxDashes)
        {
            currentDashes = maxDashes;
        }
        
        // Vitesse
        SpeedControl();
        
        // Appliquer la traînée
        ApplyDrag();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDragDistance, groundLayer);
        
        if (isGrounded && jumpCount > 0)
        {
            jumpCount = 0;
            canJump = true;
        }
    }
    
    private void CheckWallRun()
    {
        isWallRunning = false;
        
        if (!isGrounded && rb.linearVelocity.y < 0)
        {
            // Vérifier les murs à gauche et à droite
            RaycastHit hit;
            Vector3 rayDirection = transform.right;
            
            // Raycast à droite
            if (Physics.Raycast(transform.position, rayDirection, out hit, wallDetectionDistance, groundLayer))
            {
                if (transform.position.y - currentWallRunHeight < maxWallRunHeight)
                {
                    isWallRunning = true;
                    wallNormal = hit.normal;
                }
            }
            // Raycast à gauche
            else if (Physics.Raycast(transform.position, -rayDirection, out hit, wallDetectionDistance, groundLayer))
            {
                if (transform.position.y - currentWallRunHeight < maxWallRunHeight)
                {
                    isWallRunning = true;
                    wallNormal = -hit.normal;
                }
            }
        }
        
        if (isWallRunning)
        {
            currentWallRunHeight = transform.position.y;
        }
        else
        {
            currentWallRunHeight = 0f;
        }
    }
    
    private void HandleJump()
    {
        if (isWallRunning)
        {
            // Saut du mur
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            Vector3 jumpDirection = wallNormal + Vector3.up;
            rb.linearVelocity += jumpDirection.normalized * new Vector3(wallJumpSideForce, wallJumpUpForce, wallJumpSideForce).magnitude;
            jumpCount = 0; // Réinitialiser les sauts
            canJump = false;
            isWallRunning = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        else if (jumpCount < maxJumps && (isGrounded || jumpCount == 0))
        {
            Jump();
        }
    }
    
    private void Jump()
    {
        if (!canJump) return;
        
        // Réinitialiser la vélocité Y pour un saut cohérent
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.linearVelocity += Vector3.up * jumpForce;
        
        jumpCount++;
        canJump = false;
        Invoke(nameof(ResetJump), jumpCooldown);
    }
    
    private void ResetJump()
    {
        canJump = true;
    }
    
    private void MovePlayer()
    {
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        if (isWallRunning)
        {
            // Mouvement sur le mur
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -wallRunGravity), rb.linearVelocity.z);
        }
        else if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier * 10f, ForceMode.Force);
        }
    }
    
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
    
    private void ApplyDrag()
    {
        if (isGrounded)
        {
            rb.linearDamping  = groundDrag;
        }
        else if (isWallRunning)
        {
            rb.linearDamping  = 0;
        }
        else
        {
            rb.linearDamping  = airDrag;
        }
    }
    
    private void TriggerShockwave()
    {
        // Créer une onde de choc qui stun les ennemis dans le rayon
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, shockwaveRadius, enemyLayer);
        foreach (Collider hitCollider in hitColliders)
        {
            Rigidbody enemyRb = hitCollider.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
                enemyRb.AddForce(direction * shockwaveForce, ForceMode.Impulse);
            }
            // TODO: Ajouter stun effect si l'ennemi a un script pour ça
        }
        // TODO: Ajouter effet visuel et sonore
    }
    
    private void AirDash()
    {
        Vector3 dashDirection = moveDirection.normalized;
        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward;
        }
        rb.linearVelocity = dashDirection * dashSpeed;
        currentDashes--;
        canDash = false;
        Invoke(nameof(ResetDash), dashCooldown);
    }
    
    private void ResetDash()
    {
        canDash = true;
    }
    
    // Propriétés publiques
    public bool IsGrounded => isGrounded;
    public bool IsWallRunning => isWallRunning;
    public int JumpCount => jumpCount;
    public Vector3 Velocity => rb.linearVelocity;
}
