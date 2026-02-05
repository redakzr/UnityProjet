
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private int moveSpeed = 10;

    [SerializeField]
    private int jumpForce = 15;
    private float moveDirectionX;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundCheckRadius;

    [SerializeField]
    private LayerMask listGroundLayers;
    private bool isGrounded;
    private bool isFacingRight = true;

    private bool jumpRequested = false;
    private bool jumpReleased = false;

    private void Jump()
    {
       rb.linearVelocity = new Vector2(
           rb.linearVelocityX,
           jumpForce);
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     moveDirectionX = Input.GetAxisRaw("Horizontal");   
     if (Input.GetButtonDown("Jump"))
     {
         jumpRequested = true;
     }

     if (Input.GetButtonUp("Jump"))
     {
         jumpReleased = false;
     }
     Flip();

    }

    private void FixedUpdate()
    {
        Move();
        isGrounded = IsTouchingGround();
        Debug.Log(isGrounded);

        if (jumpRequested && isGrounded)
        {
            Jump();
        }

        if (jumpReleased && rb.linearVelocityY > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocityX,
                rb.linearVelocityY * 0.5f);
        }

        jumpRequested = false;
        jumpReleased = false;
        Flip();
    }


    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius);
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(
            moveDirectionX * moveSpeed, 
            rb.linearVelocityY);

        Debug.Log(rb.linearVelocity);
    }

    private bool IsTouchingGround()
    {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers);
    }

    private void Flip()
    {
        if (moveDirectionX > 0 && !isFacingRight || 
            moveDirectionX < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
