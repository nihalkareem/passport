using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [Header("Character Sprites")]
    public Sprite idle0;
    public Sprite idle1;

    public Sprite jump0;
    public Sprite jump1;

    public Sprite run0;
    public Sprite run1;

    [Header("Animation Settings")]
    public float idleFrameTime = 0.5f;
    public float runFrameTime = 0.2f;
    public float jumpFrameTime = 0.5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float moveInput;
    private bool isGrounded;
    private bool wasGrounded;

    private float animationTimer;
    private int currentFrame;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Find SpriteRenderer on a child if necessary.
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (rb == null)
            Debug.LogError("Player is missing Rigidbody2D!");

        if (spriteRenderer == null)
            Debug.LogError("Player is missing SpriteRenderer!");

        // Start with the first idle sprite.
        SetSprite(idle0);
    }

    void Update()
    {
        // Read movement keys.
        moveInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        // Check whether the player is touching the ground.
        wasGrounded = isGrounded;

        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }

        // Face the movement direction.
        if (spriteRenderer != null)
        {
            if (moveInput > 0)
                spriteRenderer.flipX = false;
            else if (moveInput < 0)
                spriteRenderer.flipX = true;
        }

        // Jump using Space or Up Arrow.
        if ((Input.GetKeyDown(KeyCode.Space) ||
             Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }

        // Reset animation when landing.
        if (isGrounded && !wasGrounded)
        {
            animationTimer = 0f;
            currentFrame = 0;
        }

        // Choose animation based on player state.
        if (!isGrounded)
        {
            PlayJumpAnimation();
        }
        else if (moveInput != 0)
        {
            PlayRunAnimation();
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                moveInput * moveSpeed,
                rb.linearVelocity.y
            );
        }
    }

    // Idle: alternate idle0 and idle1 every 0.5 seconds.
    void PlayIdleAnimation()
    {
        Animate(idle0, idle1, idleFrameTime);
    }

    // Run: alternate run0 and run1 while moving.
    void PlayRunAnimation()
    {
        Animate(run0, run1, runFrameTime);
    }

    // Jump: alternate jump0 and jump1 while airborne.
    void PlayJumpAnimation()
    {
        Animate(jump0, jump1, jumpFrameTime);
    }

    // Common function for switching between two sprites.
    void Animate(Sprite frame0, Sprite frame1, float frameTime)
    {
        if (spriteRenderer == null)
            return;

        if (frame0 == null || frame1 == null)
            return;

        animationTimer += Time.deltaTime;

        if (animationTimer >= frameTime)
        {
            animationTimer = 0f;
            currentFrame = 1 - currentFrame;
        }

        SetSprite(currentFrame == 0 ? frame0 : frame1);
    }

    void SetSprite(Sprite newSprite)
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    // Show the ground-check circle in the Scene view.
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}