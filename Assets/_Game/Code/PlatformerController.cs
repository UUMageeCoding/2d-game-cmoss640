using TMPro;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TextMeshProUGUI DamageValue;
    [SerializeField] private SpriteRenderer Sprite;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    public Timer StormTimer;
    private Animator animator;
    private Animator animatorBird;
    [SerializeField] private GameObject JumpBird;
    public static int Score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorBird = JumpBird.GetComponent<Animator>();
        
        // Set to Dynamic with gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    void Update()
    {
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        DamageValue.text = "$" + Score.ToString();
        if (Input.GetAxis("Horizontal") < 0 && isGrounded == true)
        {
            Sprite.flipX = true;
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetAxis("Horizontal") > 0 && isGrounded == true)
        {
            Sprite.flipX = false;
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetAxis("Horizontal") == 0 && isGrounded == true)
        {
            animator.SetBool("IsWalking", false);
        }
    }
    
    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // Visualise ground check in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}