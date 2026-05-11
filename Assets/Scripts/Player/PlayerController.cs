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

    [Header("Roulade")]
    [SerializeField] private float rollSpeed = 15f; // Vitesse pendant la roulade
    [SerializeField] private float rollDuration = 0.8f; // Durée de la roulade
    [SerializeField] private float rollCooldown = 1f; // Temps entre roulades
    private bool isRolling = false;
    private bool canRoll = true;
    private float rollTimer = 0f;

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
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Détection du sol
        CheckGrounded();

        // Shockwave on landing
        if (!wasGrounded && isGrounded)
        {
            TriggerShockwave();
        }
        wasGrounded = isGrounded;

        // Sprint
        isSprinting = isGrounded && Input.GetKey(KeyCode.LeftShift) && moveDirection.sqrMagnitude > 0.01f;

        // Roulade : W maintenu + Espace
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && isGrounded && canRoll && !isRolling)
        {
            StartRoll();
        }

        // Gestion de la roulade
        if (isRolling)
        {
            UpdateRoll();
        }

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

        if (!isGrounded)
        {
            RaycastHit hit;
            Vector3[] directions = { transform.right, -transform.right, transform.forward, -transform.forward };

            foreach (Vector3 dir in directions)
            {
                if (Physics.Raycast(transform.position, dir, out hit, wallDetectionDistance, groundLayer))
                {
                    if (transform.position.y <= maxWallRunHeight)
                    {
                        isWallRunning = true;
                        wallNormal = hit.normal;
                        break;
                    }
                }
            }
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
        float speed = moveSpeed * (isSprinting ? sprintMultiplier : 1f);

        if (isWallRunning)
        {
            Vector3 wallMoveDirection = Vector3.ProjectOnPlane(moveDirection, wallNormal);
            if (wallMoveDirection.sqrMagnitude < 0.01f)
            {
                wallMoveDirection = Vector3.ProjectOnPlane(transform.forward, wallNormal);
            }

            rb.useGravity = false;
            rb.AddForce(wallMoveDirection.normalized * wallRunSpeed * 10f, ForceMode.Force);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        }
        else if (isGrounded)
        {
            rb.useGravity = true;
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        else
        {
            rb.useGravity = true;
            rb.AddForce(moveDirection.normalized * speed * airMultiplier * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        float maxSpeed = isWallRunning ? wallRunSpeed : moveSpeed * (isSprinting ? sprintMultiplier : 1f);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void ApplyDrag()
    {
        if (isGrounded)
        {
            rb.linearDamping = groundDrag;
        }
        else if (isWallRunning)
        {
            rb.linearDamping = 0;
        }
        else
        {
            rb.linearDamping = airDrag;
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

    private void StartRoll()
    {
        isRolling = true;
        rollTimer = rollDuration;
        canRoll = false;

        // Appliquer la vélocité de roulade
        Vector3 rollDirection = transform.forward;
        rb.linearVelocity = rollDirection * rollSpeed;

        // TODO: Déclencher l'animation de roulade
        // animator.SetTrigger("Roll");

        Invoke(nameof(ResetRoll), rollCooldown);
    }

    private void UpdateRoll()
    {
        rollTimer -= Time.deltaTime;

        if (rollTimer <= 0f)
        {
            isRolling = false;
        }
    }

    private void ResetRoll()
    {
        canRoll = true;
    }

    // Propriétés publiques
    public bool IsGrounded => isGrounded;
    public bool IsWallRunning => isWallRunning;
    public int JumpCount => jumpCount;
    public Vector3 Velocity => rb.linearVelocity;
}
